using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    class HarborDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<Harbor> getAllHarbor()
        {
            try
            {
                return ctx.Harbors.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(Harbor h)
        {
            try
            {
                ctx.Harbors.Add(h);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Harbor h)
        {
            try
            {
                Harbor harbor = search(h.Id);
                if (harbor != null)
                {
                    harbor.Country_Id = h.Country_Id;
                    harbor.Status = h.Status;
                    harbor.Name = h.Name;
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
                Harbor p = search(id);
                if (p != null)
                {
                    ctx.Harbors.Remove(p);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Harbor search(Guid id)
        {
            try
            {
                return ctx.Harbors.Single(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
