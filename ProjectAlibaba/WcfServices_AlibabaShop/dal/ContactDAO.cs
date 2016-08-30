using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServices_AlibabaShop.dal
{
    public class ContactDAO
    {
        AlibabaShopEntities ctx = new AlibabaShopEntities();

        public vw_SupplierContact getSupplierContact(Guid supplierId)
        {
            try
            {
                return ctx.vw_SupplierContact.Single(c => c.Supplier_Id == supplierId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateSupplierContact(vw_SupplierContact vwContact)
        {
            try
            {
                if (isEmailExisted(vwContact.Email)) return false;
                Contact c = new Contact()
                {
                    Name = vwContact.Name,
                    Address = vwContact.Address,
                    Email = vwContact.Email,
                    Phone = vwContact.Phone
                };
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Contact> selectAll()
        {
            try
            {
                return ctx.Contacts.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(Contact contact)
        {
            try
            {
                ctx.Contacts.Add(contact);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contact selectBySupplierId(Guid? id)
        {
            try
            {
                return ctx.Contacts.Single(c => c.Supplier_Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool isEmailExisted(string email)
        {
            try
            {
                Contact contact = ctx.Contacts.Single(c => c.Email == email);
                return (contact != null) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool update(Contact contact, int role)
        {
            try
            {
                Contact obj;
                if (role == 0)
                    obj = selectBySupplierId(contact.Supplier_Id);
                else
                    obj = selectByWholeSalerId(contact.WholeSaler_Id);

                if (obj != null)
                {
                    if (isEmailExisted(obj.Email)) return false;

                    obj.Email = contact.Email;
                    obj.Name = contact.Name;
                    obj.Phone = contact.Phone;
                    obj.Address = contact.Address;
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

        public Contact selectByWholeSalerId(Guid? id)
        {
            try
            {
                return ctx.Contacts.Single(c => c.WholeSaler_Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool delete(Guid id, int role)
        {
            try
            {
                Contact obj;
                if (role == 0)
                    obj = selectBySupplierId(id);
                else
                    obj = selectByWholeSalerId(id);

                if (obj != null)
                {
                    ctx.Contacts.Remove(obj);
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
