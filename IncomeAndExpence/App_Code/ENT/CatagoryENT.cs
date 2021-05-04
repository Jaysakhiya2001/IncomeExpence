using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CatagoryENT
/// </summary>
namespace IncomeAndExpense.ENT
{
    public class CatagoryENT
    {
        #region constructor
        public CatagoryENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

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

        #region CatagoryName
        protected SqlString _CatagoryName;

        public SqlString CatagoryName
        {
            get
            {
                return _CatagoryName;
            }
            set
            {
                _CatagoryName = value;
            }
        }
        #endregion CatagoryName

        #region CatagoryType
        protected SqlString _CatagoryType;

        public SqlString CatagoryType
        {
            get
            {
                return _CatagoryType;
            }
            set
            {
                _CatagoryType = value;
            }
        }

        #endregion CatagoryType

        #region CatagoryDescripation
        protected SqlString _CatagoryDescripation;

        public SqlString CatagoryDescripation
        {
            get
            {
                return _CatagoryDescripation;
            }
            set
            {
                _CatagoryDescripation = value;
            }
        }

        #endregion CatagoryDescripation

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