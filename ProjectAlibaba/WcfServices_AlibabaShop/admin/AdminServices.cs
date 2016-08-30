using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.admin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminServices" in both code and config file together.
    public class AdminServices : IAdminServices
    {
        SupplierDAO supplierDAO;
        WholeSalerDao wholesalerDAO;
        CategoryDAO catDAO;
        public AdminServices()
        {
            supplierDAO = new SupplierDAO();
            wholesalerDAO = new WholeSalerDao();
            catDAO = new CategoryDAO();
        }

        bool IAdminServices.banSupplier(Guid id)
        {
            try
            {
                Supplier sup = supplierDAO.search(id);
                sup.Status = 2;
                return supplierDAO.update(sup.Id,sup);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }

        bool IAdminServices.banWholeSaler(Guid id)
        {
            try
            {
                WholeSaler wholeSaler= wholesalerDAO.search(id);
                wholeSaler.Status = 2;
                return wholesalerDAO.update(wholeSaler.Id, wholeSaler);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }

        bool IAdminServices.changeCategoryName(Category category)
        {
            try
            {
                return catDAO.update(category.Id, category);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }

        bool IAdminServices.newCategory(Category category)
        {
            try
            {
                return catDAO.insert(category);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }

        bool IAdminServices.removeCategory(Category category)
        {
            try
            {
                return catDAO.update(category.Id, category);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }

        WholeSaler IAdminServices.searchWholeSaler(string name)
        {
            try
            {
                return wholesalerDAO.search(name);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                { message = "ID is Unkown",
                    errorCode = "10003" });
            }
        }

        bool IAdminServices.unlockSupplier(Guid id)
        {
            try
            {
                Supplier sup = supplierDAO.search(id);
                sup.Status = 2;
                return supplierDAO.update(sup.Id, sup);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }

        bool IAdminServices.unlockWholeSaler(Guid id)
        {
            try
            {
                WholeSaler wholeSaler = wholesalerDAO.search(id);
                wholeSaler.Status = 2;
                return wholesalerDAO.update(wholeSaler.Id, wholeSaler);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }

        List<Supplier> IAdminServices.viewSuppliers()
        {
            try
            {
                return supplierDAO.getAllSuppliers();
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }

        List<WholeSaler> IAdminServices.viewWholeSaler()
        {
            try
            {
                return wholesalerDAO.getAllWholeSaler();
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114 "
                });
            }
        }
    }
}
