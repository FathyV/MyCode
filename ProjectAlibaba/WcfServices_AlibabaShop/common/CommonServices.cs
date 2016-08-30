using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommonServices" in both code and config file together.
    public class CommonServices : ICommonServices
    {
        CategoryDAO catDAO;
        ProductDAO productDAO;
        SupplierDAO supplierDAO;

        public CommonServices()
        {
            catDAO = new CategoryDAO();
            productDAO = new ProductDAO();
            supplierDAO = new SupplierDAO();
        }

        List<vw_Category> ICommonServices.getVwCategory()
        {
            try
            {
                return catDAO.getVwCategory();
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A10001",
                    message = "Unexpected error occured!"
                });
            }
        }

        Product ICommonServices.searchProduct(string name)
        {
            try
            {
                return productDAO.search(name);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A30001",
                    message = "Unable to get the request product!"
                });
            }
        }

        Supplier ICommonServices.searchSupplier(string name)
        {
            try
            {
                return supplierDAO.search(name);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A40001",
                    message = "Unknown Supplier!"
                });
            }
        }

        List<Category> ICommonServices.viewCategory()
        {
            try
            {
                return catDAO.getAllCategory();
            }
            catch(SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException() {
                    errorCode="A10001",message="Unexpected error occured!"
                });
            }
        }

        List<Product> ICommonServices.viewTopProduct()
        {
            throw new NotImplementedException();
        }

        List<Supplier> ICommonServices.viewTopSupplier()
        {
            throw new NotImplementedException();
        }
    }
}
