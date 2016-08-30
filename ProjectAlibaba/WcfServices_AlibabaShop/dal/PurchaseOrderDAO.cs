using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    class PurchaseOrderDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<vw_SupplierOrder> selectSupplierOrder(Guid supplierId)
        {
            try
            {
                return ctx.vw_SupplierOrder.Where(order => order.Suplier_Id == supplierId).ToList();
                //return ctx.vw_Transaction.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<vw_SupplierOrder> selectPurchaseOrderList(Guid productId)
        {
            try
            {
                return ctx.vw_SupplierOrder.Where(order => order.Product_Id == productId).ToList();
                //return ctx.vw_Transaction.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Methods to get transaction for the supplier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<vw_Transaction> getSupplierTransaction(Guid id)
        {
            try
            {
                return ctx.vw_Transaction.Where(tran => tran.Suplier_Id == id).ToList();
                //return ctx.vw_Transaction.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PurchaseOrder> getAll()
        {
            try
            {
                return ctx.PurchaseOrders.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(PurchaseOrder po)
        {
            try
            {
                ctx.PurchaseOrders.Add(po);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(PurchaseOrder po)
        {
            try
            {
                PurchaseOrder p = search(po.Id);
                if (p != null)
                {
                    p.Suplier_Id = po.Suplier_Id;
                    p.Product_Id = po.Product_Id;
                    p.WholeSaler_Id = po.WholeSaler_Id;
                    p.ShipMethod_Id = po.ShipMethod_Id;
                    p.Qty = po.Qty;
                    p.UnitMeasure_Id = po.UnitMeasure_Id;
                    p.TotalPaid = po.TotalPaid;
                    p.OrderDate = po.OrderDate;
                    p.ArrivedDate = po.ArrivedDate;
                    p.Status = po.Status;
                }
                else { return false; }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(Guid id)
        {
            try
            {
                PurchaseOrder p = search(id);
                if (p != null)
                {
                    ctx.PurchaseOrders.Remove(p);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PurchaseOrder search(Guid id)
        {
            try
            {
                return ctx.PurchaseOrders.Single(p => p.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
