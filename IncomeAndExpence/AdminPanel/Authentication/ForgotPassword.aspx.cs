using IncomeAndExpense.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Authentication_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strErrorMessage = "";

        if (txtMobileNumber.Text.Trim() == "")
        {
            strErrorMessage += "-Enter User Name <br />";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Display Name  <br />";
        }
        if (txtConfirmPassword.Text.Trim() == "")
        {
            strErrorMessage += "-enter mobile number  <br />";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblResult.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        
        UserBAL balUser = new UserBAL();
        if (balUser.selectByMobileNumber(txtMobileNumber.Text.ToString().Trim()) == txtMobileNumber.Text)
        {
            if (balUser.UpdateMobileNoByPassword(txtMobileNumber.Text.ToString().Trim(), txtPassword.Text.ToString().Trim()))
            {
                lblResult.Text = "Password Change Successfully";
                lblResult.CssClass = "text-success";
                txtMobileNumber.Text = "";
                Response.Redirect("~/AdminPanel/Authentication/Login.aspx");
            }
            else
            {
                lblResult.Text = balUser.Message;
            }
        }
        else
        {
            lblResult.Text = "Mobile Number is Invalid";
        }
    }
}