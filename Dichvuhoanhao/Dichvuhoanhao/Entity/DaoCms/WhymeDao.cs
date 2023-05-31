using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class WhymeDao
    {
        DichvuhoanhaoDbContext db = null;
        public WhymeDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(Whyme entity)
        {
            db.Whymes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Whyme entity)
        {
            try
            {
                var user = db.Whymes.Find(entity.Id);
                user.Title = entity.Title;
                user.Icon = entity.Icon;
                user.Description = entity.Description;
                user.Image = entity.Image;
                user.Alt = entity.Alt;
                user.Status = entity.Status;
                user.Sort = entity.Sort;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                var item = db.Whymes.Find(Id);
                db.Whymes.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Whyme> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Whyme> model = db.Whymes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Title).ToPagedList(page, pageSize);
        }
        public Whyme ViewDetail(long id)
        {
            return db.Whymes.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var item = db.Whymes.Find(id);
            item.Status = !item.Status;
            db.SaveChanges();
            return item.Status;
        }
    }
}