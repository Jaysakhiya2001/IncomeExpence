
using IncomeAndExpense.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommanFillDropDown
/// </summary>
public class CommanFillDropDown
{
    #region Constructor
    public CommanFillDropDown()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    public static void FillDropDownListCatagory(DropDownList ddl,SqlString CatagoryType,SqlInt32 UserID)
    {
        CatagoryBAL balCatagory = new CatagoryBAL();
        ddl.DataSource = balCatagory.SelectForDropDownList(CatagoryType,UserID);
        ddl.DataTextField = "CatagoryName";
        ddl.DataValueField = "CatagoryID";
        ddl.DataBind();

        ddl.Items.Insert(0,new ListItem("Select Catagory","-1"));
    }

    public static void FillDropDownListEmpty(DropDownList ddl, String DropDownListName)
    {
        ddl.Items.Clear();
        ddl.Items.Insert(0, new ListItem("Select " + DropDownListName, "-1"));
    }
}