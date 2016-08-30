using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.supplier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SupplierServices" in both code and config file together.
    public class SupplierServices : ISupplierServices
    {
        PurchaseOrderDAO poDAO;
        SupplierDAO supplierDAO;
        ProductDAO productDAO;
        QuotationDAO quotationDAO;
        ProductFeedbackDAO pfDAO;
        ContactDAO contactDAO;
        CountryDAO countryDAO;
        OwnershipDAO ownershipDAO;
        
        public SupplierServices()
        {
            poDAO = new PurchaseOrderDAO();
            supplierDAO = new SupplierDAO();
            productDAO = new ProductDAO();
            quotationDAO = new QuotationDAO();
            pfDAO = new ProductFeedbackDAO();
            contactDAO = new ContactDAO();
            countryDAO = new CountryDAO();
            ownershipDAO = new OwnershipDAO();
        }

        bool ISupplierServices.changeInformation(Supplier supplier)
        {
            try
            {
                return supplierDAO.update(supplier.Id, supplier);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        bool ISupplierServices.changeProductInfo(Product product)
        {
            try
            {
                return productDAO.update(product);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "server is offline",
                    errorCode = "2005"
                });
            }
        }

        bool ISupplierServices.confirmOrder(Guid purchaseOrderId)
        {
            try
            {
                PurchaseOrder obj = poDAO.search(purchaseOrderId);
                obj.Status = (byte)1;
                return poDAO.update(obj);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "server is offline",
                    errorCode = "2005"
                });
            }
        }

        bool ISupplierServices.handleQuotation(Quotation quotation)
        {
            try
            {
                return quotationDAO.updateQuotation(quotation.Id, quotation);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "server is offline",
                    errorCode = "2005"
                });
            }
        }

        bool ISupplierServices.newProduct(Product product)
        {
            try
            {
                if (productDAO.search(product.Id) != null)
                {
                    throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                    {
                        message = "Product is existed",
                        errorCode = "101"
                    });
                }
                else
                {
                    return productDAO.insert(product);
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "102"
                });
            }
        }

        bool ISupplierServices.removeProduct(Product product)
        {
            try
            {
                return productDAO.update(product);
            }
            catch (SqlException e)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "server is offline",
                    errorCode = "2005"
                });
            }
        }

        List<vw_Transaction> ISupplierServices.viewMonthlyIncome(Guid supplierId)
        {
            throw new NotImplementedException();
        }

        List<ProductFeedback> ISupplierServices.viewProductFeedback(Guid id)
        {
            try
            {
                List<ProductFeedback> lstResult = new List<ProductFeedback>();

                //Get the quotation for the supplier
                foreach (ProductFeedback item in supplierDAO.getFeedback(id))
                {
                    //if that quotation is send to the specific supplier
                    //save it to the list
                    lstResult.Add(item);
                }
                return lstResult;
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<Quotation> ISupplierServices.viewQuotation(Guid id)
        {
            try
            {
                List<Quotation> lstResult = new List<Quotation>();

                //Get the quotation for the supplier
                foreach (Quotation item in quotationDAO.getAllQuotations())
                {
                    //if that quotation is send to the specific supplier
                    //save it to the list
                    if (item.Supplier_Id == id)
                    {
                        lstResult.Add(item);
                    }
                }

                return lstResult;
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<Product> ISupplierServices.viewTopSellingItem(Guid supplier)
        {
            throw new NotImplementedException();
        }

        List<vw_Transaction> ISupplierServices.viewTransaction(Guid supplierId)
        {
            try
            {
                return poDAO.getSupplierTransaction(supplierId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<vw_Transaction> ISupplierServices.viewYearlyRevenue(Guid supplierId)
        {
            throw new NotImplementedException();
        }

        List<vw_SupplierProducts> ISupplierServices.viewProductList(Supplier supplier)
        {
            try
            {
                return productDAO.selectListBySupplierId(supplier);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        vw_SupplierProducts ISupplierServices.getProductDetails(Guid supplierId)
        {
            try
            {
                return productDAO.searchVwProduct(supplierId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<vw_SupplierOrder> ISupplierServices.getOrderList(Guid productId)
        {
            try
            {
                return poDAO.selectPurchaseOrderList(productId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<vw_SupplierFeedback> ISupplierServices.getFeedbackList(Guid productId)
        {
            try
            {
                return pfDAO.getSupplierFeedback(productId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<vw_SupplierQuotation> ISupplierServices.getQuotationListByProduct(Guid productId)
        {
            try
            {
                return quotationDAO.selectQuotationByProduct(productId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<vw_SupplierQuotation> ISupplierServices.getSupplierQuotation(Guid supplierId)
        {
            try
            {
                return quotationDAO.selectQuotationBySupplier(supplierId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<vw_SupplierOrder> ISupplierServices.getSupplierOrderList(Guid supplierId)
        {
            try
            {
                return poDAO.selectSupplierOrder(supplierId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        bool ISupplierServices.abortOrder(Guid purchaseOrderId)
        {
            try
            {
                PurchaseOrder obj = poDAO.search(purchaseOrderId);
                if (obj != null)
                {
                    if (obj.Status == 0)
                    {
                        poDAO.delete(purchaseOrderId);
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        bool ISupplierServices.finishOrder(Guid purchaseOrderId)
        {
            try
            {
                PurchaseOrder obj = poDAO.search(purchaseOrderId);
                if (obj != null)
                {
                    if (obj.Status == 1)
                    {
                        obj.Status = (byte)2;
                        poDAO.update(obj);
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        vw_SupplierQuotation ISupplierServices.getQuotationById(Guid id)
        {
            try
            {
                return quotationDAO.searchVwQuotation(id);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        Product ISupplierServices.getProductById(Guid id)
        {
            try
            {
                return productDAO.search(id);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        vw_SupplierContact ISupplierServices.getContact(Guid supplierId)
        {
            try
            {
                return contactDAO.getSupplierContact(supplierId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        vw_SupplierInfo ISupplierServices.getSupplierInfo(Guid supplierId)
        {
            try
            {
                return supplierDAO.getSupplierInfo(supplierId);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        bool ISupplierServices.updateContact(vw_SupplierContact vwContact)
        {
            try
            {
                return contactDAO.updateSupplierContact(vwContact);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        bool ISupplierServices.updateSupplierInfo(vw_SupplierInfo vwSupplier)
        {
            try
            {
                return supplierDAO.updateSupplierInfo(vwSupplier);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<Country> ISupplierServices.getCountryList()
        {
            try
            {
                return countryDAO.getAllCountry();
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }

        List<Ownership> ISupplierServices.getOwnershipList()
        {
            try
            {
                return ownershipDAO.selectAll();
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    errorCode = "A60001",
                    message = "Unexpected error occured!"
                });
            }
        }
    }
}
