using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBaseConfig
/// </summary>
namespace IncomeAndExpense
{
    public class DataBaseConfig
    {
        #region constructor
        public DataBaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["IncomeAndExpense"].ConnectionString;
    }
}