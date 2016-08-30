using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices_AlibabaShop.dal;
using WcfServices_AlibabaShop.exception;
using System.Data.SqlClient;

namespace WcfServices_AlibabaShop.guest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GuestServices" in both code and config file together.
    public class GuestServices : IGuestServices
    {
        WholeSalerDao wholesalerDAO;
        SupplierDAO supplierDAO;

        public GuestServices()
        {
            wholesalerDAO = new WholeSalerDao();
            supplierDAO = new SupplierDAO();
        }

        bool IGuestServices.Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        bool IGuestServices.SupplierRegister(Supplier supplier)
        {
            try
            {
                return supplierDAO.insert(supplier);
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

        bool IGuestServices.WholeSalerRegister(WholeSaler wholesaler)
        {
            try
            {
                return wholesalerDAO.insert(wholesaler);
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
    }
}
