using IncomeAndExpense.BAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Profile_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx");
        }
        imgProfile.ImageUrl = Session["UserProfileImage"].ToString();
        lblName.Text = Session["DisplayName"].ToString();

        if (!Page.IsPostBack)
        {
            profile();
            profileEdit();
        }
    }
    protected void profile()
    {
        lblUserName.Text = Session["UserName"].ToString();
        lblDisplayName.Text = Session["DisplayName"].ToString();
        lblAddress.Text = Session["Address"].ToString();
        lblMobilePhone.Text = Session["MobileNo"].ToString();
    }
    protected void profileEdit()
    {
        txtUserName.Text = Session["UserName"].ToString();
        txtDisplayName.Text = Session["DisplayName"].ToString();
        txtAddress.Text = Session["Address"].ToString();
        txtMobileNo.Text = Session["MobileNo"].ToString();
    }

    protected void btnUpdateProfile_Click(object sender, EventArgs e)
    {

        #region Server Side Validation
        string strErrorMessage = "";

        if (txtUserName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter User Name <br />";
        }
        if (txtDisplayName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Display Name  <br />";
        }
        if (txtMobileNo.Text.Trim() == "")
        {
            strErrorMessage += "-enter mobile number  <br />";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessageProfile.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        UserENT entUser = new UserENT();
        #region Read Data
        if (txtUserName.Text.Trim() != "")
        {
            entUser.UserName = txtUserName.Text.ToString();
        }
        if (txtDisplayName.Text.Trim() != "")
        {
            entUser.DisplayName = txtDisplayName.Text.ToString();
        }
        if (txtMobileNo.Text.Trim() != "")
        {
            entUser.MobileNumber = txtMobileNo.Text.ToString();
        }
        entUser.Address = txtAddress.Text.ToString();
        entUser.UserID = Convert.ToInt32(Session["UserID"].ToString());
        
        #endregion Read Data

        UserBAL balUser = new UserBAL();

        if (balUser.UpdateByPK(entUser))
        {
            lblMessageProfile.Text = "Updated Successfully";
            divMessage.Visible = true;
            Session["UserName"] = txtUserName.Text;
            Session["DisplayName"] = txtDisplayName.Text;
            Session["Address"] = txtAddress.Text.ToString();
            Session["MobileNo"] = txtMobileNo.Text.ToString();
            profile();
        }
        else
        {
            lblMessageProfile.Text = balUser.Message;
        }
        Response.Redirect("~/AdminPanel/Profile/Profile.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strErrorMessage = "";

        if (txtCurrentPassword.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Current Password  <br />";
        }
        if (txtNewPassword.Text.Trim() == "")
        {
            strErrorMessage += "-Enter New Password  <br />";
        }
        if (txtVerifyPassword.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Verify Password  <br />";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessageProfile.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation
        
        UserBAL balUser = new UserBAL();
        if (balUser.SelectByUserID(Convert.ToInt32(Session["UserID"].ToString())) == txtCurrentPassword.Text.ToString().Trim())
        {
            if (balUser.UpdateByPassword(Convert.ToInt32(Session["UserID"].ToString()), txtCurrentPassword.Text.Trim(), txtNewPassword.Text.Trim()))
            {
                lblMessage.Text = "Password Changed Successfully";
                divMessageLable.Visible = true;
            }
            else
            {
                lblMessage.Text = balUser.Message;
            }
        }
        else
        {
            lblMessage.Text = "Invalid Current Password";
            divMessageLable.Visible = true;
            lblMessage.CssClass = "text-danger";
        }
        
    }

    protected void btnUpdateProfileImage_Click(object sender, EventArgs e)
    {
        UserENT entUser = new UserENT();

        entUser.UserID = Convert.ToInt32(Session["UserID"].ToString());
        if (fuProfile.HasFiles)
        {
            string strPath = "~/UserImages/";
            string strPhysicalPath = "";
            strPhysicalPath = Server.MapPath(strPath);
            strPhysicalPath += fuProfile.FileName;
            strPath += fuProfile.FileName;

            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuProfile.SaveAs(strPhysicalPath);
            entUser.UserProfileImage = strPath;
            Session["UserProfileImage"] = strPath;
        }
        UserBAL balUser = new UserBAL();

        if (balUser.UpdateProfile(entUser))
        {
            Response.Redirect("~/AdminPanel/Profile/Profile.aspx");
        }
        else
        {
            lblMessageProfile.Text = balUser.Message;
        }
    }
}