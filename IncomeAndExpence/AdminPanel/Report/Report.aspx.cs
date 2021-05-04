using IncomeAndExpense.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Report_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx");
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
    
        #region Server Side Validation
        string strError = "";

        if (txtStartingdate.Text.Trim() == "")
            strError += "Enter Income Name";
        
        if (txtEndingdate.Text.Trim() == "")
            strError += "Enter Date";

        if (strError.Trim() != "")
        {
            lblMessage.Text = strError;
            divMessage.Visible = true;
            lblMessage.CssClass = "text-danger";
            return;
        }
        #endregion Server Side Validation

        ReportDAL dalReport = new ReportDAL();
        DataTable dtReport = new DataTable();

        dtReport = dalReport.ReportSelectByDate(Convert.ToDateTime(txtStartingdate.Text.ToString()), Convert.ToDateTime(txtEndingdate.Text.ToString()), Convert.ToInt32(Session["UserID"].ToString()));

        if (dtReport != null && dtReport.Rows.Count > 0)
        {
            gvReport.DataSource = dtReport;
            gvReport.DataBind();
            calculateSum();
        }
        else
        {
            gvReport.DataSource = null;
            gvReport.DataBind();
            lblMessage.Text = "No Data Avaliable";
            divMessage.Visible = true;
        }
    }

    private void calculateSum()
    {
        decimal grandtotal = 0;
        foreach (GridViewRow row in gvReport.Rows)
        {
            grandtotal = grandtotal + Convert.ToDecimal(row.Cells[4].Text);
        }
        if (grandtotal < 0)
        {
            gvReport.FooterRow.Cells[3].Text = "Loss";
        }
        else
        {
            gvReport.FooterRow.Cells[3].Text = "Profit";
        }
        gvReport.FooterRow.Cells[4].Text = grandtotal.ToString();

        
        if (gvReport.FooterRow.Cells[3].Text.Equals("Profit"))
        {
            gvReport.FooterRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#379683");
            gvReport.FooterRow.ForeColor = System.Drawing.ColorTranslator.FromHtml("#EDF5E1");
        }
        if (gvReport.FooterRow.Cells[3].Text.Equals("Loss"))
        {
            gvReport.FooterRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#B23850");
            gvReport.FooterRow.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ECECEC");
        }
    }

    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow grv = e.Row;
            if (grv.Cells[3].Text.Equals("Income"))
            {
                grv.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#689F38");
                grv.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#689F38");
            }
            if (grv.Cells[3].Text.Equals("Expense"))
            {
                grv.Cells[3].ForeColor = System.Drawing.ColorTranslator.FromHtml("#E12B38");
                grv.Cells[4].ForeColor = System.Drawing.ColorTranslator.FromHtml("#E12B38");
            }
        }
    }
}