using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supermarket.DAL;
using Supermarket.Model;

namespace Supermarket.BLL
{
    public class SaleBll
    {
        SaleDal saleDalObj = new SaleDal();

        /// <summary>
        /// 获取所有销售列表
        /// </summary>
        /// <returns></returns>
        public List<Sale> GetAllSale()
        {
            return saleDalObj.GetAllSale();
        }

        /// <summary>
        /// 获取指定销售记录
        /// </summary>
        /// <param name="saleId">记录ID</param>
        /// <returns></returns>
        public Sale GetSingleSale(int saleId)
        {
            return saleDalObj.GetSingleSale(saleId);
        }

        /// <summary>
        /// 添加销售记录
        /// </summary>
        /// <param name="saleObj">销售实例</param>
        /// <returns></returns>
        public bool InsertSale(Sale saleObj)
        {
            int id = saleDalObj.InsertSale(saleObj);
            if (id > 0) return true;
            else return false;
        }

        /// <summary>
        /// 更改销售记录
        /// </summary>
        /// <param name="saleObj">销售实例</param>
        /// <returns></returns>
        public bool UpdateSale(Sale saleObj)
        {
            int rows = saleDalObj.UpdateSale(saleObj);
            if (rows > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除销售记录
        /// </summary>
        /// <param name="saleId">销售ID</param>
        /// <returns></returns>
        public bool DeleteSale(int saleId)
        {
            int rows = saleDalObj.DeleteSale(saleId);
            if (rows > 0) return true;
            else return false;
        }
    }
}