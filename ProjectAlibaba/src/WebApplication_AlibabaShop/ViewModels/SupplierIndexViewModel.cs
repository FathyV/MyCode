using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupplierReference;

namespace WebApplication_AlibabaShop.ViewModels
{
    public class SupplierIndexViewModel
    {
        public List<vw_SupplierProducts> topProduct { get; set; }
        public List<vw_SupplierQuotation> pendingQuotation { get; set; }
        public List<vw_SupplierOrder> orderCollection { get; set; }
        public List<SupplierRevenue> productRevenue { get; set; }
        public int totalQuotation { get; set; }
        public int totalOrder { get; set; }
        public int totalProduct { get; set; }
        public int totalRevenue { get; set; }
    }
}
