using IncomeAndExpense.DAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IncomeBAL
/// </summary>
namespace IncomeAndExpense.BAL
{
    public class IncomeBAL
    {
        #region Constructor
        public IncomeBAL()
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

        #region Insert Operation
        public Boolean Insert(IncomeENT entIncome)
        {
            IncomeDAL dalIncome = new IncomeDAL();
            if (dalIncome.Insert(entIncome))
            {
                return true;
            }
            else
            {
                Message = dalIncome.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(IncomeENT entIncome)
        {
            IncomeDAL dalIncome = new IncomeDAL();
            if (dalIncome.Update(entIncome))
            {
                return true;
            }
            else
            {
                Message = dalIncome.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 IncomeID, SqlInt32 UserID)
        {
            IncomeDAL dalIncome = new IncomeDAL();
            if (dalIncome.Delete(IncomeID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalIncome.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            IncomeDAL dalIncome = new IncomeDAL();
            return dalIncome.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectDropDownList

        #endregion SelectDropDownList

        #region SelectByPK
        public IncomeENT SelectByPK(SqlInt32 IncomeID, SqlInt32 UserID)
        {
            IncomeDAL dalIncome = new IncomeDAL();
            return dalIncome.SelectByPK(IncomeID, UserID);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}