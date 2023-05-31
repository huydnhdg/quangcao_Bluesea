using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class SliderDao
    {
        DichvuhoanhaoDbContext db = null;
        public SliderDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Slider> get_Slider_in_Home()
        {
            return db.Sliders.OrderByDescending(a => a.Id).ToList();
        }
    }
}