using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class QuoteDao
    {
        DichvuhoanhaoDbContext db = null;
        public QuoteDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(Quote entity)
        {
            db.Quotes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Quote entity)
        {
            try
            {
                var user = db.Quotes.Find(entity.Id);
                user.Title = entity.Title;
                user.Description = entity.Description;
                user.Alt = entity.Alt;
                user.Image = entity.Image;
                user.Text = entity.Text;
                user.FileDownload = entity.FileDownload;
                user.Service = entity.Service;
                user.Status = entity.Status;
                user.MetaDescription = entity.MetaDescription;
                user.MetaTitle = entity.MetaTitle;
                user.Url = entity.Url;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Quote> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Quote> model = db.Quotes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString)||x.Service.ToString().Contains(searchString));
            }

            return model.OrderByDescending(x => x.Title).ToPagedList(page, pageSize);
        }
        public Quote ViewDetail(int id)
        {
            return db.Quotes.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Quotes.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Quotes.Find(id);
                db.Quotes.Remove(user);
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