using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class SliderDao
    {
        DichvuhoanhaoDbContext db = null;
        public SliderDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(Slider entity)
        {
            db.Sliders.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Slider entity)
        {
            try
            {
                var user = db.Sliders.Find(entity.Id);
                user.Image = entity.Image;
                user.Link = entity.Link;
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
        public IEnumerable<Slider> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slider> model = db.Sliders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Image.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Image).ToPagedList(page, pageSize);
        }
        //public Slider GetById(string userName)
        //{
        //    return db.Sliders.SingleOrDefault(x => x.SkypeName == userName);
        //}
        public Slider ViewDetail(int id)
        {
            return db.Sliders.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Sliders.Find(id);
                db.Sliders.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}