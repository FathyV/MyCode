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
    
    public partial class Quotation
    {
        public System.Guid Id { get; set; }
        public System.Guid Product_Id { get; set; }
        public System.Guid Supplier_Id { get; set; }
        public System.Guid WholeSaler_Id { get; set; }
        public System.Guid UnitMeasure_Id { get; set; }
        public int Qty { get; set; }
        public string Message { get; set; }
        public string FileAttachment { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Total { get; set; }
        public System.DateTime RequestDate { get; set; }
        public byte Status { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; }
        public virtual WholeSaler WholeSaler { get; set; }
    }
}