using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupplierReference;
using CommonReference;
namespace WebApplication_AlibabaShop.ViewModels
{
    public class SupplierProductDetailsViewModel
    {
        public vw_SupplierProducts product { get; set; }
        public List<vw_SupplierOrder> orders { get; set; }
        public List<vw_SupplierFeedback> feedbacks { get; set; }
        public List<vw_SupplierQuotation> quotations { get; set; }
        public List<vw_Category> categories { get; set; }
    }    
}
