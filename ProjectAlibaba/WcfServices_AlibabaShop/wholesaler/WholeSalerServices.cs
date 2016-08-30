using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;

namespace WcfServices_AlibabaShop.wholesaler
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WholeSalerServices" in both code and config file together.
    public class WholeSalerServices : IWholeSalerServices
    {
        WholeSalerDao wholesalerDAO;
        PurchaseOrderDAO poDAO;
        QuotationDAO quotationDAO;

        public WholeSalerServices()
        {
            wholesalerDAO = new WholeSalerDao();
            poDAO = new PurchaseOrderDAO();
            quotationDAO = new QuotationDAO();
        }

        bool IWholeSalerServices.changeInformation(WholeSaler wholesaler)
        {
            try
            {
                return wholesalerDAO.update(wholesaler.Id, wholesaler);
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "ID is Unkown",
                    errorCode = "10003"
                });
            }
        }

        bool IWholeSalerServices.makeOrder(PurchaseOrder order)
        {
            try
            {
                if (poDAO.search(order.Id) != null)
                {
                    throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException
                    {
                        message = "PurchaseOrder is existed",
                        errorCode = "101"
                    });
                }
                else
                {
                    return poDAO.insert(order);
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

        bool IWholeSalerServices.sendQuotation(Quotation quotation)
        {
            try
            {
                if (quotationDAO.checkQuotationId(quotation.Id))
                {
                    throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                    {
                        message = "Id is existed",
                        errorCode = "113"
                    });
                }
                else
                {
                    return quotationDAO.insertQuotation(quotation);
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException<AlibabaShopFaultedException>(new AlibabaShopFaultedException()
                {
                    message = "Unknown",
                    errorCode = "114"
                });
            }
        }

        List<Quotation> IWholeSalerServices.viewQuotation(Guid wholeSalerId)
        {
            throw new NotImplementedException();
        }

        List<Quotation> IWholeSalerServices.viewTransaction(Guid wholeSalerId)
        {
            throw new NotImplementedException();
        }
    }
}
