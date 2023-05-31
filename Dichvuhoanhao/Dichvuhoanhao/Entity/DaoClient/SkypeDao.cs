using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class SkypeDao
    {
        DichvuhoanhaoDbContext db = null;
        public SkypeDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Skype> get_Skype_in_Home()
        {
            return db.Skypes.Where(x => x.Status==true).ToList();
        }
    }
}