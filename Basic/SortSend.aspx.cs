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
            if (sortId == 0)
            {
            }
        }
    }
}