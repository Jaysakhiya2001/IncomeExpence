using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportDAL
/// </summary>
namespace IncomeAndExpense.DAL
{
    public class ReportDAL : DataBaseConfig
    {
        #region Constructor
        public ReportDAL()
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

        #region Select Operation

        #region selectByPK
        
        #region  Report
        public DataTable ReportSelectByDate(SqlDateTime StartingDate,SqlDateTime EndingDate,SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Report_SelectByDate";

                        objCmd.Parameters.Add("@StartingDate",SqlDbType.DateTime).Value = StartingDate;
                        objCmd.Parameters.Add("@EndingDate", SqlDbType.DateTime).Value = EndingDate;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
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
        #endregion  Report
        

        #endregion selectByPK

        #endregion Select Operation
    }
}