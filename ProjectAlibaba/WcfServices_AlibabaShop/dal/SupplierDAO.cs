using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    public class SupplierDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public vw_SupplierInfo getSupplierInfo(Guid id)
        {
            try
            {
                return ctx.vw_SupplierInfo.Single(s=>s.Id==id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateSupplierInfo(vw_SupplierInfo vwSupplier)
        {
            Supplier updateSup = search(vwSupplier.Id);
            if (updateSup != null)
            {
                updateSup.Name = vwSupplier.Supplier_Name;
                updateSup.Description = vwSupplier.Description;
                updateSup.Address = vwSupplier.Address;
                updateSup.Country_Id = vwSupplier.Country_Id;
                updateSup.Ownership_Id = vwSupplier.Ownership_Id;
                updateSup.Employees = vwSupplier.Employees;
                updateSup.Status = vwSupplier.Status;
                updateSup.Revenue = vwSupplier.Revenue;
                updateSup.Email = vwSupplier.Email;
                updateSup.Logo = vwSupplier.Logo;
            }
            ctx.SaveChanges();
            return true;
        }

        public List<Supplier> getAllSuppliers()
        {
            try
            {
                return ctx.Suppliers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductFeedback> getFeedback(Guid id)
        {
            try
            {
                Supplier sup = search(id);
                List<ProductFeedback> lstResult = new List<ProductFeedback>();
                foreach (Product productItem in ctx.Products.Where(p => p.Supplier_Id == id))
                {
                    foreach (ProductFeedback feedbackitem in ctx.ProductFeedbacks.Where(pfb=>pfb.Product_Id==productItem.Id))
                    {
                        lstResult.Add(feedbackitem);
                    }
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(Supplier sup)
        {
            try
            {
                ctx.Suppliers.Add(sup);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Supplier search(Guid id)
        {
            try
            {
                return ctx.Suppliers.Single(sup => sup.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Supplier search(string name)
        {
            try
            {
                return ctx.Suppliers.Single(sup => sup.Name == name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Guid id, Supplier sup)
        {
            try
            {
                Supplier updateSup = search(id);
                if (updateSup != null)
                {
                    updateSup.Name = sup.Name;
                    updateSup.Description = sup.Description;
                    updateSup.Address = sup.Address;
                    updateSup.Country_Id = sup.Country_Id;
                    updateSup.Ownership_Id = sup.Ownership_Id;
                    updateSup.Employees = sup.Employees;
                    updateSup.Status = sup.Status;
                    updateSup.Revenue = sup.Revenue;
                    updateSup.Email = sup.Email;
                    updateSup.Logo = sup.Logo;
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
                Supplier sup = search(id);
                if (sup != null)
                {
                    ctx.Suppliers.Remove(sup);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkSupplierId(Guid id)
        {
            try
            {
                Supplier sup = ctx.Suppliers.SingleOrDefault(s => s.Id == id);
                if (sup != null)
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
