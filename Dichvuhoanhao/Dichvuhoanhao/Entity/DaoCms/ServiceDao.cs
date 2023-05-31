using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class ServiceDao
    {
        DichvuhoanhaoDbContext db = null;
        public ServiceDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Service> get_Service_in_Home()
        {
            return db.Services.Where(x => x.Status == true).ToList();
        }
        public long Insert(Service entity)
        {
            db.Services.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Service entity)
        {
            try
            {
                var user = db.Services.Find(entity.Id);
                user.Name = entity.Name;
                user.Icon = entity.Icon;
                user.Description = entity.Description;
                user.Text = entity.Text;
                user.BigImage = entity.BigImage;
                user.Alt = entity.Alt;
                user.Url = entity.Url;
                user.MetaDescription = entity.MetaDescription;
                user.MetaTitle = entity.MetaTitle;
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
                var item = db.Services.Find(Id);
                db.Services.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Service> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Service> model = db.Services;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
        public Service ViewDetail(long id)
        {
            return db.Services.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var item = db.Services.Find(id);
            item.Status = !item.Status;
            db.SaveChanges();
            return item.Status;
        }
    }
}