using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Supermarket.Helper;
using Supermarket.Model;

namespace Supermarket.DAL
{
    public class GoodsDal
    {
        string strCmd = "";

        /// <summary>
        /// 从数据库中提取所有分类名称
        /// </summary>
        /// <returns></returns>
        public List<Sort> GetSort()
        {
            strCmd = "";
            strCmd += "select * from Sort order by Sort_Name";
            DataSet ds = ServerHelper.GetQueryResultList(strCmd);
            List<Sort> sortList = new List<Sort>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sortList.Add(PackageHelper.SortPackage(dr));
            }
            return sortList;
        }

        /// <summary>
        /// 从数据库提取指定分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public Sort GetSingleSort(int id)
        {
            strCmd = "";
            strCmd = String.Format("select * from Sort where Sort_Id={0}", id);
            DataSet ds = ServerHelper.GetQueryResultList(strCmd);
            return PackageHelper.SortPackage(ds.Tables[0].Rows[0]);
        }

        public void InsertSort(string sortName)
        {
            DateTime currentTime = DateTime.Now;
            strCmd = "";
            strCmd += "if not exists (select * from Sort where Sort_Name='" + sortName + "')";
            strCmd += " insert into Sort values ('" + sortName + "')";
            strCmd += ";select @@IDENTITY as Id";
            int insertId = ServerHelper.ExecuteScalar(strCmd);
            if (insertId != -1)
            {
                strCmd = "";
                strCmd += "insert into Sort_Modification values (" + insertId.ToString() + ",'" + sortName + "','" + currentTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
        }
    }
}