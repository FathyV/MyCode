//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServices_AlibabaShop.dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_ProductTop10
    {
        public System.Guid Id { get; set; }
        public System.Guid Supplier_Id { get; set; }
        public System.Guid Category_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MinimumOrder { get; set; }
        public int MaximumOrder { get; set; }
        public int QtyInHand { get; set; }
        public byte Status { get; set; }
        public int Views { get; set; }
        public System.DateTime PostDate { get; set; }
        public string Image { get; set; }
        public Nullable<int> Discount { get; set; }
    }
}
