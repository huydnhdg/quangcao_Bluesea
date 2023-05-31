using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class ItemServiceDao
    {
        DichvuhoanhaoDbContext db = null;
        public ItemServiceDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public ItemService GetById(string title)
        {
            return db.ItemServices.SingleOrDefault(x => x.Title == title);
        }
        public long Insert(ItemService entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ItemServices.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(ItemService entity)
        {
            try
            {
                var user = db.ItemServices.Find(entity.Id);
                user.Title = entity.Title;
                user.Icon = entity.Icon;
                user.Description = entity.Description;
                user.Text = entity.Text;
                user.BigImage = entity.BigImage;
                user.Alt = entity.Alt;
                user.CreateDate = DateTime.Now;
                user.Service = entity.Service;
                user.Status = entity.Status;
                user.MetaDescription = entity.MetaDescription;
                user.Tags = entity.Tags;
                user.MetaTitle = entity.MetaTitle;
                user.Url = entity.Url;
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
                var item = db.ItemServices.Find(Id);
                db.ItemServices.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<ItemService> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ItemService> model = db.ItemServices;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString) || x.Service.ToString().Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public ItemService ViewDetail(long id)
        {
            return db.ItemServices.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var item = db.ItemServices.Find(id);
            item.Status = !item.Status;
            db.SaveChanges();
            return item.Status;
        }
    }
}