using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.supplier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISupplierServices" in both code and config file together.
    [ServiceContract]
    public interface ISupplierServices
    {
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Country> getCountryList();

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Ownership> getOwnershipList();

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        vw_SupplierContact getContact(Guid supplierId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        vw_SupplierInfo getSupplierInfo(Guid supplierId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool updateContact(vw_SupplierContact vwContact);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool updateSupplierInfo(vw_SupplierInfo vwSupplier);


        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        Product getProductById(Guid id);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        vw_SupplierQuotation getQuotationById(Guid id);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_SupplierQuotation> getSupplierQuotation(Guid supplierId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_SupplierQuotation> getQuotationListByProduct(Guid productId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_SupplierFeedback> getFeedbackList(Guid productId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_SupplierOrder> getSupplierOrderList(Guid supplierId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_SupplierOrder> getOrderList(Guid productId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_SupplierProducts> viewProductList(Supplier supplier);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        vw_SupplierProducts getProductDetails(Guid supplierId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool changeInformation(Supplier supplier);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Quotation> viewQuotation(Guid id);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<ProductFeedback> viewProductFeedback(Guid id);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Product> viewTopSellingItem(Guid supplier);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool handleQuotation(Quotation quotation);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool newProduct(Product product);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool changeProductInfo(Product product);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool removeProduct(Product product);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool confirmOrder(Guid purchaseOrderId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool abortOrder(Guid purchaseOrderId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool finishOrder(Guid purchaseOrderId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_Transaction> viewTransaction(Guid supplierId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_Transaction> viewMonthlyIncome(Guid supplierId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_Transaction> viewYearlyRevenue(Guid supplierId);        


    }
}
