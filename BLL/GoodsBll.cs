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
    }
}