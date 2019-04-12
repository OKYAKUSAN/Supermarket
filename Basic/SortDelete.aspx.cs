using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Supermarket.BLL;
using Supermarket.Model;

namespace Supermarket.Basic
{
    public partial class SortDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int sortId = Request.QueryString["sortId"] != null ? Int32.Parse(Request.QueryString["sortId"]) : 0;
            int rows = 0;
            if (sortId != 0)
            {
                GoodsBll gb = new GoodsBll();
                rows = gb.DeleteSort(sortId);
            }
            if (rows == 0) Msg.Text = "存在与之相关联的商品记录，未删除成功！";
            else Msg.Text = "删除成功！";
        }
    }
}