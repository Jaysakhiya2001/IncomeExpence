using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAL
/// </summary>
namespace IncomeAndExpense.DAL
{
    public class UserDAL : DataBaseConfig
    {
        #region Constructor
        public UserDAL()
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_Insert";

                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entUser.UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = entUser.Password;
                        objCmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = entUser.DisplayName;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entUser.Address;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entUser.MobileNumber;
                        objCmd.Parameters.Add("@UserProfileImage", SqlDbType.VarChar).Value = entUser.UserProfileImage;

                        objCmd.ExecuteNonQuery();
                        entUser.UserID = Convert.ToInt32(objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value);
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Insert Operation

        #region Update Operation

        #region Profile
        public Boolean UpdateByPK(UserENT entUser)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_UpdateByPK";

                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entUser.UserID;
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entUser.UserName;
                        objCmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = entUser.DisplayName;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entUser.Address;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entUser.MobileNumber;
                        objCmd.Parameters.Add("@UserProfileImage", SqlDbType.VarChar).Value = entUser.UserProfileImage;

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Profile

        #region Upadate Password
        public Boolean UpdateByPassword(SqlInt32 UserID,SqlString OldPassword,SqlString NewPassword)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_UpdateByPassword";

                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        objCmd.Parameters.Add("@OldPassword", SqlDbType.VarChar).Value = OldPassword;
                        objCmd.Parameters.Add("@NewPassword", SqlDbType.VarChar).Value = NewPassword;
                        
                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Upadate Password

        #region Upadate MobileNo By Password
        public Boolean UpdateMobileNoByPassword(SqlString MobileNo,SqlString Password)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_UpdateByMobileNo";
                        
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = MobileNo;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Upadate By MobileNo

        #region Upadte Profile Image
        public Boolean UpdateProfile(UserENT entUser)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_UpdateProfile";

                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entUser.UserID;
                        objCmd.Parameters.Add("@UserProfileImage", SqlDbType.VarChar).Value = entUser.UserProfileImage;

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Upadte Profile Image

        #endregion Update Operation

        #region Delete Operation
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        #endregion SelectAll

        #region SelectByPK

        #region SelectByUserName
        public SqlInt32 SelectByUserName(SqlString UserName)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_SelectByUserName";

                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;

                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                    {
                                        entUser.UserID = Convert.ToInt32(objSDR["UserID"].ToString().Trim());
                                    }
                                }
                            }
                        }
                        return entUser.UserID;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.ToString();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.ToString();
                        return 0;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByUserName

        #region Select By UserName And Password
        public UserENT SelectByUserNameAndPassword(SqlString UserName, SqlString Password)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_SelectByUserNamePassword";

                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;

                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                    {
                                        entUser.UserID = Convert.ToInt32(objSDR["UserID"].ToString().Trim());
                                    }
                                    if (!objSDR["UserName"].Equals(DBNull.Value))
                                    {
                                        entUser.UserName = objSDR["UserName"].ToString().Trim();
                                    }
                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                    {
                                        entUser.DisplayName = objSDR["DisplayName"].ToString().Trim();
                                    }
                                    if (!objSDR["Address"].Equals(DBNull.Value))
                                    {
                                        entUser.Address = objSDR["Address"].ToString().Trim();
                                    }
                                    if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    {
                                        entUser.MobileNumber = objSDR["MobileNo"].ToString().Trim();
                                    }
                                    if (!objSDR["UserProfileImage"].Equals(DBNull.Value))
                                    {
                                        entUser.UserProfileImage = objSDR["UserProfileImage"].ToString().Trim();
                                    }
                                }
                            }
                        }
                        return entUser;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Select By UserName And Password

        #region Select By UserID
        public SqlString SelectByUserID(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_SelectByUserID";

                        objCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserID;

                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["Password"].Equals(DBNull.Value))
                                    {
                                        entUser.Password = Convert.ToString(objSDR["Password"].ToString().Trim());
                                    }
                                }
                            }
                        }
                        return entUser.Password;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Select By UserID

        #region Select By Mobile Number
        public SqlString selectByMobileNumber(SqlString MobileNo)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_SelectByMobileNo";

                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = MobileNo;

                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    {
                                        entUser.MobileNumber = objSDR["MobileNo"].ToString().Trim();
                                    }
                                }
                            }
                        }
                        return entUser.MobileNumber;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Select By Mobile Number


        #endregion SelectByPK

        #endregion Select Operation
    }
}