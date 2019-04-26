using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Supermarket.Model;
using Supermarket.BLL;
using Supermarket.Helper;

namespace Supermarket.Transaction
{
    public partial class SaleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SaleBll sb = new SaleBll();
            List<Sale> saleList = sb.GetAllSale();
            int showCount = 15;
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            int page = Request.QueryString["page"] == null ? 1 : Int32.Parse(Request.QueryString["page"]);
            int maxPage = saleList.Count % showCount == 0 ? saleList.Count / showCount : saleList.Count / showCount + 1;
            string html = "";
            if (saleList.Count != 0)
            {
                SalePageNum.Text = HtmlHelper.PageNumAdminControl(url, "rightFrame", page, maxPage);

                int startIndex = showCount * (page - 1);
                int endIndex = page == maxPage ? saleList.Count - 1 : showCount * page - 1;
                bool tbg = true;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    html += tbg ? "<tr class='tbg1'>" : "<tr class='tbg2'>";
                    html += "<td>" + saleList[i].SaleNumber + "</td>";
                    html += "<td>" + saleList[i].GoodsName + "</td>";
                    html += "<td>" + saleList[i].SortName + "</td>";
                    html += "<td>" + saleList[i].SalePrice.ToString() + "</td>";
                    html += "<td>" + saleList[i].SaleCount.ToString() + "</td>";
                    html += "<td>" + saleList[i].SaleUnit + "</td>";
                    html += "<td>" + saleList[i].SaleDate.ToString("yyyy-MM-dd HH:mm:ss") + "</td>";
                    html += "<td><a href='/Transaction/SaleEdit.aspx?saleId=" + saleList[i].SaleId.ToString() + "' target='rightFrame'>编辑</a>";
                    html += "&nbsp;&nbsp;|&nbsp;&nbsp;<a href='/Transaction/SaleDelete.aspx?saleId=" + saleList[i].SaleId.ToString() + "' target='rightFrame'>删除</a>";
                    html += "</td>";
                    html += "</tr>";
                    tbg = !tbg;
                }
                SaleListTable.Text = html;
            }
            else SaleListTable.Text = "<tr class='tbg1'><td colspan='8'>暂无记录</td></tr>";
        }
    }
}