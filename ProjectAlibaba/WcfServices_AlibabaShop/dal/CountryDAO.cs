using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServices_AlibabaShop.dal;
namespace WcfServices_AlibabaShop.dal
{
    public class CountryDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public CountryDAO()
        {
            ctx = new AlibabaShopEntities();
        }

       

        public List<Country> getAllCountry()
        {
            try
            {
                return ctx.Countries.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Country search(Guid id)
        {
            try
            {
                return ctx.Countries.Single(cat => cat.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool insert(Country con)
        {
            try
            {
                ctx.Countries.Add(con);
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
                Country con = search(id);
                if (con != null)
                {
                    ctx.Countries.Remove(con);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool update(Guid id, Country con)
        {
            try
            {
                Country updateCountry = search(id);
                if (updateCountry != null)
                {
                    updateCountry.Name = con.Name;
                    updateCountry.RegionCode = con.RegionCode;
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
