using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class WhymeDao
    {
        DichvuhoanhaoDbContext db = null;
        public WhymeDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Whyme> get_Whyme_in_Home()
        {
            return db.Whymes.Where(x=>x.Status==true).ToList();
        }
    }
}