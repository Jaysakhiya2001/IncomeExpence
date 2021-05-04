using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExpenseENT
/// </summary>
namespace IncomeAndExpense.ENT
{
    public class ExpenseENT
    {
        #region constructor
        public ExpenseENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region ExpenseID
        protected SqlInt32 _ExpenseID;

        public SqlInt32 ExpenseID
        {
            get
            {
                return _ExpenseID;
            }
            set
            {
                _ExpenseID = value;
            }
        }

        #endregion ExpenseID

        #region ExpenseName
        protected SqlString _ExpenseName;

        public SqlString ExpenseName
        {
            get
            {
                return _ExpenseName;
            }
            set
            {
                _ExpenseName = value;
            }
        }
        #endregion ExpenseName

        #region CatagoryID
        protected SqlInt32 _CatagoryID;

        public SqlInt32 CatagoryID
        {
            get
            {
                return _CatagoryID;
            }
            set
            {
                _CatagoryID = value;
            }
        }


        #endregion CatagoryID

        #region Date
        protected SqlDateTime _Date;

        public SqlDateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }
        #endregion Date

        #region Descripation
        protected SqlString _Descripation;

        public SqlString Descripation
        {
            get
            {
                return _Descripation;
            }
            set
            {
                _Descripation = value;
            }
        }

        #endregion Descripation

        #region ExpenseAmount
        protected SqlDecimal _ExpenseAmount;

        public SqlDecimal ExpenseAmount
        {
            get
            {
                return _ExpenseAmount;
            }
            set
            {
                _ExpenseAmount = value;
            }
        }


        #endregion ExpenseAmount

        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        #endregion UserID
    }
}