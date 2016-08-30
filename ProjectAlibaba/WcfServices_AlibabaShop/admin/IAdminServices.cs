using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.admin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminServices" in both code and config file together.
    [ServiceContract]
    public interface IAdminServices
    {
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        WholeSaler searchWholeSaler(string name);


        #region Ban/Unlock for Supplier/WholeSaler
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool banSupplier(Guid id);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool banWholeSaler(Guid id);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool unlockSupplier(Guid id);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool unlockWholeSaler(Guid id);
        #endregion

        #region Manage Category
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool newCategory(Category category);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool changeCategoryName(Category category);

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        bool removeCategory(Category category);
        #endregion

        #region Admin views
        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<Supplier> viewSuppliers();

        [OperationContract]
        [FaultContract(typeof(AlibabaShopFaultedException))]
        List<WholeSaler> viewWholeSaler();
        #endregion        
    }
}
