using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleReports.Tools
{
    public class SPHelper
    {
        //连接字符串

        public static string connectionString = ConfigurationManager.ConnectionStrings["zkh_evmConnectionString"].ConnectionString;

        public SPHelper()
        {

        }

        /// <summary>
        /// 存数过程调用
        /// </summary>
        /// <param name="spname">存储过程名称</param>
        /// <param name="parameters">存储过程参数集</param>
        /// <returns></returns>
        public int ExecuteSP(string spname, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(spname, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@returnValue", "").Direction = ParameterDirection.ReturnValue;
            comm.Parameters.AddRange(parameters);
            conn.Open();
            try
            {
                comm.ExecuteNonQuery();
                //1 成功/2 参数错误/3 数据不存在/4 其他异常
                int rtnStatus = (int)comm.Parameters["@returnValue"].Value;
                conn.Close();
                return rtnStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 存数过程调用
        /// </summary>
        /// <param name="spname">存储过程名称</param>
        /// <param name="parameters">存储过程参数集</param>
        /// <returns></returns>
        public string ExecuteSPStr(string spname, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(spname, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("@returnValue", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            comm.Parameters.AddRange(parameters);
            conn.Open();
            try
            {
                comm.ExecuteNonQuery();
                string rtnStatus = (string)comm.Parameters["@returnValue"].Value;
                conn.Close();
                return rtnStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 执行非查询SQL
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public int ExecuteSql(string sqlStr)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(sqlStr, conn);
            comm.CommandType = CommandType.Text;
            conn.Open();
            try
            {
                int rtnStatus = comm.ExecuteNonQuery();
                conn.Close();
                return rtnStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public DataTable ExecuteToDataTable(string sqlStr)
        {
            try
            {
                DataTable dt = null;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand comm = new SqlCommand(sqlStr, conn);
                comm.CommandTimeout = 0;
                SqlDataAdapter sda = new SqlDataAdapter(sqlStr, connectionString);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public DataSet ExecuteToDataSet(string sqlStr)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand comm = new SqlCommand(sqlStr, conn);
                SqlDataAdapter sda = new SqlDataAdapter(sqlStr, connectionString);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

       
    }
}