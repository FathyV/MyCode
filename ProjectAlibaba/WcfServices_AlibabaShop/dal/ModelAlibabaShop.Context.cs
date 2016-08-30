﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AlibabaShopEntities : DbContext
    {
        public AlibabaShopEntities()
            : base("name=AlibabaShopEntities")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Harbor> Harbors { get; set; }
        public virtual DbSet<Ownership> Ownerships { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductFeedback> ProductFeedbacks { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<ShipMethod> ShipMethods { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }
        public virtual DbSet<WholeSaler> WholeSalers { get; set; }
        public virtual DbSet<vw_SupplierBasicInfo> vw_SupplierBasicInfo { get; set; }
        public virtual DbSet<vw_SupplierForAdmin> vw_SupplierForAdmin { get; set; }
        public virtual DbSet<vw_SupplierInfo> vw_SupplierInfo { get; set; }
        public virtual DbSet<vw_SupplierRevenue> vw_SupplierRevenue { get; set; }
        public virtual DbSet<vw_Transaction> vw_Transaction { get; set; }
        public virtual DbSet<vw_SupplierProducts> vw_SupplierProducts { get; set; }
        public virtual DbSet<vw_SupplierFeedback> vw_SupplierFeedback { get; set; }
        public virtual DbSet<vw_SupplierOrder> vw_SupplierOrder { get; set; }
        public virtual DbSet<vw_SupplierQuotation> vw_SupplierQuotation { get; set; }
        public virtual DbSet<vw_Category> vw_Category { get; set; }
        public virtual DbSet<vw_ProductTop10> vw_ProductTop10 { get; set; }
        public virtual DbSet<vw_Products> vw_Products { get; set; }
        public virtual DbSet<vw_PurchaseOrder> vw_PurchaseOrder { get; set; }
        public virtual DbSet<vw_Wholesaler> vw_Wholesaler { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<vw_SupplierContact> vw_SupplierContact { get; set; }
    
        public virtual int country_delete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("country_delete", idParameter);
        }
    
        public virtual int country_insert(string name, string regionCode)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var regionCodeParameter = regionCode != null ?
                new ObjectParameter("RegionCode", regionCode) :
                new ObjectParameter("RegionCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("country_insert", nameParameter, regionCodeParameter);
        }
    
        public virtual int country_update(Nullable<System.Guid> id, string name, string regionCode)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var regionCodeParameter = regionCode != null ?
                new ObjectParameter("RegionCode", regionCode) :
                new ObjectParameter("RegionCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("country_update", idParameter, nameParameter, regionCodeParameter);
        }
    
        public virtual int harbor_delete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("harbor_delete", idParameter);
        }
    
        public virtual int harbor_insert(string name, Nullable<System.Guid> country_Id, Nullable<byte> status)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var country_IdParameter = country_Id.HasValue ?
                new ObjectParameter("Country_Id", country_Id) :
                new ObjectParameter("Country_Id", typeof(System.Guid));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("harbor_insert", nameParameter, country_IdParameter, statusParameter);
        }
    
        public virtual int harbor_update(Nullable<System.Guid> id, string name, Nullable<System.Guid> country_Id, Nullable<byte> status)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var country_IdParameter = country_Id.HasValue ?
                new ObjectParameter("Country_Id", country_Id) :
                new ObjectParameter("Country_Id", typeof(System.Guid));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("harbor_update", idParameter, nameParameter, country_IdParameter, statusParameter);
        }
    
        public virtual int shipMethod_delete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("shipMethod_delete", idParameter);
        }
    
        public virtual int shipMethod_insert(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("shipMethod_insert", nameParameter);
        }
    
        public virtual int shipMethod_update(Nullable<System.Guid> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("shipMethod_update", idParameter, nameParameter);
        }
    
        public virtual int sp_CreateCategory(string name, Nullable<System.Guid> pId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("PId", pId) :
                new ObjectParameter("PId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateCategory", nameParameter, pIdParameter);
        }
    
        public virtual int sp_CreateProduct(Nullable<System.Guid> supplier_Id, Nullable<System.Guid> category_Id, string name, string description, Nullable<decimal> price, Nullable<int> miniumOrder, Nullable<int> maximumOrder, Nullable<int> qtyInHand, Nullable<byte> status, Nullable<int> views, Nullable<System.DateTime> postDate, string image)
        {
            var supplier_IdParameter = supplier_Id.HasValue ?
                new ObjectParameter("Supplier_Id", supplier_Id) :
                new ObjectParameter("Supplier_Id", typeof(System.Guid));
    
            var category_IdParameter = category_Id.HasValue ?
                new ObjectParameter("Category_Id", category_Id) :
                new ObjectParameter("Category_Id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            var miniumOrderParameter = miniumOrder.HasValue ?
                new ObjectParameter("MiniumOrder", miniumOrder) :
                new ObjectParameter("MiniumOrder", typeof(int));
    
            var maximumOrderParameter = maximumOrder.HasValue ?
                new ObjectParameter("MaximumOrder", maximumOrder) :
                new ObjectParameter("MaximumOrder", typeof(int));
    
            var qtyInHandParameter = qtyInHand.HasValue ?
                new ObjectParameter("QtyInHand", qtyInHand) :
                new ObjectParameter("QtyInHand", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(byte));
    
            var viewsParameter = views.HasValue ?
                new ObjectParameter("Views", views) :
                new ObjectParameter("Views", typeof(int));
    
            var postDateParameter = postDate.HasValue ?
                new ObjectParameter("PostDate", postDate) :
                new ObjectParameter("PostDate", typeof(System.DateTime));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateProduct", supplier_IdParameter, category_IdParameter, nameParameter, descriptionParameter, priceParameter, miniumOrderParameter, maximumOrderParameter, qtyInHandParameter, statusParameter, viewsParameter, postDateParameter, imageParameter);
        }
    
        public virtual int sp_CreateUnitMeasure(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateUnitMeasure", nameParameter);
        }
    
        public virtual int sp_DeleteCategory(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCategory", idParameter);
        }
    
        public virtual int sp_DeleteProduct(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteProduct", idParameter);
        }
    
        public virtual int sp_DeleteUnitMeasure(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteUnitMeasure", idParameter);
        }
    
        public virtual int sp_UpdateCategory(Nullable<System.Guid> id, string name, Nullable<System.Guid> pId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("PId", pId) :
                new ObjectParameter("PId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateCategory", idParameter, nameParameter, pIdParameter);
        }
    
        public virtual int sp_UpdateProduct(Nullable<System.Guid> id, Nullable<System.Guid> supplier_Id, Nullable<System.Guid> category_Id, string name, string description, Nullable<decimal> price, Nullable<int> miniumOrder, Nullable<int> maximumOrder, Nullable<int> qtyInHand, Nullable<byte> status, Nullable<int> views, Nullable<System.DateTime> postDate, string image)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var supplier_IdParameter = supplier_Id.HasValue ?
                new ObjectParameter("Supplier_Id", supplier_Id) :
                new ObjectParameter("Supplier_Id", typeof(System.Guid));
    
            var category_IdParameter = category_Id.HasValue ?
                new ObjectParameter("Category_Id", category_Id) :
                new ObjectParameter("Category_Id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            var miniumOrderParameter = miniumOrder.HasValue ?
                new ObjectParameter("MiniumOrder", miniumOrder) :
                new ObjectParameter("MiniumOrder", typeof(int));
    
            var maximumOrderParameter = maximumOrder.HasValue ?
                new ObjectParameter("MaximumOrder", maximumOrder) :
                new ObjectParameter("MaximumOrder", typeof(int));
    
            var qtyInHandParameter = qtyInHand.HasValue ?
                new ObjectParameter("QtyInHand", qtyInHand) :
                new ObjectParameter("QtyInHand", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(byte));
    
            var viewsParameter = views.HasValue ?
                new ObjectParameter("Views", views) :
                new ObjectParameter("Views", typeof(int));
    
            var postDateParameter = postDate.HasValue ?
                new ObjectParameter("PostDate", postDate) :
                new ObjectParameter("PostDate", typeof(System.DateTime));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateProduct", idParameter, supplier_IdParameter, category_IdParameter, nameParameter, descriptionParameter, priceParameter, miniumOrderParameter, maximumOrderParameter, qtyInHandParameter, statusParameter, viewsParameter, postDateParameter, imageParameter);
        }
    
        public virtual int sp_UpdateUnitMeasure(Nullable<System.Guid> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateUnitMeasure", idParameter, nameParameter);
        }
    
        public virtual int Suppiler_Update(Nullable<System.Guid> id, string name, string description, string address, Nullable<System.Guid> country_Id, string ownership, Nullable<int> employees, string businessType, Nullable<int> establishedYear, Nullable<byte> status, Nullable<decimal> revenue, string email, string logo)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var country_IdParameter = country_Id.HasValue ?
                new ObjectParameter("Country_Id", country_Id) :
                new ObjectParameter("Country_Id", typeof(System.Guid));
    
            var ownershipParameter = ownership != null ?
                new ObjectParameter("Ownership", ownership) :
                new ObjectParameter("Ownership", typeof(string));
    
            var employeesParameter = employees.HasValue ?
                new ObjectParameter("Employees", employees) :
                new ObjectParameter("Employees", typeof(int));
    
            var businessTypeParameter = businessType != null ?
                new ObjectParameter("BusinessType", businessType) :
                new ObjectParameter("BusinessType", typeof(string));
    
            var establishedYearParameter = establishedYear.HasValue ?
                new ObjectParameter("EstablishedYear", establishedYear) :
                new ObjectParameter("EstablishedYear", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(byte));
    
            var revenueParameter = revenue.HasValue ?
                new ObjectParameter("Revenue", revenue) :
                new ObjectParameter("Revenue", typeof(decimal));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var logoParameter = logo != null ?
                new ObjectParameter("Logo", logo) :
                new ObjectParameter("Logo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Suppiler_Update", idParameter, nameParameter, descriptionParameter, addressParameter, country_IdParameter, ownershipParameter, employeesParameter, businessTypeParameter, establishedYearParameter, statusParameter, revenueParameter, emailParameter, logoParameter);
        }
    
        public virtual int Supplier_Delete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Supplier_Delete", idParameter);
        }
    
        public virtual int Supplier_Insert(string name, string description, string address, Nullable<System.Guid> country_Id, string ownership, Nullable<int> employees, string businessType, Nullable<int> establishedYear, Nullable<byte> status, Nullable<decimal> revenue, string email, string logo)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var country_IdParameter = country_Id.HasValue ?
                new ObjectParameter("Country_Id", country_Id) :
                new ObjectParameter("Country_Id", typeof(System.Guid));
    
            var ownershipParameter = ownership != null ?
                new ObjectParameter("Ownership", ownership) :
                new ObjectParameter("Ownership", typeof(string));
    
            var employeesParameter = employees.HasValue ?
                new ObjectParameter("Employees", employees) :
                new ObjectParameter("Employees", typeof(int));
    
            var businessTypeParameter = businessType != null ?
                new ObjectParameter("BusinessType", businessType) :
                new ObjectParameter("BusinessType", typeof(string));
    
            var establishedYearParameter = establishedYear.HasValue ?
                new ObjectParameter("EstablishedYear", establishedYear) :
                new ObjectParameter("EstablishedYear", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(byte));
    
            var revenueParameter = revenue.HasValue ?
                new ObjectParameter("Revenue", revenue) :
                new ObjectParameter("Revenue", typeof(decimal));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var logoParameter = logo != null ?
                new ObjectParameter("Logo", logo) :
                new ObjectParameter("Logo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Supplier_Insert", nameParameter, descriptionParameter, addressParameter, country_IdParameter, ownershipParameter, employeesParameter, businessTypeParameter, establishedYearParameter, statusParameter, revenueParameter, emailParameter, logoParameter);
        }
    }
}
