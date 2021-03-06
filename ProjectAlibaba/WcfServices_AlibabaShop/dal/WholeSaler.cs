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
    
    public partial class WholeSaler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WholeSaler()
        {
            this.ProductFeedbacks = new HashSet<ProductFeedback>();
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
            this.Quotations = new HashSet<Quotation>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public System.Guid Ownership_Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public System.Guid Country_Id { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string Email { get; set; }
        public byte Status { get; set; }
    
        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductFeedback> ProductFeedbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}
