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
    public partial class GoodsEdit : System.Web.UI.Page
    {
        protected int goodsId;
        protected string goodsName;
        protected int sortId;
        protected string goodsPrice;
        protected string goodsCost;
        protected bool goodsOnsales;
        protected void Page_Load(object sender, EventArgs e)
        {
            goodsId = Request.QueryString["goodsId"] == null ? 0 : Int32.Parse(Request.QueryString["goodsId"]);
            GoodsIdInput.Text = "<input type='hidden' id='formGooodsId' name='formGooodsId' value='" + goodsId.ToString() + "' />";

            GoodsBll gb = new GoodsBll();
            List<Sort> sortList = gb.GetSort();
            string html = "";
            foreach (Sort sort in sortList)
            {
                html += "<option value='" + sort.SortId.ToString() + "'>" + sort.SortName + "</option>";
            }
            SortListSelect.Text = html;

            if (goodsId != 0)
            {
                Goods currentGoods = gb.GetSingleGoods(goodsId);
                goodsName = currentGoods.GoodsName;
                sortId = currentGoods.SortId;
                goodsPrice = currentGoods.Price.ToString("f2");
                goodsCost = currentGoods.Cost.ToString("f2");
                goodsOnsales = currentGoods.Onsale;
            }
        }
    }
}