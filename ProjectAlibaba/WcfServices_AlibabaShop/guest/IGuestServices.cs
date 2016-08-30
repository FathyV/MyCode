using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.guest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGuestServices" in both code and config file together.
    [ServiceContract]
    public interface IGuestServices
    {
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool WholeSalerRegister(WholeSaler wholesaler);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool SupplierRegister(Supplier supplier);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool Login(string userName, string password);
    }
}
