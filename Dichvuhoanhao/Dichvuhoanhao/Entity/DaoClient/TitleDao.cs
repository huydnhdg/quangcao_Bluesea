using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class TitleDao
    {
        DichvuhoanhaoDbContext db = null;
        public TitleDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public Title getTitle()
        {
            return db.Titles.FirstOrDefault();
        }
    }
}