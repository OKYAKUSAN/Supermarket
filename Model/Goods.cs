using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supermarket.Model
{
    public class Goods
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public int SortId { get; set; }
        public string SortName { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public bool Onsale { get; set; }
    }
}