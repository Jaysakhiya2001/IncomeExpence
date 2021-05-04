using IncomeAndExpense.DAL;
using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBAL
/// </summary>
namespace IncomeAndExpense.BAL
{
    public class UserBAL
    {
        #region Constructor
        public UserBAL()
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

        #region Insert Operation
        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update operation
        public Boolean UpdateByPK(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.UpdateByPK(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }

        #region Update Password
        public Boolean UpdateByPassword(SqlInt32 UserID, SqlString OldPassword, SqlString NewPassword)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.UpdateByPassword(UserID, OldPassword, NewPassword))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Update Password

        #region Upadate MobileNo By Password
        public Boolean UpdateMobileNoByPassword(SqlString MobileNo, SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.UpdateMobileNoByPassword(MobileNo, Password))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Upadate MobileNo By Password

        #region Upadte Profile Image
        public Boolean UpdateProfile(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.UpdateProfile(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Upadte Profile Image

        #endregion Update operation

        #region Delete Operation
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        #endregion SelectAll

        #region SelectByPK

        #region SelectByUserName
        public SqlInt32 SelectByUserName(SqlString UserName)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserName(UserName);
        }
        #endregion SelectByUserName

        #region SelectByUserNameAndPassword
        public UserENT SelectByUserNameAndPassword(SqlString UserName, SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserNameAndPassword(UserName, Password);
        }
        #endregion SelectByUserNameAndPassword

        #region Select By UserID
        public SqlString SelectByUserID(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserID(UserID);
        }
        #endregion Select By UserID

        #region Select By Mobile Number
        public SqlString selectByMobileNumber(SqlString MobileNo)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.selectByMobileNumber(MobileNo);
        }
        #endregion Select By Mobile Number

        #endregion SelectByPK

        #endregion Select Operation

    }
}