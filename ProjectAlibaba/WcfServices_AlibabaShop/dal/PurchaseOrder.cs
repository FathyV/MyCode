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
    
    public partial class PurchaseOrder
    {
        public System.Guid Id { get; set; }
        public System.Guid Suplier_Id { get; set; }
        public System.Guid Product_Id { get; set; }
        public System.Guid WholeSaler_Id { get; set; }
        public System.Guid ShipMethod_Id { get; set; }
        public int Qty { get; set; }
        public System.Guid UnitMeasure_Id { get; set; }
        public decimal TotalPaid { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime ArrivedDate { get; set; }
        public byte Status { get; set; }
        public string OrderNo { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ShipMethod ShipMethod { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; }
        public virtual WholeSaler WholeSaler { get; set; }
    }
}
