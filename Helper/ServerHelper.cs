using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Supermarket.Helper
{
    public static class ServerHelper
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connstring"].ToString());
        static SqlCommand cmd = conn.CreateCommand();

        /// <summary>
        /// 获取查询数据库结果列表
        /// </summary>
        /// <param name="cmdStr">Transact-SQL查询语句</param>
        /// <returns>DataSet类型查询结果列表</returns>
        public static DataSet GetQueryResultList(string cmdStr)
        {
            cmd.CommandText = cmdStr;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet resultDs = new DataSet();
            da.Fill(resultDs);
            conn.Close();
            return resultDs;
        }

        /// <summary>
        /// 增、删、改操作并返回第一行第一列
        /// </summary>
        /// <param name="cmdStr">Transact-SQL语句</param>
        /// <returns>-1表示数据未添加</returns>
        public static int ExecuteScalar(string cmdStr)
        {
            cmd.CommandText = cmdStr;
            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();
            int id = Convert.ToString(result) != "" ? Convert.ToInt32(result) : -1;
            return id;
        }

        /// <summary>
        /// 增、删、改操作并返回影响行数
        /// </summary>
        /// <param name="cmdStr">Transact-SQL语句</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdStr)
        {
            cmd.CommandText = cmdStr;
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
    }
}