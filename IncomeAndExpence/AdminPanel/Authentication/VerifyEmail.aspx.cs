using IncomeAndExpense.BAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Authentication_VerifyEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            imgProfile.ImageUrl = Session["UserProfileImage"].ToString();
            lblUserName.Text = Session["UserName"].ToString().Trim();
        }
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strErrorMessage = "";

        if (txtOTP.Text.Trim() == "")
        {
            strErrorMessage += "-Enter OTP <br />";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            lblMessage.CssClass = "text-danger";
            return;
        }

        if (Session["OTP"].Equals(txtOTP.Text.ToString()))
        {
            createNewUser();
        }
        else
        {
            lblMessage.Text = "Invalid OTP";
            lblMessage.CssClass = "text-danger";
        }
        #endregion Server Side Validation
    }

    #region Create New User
    private void createNewUser()
    {
        UserENT entUser = new UserENT();
        
        #region Read Data
        entUser.UserName = Session["UserName"].ToString().Trim();
        entUser.Password = Session["Password"].ToString().Trim();
        entUser.DisplayName = Session["DisplayName"].ToString().Trim();
        entUser.Address = Session["Address"].ToString().Trim();
        entUser.MobileNumber = Session["MobileNumber"].ToString().Trim();
        entUser.UserProfileImage = Session["UserProfileImage"].ToString().Trim();
        #endregion

        UserBAL balUser = new UserBAL();
        if (balUser.Insert(entUser))
        {
            lblMessage.Text = "Insert Successfully";
            lblMessage.CssClass = "text-success";
            Session["Password"] = null;
            Session["MobileNumber"] = null;
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx");
        }
        else
        {
            lblMessage.Text = balUser.Message;
        }
    }
    #endregion


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

    protected void lbtnResendOTP_Click(object sender, EventArgs e)
    {
        string strOTP = GeneratePassword().ToString();
        Session["OTP"] = strOTP;

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("commexinfo@gmail.com");
        msg.To.Add(lblUserName.Text);
        msg.Subject = "Verfiy your email account";
        msg.Body = "Welcome to Income Expence <br/><br/>Your OTP is:<strong>" + strOTP + "</strong>";
        msg.IsBodyHtml = true;

        SmtpClient smt = new SmtpClient();
        smt.Host = "smtp.gmail.com";
        System.Net.NetworkCredential ntwd = new NetworkCredential();
        ntwd.UserName = "commexinfo@gmail.com";   
        ntwd.Password = "";   
        smt.UseDefaultCredentials = true;
        smt.Credentials = ntwd;
        smt.Port = 587;
        smt.EnableSsl = true;
        smt.Send(msg);
        lblMessage.Text = "Email Sent Successfully";
        lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
    }
}