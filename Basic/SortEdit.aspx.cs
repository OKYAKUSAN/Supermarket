using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Supermarket.Model;
using Supermarket.BLL;

namespace Supermarket.Basic
{
    public partial class SortEdit : System.Web.UI.Page
    {
        protected string sortName;
        protected void Page_Load(object sender, EventArgs e)
        {
            int sortId = Request.QueryString["sortId"] == null ? 0 : Int32.Parse(Request.QueryString["sortId"]);
            SortIdInput.Text = "<input type='hidden' id='formSortId' name='formSortId' value='" + sortId.ToString() + "' />";

            sortName = "";
            if (sortId != 0)
            {
                GoodsBll gb = new GoodsBll();
                Sort currentSort = gb.GetSingleSort(sortId);
                sortName = currentSort.SortName;
            }
        }
    }
}