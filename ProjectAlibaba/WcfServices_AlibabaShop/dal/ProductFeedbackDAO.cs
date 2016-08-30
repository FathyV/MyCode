using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    public class ProductFeedbackDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<vw_SupplierFeedback> getSupplierFeedback(Guid productId)
        {
            try
            {
                return ctx.vw_SupplierFeedback.Where(feedback => feedback.Product_Id == productId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductFeedback> getAllFeedbacks()
        {
            try
            {
                return ctx.ProductFeedbacks.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(ProductFeedback feedback)
        {
            try
            {
                ctx.ProductFeedbacks.Add(feedback);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductFeedback search(Guid id)
        {
            try
            {
                return ctx.ProductFeedbacks.Single(feedback => feedback.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Guid id, ProductFeedback feedback)
        {
            try
            {
                ProductFeedback updateFeedback = search(id);
                if (updateFeedback != null)
                {
                    updateFeedback.Product_Id = feedback.Product_Id;
                    updateFeedback.WholeSaler_Id = feedback.WholeSaler_Id;
                    updateFeedback.Feedback = feedback.Feedback;
                    updateFeedback.PostTime = feedback.PostTime;
                    updateFeedback.Status = feedback.Status;
                }
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
                ProductFeedback feedback = search(id);
                if (feedback != null)
                {
                    ctx.ProductFeedbacks.Remove(feedback);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkProductFeedback(Guid id)
        {
            try
            {
                ProductFeedback feedback = ctx.ProductFeedbacks.SingleOrDefault(f => f.Id == id);
                if (feedback != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
