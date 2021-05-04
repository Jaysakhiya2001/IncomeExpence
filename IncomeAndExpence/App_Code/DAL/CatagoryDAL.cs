using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CatagoryDAL
/// </summary>
namespace IncomeAndExpense.DAL
{
    public class CatagoryDAL : DataBaseConfig
    {
        #region Constructor
        public CatagoryDAL()
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
        public Boolean Insert(CatagoryENT entCatagory)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Catagory_InsertByUserID";

                            objCmd.Parameters.Add("@CatagoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                            objCmd.Parameters.Add("@CatagoryName", SqlDbType.VarChar).Value = entCatagory.CatagoryName;
                            objCmd.Parameters.Add("@CatagoryType", SqlDbType.VarChar).Value = entCatagory.CatagoryType;
                            objCmd.Parameters.Add("@CatagoryDescripation", SqlDbType.VarChar).Value = entCatagory.CatagoryDescripation;
                            objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entCatagory.UserID;
                        
                        objCmd.ExecuteNonQuery();
                        entCatagory.CatagoryID = Convert.ToInt32(objCmd.Parameters.Add("@CatagoryID", SqlDbType.Int).Value);
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
        public Boolean Update(CatagoryENT entCatagory)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Catagory_UpdateByPKAndUserID";

                        objCmd.Parameters.AddWithValue("@CatagoryID", entCatagory.CatagoryID);
                        objCmd.Parameters.AddWithValue("@CatagoryName", entCatagory.CatagoryName);
                        objCmd.Parameters.AddWithValue("@CatagoryType", entCatagory.CatagoryType);
                        objCmd.Parameters.AddWithValue("@CatagoryDescripation", entCatagory.CatagoryDescripation);
                        objCmd.Parameters.AddWithValue("@UserID", entCatagory.UserID);

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
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CatagoryID,SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Catagory_DeleteByUserID";

                        objCmd.Parameters.Add("@CatagoryID", SqlDbType.Int).Value = CatagoryID;
                        objCmd.Parameters.Add("@UserID",SqlDbType.Int).Value = UserID;

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
        #endregion Delete Operation

        #region Select Operation

        #region Select All
        public DataTable SelectAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Catagory_SelectAllBYUserID";

                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
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
        #endregion Select All

        #region Select For Income Dropdown
        public DataTable SelectForDropDownList(SqlString CatagoryType,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand()) 
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Catagory_SelectForDropDownlistUserID";

                        objCmd.Parameters.AddWithValue("@CatagoryType", CatagoryType);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        DataTable dt = new DataTable();
                        using(SqlDataReader objSdR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSdR);
                        }
                        return dt;
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
        #endregion Select For Income Dropdown

        #region selectByPK
        public CatagoryENT SelectByPK(SqlInt32 CatagoryID,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand()) 
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Catagory_SelectAllBYPKAndUserID";

                        objCmd.Parameters.Add("@CatagoryID", SqlDbType.Int).Value = CatagoryID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

                        CatagoryENT entCatagory = new CatagoryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CatagoryID"].Equals(DBNull.Value))
                                    entCatagory.CatagoryID = Convert.ToInt32(objSDR["CatagoryID"].ToString());

                                if (!objSDR["CatagoryName"].Equals(DBNull.Value))
                                    entCatagory.CatagoryName = Convert.ToString(objSDR["CatagoryName"].ToString());

                                if (!objSDR["CatagoryType"].Equals(DBNull.Value))
                                    entCatagory.CatagoryType = Convert.ToString(objSDR["CatagoryType"].ToString());

                                if (!objSDR["CatagoryDescripation"].Equals(DBNull.Value))
                                    entCatagory.CatagoryDescripation = Convert.ToString(objSDR["CatagoryDescripation"].ToString());
                                
                            }
                        }
                        return entCatagory;
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
        #endregion selectByPK

        #endregion Select Operation

    }
}