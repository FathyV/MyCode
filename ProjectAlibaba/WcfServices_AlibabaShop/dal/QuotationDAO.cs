using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    public class QuotationDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<vw_SupplierQuotation> selectQuotationBySupplier(Guid id)
        {
            try
            {
                return ctx.vw_SupplierQuotation.Where(q => q.Supplier_Id == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<vw_SupplierQuotation> selectQuotationByProduct(Guid id)
        {
            try
            {
                return ctx.vw_SupplierQuotation.Where(q=>q.Product_Id==id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Quotation> getAllQuotations()
        {
            try
            {
                return ctx.Quotations.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insertQuotation(Quotation quotation)
        {
            try
            {
                ctx.Quotations.Add(quotation);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Quotation search(Guid id)
        {
            try
            {
                return ctx.Quotations.Single(quotation => quotation.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public vw_SupplierQuotation searchVwQuotation(Guid id)
        {
            try
            {
                return ctx.vw_SupplierQuotation.Single(quotation => quotation.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateQuotation(Guid id, Quotation quotation)
        {
            Quotation updateQuo = search(id);
            if (updateQuo != null)
            {
                updateQuo.Product_Id = quotation.Product_Id;
                updateQuo.Supplier_Id = quotation.Supplier_Id;
                updateQuo.WholeSaler_Id = quotation.WholeSaler_Id;
                updateQuo.UnitMeasure_Id = quotation.UnitMeasure_Id;
                updateQuo.Qty = quotation.Qty;
                updateQuo.Message = quotation.Message;
                updateQuo.FileAttachment = quotation.FileAttachment;
                updateQuo.UnitPrice = quotation.UnitPrice;
                updateQuo.TaxAmount = quotation.TaxAmount;
                updateQuo.SubTotal = quotation.SubTotal;
                updateQuo.Total = quotation.Total;
                updateQuo.RequestDate = quotation.RequestDate;
                updateQuo.Status = quotation.Status;
            }
            ctx.SaveChanges();
            return true;
        }

        public bool checkQuotationId(Guid id)
        {
            Quotation quotation = ctx.Quotations.SingleOrDefault(q => q.Id == id);
            if (quotation != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
