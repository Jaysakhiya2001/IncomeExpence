using IncomeAndExpense.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportBAL
/// </summary>
namespace IncomeAndExpense.BAL
{
    public class ReportBAL
    {
        #region Constructor
        public ReportBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Local Variables
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

        #endregion Local Variables

        #region Select Operation

        #region SelectByPK

        #region  Report
        public DataTable ReportSelectByDate(SqlDateTime StartingDate, SqlDateTime EndingDate, SqlInt32 UserID)
        {
            ReportDAL dalReport = new ReportDAL();
            return dalReport.ReportSelectByDate(StartingDate, EndingDate, UserID);
        }
        #endregion  Report
        
        #endregion SelectByPK

        #endregion Select Operation
    }
}