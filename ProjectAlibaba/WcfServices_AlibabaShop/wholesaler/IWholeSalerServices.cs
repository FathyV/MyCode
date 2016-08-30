using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.wholesaler
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWholeSalerServices" in both code and config file together.
    [ServiceContract]
    public interface IWholeSalerServices
    {
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool sendQuotation(Quotation quotation);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool makeOrder(PurchaseOrder order);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Quotation> viewQuotation(Guid wholeSalerId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Quotation> viewTransaction(Guid wholeSalerId);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool changeInformation(WholeSaler wholesaler);
    }
}
