using IncomeAndExpense.BAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Authentication_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region ClearControls
    public void ClearControls()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtPassword.Focus();
    }
    #endregion ClearControls

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        #region Server Side Validation
        string strErrorMessage = "";

        if (txtUserName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter User Name <br />";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Password  <br />";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();

        entUser = balUser.SelectByUserNameAndPassword(txtUserName.Text.Trim(),txtPassword.Text.Trim());
        
        if (entUser.UserID.IsNull)
        {
            ClearControls();
            lblErrorMessage.Text = "Invalid User";
            lblErrorMessage.CssClass = "text-danger";
        }
        else
        {
            Session["UserID"] = entUser.UserID.ToString().Trim();
            Session["UserName"] = entUser.UserName.ToString().Trim();
            Session["DisplayName"] = entUser.DisplayName.ToString().Trim();
            Session["Address"] = entUser.Address.ToString();
            Session["MobileNo"] = entUser.MobileNumber.ToString().Trim();
            Session["UserProfileImage"] = entUser.UserProfileImage.ToString().Trim();
            ClearControls();
            Response.Redirect("~/AdminPanel/Dashboard/Dashboard.aspx");
        }
    }
}