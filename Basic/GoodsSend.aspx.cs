using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Supermarket.BLL;
using Supermarket.Model;

namespace Supermarket.Basic
{
    public partial class GoodsSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Goods goodsObj = new Goods();
            goodsObj.GoodsId = Int32.Parse(Request.Form["formGooodsId"]);
            goodsObj.GoodsName = Request.Form["formGoodsName"];
            goodsObj.SortId = Int32.Parse(Request.Form["formSortId"]);
            goodsObj.Price = Double.Parse(Request.Form["formGoodsPrice"]);
            goodsObj.Cost = Double.Parse(Request.Form["formGoodsCost"]);
            goodsObj.Onsale = Int32.Parse(Request.Form["formGoodsOnsale"]) == 1 ? true : false;

            GoodsBll gb = new GoodsBll();
            bool success = false;
            if (goodsObj.GoodsId == 0)
            {
                success = gb.InsertGoods(goodsObj);
                if (success) Msg.Text = "添加成功！";
                else Msg.Text = "添加失败！该商品已存在。";
            }
            else
            {
                success = gb.UpdateGoods(goodsObj);
                if (success) Msg.Text = "修改成功！";
                else Msg.Text = "修改失败！";
            }
        }
    }
}