using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supermarket.Model;
using Supermarket.Helper;

namespace Supermarket.DAL
{
    public class SaleDal
    {
        string strCmd = "";

        /// <summary>
        /// 从数据库获取所有销售列表
        /// </summary>
        /// <returns></returns>
        public List<Sale> GetAllSale()
        {
            strCmd = "";
            strCmd += "select sa.Sale_Id, g.Goods_Id, g.Goods_Name, so.Sort_Id, so.Sort_Name, sa.Sale_Number, sa.Sale_Price, sa.Sale_Count, sa.Sale_Unit, sa.Sale_Date";
            strCmd += " from Sale as sa, Goods as g, Sort as so";
            strCmd += " where sa.Sale_Goods=g.Goods_Id and g.Goods_Sort=so.Sort_Id order by sa.Sale_Id desc";
            DataSet ds = ServerHelper.GetQueryResultList(strCmd);
            List<Sale> saleList = new List<Sale>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                saleList.Add(PackageHelper.SalePackage(dr));
            }
            return saleList;
        }

        /// <summary>
        /// 从数据库获取指定销售记录
        /// </summary>
        /// <param name="saleId">销售记录ID</param>
        /// <returns></returns>
        public Sale GetSingleSale(int saleId)
        {
            strCmd = "";
            strCmd += "select sa.Sale_Id, g.Goods_Id, g.Goods_Name, so.Sort_Id, so.Sort_Name, sa.Sale_Number, sa.Sale_Price, sa.Sale_Count, sa.Sale_Unit, sa.Sale_Date";
            strCmd += " from Sale as sa, Goods as g, Sort as so";
            strCmd += " where sa.Sale_Goods=g.Goods_Id and g.Goods_Sort=so.Sort_Id and sa.Sale_Id=" + saleId.ToString();
            DataSet ds = ServerHelper.GetQueryResultList(strCmd);
            return PackageHelper.SalePackage(ds.Tables[0].Rows[0]);
        }

        /// <summary>
        /// 向数据库添加新的销售记录
        /// </summary>
        /// <param name="saleObj">销售实例</param>
        /// <returns></returns>
        public int InsertSale(Sale saleObj)
        {
            strCmd = "";
            strCmd += "insert into Sale values (" + saleObj.GoodsId.ToString() + ",'" + saleObj.SaleNumber + "'," + saleObj.SalePrice.ToString() + "," + saleObj.SaleCount.ToString() + ",'" + saleObj.SaleUnit + "','" + saleObj.SaleDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            strCmd += ";select @@IDENTITY as Id";
            int insertId = ServerHelper.ExecuteScalar(strCmd);
            int saleModificationId = 0;
            if (insertId > 0)
            {
                strCmd = "";
                strCmd += "insert into Sale_Modification values (";
                strCmd += insertId.ToString();
                strCmd += "," + saleObj.GoodsId.ToString();
                strCmd += ",'" + saleObj.SaleNumber + "'";
                strCmd += "," + saleObj.SalePrice.ToString();
                strCmd += "," + saleObj.SaleCount.ToString();
                strCmd += ",'" + saleObj.SaleUnit + "'";
                strCmd += ",'" + saleObj.SaleDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                strCmd += ",'" + saleObj.SaleDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                strCmd += ";select @@IDENTITY as Id";
                saleModificationId = ServerHelper.ExecuteScalar(strCmd);
            }
            return insertId;
        }

        /// <summary>
        /// 更新数据库指定销售记录
        /// </summary>
        /// <param name="saleObj">销售实例</param>
        /// <returns></returns>
        public int UpdateSale(Sale saleObj)
        {
            strCmd = "";
            strCmd += "update Sale set Sale_Goods=" + saleObj.GoodsId.ToString();
            strCmd += ",Sale_Number=" + saleObj.SaleNumber;
            strCmd += ",Sale_Price=" + saleObj.SalePrice.ToString();
            strCmd += ",Sale_Count=" + saleObj.SaleCount.ToString();
            strCmd += ",Sale_Unit=" + saleObj.SaleUnit.ToString();
            strCmd += ",Sale_Date='" + saleObj.SaleDate.ToString("yyyy-MM-dd HH:mm:ss");
            strCmd += " where Sale_Id=" + saleObj.SaleId.ToString();
            int rows = ServerHelper.ExecuteNonQuery(strCmd);
            if (rows > 0)
            {
                DateTime newTime = DateTime.Now;
                strCmd = "";
                strCmd += "insert into Sale_Modification values(" + saleObj.SaleId.ToString();
                strCmd += "," + saleObj.GoodsId.ToString();
                strCmd += ",'" + saleObj.SaleNumber + "'";
                strCmd += "," + saleObj.SalePrice.ToString();
                strCmd += "," + saleObj.SaleCount.ToString();
                strCmd += ",'" + saleObj.SaleUnit + "'";
                strCmd += ",'" + saleObj.SaleDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                strCmd += ",'" + newTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                strCmd += ";select @@IDENTITY as Id";
            }
            return rows;
        }

        /// <summary>
        /// 删除数据库销售记录
        /// </summary>
        /// <param name="saleId">记录ID</param>
        /// <returns></returns>
        public int DeleteSale(int saleId)
        {
            strCmd = "";
            strCmd += "delete from Sale_Modification where Sale_Id=" + saleId.ToString();
            strCmd += ";delete from Sale where Sale_Id=" + saleId.ToString();
            int rows = ServerHelper.ExecuteNonQuery(strCmd);
            return rows;
        }
    }
}