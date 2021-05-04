using IncomeAndExpense.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExpenseDAL
/// </summary>
namespace IncomeAndExpense.DAL
{
    public class ExpenseDAL : DataBaseConfig
    {
        #region Constructor
        public ExpenseDAL()
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
        public Boolean Insert(ExpenseENT entExpense)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Expense_InsertByUserID";

                        objCmd.Parameters.Add("@ExpenseID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@ExpenseName", SqlDbType.VarChar).Value = entExpense.ExpenseName;
                        objCmd.Parameters.Add("@ExpenseAmount", SqlDbType.Decimal).Value = entExpense.ExpenseAmount;
                        objCmd.Parameters.Add("@CatagoryID", SqlDbType.Int).Value = entExpense.CatagoryID;
                        objCmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = entExpense.Date;
                        objCmd.Parameters.Add("@Descripation", SqlDbType.VarChar).Value = entExpense.Descripation;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entExpense.UserID;

                        objCmd.ExecuteNonQuery();

                        entExpense.ExpenseID = Convert.ToInt32(objCmd.Parameters.Add("@ExpenseID", SqlDbType.Int).Value);
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

        #endregion Insert

        #region Update
        public Boolean Update(ExpenseENT entExpense)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Expense_UpdateByPKAndUserID";

                        objCmd.Parameters.AddWithValue("@ExpenseID",entExpense.ExpenseID);
                        objCmd.Parameters.AddWithValue("@ExpenseName", entExpense.ExpenseName);
                        objCmd.Parameters.AddWithValue("@ExpenseAmount", entExpense.ExpenseAmount);
                        objCmd.Parameters.AddWithValue("@CatagoryID", entExpense.CatagoryID);
                        objCmd.Parameters.AddWithValue("@Date", entExpense.Date);
                        objCmd.Parameters.AddWithValue("@Descripation", entExpense.Descripation);
                        objCmd.Parameters.AddWithValue("@UserID", entExpense.UserID);

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
        public Boolean Delete(SqlInt32 ExpenseID,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Expense_DeleteByPKAndUserID";

                        objCmd.Parameters.Add("@ExpenseID", SqlDbType.Int).Value = ExpenseID;
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
                        objCmd.CommandText = "PR_Expense_SelectAllByUserID";

                        objCmd.Parameters.AddWithValue("@UserID",UserID);

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
        public ExpenseENT SelectByPK(SqlInt32 ExpenseID,SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Expense_SelectAllByPKAndUserID";

                        objCmd.Parameters.Add("@ExpenseID", SqlDbType.Int).Value = ExpenseID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

                        ExpenseENT entExpense = new ExpenseENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ExpenseID"].Equals(DBNull.Value))
                                    entExpense.ExpenseID = Convert.ToInt32(objSDR["ExpenseID"].ToString());

                                if (!objSDR["ExpenseName"].Equals(DBNull.Value))
                                    entExpense.ExpenseName = Convert.ToString(objSDR["ExpenseName"].ToString());

                                if (!objSDR["ExpenseAmount"].Equals(DBNull.Value))
                                    entExpense.ExpenseAmount = Convert.ToDecimal(objSDR["ExpenseAmount"].ToString());

                                if (!objSDR["CatagoryID"].Equals(DBNull.Value))
                                    entExpense.CatagoryID = Convert.ToInt32(objSDR["CatagoryID"].ToString());

                                if (!objSDR["Date"].Equals(DBNull.Value))
                                    entExpense.Date = Convert.ToDateTime(objSDR["Date"].ToString());

                                if (!objSDR["Descripation"].Equals(DBNull.Value))
                                    entExpense.Descripation = Convert.ToString(objSDR["Descripation"].ToString());
                            }
                        }
                        return entExpense;
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