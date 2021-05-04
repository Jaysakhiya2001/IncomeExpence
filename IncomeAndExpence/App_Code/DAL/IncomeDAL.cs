using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IncomeDAL
/// </summary>
namespace IncomeAndExpense.DAL
{
    public class IncomeDAL : DataBaseConfig
    {
        #region Constructor
        public IncomeDAL()
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

        #region Insert
        public Boolean Insert(IncomeENT entIncome)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Income_InsertByUserID";

                        objCmd.Parameters.Add("@IncomeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@IncomeName", SqlDbType.VarChar).Value = entIncome.IncomeName;
                        objCmd.Parameters.Add("@IncomeAmount", SqlDbType.Decimal).Value = entIncome.IncomeAmount;
                        objCmd.Parameters.Add("@CatagoryID", SqlDbType.Int).Value = entIncome.CatagoryID;
                        objCmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = entIncome.Date;
                        objCmd.Parameters.Add("@Descripation", SqlDbType.VarChar).Value = entIncome.Descripation;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entIncome.UserID;

                        objCmd.ExecuteNonQuery();

                        entIncome.IncomeID = Convert.ToInt32(objCmd.Parameters.Add("@IncomeID", SqlDbType.Int).Value);
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

        #endregion Insert

        #region Update
        public Boolean Update(IncomeENT entIncome)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Income_UpdateByPKAndUserID";

                        objCmd.Parameters.AddWithValue("@IncomeID", entIncome.IncomeID);
                        objCmd.Parameters.AddWithValue("@IncomeName", entIncome.IncomeName);
                        objCmd.Parameters.AddWithValue("@IncomeAmount", entIncome.IncomeAmount);
                        objCmd.Parameters.AddWithValue("@CatagoryID", entIncome.CatagoryID);
                        objCmd.Parameters.AddWithValue("@Date", entIncome.Date);
                        objCmd.Parameters.AddWithValue("@Descripation", entIncome.Descripation);
                        objCmd.Parameters.AddWithValue("@UserID", entIncome.UserID);

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

        #endregion Update

        #region Delete
        public Boolean Delete(SqlInt32 IncomeID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Income_DeleteByPKAndUserID";

                        objCmd.Parameters.Add("@IncomeID", SqlDbType.Int).Value = IncomeID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

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
        #endregion Delete

        #region Select Operation

        #region Select All
        public DataTable SelectAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Income_SelectAllByUserID";

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

        #region Select For Dropdown

        #endregion Select For Dropdown

        #region selectByPK
        public IncomeENT SelectByPK(SqlInt32 IncomeID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Income_SelectAllByPKAndUserID";

                        objCmd.Parameters.Add("@IncomeID", SqlDbType.Int).Value = IncomeID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

                        IncomeENT entIncome = new IncomeENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["IncomeID"].Equals(DBNull.Value))
                                    entIncome.IncomeID = Convert.ToInt32(objSDR["IncomeID"].ToString());

                                if (!objSDR["IncomeName"].Equals(DBNull.Value))
                                    entIncome.IncomeName = Convert.ToString(objSDR["IncomeName"].ToString());

                                if (!objSDR["IncomeAmount"].Equals(DBNull.Value))
                                    entIncome.IncomeAmount = Convert.ToDecimal(objSDR["IncomeAmount"].ToString());

                                if (!objSDR["CatagoryID"].Equals(DBNull.Value))
                                    entIncome.CatagoryID = Convert.ToInt32(objSDR["CatagoryID"].ToString());

                                if (!objSDR["Date"].Equals(DBNull.Value))
                                    entIncome.Date = Convert.ToDateTime(objSDR["Date"].ToString());

                                if (!objSDR["Descripation"].Equals(DBNull.Value))
                                    entIncome.Descripation = Convert.ToString(objSDR["Descripation"].ToString());
                            }
                        }
                        return entIncome;
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