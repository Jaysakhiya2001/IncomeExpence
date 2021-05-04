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

public partial class AdminPanel_Expense_Expense : System.Web.UI.Page
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
            string CatagoryType = "Expense";
            FillCategoryDropDownList(CatagoryType);
            fillGridViewExpense(Convert.ToInt32(Session["UserID"].ToString()));
        }
    }
    #endregion

    #region Expense List Page

    #region Fill Expense GridView 
    private void fillGridViewExpense(SqlInt32 UserID)
    {
        ExpenseDAL dalExpense = new ExpenseDAL();
        DataTable dtExpense = new DataTable();

        dtExpense = dalExpense.SelectAll(UserID);

        if (dtExpense != null && dtExpense.Rows.Count > 0)
        {
            gvExpense.DataSource = dtExpense;
            gvExpense.DataBind();
            calculateSum();
        }
        else
        {
            gvExpense.DataSource = null;
            gvExpense.DataBind();
        }
    }
    #endregion

    #region Delete Click Event
    protected void lbtnDeleteExpense_Click(object sender, EventArgs e)
    {
        ExpenseBAL balExpense = new ExpenseBAL();
        foreach (GridViewRow gvRow in gvExpense.Rows)
        {
            CheckBox chkDeleteExpense = (CheckBox)gvRow.FindControl("chkExpense");
            if (chkDeleteExpense.Checked)
            {
                int ExpenseID = Convert.ToInt32(gvExpense.DataKeys[gvRow.RowIndex].Value.ToString());
                balExpense.Delete(ExpenseID, Convert.ToInt32(Session["UserID"].ToString()));
            }
        }
        fillGridViewExpense(Convert.ToInt32(Session["UserID"].ToString()));
    }
    #endregion

    #endregion Expense List Page

    #region Expense ADD/Edit page

    #region Fill Catagory DropDown
    private void FillCategoryDropDownList(string CatagoryType)
    {
        CommanFillDropDown.FillDropDownListCatagory(ddlCatagoryList,CatagoryType,Convert.ToInt32(Session["UserID"].ToString()));
    }
    #endregion

    #region FillControls
    private void FillControls(SqlInt32 ExpenseID, SqlInt32 UserID)
    {
        ExpenseBAL balExpense = new ExpenseBAL();
        ExpenseENT entExpense = new ExpenseENT();

        entExpense = balExpense.SelectByPK(ExpenseID, UserID);

        if (!entExpense.ExpenseName.IsNull)
            txtExpenseName.Text = entExpense.ExpenseName.Value;

        if (!entExpense.CatagoryID.IsNull)
            ddlCatagoryList.SelectedValue = entExpense.CatagoryID.Value.ToString();

        if (!entExpense.Date.IsNull)
            txtdate.Text = entExpense.Date.Value.ToString();

        if (!entExpense.Descripation.IsNull)
            txtDescripation.Text = entExpense.Descripation.Value.ToString();

        if (!entExpense.ExpenseAmount.IsNull)
            txtExpenseAmount.Text = entExpense.ExpenseAmount.Value.ToString().Trim();

    }
    #endregion FillControls

    #region ClearControls
    public void ClearControls()
    {
        txtExpenseName.Text = "";
        ddlCatagoryList.SelectedIndex = -1;
        txtdate.Text = "";
        txtDescripation.Text = "";
        txtExpenseAmount.Text = "";
        txtExpenseName.Focus();
    }
    #endregion ClearControls

    #region Save Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strError = "";

        if (txtExpenseName.Text.Trim() == "")
            strError += "Enter Expense Name";

        if (ddlCatagoryList.SelectedIndex == 0)
            strError += "Enter Catagory";

        if (txtdate.Text.Trim() == "")
            strError += "Enter Date";

        if (txtExpenseAmount.Text.Trim() == "")
            strError += "Enter Expense Amount";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        ExpenseENT entExpense = new ExpenseENT();

        if (txtExpenseName.Text.Trim() != "")
            entExpense.ExpenseName = txtExpenseName.Text;

        if (ddlCatagoryList.SelectedIndex > 0)
            entExpense.CatagoryID = Convert.ToInt32(ddlCatagoryList.SelectedValue.ToString().Trim());

        if (txtdate.Text.Trim() != "")
            entExpense.Date = Convert.ToDateTime(txtdate.Text.ToString());

        if (txtExpenseAmount.Text.Trim() != "")
            entExpense.ExpenseAmount = Convert.ToDecimal(txtExpenseAmount.Text.ToString().Trim());

        if (Session["UserID"] != null)
            entExpense.UserID = Convert.ToInt32(Session["UserID"].ToString());

        entExpense.Descripation = txtDescripation.Text;

        #endregion Collect Data

        ExpenseBAL balExpense = new ExpenseBAL();

        if (hfExpenseID.Value == "")
        {
            if (balExpense.Insert(entExpense))
            {
                lblErrorMessage.Text = "Data Insert Successfully...";
                divMessage.Visible = true;
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balExpense.Message;
            } 
        }
        else
        {
            entExpense.ExpenseID = Convert.ToInt32(hfExpenseID.Value.ToString().Trim());

            if (balExpense.Update(entExpense))
            {
                lblErrorMessage.Text = "Data Updated Successfully...";
                divMessage.Visible = true;
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balExpense.Message;
            }
        }
        fillGridViewExpense(Convert.ToInt32(Session["UserID"].ToString()));
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#add-contact", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();", true);
    }
    #endregion
    
    #endregion Expense ADD/Edit page

    private void calculateSum()
    {
        decimal grandtotal = 0;
        foreach (GridViewRow row in gvExpense.Rows)
        {
            grandtotal = grandtotal + Convert.ToDecimal(row.Cells[5].Text);
        }
        gvExpense.FooterRow.Cells[4].Text = "Grand Total";
        gvExpense.FooterRow.Cells[5].Text = grandtotal.ToString();
        gvExpense.FooterRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#B23850");
        gvExpense.FooterRow.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ECECEC");
    }
}