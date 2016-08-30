using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WcfServices_AlibabaShop.dal
{
    public class OwnershipDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<Ownership> selectAll()
        {
            try
            {
                return ctx.Ownerships.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Ownership select(Guid id)
        {
            try
            {
                return ctx.Ownerships.Single(ownership => ownership.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ownership select(string name)
        {
            try
            {
                return ctx.Ownerships.Single(ownership => ownership.Name == name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(Ownership own)
        {
            try
            {
                ctx.Ownerships.Add(own);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Ownership own)
        {
            try
            {
                Ownership updateOwnership = select(own.Id);
                if (updateOwnership != null)
                {
                    updateOwnership.Name = own.Name;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
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
                Ownership deleteOwnership = select(id);
                if (deleteOwnership != null)
                {
                    ctx.Ownerships.Remove(deleteOwnership);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
