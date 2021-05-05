using IncomeAndExpense.BAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Authentication_CreateNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Genrate OTP

    public string GeneratePassword()
    {
        string PasswordLength = "6";
        string OTP = "";

        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0";


        char[] sep = {
            ','
        };
        string[] arr = allowedChars.Split(sep);


        string IDString = "";
        string temp = "";

        Random rand = new Random();

        for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            IDString += temp;
            OTP = IDString;

        }
        return OTP;
    }

    #endregion Genrate OTP


    #region Button Click Event
    protected void btnRegister_Click(object sender, EventArgs e)
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
            lblMassage.Text = strErrorMessage;
            lblMassage.CssClass = "text-danger";
            return;
        }
        #endregion Server Side Validation

        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();

        if (balUser.SelectByUserName(txtUserName.Text.ToString().Trim()).IsNull)
        {
            readData();

            string strOTP = GeneratePassword().ToString();
            Session["OTP"] = strOTP;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("commexinfo@gmail.com");
            msg.To.Add(txtUserName.Text);
            msg.Subject = "Verfiy your email account";
            msg.Body = "Welcome to Income Expence <br/><br/>Your OTP is:<strong>" + strOTP + "</strong>";
            msg.IsBodyHtml = true;

            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "commexinfo@gmail.com"; // Your Email ID  
            ntwd.Password = ""; // Your Password  
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);
            lblMassage.Text = "Email Sent Successfully";
            lblMassage.ForeColor = System.Drawing.Color.ForestGreen;
            ClearControls();
            Response.Redirect("~/AdminPanel/Authentication/VerifyEmail.aspx");
        }
        else
        {
            lblMassage.Text = "User Name is alrady Entered";
            lblMassage.CssClass = "text-danger";
            ClearControls();
        }
    }
    #endregion

    #region ClearControls
    public void ClearControls()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtDisplayName.Text = "";
        txtAddress.Text = "";
        txtMobileNo.Text = "";
        txtUserName.Focus();
    }
    #endregion ClearControls
    
    #region Read Data
    private void readData()
    {
        string strErrorMessage = "";

        #region Server Side Validation
        if (txtUserName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter User Name <br/>";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Password <br/>";
        }
        if (txtDisplayName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Display Name <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMassage.Text = strErrorMessage;
            lblMassage.CssClass = "text-danger";
            return;
        }
        #endregion
        
        #region Data
        if (txtUserName.Text.Trim() != "")
        {
            Session["UserName"] = txtUserName.Text.Trim();
        }
        if (txtPassword.Text.Trim() != "")
        {
           Session["Password"] = txtPassword.Text.Trim();
        }
        if (txtDisplayName.Text.Trim() != "")
        {
            Session["DisplayName"] = txtDisplayName.Text.Trim();
        }
        Session["Address"] = txtAddress.Text.Trim();
        Session["MobileNumber"] = txtMobileNo.Text.Trim();

        if (fuUserProfileImage.HasFiles)
        {
            string strPath = "~/UserImages/";
            string strPhysicalPath = "";
            strPhysicalPath = Server.MapPath(strPath);
            strPhysicalPath += fuUserProfileImage.FileName;
            strPath += fuUserProfileImage.FileName;

            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuUserProfileImage.SaveAs(strPhysicalPath);
            Session["UserProfileImage"] = strPath;
        }
        else
        {
            if (File.Exists(Server.MapPath("~/UserImages/avatar0.jpg")))
            {
                File.Delete(Server.MapPath("~/UserImages/avatar0.jpg"));
            }
            fuUserProfileImage.SaveAs(Server.MapPath("~/UserImages/avatar0.jpg"));
            Session["UserProfileImage"] = "~/UserImages/avatar0.jpg";
        }
        #endregion
    }
    #endregion Read Data
    
}