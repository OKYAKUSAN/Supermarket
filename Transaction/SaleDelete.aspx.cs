using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Supermarket.BLL;
using Supermarket.Model;

namespace Supermarket.Transaction
{
    public partial class SaleDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int saleId = Request.QueryString["saleId"] != null ? Int32.Parse(Request.QueryString["saleId"]) : 0;

            bool success = true;
            if (saleId != 0)
            {
                SaleBll sb = new SaleBll();
                success = sb.DeleteSale(saleId);
                if (success) Msg.Text = "删除成功！";
                else Msg.Text = "删除失败！";
            }
        }
    }
}