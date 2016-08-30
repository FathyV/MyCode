using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    class ProductDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<vw_SupplierProducts> selectListBySupplierId(Supplier supplier)
        {
            try
            {
                return ctx.vw_SupplierProducts.Where(p=>p.Supplier_Id==supplier.Id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                

        public vw_SupplierProducts searchVwProduct(Guid id)
        {
            try
            {
                return ctx.vw_SupplierProducts.Single(p => p.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
                

        public List<Product> getAllProducts()
        {
            try
            {
                return ctx.Products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(Product pdt)
        {
            try
            {
                ctx.Products.Add(pdt);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Product pdt)
        {
            try
            {
                Product p = search(pdt.Id);
                if (p != null)
                {
                    p.Supplier_Id = pdt.Supplier_Id;
                    p.Category_Id = pdt.Category_Id;
                    p.Name = pdt.Name;
                    p.Description = pdt.Description;
                    p.Price = pdt.Price;
                    p.MinimumOrder = pdt.MinimumOrder;
                    p.QtyInHand = pdt.QtyInHand;
                    p.Status = pdt.Status;
                    p.Views = pdt.Views;
                    p.PostDate = pdt.PostDate;
                    p.Image = pdt.Image;
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
                Product p = search(id);
                if (p != null)
                {
                    ctx.Products.Remove(p);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product search(Guid id)
        {
            try
            {
                return ctx.Products.Single(p => p.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product search(string name)
        {
            try
            {
                return ctx.Products.Single(p => p.Name == name);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
