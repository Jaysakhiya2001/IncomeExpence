using IncomeAndExpense.BAL;
using IncomeAndExpense.DAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Catagory_Catagory : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            FillGridViewCatagory(Convert.ToInt32(Session["UserID"].ToString()));

            if (Request.QueryString["CatagoryID"] == null)
            {
                lblErrorMessage.Text = "Catagory Add";
                lblErrorMessage.CssClass = "text-success";
            }
            else
            {
                FillControls(Convert.ToInt32(Request.QueryString["CatagoryID"].ToString().Trim()), Convert.ToInt32(Session["UserID"].ToString()));
            }

        }
    }
    #endregion

    #region Catagory List Page

    #region Fill Catagory Grid View
    private void FillGridViewCatagory(SqlInt32 UserID)
    {
        CatagoryDAL dalCatagory = new CatagoryDAL();
        DataTable dtCatagory = new DataTable();

        dtCatagory = dalCatagory.SelectAll(UserID);

        if (dtCatagory != null && dtCatagory.Rows.Count > 0)
        {
            gvCatagory.DataSource = dtCatagory;
            gvCatagory.DataBind();
        }
        else
        {
            gvCatagory.DataSource = null;
            gvCatagory.DataBind();
        }
    }
    #endregion

    #region Delete Click Event
    protected void lbtnDeleteCatagory_Click(object sender, EventArgs e)
    {
        CatagoryBAL balCatagory = new CatagoryBAL();
        foreach (GridViewRow gvRow in gvCatagory.Rows)
        {
            CheckBox chkDeleteCatagory = (CheckBox)gvRow.FindControl("chkCatagory");
            if (chkDeleteCatagory.Checked)
            {
                int CatagoryID = Convert.ToInt32(gvCatagory.DataKeys[gvRow.RowIndex].Value.ToString());
                balCatagory.Delete(CatagoryID, Convert.ToInt32(Session["UserID"].ToString()));
            }
        }
        FillGridViewCatagory(Convert.ToInt32(Session["UserID"].ToString()));
    }
    #endregion

    #endregion Catagory List Page

    #region Catagory ADD / Edit

    #region FillControls
    private void FillControls(SqlInt32 CatagoryID, SqlInt32 UserID)
    {
        CatagoryBAL balCatagory = new CatagoryBAL();
        CatagoryENT entCatagory = new CatagoryENT();

        entCatagory = balCatagory.SelectByPK(CatagoryID, UserID);

        if (!entCatagory.CatagoryName.IsNull)
            txtCatagoryName.Text = entCatagory.CatagoryName.Value;

        if (!entCatagory.CatagoryType.IsNull)
            rbCatagoryType.Text = entCatagory.CatagoryType.Value;

        if (!entCatagory.CatagoryDescripation.IsNull)
            txtDescripation.Text = entCatagory.CatagoryDescripation.Value;

    }
    #endregion FillControls

    #region ClearControls
    public void ClearControls()
    {
        txtCatagoryName.Text = "";
        txtDescripation.Text = "";
        txtCatagoryName.Focus();
    }
    #endregion ClearControls

    #region Save Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strError = "";

        if (txtCatagoryName.Text.Trim() == "")
            strError += "Enter Catagory Name";

        if (rbCatagoryType.Text.Trim() == "")
            strError += "Enter Catagory Type";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            divMessage.Visible = true;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        CatagoryENT entCatagory = new CatagoryENT();

        if (txtCatagoryName.Text != "")
            entCatagory.CatagoryName = txtCatagoryName.Text;

        if (rbCatagoryType.Text != "")
            entCatagory.CatagoryType = rbCatagoryType.Text;

        if (txtDescripation.Text != "")
            entCatagory.CatagoryDescripation = txtDescripation.Text;

        if (Session["UserID"] != null)
            entCatagory.UserID = Convert.ToInt32(Session["UserID"].ToString());

        #endregion Collect Data

        CatagoryBAL balCatagory = new CatagoryBAL();

        if (hfCatagoryID.Value == "")
        {
            if (balCatagory.Insert(entCatagory))
            {
                lblErrorMessage.Text = "Data Insert Successfully...";
                lblErrorMessage.CssClass = "text-success";
                divMessage.Visible = true;
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balCatagory.Message;
                
            }
        }
        else
        {
            entCatagory.CatagoryID = Convert.ToInt32(hfCatagoryID.Value.ToString().Trim());

            if (balCatagory.Update(entCatagory))
            {
                lblErrorMessage.Text = "Data Updated Successfully...";
                divMessage.Visible = true;
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balCatagory.Message;
            }
        }
        FillGridViewCatagory(Convert.ToInt32(Session["UserID"].ToString()));
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#add-contact", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();", true);
    }
    #endregion

    #endregion Catagory ADD / Edit
    
}
