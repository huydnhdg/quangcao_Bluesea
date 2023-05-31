using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class FeedbackDao
    {
        DichvuhoanhaoDbContext db = null;
        public FeedbackDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Service> get_Service_in_Lienhe()
        {
            return db.Services.Where(x => x.Status == true).ToList();
        }
        public long Insert(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.Id;
        }
    }
}