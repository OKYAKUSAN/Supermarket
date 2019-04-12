using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Supermarket.Model;

namespace Supermarket.Helper
{
    public static class PackageHelper
    {
        public static Sort SortPackage(DataRow dr)
        {
            Sort s = new Sort();
            s.SortId = Int32.Parse(dr["Sort_Id"].ToString());
            s.SortName = dr["Sort_Name"].ToString();
            return s;
        }

        public static Goods GoodsPackage(DataRow dr)
        {
            Goods g = new Goods();
            g.GoodsId = Int32.Parse(dr["Goods_Id"].ToString());
            g.GoodsName = dr["Goods_Name"].ToString();
            g.SortId = Int32.Parse(dr["Sort_Id"].ToString());
            g.SortName = dr["Sort_Name"].ToString();
            g.Price = Double.Parse(dr["Goods_Price"].ToString());
            g.Cost = Double.Parse(dr["Goods_Cost"].ToString());
            g.Onsale = (bool)dr["Goods_Onsale"];
            return g;
        }
    }
}