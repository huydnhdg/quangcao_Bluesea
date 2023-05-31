using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class VideoDao
    {
        DichvuhoanhaoDbContext db = null;
        public VideoDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public bool Update(Video entity)
        {
            try
            {
                var user = db.Videos.Find(entity.Id);
                user.Icon = entity.Icon;
                user.Title = entity.Title;
                user.LinkFile = entity.LinkFile;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Video> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Video> model = db.Videos;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Title).ToPagedList(page, pageSize);
        }
        public Video ViewDetail(int id)
        {
            return db.Videos.Find(id);
        }
    }
}