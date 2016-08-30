using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    public class UnitMeasureDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public List<UnitMeasure> getAllUnitMeasures()
        {
            return ctx.UnitMeasures.ToList();
        }

        public bool insert(UnitMeasure unit)
        {
            try
            {
                ctx.UnitMeasures.Add(unit);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public UnitMeasure search(Guid id)
        {
            return ctx.UnitMeasures.Single(unit => unit.Id == id); 
        }

        public bool update(Guid id, UnitMeasure unit)
        {
            UnitMeasure updateUnit = search(id);
            if (updateUnit != null)
            {
                updateUnit.Name = unit.Name;
            }
            ctx.SaveChanges();
            return true;
        }

        public bool delete(Guid id)
        {
            UnitMeasure unit = search(id);
            if (unit != null)
            {
                ctx.UnitMeasures.Remove(unit);
            }
            ctx.SaveChanges();
            return true;
        }

        public bool checkUnitMeasureId(Guid id)
        {
            UnitMeasure unit = ctx.UnitMeasures.SingleOrDefault(u => u.Id == id);
            if (unit != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
