using IncomeAndExpense.DAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CatagoryBAL
/// </summary>
namespace IncomeAndExpense.BAL
{
    public class CatagoryBAL
    {
        #region Constructor
        public CatagoryBAL()
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
        public Boolean Insert(CatagoryENT entCatagory)
        {
            CatagoryDAL dalCatagory = new CatagoryDAL();
            if (dalCatagory.Insert(entCatagory))
            {
                return true;
            }
            else
            {
                Message = dalCatagory.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CatagoryENT entCatagory)
        {
            CatagoryDAL dalCatagory = new CatagoryDAL();
            if (dalCatagory.Update(entCatagory))
            {
                return true;
            }
            else
            {
                Message = dalCatagory.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CatagoryID, SqlInt32 UserID)
        {
            CatagoryDAL dalCatagory = new CatagoryDAL();
            if (dalCatagory.Delete(CatagoryID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalCatagory.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            CatagoryDAL dalCatagory = new CatagoryDAL();
            return dalCatagory.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectDropDownList
        public DataTable SelectForDropDownList(SqlString CatagoryType,SqlInt32 UserID)
        {
            CatagoryDAL dalCatagory = new CatagoryDAL();
            return dalCatagory.SelectForDropDownList(CatagoryType,UserID);
        }
        #endregion SelectDropDownList

        #region SelectByPK
        public CatagoryENT SelectByPK(SqlInt32 CatagoryID, SqlInt32 UserID)
        {
            CatagoryDAL dalCatagory = new CatagoryDAL();
            return dalCatagory.SelectByPK(CatagoryID,UserID);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}