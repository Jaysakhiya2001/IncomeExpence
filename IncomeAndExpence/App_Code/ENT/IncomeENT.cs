using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IncomeENT
/// </summary>
namespace IncomeAndExpense.ENT
{
    public class IncomeENT
    {
        #region constructor
        public IncomeENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region IncomeID
        protected SqlInt32 _IncomeID;

        public SqlInt32 IncomeID
        {
            get
            {
                return _IncomeID;
            }
            set
            {
                _IncomeID = value;
            }
        }

        #endregion IncomeID

        #region IncomeName
        protected SqlString _IncomeName;

        public SqlString IncomeName
        {
            get
            {
                return _IncomeName;
            }
            set
            {
                _IncomeName = value;
            }
        }
        #endregion IncomeName

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

        #region IncomeAmount
        protected SqlDecimal _IncomeAmount;

        public SqlDecimal IncomeAmount
        {
            get
            {
                return _IncomeAmount;
            }
            set
            {
                _IncomeAmount = value;
            }
        }


        #endregion IncomeAmount

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