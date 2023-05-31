using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class VideoDao
    {
        DichvuhoanhaoDbContext db = null;
        public VideoDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public Video get_Video_in_Home()
        {
            return db.Videos.FirstOrDefault();
        }
    }
}