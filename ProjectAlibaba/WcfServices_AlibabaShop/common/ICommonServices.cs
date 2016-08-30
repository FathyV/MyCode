using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommonServices" in both code and config file together.
    [ServiceContract]
    public interface ICommonServices
    {
        #region Common Views
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<vw_Category> getVwCategory();

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Category> viewCategory();

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Supplier> viewTopSupplier();

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Product> viewTopProduct();
        #endregion

        #region Common searching engine
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        Product searchProduct(string name);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        Supplier searchSupplier(string name);
        #endregion
    }
}
