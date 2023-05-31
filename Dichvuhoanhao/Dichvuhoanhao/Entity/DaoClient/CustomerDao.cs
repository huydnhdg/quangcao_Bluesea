using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class CustomerDao
    {
        DichvuhoanhaoDbContext db = null;
        public CustomerDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Customer> get_Customer_in_Home()
        {
            return db.Customers.Where(x => x.Status==true).ToList();
        }
    }
}