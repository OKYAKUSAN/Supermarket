using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supermarket.Model
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public int SortId { get; set; }
        public string SortName { get; set; }
        public string SaleNumber { get; set; }
        public double SalePrice { get; set; }
        public int SaleCount { get; set; }
        public string SaleUnit { get; set; }
        public DateTime SaleDate { get; set; }
    }
}