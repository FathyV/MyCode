using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    class AdministratorDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<Administrator> getAllAdmins()
        {
            try
            {
                return ctx.Administrators.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(Administrator a)
        {
            try
            {
                ctx.Administrators.Add(a);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Administrator a)
        {
            try
            {
                Administrator ad = search(a.Id);
                if (ad != null)
                {
                    ad.Name = a.Name;
                    ad.Address = a.Address;
                    ad.Gender = a.Gender;
                    ad.BirthDate = a.BirthDate;
                    ad.Email = a.Email;
                    ad.PhoneNumber = a.PhoneNumber;
                    ad.Avatar = a.Avatar;
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
                Administrator ad = search(id);
                if (ad != null)
                {
                    ctx.Administrators.Remove(ad);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Administrator search(Guid id)
        {
            try
            {
                return ctx.Administrators.Single(a => a.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
