using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserENT
/// </summary>
namespace IncomeAndExpense.ENT
{
    public class UserENT
    {
        #region Constructor
        public UserENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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

        #region UserName
        protected SqlString _UserName;

        public SqlString UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        #endregion UserName

        #region Password
        protected SqlString _Password;

        public SqlString Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        #endregion Password

        #region DisplayName
        protected SqlString _DisplayName;

        public SqlString DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                _DisplayName = value;
            }
        }
        #endregion DisplayName

        #region Address
        protected SqlString _Address;

        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        #endregion Address

        #region MobileNumber
        protected SqlString _MobileNumber;

        public SqlString MobileNumber
        {
            get
            {
                return _MobileNumber;
            }
            set
            {
                _MobileNumber = value;
            }
        }
        #endregion MobileNumber

        #region UserProfileImage
        protected SqlString _UserProfileImage;

        public SqlString UserProfileImage
        {
            get
            {
                return _UserProfileImage;
            }
            set
            {
                _UserProfileImage = value;
            }
        }

        #endregion UserProfileImage

    }
}