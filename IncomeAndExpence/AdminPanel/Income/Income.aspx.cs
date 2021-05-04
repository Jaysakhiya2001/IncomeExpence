using IncomeAndExpense.BAL;
using IncomeAndExpense.DAL;
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

public partial class AdminPanel_Income_Income : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            string CatagoryType = "Income";
            FillCategoryDropDownList(CatagoryType);
            fillGridViewIncome(Convert.ToInt32(Session["UserID"].ToString()));
        }  
    }
    #endregion Page Load

    #region Income List Page

    #region Fill Income GridView 
    private void fillGridViewIncome(SqlInt32 UserID)
    {
        IncomeDAL dalIncome = new IncomeDAL();
        DataTable dtIncome = new DataTable();

        dtIncome = dalIncome.SelectAll(UserID);

        if (dtIncome != null && dtIncome.Rows.Count > 0)
        {
            gvIncome.DataSource = dtIncome;
            gvIncome.DataBind();
            calculateSum();
        }
        else
        {
            gvIncome.DataSource = null;
            gvIncome.DataBind();
        }
    }
    #endregion

    #region Delete Click Event
    protected void lbtnDeleteIncome_Click(object sender, EventArgs e)
    {
        IncomeBAL balIncome = new IncomeBAL();
        foreach (GridViewRow gvRow in gvIncome.Rows)
        {
            CheckBox chkDeleteIncome = (CheckBox)gvRow.FindControl("chkIncome");
            if (chkDeleteIncome.Checked)
            {
                int IncomeID = Convert.ToInt32(gvIncome.DataKeys[gvRow.RowIndex].Value.ToString());
                balIncome.Delete(IncomeID, Convert.ToInt32(Session["UserID"].ToString()));
            }
        }
        fillGridViewIncome(Convert.ToInt32(Session["UserID"].ToString()));
    }
    #endregion

    #endregion Income List Page

    #region Income ADD/Edit page

    #region Fill Catagory DropDown
    private void FillCategoryDropDownList(String CatagoryType)
    {
        CommanFillDropDown.FillDropDownListCatagory(ddlCatagoryList,CatagoryType, Convert.ToInt32(Session["UserID"].ToString()));
    }
    #endregion

    #region FillControls
    private void FillControls(SqlInt32 IncomeID, SqlInt32 UserID)
    {
        IncomeBAL balIncome = new IncomeBAL();
        IncomeENT entIncome = new IncomeENT();

        entIncome = balIncome.SelectByPK(IncomeID, UserID);

        if (!entIncome.IncomeName.IsNull)
            txtIncomeName.Text = entIncome.IncomeName.Value;

        if (!entIncome.CatagoryID.IsNull)
            ddlCatagoryList.SelectedValue = entIncome.CatagoryID.Value.ToString();

        if (!entIncome.Date.IsNull)
            txtdate.Text = entIncome.Date.Value.ToString();

        if (!entIncome.Descripation.IsNull)
            txtDescripation.Text = entIncome.Descripation.Value.ToString();

        if (!entIncome.IncomeAmount.IsNull)
            txtIncomeAmount.Text = entIncome.IncomeAmount.Value.ToString().Trim();
        
    }
    #endregion FillControls

    #region ClearControls
    public void ClearControls()
    {
        txtIncomeName.Text = "";
        ddlCatagoryList.SelectedIndex = -1;
        txtdate.Text = "";
        txtDescripation.Text = "";
        txtIncomeAmount.Text = "";
        txtIncomeName.Focus();
    }
    #endregion ClearControls

    #region Save Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strError = "";

        if (txtIncomeName.Text.Trim() == "")
            strError += "Enter Income Name";

        if (ddlCatagoryList.SelectedIndex == 0)
            strError += "Enter Catagory";

        if (txtdate.Text.Trim() == "")
            strError += "Enter Date";
        
        if (txtIncomeAmount.Text.Trim() == "")
            strError += "Enter Income Amount";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        IncomeENT entIncome = new IncomeENT();

        if (txtIncomeName.Text.Trim() != "")
            entIncome.IncomeName = txtIncomeName.Text;

        if (ddlCatagoryList.SelectedIndex > 0)
            entIncome.CatagoryID = Convert.ToInt32(ddlCatagoryList.SelectedValue.ToString().Trim());

        if (txtdate.Text.Trim() != "")
            entIncome.Date = Convert.ToDateTime(txtdate.Text.ToString());

        if (txtIncomeAmount.Text.Trim() != "")
            entIncome.IncomeAmount = Convert.ToDecimal(txtIncomeAmount.Text.ToString().Trim());
        
        if (Session["UserID"] != null)
            entIncome.UserID = Convert.ToInt32(Session["UserID"].ToString());

        entIncome.Descripation = txtDescripation.Text;

        #endregion Collect Data

        IncomeBAL balIncome = new IncomeBAL();
        if (hfIncomeID.Value == "")
        {
            if (balIncome.Insert(entIncome))
            {
                lblErrorMessage.Text = "Data Insert Successfully...";
                divMessage.Visible = true;
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balIncome.Message;
            }
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#add-contact", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();", true);
        }
        else
        {
            entIncome.IncomeID = Convert.ToInt32(hfIncomeID.Value.ToString().Trim());

            if (balIncome.Update(entIncome))
            {
                //Response.Redirect("~/AdminPanel/Income/Income.aspx");
                lblErrorMessage.Text = "Data Updated Successfully...";
                divMessage.Visible = true;
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balIncome.Message;
            }
        }
        fillGridViewIncome(Convert.ToInt32(Session["UserID"].ToString()));
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#add-contact", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();", true);
    }
    #endregion
    
    #endregion Income ADD/Edit page

    private void calculateSum()
    {
        decimal grandtotal = 0;
        foreach (GridViewRow row in gvIncome.Rows)
        {

            grandtotal = grandtotal + Convert.ToDecimal(row.Cells[5].Text); 
        }
        gvIncome.FooterRow.Cells[4].Text = "Grand Total";
        gvIncome.FooterRow.Cells[5].Text = grandtotal.ToString();
        gvIncome.FooterRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#379683");
        gvIncome.FooterRow.ForeColor = System.Drawing.ColorTranslator.FromHtml("#EDF5E1");
    }
}

