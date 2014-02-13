using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace THOK.WES.Dal
{
    public class SQLHelper
    {
        #region Connection
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                //数据库连接字符串(web.config/app.config来配置)
                string connectionString = ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString;

                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        #endregion

        /// <summary>SQL查询 返回第一行第一列</summary>
        public static int GetScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        /// <summary>SQL语句 返回DataTable</summary>
        public static DataTable GetDataTable(string sql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        /// <summary>SQL增删改 返回结果</summary>
        public static int ExecuteCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
