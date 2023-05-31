using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class SkypeDao
    {
        DichvuhoanhaoDbContext db = null;
        public SkypeDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(Skype entity)
        {
            db.Skypes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Skype entity)
        {
            try
            {
                var user = db.Skypes.Find(entity.Id);
                user.SkypeName = entity.SkypeName;
                user.LinkSkype = entity.LinkSkype;
                user.Status = entity.Status;
                user.Image = entity.Image;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Skype> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Skype> model = db.Skypes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.SkypeName.Contains(searchString));
            }

            return model.OrderByDescending(x => x.SkypeName).ToPagedList(page, pageSize);
        }
        public Skype GetById(string userName)
        {
            return db.Skypes.SingleOrDefault(x => x.SkypeName == userName);
        }
        public Skype ViewDetail(int id)
        {
            return db.Skypes.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Skypes.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Skypes.Find(id);
                db.Skypes.Remove(user);
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