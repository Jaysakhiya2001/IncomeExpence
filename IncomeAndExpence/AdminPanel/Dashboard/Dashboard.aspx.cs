using IncomeAndExpense.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Dashbord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx");
        }
        FillDashbordData(Convert.ToInt32(Session["UserID"].ToString()));
    }

    private void FillDashbordData(SqlInt32 UserID)
    {
        DataTable dt = new DataTable();
        DashbordBAL balDashbord = new DashbordBAL();

        dt = balDashbord.fillDashbordData(UserID);


        if (dt != null && dt.Rows.Count > 0)
        {
            lblCountCatagory.Text = dt.Rows[0][0].ToString();
            lblSumIncome.Text = dt.Rows[0][1].ToString();
            lblSumExpense.Text = dt.Rows[0][2].ToString();
            lblThisMonthIncome.Text = dt.Rows[0][3].ToString();
            lblThisMonthExpense.Text = dt.Rows[0][4].ToString();

            if (lblSumIncome.Text == "")
                lblSumIncome.Text = "0";

            if (lblSumExpense.Text == "")
                lblSumExpense.Text = "0";

            if (lblThisMonthIncome.Text == "")
                lblThisMonthIncome.Text = "0";

            if (lblThisMonthExpense.Text == "")
                lblThisMonthExpense.Text = "0";
        }
        else
        {
            lblCountCatagory.Text = "0";
            lblSumIncome.Text = "0";
            lblSumExpense.Text = "0";
            lblThisMonthIncome.Text = "0";
            lblThisMonthExpense.Text = "0";
        }

    }
}