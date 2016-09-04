using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_AlibabaShop.ViewModels
{
    public class SupplierRevenue
    {
        public string productName { get; set; }
        public int totalOrder { get; set; }
        public int totalQuotation { get; set; }
        public decimal totalEarn { get; set; }
    }
}
