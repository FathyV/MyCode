using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupplierReference;

namespace WebApplication_AlibabaShop.ViewModels
{
    public class SupplierInfoViewModel
    {
        public vw_SupplierInfo supplierInfo { get; set; }
        public vw_SupplierContact contactInfo { get; set; }
        public List<SupplierReference.Country> lstCountry { get; set; }
        public List<SupplierReference.Ownership> lstOwnership { get; set; }
    }
}
