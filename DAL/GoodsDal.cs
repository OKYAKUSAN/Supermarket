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
        /// 按分类名称顺序从数据库中提取所有分类
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
        /// 按分类ID顺序从数据库中提取所有分类
        /// </summary>
        /// <param name="desc">是否降序排列</param>
        /// <returns></returns>
        public List<Sort> GetSortOrderById(bool desc)
        {
            strCmd = "";
            strCmd += "select * from Sort";
            if (desc) strCmd += " order by Sort_Id desc";
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

        /// <summary>
        /// 向数据库新增分类
        /// </summary>
        /// <param name="sortName">分类名称</param>
        /// <returns></returns>
        public int InsertSort(string sortName)
        {
            DateTime currentTime = DateTime.Now;
            strCmd = "";
            strCmd += "if not exists (select * from Sort where Sort_Name='" + sortName + "')";
            strCmd += " insert into Sort values ('" + sortName + "')";
            strCmd += ";select @@IDENTITY as Id";
            int insertId = ServerHelper.ExecuteScalar(strCmd);
            int sortModificationId = 0;
            if (insertId != -1)
            {
                strCmd = "";
                strCmd += "insert into Sort_Modification values (" + insertId.ToString() + ",'" + sortName + "','" + currentTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                strCmd += ";select @@IDENTITY as Id";
                sortModificationId = ServerHelper.ExecuteScalar(strCmd);
            }
            return insertId;
        }

        /// <summary>
        /// 更新数据库中分类
        /// </summary>
        /// <param name="sortObj">更新后的分类名称</param>
        /// <returns></returns>
        public int UpdateSort(Sort sortObj)
        {
            DateTime currentTime = DateTime.Now;
            strCmd = "";
            strCmd += "update Sort set Sort_Name='" + sortObj.SortName + "' where Sort_Id=" + sortObj.SortId.ToString();
            int rows = ServerHelper.ExecuteNonQuery(strCmd);
            int sortModificationId = 0;
            if (rows != 0)
            {
                strCmd = "";
                strCmd += "insert into Sort_Modification values (" + sortObj.SortId.ToString() + ",'" + sortObj.SortName + "','" + currentTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                strCmd += ";select @@IDENTITY as Id";
                sortModificationId = ServerHelper.ExecuteScalar(strCmd);
            }
            return rows;
        }

        /// <summary>
        /// 删除数据库中指定分类
        /// </summary>
        /// <param name="sortId">分类ID</param>
        /// <returns></returns>
        public int DeleteSort(int sortId)
        {
            strCmd = "";
            strCmd += "if not exists (select * from Goods where Goods_Sort=" + sortId.ToString() + ")";
            strCmd += " delete from Sort_Modification where Sort_Id=" + sortId.ToString();
            strCmd += ";if not exists (select * from Goods where Goods_Sort=" + sortId.ToString() + ")";
            strCmd += " delete from Sort where Sort_Id=" + sortId.ToString();
            int rows = ServerHelper.ExecuteNonQuery(strCmd);
            return rows;
        }

        /// <summary>
        /// 从数据库获取所有商品
        /// </summary>
        /// <param name="desc">是否降序排列</param>
        /// <returns></returns>
        public List<Goods> GetAllGoods(bool desc)
        {
            strCmd = "";
            strCmd += "select g.Goods_Id, g.Goods_Name, s.Sort_Id, s.Sort_Name, g.Goods_Price, g.Goods_Cost, g.Goods_Onsale";
            strCmd += " from Goods as g, Sort as s where g.Goods_Sort=s.Sort_Id";
            if (desc) strCmd += " order by g.Goods_Id desc";
            DataSet ds = ServerHelper.GetQueryResultList(strCmd);
            List<Goods> goodsList = new List<Goods>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                goodsList.Add(PackageHelper.GoodsPackage(dr));
            }
            return goodsList;
        }

        /// <summary>
        /// 按分类名称、商品名称顺序从数据库获取商品
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetAllGoodsOrderByName()
        {
            strCmd = "";
            strCmd += "select g.Goods_Id, g.Goods_Name, s.Sort_Id, s.Sort_Name, g.Goods_Price, g.Goods_Cost, g.Goods_Onsale";
            strCmd += " from Goods as g, Sort as s where g.Goods_Sort=s.Sort_Id order by s.Sort_Id, g.Goods_Name";
            DataSet ds = ServerHelper.GetQueryResultList(strCmd);
            List<Goods> goodsList = new List<Goods>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                goodsList.Add(PackageHelper.GoodsPackage(dr));
            }
            return goodsList;
        }

        /// <summary>
        /// 从数据库获取指定商品
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <returns></returns>
        public Goods GetSingleGoods(int goodsId)
        {
            strCmd = "";
            strCmd += "select g.Goods_Id, g.Goods_Name, s.Sort_Id, s.Sort_Name, g.Goods_Price, g.Goods_Cost, g.Goods_Onsale";
            strCmd += " from Goods as g, Sort as s where g.Goods_Sort=s.Sort_Id and g.Goods_Id=" + goodsId.ToString();
            DataSet ds = ServerHelper.GetQueryResultList(strCmd);
            return PackageHelper.GoodsPackage(ds.Tables[0].Rows[0]);
        }

        /// <summary>
        /// 向数据库添加商品
        /// </summary>
        /// <param name="goodsObj">商品实例</param>
        /// <returns></returns>
        public int InsertGoods(Goods goodsObj)
        {
            DateTime currentTime = DateTime.Now;
            strCmd = "";
            strCmd += "if not exists (select * from Goods where Goods_Name='" + goodsObj.GoodsName + "')";
            strCmd += " insert into Goods values ('" + goodsObj.GoodsName + "'," + goodsObj.SortId.ToString() + "," + goodsObj.Price.ToString() + "," + goodsObj.Cost.ToString() + "," + (goodsObj.Onsale ? "1" : "0") + ")";
            strCmd += ";select @@IDENTITY as Id";
            int insertId = ServerHelper.ExecuteScalar(strCmd);
            int goodsModificationId = 0;
            if (insertId > 0)
            {
                strCmd = "";
                strCmd += "insert into Goods_Modification values (" + insertId.ToString() + ",'" + goodsObj.GoodsName + "'," + goodsObj.SortId.ToString() + "," + goodsObj.Price.ToString() + "," + goodsObj.Cost.ToString() + "," + (goodsObj.Onsale ? "1" : "0") + ",'" + currentTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                strCmd += ";select @@IDENTITY as Id";
                goodsModificationId = ServerHelper.ExecuteScalar(strCmd);
            }
            return insertId;
        }

        /// <summary>
        /// 更新数据库中商品记录
        /// </summary>
        /// <param name="goodsObj">商品实例</param>
        /// <returns></returns>
        public int UpdateGoods(Goods goodsObj)
        {
            DateTime currentTime = DateTime.Now;
            strCmd = "";
            strCmd += "update Goods set Goods_Name='" + goodsObj.GoodsName + "'";
            strCmd += ",Goods_Sort=" + goodsObj.SortId.ToString();
            strCmd += ",Goods_Price=" + goodsObj.Price.ToString();
            strCmd += ",Goods_Cost=" + goodsObj.Cost.ToString();
            strCmd += ",Goods_Onsale=" + (goodsObj.Onsale ? "1" : "0");
            strCmd += " where Goods_Id=" + goodsObj.GoodsId.ToString();
            int rows = ServerHelper.ExecuteNonQuery(strCmd);
            int goodsModificationId = 0;
            if (rows != 0)
            {
                strCmd = "";
                strCmd += "insert into Goods_Modification values (" + goodsObj.GoodsId.ToString();
                strCmd += ",'" + goodsObj.GoodsName + "'";
                strCmd += "," + goodsObj.SortId.ToString();
                strCmd += "," + goodsObj.Price.ToString();
                strCmd += "," + goodsObj.Cost.ToString();
                strCmd += "," + (goodsObj.Onsale ? "1" : "0");
                strCmd += ",'" + currentTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                strCmd += ";select @@IDENTITY as Id";
                goodsModificationId = ServerHelper.ExecuteScalar(strCmd);
            }
            return rows;
        }

        /// <summary>
        /// 从数据库删除商品记录
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <returns></returns>
        public int DeleteGoods(int goodsId)
        {
            strCmd = "";
            strCmd += "if not exists (";
            strCmd += "select Sale.Sale_Id, S.Stock_Id from Sale";
            strCmd += " full join (select Stock.Stock_Id, Stock.Stock_Goods from Stock) S on Sale.Sale_Goods=S.Stock_Goods";
            strCmd += " where Sale.Sale_Goods=" + goodsId.ToString() + " or S.Stock_Goods=" + goodsId.ToString();
            strCmd += ") delete from Goods_Modification where Goods_Modification.Goods_Id=" + goodsId.ToString();
            strCmd += ";if not exists (";
            strCmd += "select Sale.Sale_Id, S.Stock_Id from Sale";
            strCmd += " full join (select Stock.Stock_Id, Stock.Stock_Goods from Stock) S on Sale.Sale_Goods=S.Stock_Goods";
            strCmd += " where Sale.Sale_Goods=" + goodsId.ToString() + " or S.Stock_Goods=" + goodsId.ToString();
            strCmd += ") delete from Goods where Goods.Goods_Id=" + goodsId.ToString();
            int rows = ServerHelper.ExecuteNonQuery(strCmd);
            return rows;
        }
    }
}