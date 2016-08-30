using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    public class WholeSalerDao
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();
        public List<WholeSaler> getAllWholeSaler()
        {
            try
            {
                return ctx.WholeSalers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public WholeSaler search(Guid id)
        {
            try
            {
                return ctx.WholeSalers.Single(cat => cat.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public WholeSaler search(string name)
        {
            try
            {
                return ctx.WholeSalers.Single(wholesaler => wholesaler.Name == name);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool insert(WholeSaler who)
        {
            try
            {
                ctx.WholeSalers.Add(who);
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
                WholeSaler who = search(id);
                if (who != null)
                {
                    ctx.WholeSalers.Remove(who);
                }
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public bool update(Guid id, WholeSaler who)
        {
            try
            {
                WholeSaler updateWHO = search(id);
                if (updateWHO != null)
                {
                    updateWHO.Name = who.Name;
                    updateWHO.Ownership_Id = who.Ownership_Id;
                    updateWHO.Address = who.Address;
                    updateWHO.Description = who.Description;
                    updateWHO.Country_Id = who.Country_Id;
                    updateWHO.RegisterDate = who.RegisterDate;
                    updateWHO.Email = who.Email;
                    updateWHO.Status = who.Status;

                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
