using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class ServiceDao
    {
        DichvuhoanhaoDbContext db = null;
        public ServiceDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Service> get_Service_in_Home()
        {
            return db.Services.Where(x => x.Status == true).ToList();
        }
        public Service get_Service_ById(long id)
        {
            return db.Services.FirstOrDefault(x => x.Id == id);
        }
    }
}