using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Supermarket.Model;
using Supermarket.BLL;

namespace Supermarket.Transaction
{

    public partial class SaleEdit : System.Web.UI.Page
    {
        protected int frontSaleId;
        protected int frontSortId;
        protected int frontGoodsId;
        protected double frontSalePrice;
        protected int frontSaleCount;
        protected string frontSaleUnit;
        protected DateTime frontSaleDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            GoodsBll gb = new GoodsBll();
            List<Sort> sortList = gb.GetSort();
            List<Goods> goodsList = gb.GetAllGoodsOrderByName();
            string html = "";
            foreach (Sort tempSort in sortList)
            {
                html += "<option value='" + tempSort.SortId.ToString() + "'>" + tempSort.SortName + "</option>";
            }
            FormSortIdSelect.Text = html;
            html = "";
            foreach (Goods tempGoods in goodsList)
            {
                html += "<option sortTag='" + tempGoods.SortId.ToString() + "' price='" + tempGoods.Price.ToString("f2") + "' value='" + tempGoods.GoodsId.ToString() + "'>" + tempGoods.GoodsName + "</option>";
            }
            FormGoodsIdSelect.Text = html;

            int saleId = Request.QueryString["saleId"] == null ? 0 : Int32.Parse(Request.QueryString["saleId"]);
            SaleIdInput.Text = "<input type='hidden' id='formSaleId' name='formSaleId' value='" + saleId.ToString() + "' />";
            frontSaleId = saleId;
            if (saleId != 0)
            {
                SaleBll sb = new SaleBll();
                Sale saleObj = sb.GetSingleSale(saleId);
                SaleNumberInput.Text = "<input type='hidden' id='formSaleNumber' name='formSaleNumber' value='" + saleObj.SaleNumber + "' />";
                frontSortId = saleObj.SortId;
                frontGoodsId = saleObj.GoodsId;
                frontSalePrice = saleObj.SalePrice;
                frontSaleCount = saleObj.SaleCount;
                frontSaleUnit = saleObj.SaleUnit;
                frontSaleDate = saleObj.SaleDate;
            }
            else
            {
                SaleNumberInput.Text = "<input type='hidden' id='formSaleNumber' name='formSaleNumber' value='' />";
            }
        }
    }
}