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
    public partial class GoodsDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int goodsId = Request.QueryString["goodsId"] != null ? Int32.Parse(Request.QueryString["goodsId"]) : 0;

            if (goodsId != 0)
            {
                GoodsBll gb = new GoodsBll();
                int rows = gb.DeleteGoods(goodsId);
                if (rows > 0) Msg.Text = "删除成功！";
                else Msg.Text = "删除失败！存在与之相关联的商品销售或进货记录。";
            }
        }
    }
}