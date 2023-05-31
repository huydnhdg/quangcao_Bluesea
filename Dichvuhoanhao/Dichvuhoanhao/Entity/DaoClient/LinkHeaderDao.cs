using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class LinkHeaderDao
    {
        DichvuhoanhaoDbContext db = null;
        public LinkHeaderDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public LinkHeader get_LinkHeader(string name)
        {
            return db.LinkHeaders.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}