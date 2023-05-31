using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class PartnerDao
    {
        DichvuhoanhaoDbContext db = null;
        public PartnerDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Partner> get_Partner_in_Home()
        {
            return db.Partners.Where(x => x.Status==true).ToList();
        }
    }
}