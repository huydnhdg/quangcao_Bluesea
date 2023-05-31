using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class FuntionDao
    {
        DichvuhoanhaoDbContext db = null;
        public FuntionDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(Function entity)
        {
            db.Functions.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Function entity)
        {
            try
            {
                var user = db.Functions.Find(entity.Id);
                user.Title = entity.Title;
                user.Icon = entity.Icon;
                user.LinkDetail = entity.LinkDetail;
                user.Alt = entity.Alt;
                user.Service = entity.Service;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public bool Delete(int Id)
        {
            try
            {
                var item = db.Functions.Find(Id);
                db.Functions.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Function> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Function> model = db.Functions;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Service.ToString().Contains(searchString));
            }
            return model.OrderByDescending(x => x.Title).ToPagedList(page, pageSize);
        }
        public Function ViewDetail(long id)
        {
            return db.Functions.Find(id);
        }
    }
}