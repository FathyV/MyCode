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
    
    public partial class vw_SupplierInfo
    {
        public System.Guid Id { get; set; }
        public string Supplier_Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Ownership { get; set; }
        public int Employees { get; set; }
        public int EstablishedYear { get; set; }
        public decimal Revenue { get; set; }
        public string Logo { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public System.Guid Ownership_Id { get; set; }
        public System.Guid Country_Id { get; set; }
        public byte Status { get; set; }
    }
}