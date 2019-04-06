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
    public partial class SortSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int sortId = Int32.Parse(Request.Form["formSortId"]);
            string sortName = Request.Form["formSortName"];
            Sort sortEdit = new Sort();
            sortEdit.SortId = sortId;
            sortEdit.SortName = sortName;
            GoodsBll gb = new GoodsBll();
            bool success = false;
            if (sortId == 0)
            {
                success = gb.InsertSort(sortEdit.SortName);
                if (success) Msg.Text = "添加成功！";
                else Msg.Text = "添加失败！“" + sortEdit.SortName + "”已存在。";
            }
            else
            {
                success = gb.UpdateSort(sortEdit);
                if (success) Msg.Text = "修改成功！";
                else Msg.Text = "修改失败！";
            }
        }
    }
}