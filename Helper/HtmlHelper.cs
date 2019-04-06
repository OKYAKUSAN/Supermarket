using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supermarket.Helper
{
    public static class HtmlHelper
    {
        /// <summary>
        /// 页码控件
        /// </summary>
        /// <param name="url">页面地址</param>
        /// <param name="page">展示页码</param>
        /// <param name="maxPage">最大页码数</param>
        /// <param name="showNums">每组显示多少页码数</param>
        /// <returns></returns>
        public static string PageNumControl(string url, int page, int maxPage, int showNums)
        {
            showNums = Convert.ToString(showNums) != "" ? showNums : 10;
            int startPage = (page / showNums) * showNums + 1;
            int endPage = (page / showNums + 1) * showNums;
            if (endPage > maxPage) endPage = maxPage;
            string html = "";
            html += "<div class='pageNum'>";
            html += page == 1 ? "<span class='unable'>上一页</span>" : ("<a href='" + url + "?page=" + (page - 1).ToString() + "'>上一页</a>");
            if (page > showNums)
            {
                html += "<a href='" + url + "?page=1'>1</a>";
                html += "<span>...</span>";
            }
            for (int i = startPage; i <= endPage; i++)
            {
                html += page == i ? ("<span class='red'>" + i.ToString() + "</span>") : ("<a href='" + url + "?page=" + i.ToString() + "'>" + i.ToString() + "</a>");
            }
            if (endPage < maxPage)
            {
                html += "<span>...</span>";
                html += "<a href='" + url + "?page=" + maxPage.ToString() + "'>" + maxPage.ToString() + "</a>";
            }
            html += page == maxPage ? "<span class='unable'>下一页</span>" : ("<a href='" + url + "?page=" + (page + 1).ToString() + "'>下一页</a>");
            html += "</div>";

            return html;
        }

        /// <summary>
        /// 页码控件
        /// </summary>
        /// <param name="url">页面地址</param>
        /// <param name="page">展示页码</param>
        /// <param name="maxPage">最大页码数</param>
        /// <returns></returns>
        public static string PageNumControl(string url, int page, int maxPage)
        {
            return PageNumControl(url, page, maxPage, 10);
        }

        public static string PageNumAdminControl(string url, string target, int page, int maxPage)
        {
            int startNum = page / 10 * 10 + 1;
            int endNum = (page / 10 + 1) * 10;
            if (endNum > maxPage) endNum = maxPage;
            string html = "";
            html += "<div class='pageNum'>";
            html += page == 1 ? "" : "<a href='" + url + "?page=" + (page - 1).ToString() + "' target='" + target + "'>上一页</a>";
            if (page > 10)
            {
                html += "<a href='" + url + "?page=1' target='" + target + "'>1</a>";
                html += "<span>...</span>";
            }
            for (int i = startNum; i <= endNum; i++)
            {
                html += page == i ? "<a href='" + url + "?page=" + i.ToString() + "' target='" + target + "' class='sel'>" + i.ToString() + "</a>" : "<a href='" + url + "?page=" + i.ToString() + "' target='" + target + "'>" + i.ToString() + "</a>";
            }
            if (endNum < maxPage)
            {
                html += "<span>...</span>";
                html += "<a href='" + url + "?page=" + maxPage.ToString() + "' target='" + target + "'>" + maxPage.ToString() + "</a>";
            }
            html += page == maxPage ? "" : "<a href='" + url + "?page=" + (page + 1).ToString() + "' target='" + target + "'>下一页</a>";
            html += "</div>";

            return html;
        }
    }
}