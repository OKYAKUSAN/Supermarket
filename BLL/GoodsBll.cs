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
    }
}