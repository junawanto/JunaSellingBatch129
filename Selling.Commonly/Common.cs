using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Selling.Commonly
{
    public class Common
    {
        public static string StrConn =
        System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

        public static int SQLCommandTimeout =
            Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("SqlCommandTimeOut")); // sqlcommandtimeout = max waiting time
        //1
        public static void ExecuteNonQuery(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(StrConn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = SQLCommandTimeout;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //2
        public static DataSet ExecuteDataSet(string sql/*nama prosudur*/)
        {
            DataSet dsData = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(StrConn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = sql; //panggil nama prosudur
                        cmd.CommandTimeout = SQLCommandTimeout;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dsData);
                    }
                }
                return dsData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //3
        public static DataSet ExecuteDataSet(SqlCommand sqlCmd)
        {

            DataSet dsData = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(StrConn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    using (sqlCmd)
                    {
                        sqlCmd.CommandTimeout = SQLCommandTimeout;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Connection = conn;

                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        da.Fill(dsData);
                    }
                }
                return dsData;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //4
        public static DataSet ExecuteDataSet(string sql, string dataSetName)
        {
            DataSet dsData = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(StrConn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = SQLCommandTimeout;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dsData, dataSetName);
                    }
                }
                return dsData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
