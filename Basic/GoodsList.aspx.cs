using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Supermarket.BLL;
using Supermarket.Model;
using Supermarket.Helper;

namespace Supermarket.Basic
{
    public partial class GoodsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoodsBll gb = new GoodsBll();
            List<Goods> goodsList = gb.GetAllGoods(true);
            int showCount = 15;
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            int page = Request.QueryString["page"] == null ? 1 : Int32.Parse(Request.QueryString["page"]);
            int maxPage = goodsList.Count % showCount == 0 ? goodsList.Count / showCount : goodsList.Count / showCount + 1;
            string html = "";
            if (goodsList.Count != 0)
            {
                GoodsPageNum.Text = HtmlHelper.PageNumAdminControl(url, "rightFrame", page, maxPage);

                int startIndex = (page - 1) * showCount;
                int endIndex = page == maxPage ? goodsList.Count - 1 : page * showCount - 1;
                bool tbg = true;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    html += tbg ? "<tr class='tbg1'>" : "<tr class='tbg2'>";
                    html += "<td>" + goodsList[i].GoodsName + "</td>";
                    html += "<td>" + goodsList[i].SortName + "</td>";
                    html += "<td>" + goodsList[i].Price.ToString("f2") + "</td>";
                    html += "<td>" + goodsList[i].Cost.ToString("f2") + "</td>";
                    html += "<td>" + (goodsList[i].Onsale ? "是" : "否") + "</td>";
                    html += "<td><a href='/Basic/GoodsEdit.aspx?goodsId=" + goodsList[i].GoodsId.ToString() + "' target='rightFrame'>编辑</a>";
                    html += "&nbsp;&nbsp;|&nbsp;&nbsp;<a href='/Basic/GoodsDelete.aspx?goodsId=" + goodsList[i].GoodsId.ToString() + "' target='rightFrame' onclick=\"javascript:return confirm('确定要删除吗？')\">删除</a>";
                    html += "</tr>";
                    tbg = !tbg;
                }
                GoodsListTable.Text = html;
            }
            else
            {
                GoodsListTable.Text = "<tr class='tbg1'><td colspan='6'>暂无记录</td></tr>";
            }
        }
    }
}