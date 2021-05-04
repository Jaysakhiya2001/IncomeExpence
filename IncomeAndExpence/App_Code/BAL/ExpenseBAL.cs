using IncomeAndExpense.DAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExpenseBAL
/// </summary>
namespace IncomeAndExpense.BAL
{
    public class ExpenseBAL
    {
        #region Constructor
        public ExpenseBAL()
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
        public Boolean Insert(ExpenseENT entExpense)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            if (dalExpense.Insert(entExpense))
            {
                return true;
            }
            else
            {
                Message = dalExpense.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ExpenseENT entExpense)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            if (dalExpense.Update(entExpense))
            {
                return true;
            }
            else
            {
                Message = dalExpense.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ExpenseID, SqlInt32 UserID)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            if (dalExpense.Delete(ExpenseID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalExpense.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            return dalExpense.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectDropDownList

        #endregion SelectDropDownList

        #region SelectByPK
        public ExpenseENT SelectByPK(SqlInt32 ExpenseID, SqlInt32 UserID)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            return dalExpense.SelectByPK(ExpenseID,UserID);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}