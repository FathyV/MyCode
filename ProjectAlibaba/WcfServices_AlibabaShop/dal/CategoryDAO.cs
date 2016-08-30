using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    public class CategoryDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<vw_Category> getVwCategory()
        {
            try
            {
                return ctx.vw_Category.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Category> getAllCategory()
        {
            try
            {
                return ctx.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(Category cat)
        {
            try
            {                
                ctx.Categories.Add(cat);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(Guid id)
        {
            try
            {
                Category cat = search(id);
                if (cat != null)
                {
                    ctx.Categories.Remove(cat);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Guid id,Category cat)
        {
            try
            {
                Category updateCat = search(id);
                if (updateCat != null)
                {
                    updateCat.Name = cat.Name;
                    updateCat.PId = cat.PId;
                }
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Category search(Guid id)
        {
            try
            {
                return ctx.Categories.Single(cat => cat.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category search(string name)
        {
            try
            {
                return ctx.Categories.Single(cat => cat.Name== name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
