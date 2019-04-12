using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supermarket.DAL;
using Supermarket.Model;

namespace Supermarket.BLL
{
    public class GoodsBll
    {
        GoodsDal goodsDal = new GoodsDal();

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public List<Sort> GetSort()
        {
            return goodsDal.GetSort();
        }

        public List<Sort> GetSortOrderById(bool desc)
        {
            return goodsDal.GetSortOrderById(desc);
        }

        /// <summary>
        /// 获取指定分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public Sort GetSingleSort(int id)
        {
            return goodsDal.GetSingleSort(id);
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="sortName">分类名称</param>
        /// <returns></returns>
        public bool InsertSort(string sortName)
        {
            int id = goodsDal.InsertSort(sortName);
            if (id == -1) return false;
            else return true;
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="sortObj">需要更新的Sort实例</param>
        /// <returns></returns>
        public bool UpdateSort(Sort sortObj)
        {
            int rows = goodsDal.UpdateSort(sortObj);
            if (rows == 0) return false;
            else return true;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="sortId">分类ID</param>
        /// <returns></returns>
        public int DeleteSort(int sortId)
        {
            return goodsDal.DeleteSort(sortId);
        }

        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <param name="desc">是否降序排列</param>
        /// <returns></returns>
        public List<Goods> GetAllGoods(bool desc)
        {
            return goodsDal.GetAllGoods(desc);
        }

        /// <summary>
        /// 按分类名称、商品名称顺序获取所有商品
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetAllGoodsOrderByName()
        {
            return goodsDal.GetAllGoodsOrderByName();
        }

        /// <summary>
        /// 获取指定商品
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <returns></returns>
        public Goods GetSingleGoods(int goodsId)
        {
            return goodsDal.GetSingleGoods(goodsId);
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goodsObj">商品实例</param>
        /// <returns></returns>
        public bool InsertGoods(Goods goodsObj)
        {
            int id = goodsDal.InsertGoods(goodsObj);
            if (id == -1) return false;
            else return true;
        }

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="goodsObj">商品实例</param>
        /// <returns></returns>
        public bool UpdateGoods(Goods goodsObj)
        {
            int rows = goodsDal.UpdateGoods(goodsObj);
            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <returns></returns>
        public int DeleteGoods(int goodsId)
        {
            return goodsDal.DeleteGoods(goodsId);
        }
    }
}