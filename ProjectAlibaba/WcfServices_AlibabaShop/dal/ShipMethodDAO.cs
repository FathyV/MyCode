using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServices_AlibabaShop.dal;
namespace WcfServices_AlibabaShop.dal
{
    public class ShipMethodDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public ShipMethodDAO()
        {
            ctx = new AlibabaShopEntities();
        }

        public List<ShipMethod> getAllShipMethod()
        {
            try
            {
                return ctx.ShipMethods.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public ShipMethod search(Guid id)
        {
            try
            {
                return ctx.ShipMethods.Single(e => e.Id == id);
            }catch(Exception ex)
            {
                return null;
            }
        }

        public bool insert(ShipMethod ship)
        {
            try
            {
                ctx.ShipMethods.Add(ship);
                ctx.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(Guid id)
        {
            try
            {
                ShipMethod ship = search(id);
                if (ship != null)
                {
                    ctx.ShipMethods.Remove(ship);
                }
                ctx.SaveChanges();
                return true;
                
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Guid id,ShipMethod ship)
        {
            try
            {
                ShipMethod updateShipMethod = search(id);
                if(updateShipMethod != null)
                {
                    updateShipMethod.Name = ship.Name;
                }
                ctx.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
