using IncomeAndExpense.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Dashbord
/// </summary>
namespace IncomeAndExpense.BAL
{
    public class DashbordBAL
    {
        #region Constructor
        public DashbordBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Message
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Message

        #region Fill Dashbord Data
        public DataTable fillDashbordData(SqlInt32 UserID)
        {
            DashbordDAL dalDashbord = new DashbordDAL();
            return dalDashbord.fillDashbordData(UserID);
        }
        #endregion Fill Dashbord Data
    }
}