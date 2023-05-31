using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class CustomerDao
    {
        DichvuhoanhaoDbContext db = null;
        public CustomerDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Customer entity)
        {
            try
            {
                var user = db.Customers.Find(entity.Id);
                user.FullName = entity.FullName;
                user.WebsiteAddress = entity.WebsiteAddress;
                user.Status = entity.Status;
                user.Image = entity.Image;
                user.Alt = entity.Alt;
                user.Description = entity.Description;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Customer> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Customer> model = db.Customers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.FullName.Contains(searchString));
            }

            return model.OrderByDescending(x => x.FullName).ToPagedList(page, pageSize);
        }
        public Customer GetById(string userName)
        {
            return db.Customers.SingleOrDefault(x => x.FullName == userName);
        }
        public Customer ViewDetail(int id)
        {
            return db.Customers.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Customers.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Customers.Find(id);
                db.Customers.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}