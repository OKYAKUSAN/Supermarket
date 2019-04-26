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
    public partial class SaleSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sale saleObj = new Sale();
            saleObj.SaleId = Int32.Parse(Request.Form["formSaleId"]);
            saleObj.GoodsId = Int32.Parse(Request.Form["formGoodsId"]);
            saleObj.SaleNumber = Request.Form["formSaleNumber"];
            saleObj.SalePrice = Double.Parse(Request.Form["formSalePrice"]);
            saleObj.SaleCount = Int32.Parse(Request.Form["formSaleCount"]);
            saleObj.SaleUnit = Request.Form["formSaleUnit"];
            int year = Int32.Parse(Request.Form["formSaleYear"]);
            int month = Int32.Parse(Request.Form["formSaleMonth"]);
            int day = Int32.Parse(Request.Form["formSaleDay"]);
            int hours = Int32.Parse(Request.Form["formSaleHours"]);
            int minutes = Int32.Parse(Request.Form["formSaleMinutes"]);
            int seconds = Int32.Parse(Request.Form["formSaleSecond"]);
            string dateStr = year.ToString() + "-" + (month < 10 ? "0" + month.ToString() : month.ToString()) + "-" + (day < 10 ? "0" + day.ToString() : day.ToString()) + " " + (hours < 10 ? "0" + hours.ToString() : hours.ToString()) + ":" + (minutes < 10 ? "0" + minutes.ToString() : minutes.ToString()) + ":" + (seconds < 10 ? "0" + seconds.ToString() : seconds.ToString());
            saleObj.SaleDate = DateTime.Parse(dateStr);

            SaleBll sb = new SaleBll();
            bool success = true;
            if (saleObj.SaleId == 0)
            {
                DateTime now = DateTime.Now;
                saleObj.SaleNumber = "SA" + now.Year.ToString() + (now.Month < 10 ? "0" + now.Month.ToString() : now.Month.ToString()) + (now.Day < 10 ? "0" + now.Day.ToString() : now.Day.ToString()) + (now.Hour < 10 ? "0" + now.Hour.ToString() : now.Hour.ToString()) + (now.Minute < 10 ? "0" + now.Minute.ToString() : now.Minute.ToString()) + (now.Second < 10 ? "0" + now.Second.ToString() : now.Second.ToString());
                success = sb.InsertSale(saleObj);
                if (success) Msg.Text = "添加成功！";
                else Msg.Text = "添加失败！";
            }
            else
            {
                success = sb.UpdateSale(saleObj);
                if (success) Msg.Text = "修改成功！";
                else Msg.Text = "修改失败！";
            }
        }
    }
}