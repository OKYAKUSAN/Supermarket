using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Supermarket.Model;

namespace Supermarket.Helper
{
    public static class PackageHelper
    {
        public static Sort SortPackage(DataRow dr)
        {
            Sort s = new Sort();
            s.SortId = Int32.Parse(dr["Sort_Id"].ToString());
            s.SortName = dr["Sort_Name"].ToString();
            return s;
        }
    }
}