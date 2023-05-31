using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class FeedBackDao
    {
        DichvuhoanhaoDbContext db = null;
        public FeedBackDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public IEnumerable<Feedback> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Feedback> model = db.Feedbacks;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.CreateDate.ToString().Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
    }
}