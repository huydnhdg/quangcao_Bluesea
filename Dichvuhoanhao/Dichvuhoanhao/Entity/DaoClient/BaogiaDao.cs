using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class BaogiaDao
    {
        DichvuhoanhaoDbContext db = null;
        public BaogiaDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public Quote get_Baogia(long id)
        {
            return db.Quotes.SingleOrDefault(x => x.Service == id);
        }
    }
}