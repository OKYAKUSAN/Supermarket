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
    public partial class sortlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GoodsBll gb = new GoodsBll();
            List<Sort> sortList = new List<Sort>();
            sortList = gb.GetSort();
            int showCount = 15;
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            int page = Request.QueryString["page"] == null ? 1 : Int32.Parse(Request.QueryString["page"]);
            int maxPage = sortList.Count % showCount == 0 ? sortList.Count / showCount : sortList.Count / showCount + 1;
            string html = "";
            if (sortList.Count != 0)
            {
                SortPageNum.Text = HtmlHelper.PageNumAdminControl(url, "rightFrame", page, maxPage);

                int startIndex = (page - 1) * showCount;
                int endIndex = page == maxPage ? sortList.Count - 1 : page * showCount - 1;
                bool tbg = true;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    html += tbg ? "<tr class='tbg1'>" : "<tr class='tbg2'>";
                    html += "<td>" + sortList[i].SortName + "</td>";
                    html += "<td></td>";
                    html += "<td><a href='" + sortList[i].SortId.ToString() + "' target='rightFrame'>编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href='" + sortList[i].SortId.ToString() + "' target='rightFrame'>删除</a>";
                    html += "</tr>";
                    tbg = !tbg;
                }
                SortListTable.Text = html;
            }
            else SortListTable.Text = "<tr class='tbg1'><td colspan=3>暂无记录</td></tr>";
        }
    }
}