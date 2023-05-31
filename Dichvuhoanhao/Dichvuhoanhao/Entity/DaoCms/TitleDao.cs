using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class TitleDao
    {

        DichvuhoanhaoDbContext db = null;
        public TitleDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public bool Update(Title entity)
        {
            try
            {
                var user = db.Titles.Find(entity.Id);
                user.Title1 = entity.Title1;
                user.Extra1 = entity.Extra1;
                user.Extra2 = entity.Extra2;
                user.Extra3 = entity.Extra3;
                user.Extra4 = entity.Extra4;
                user.Extra5 = entity.Extra5;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Title> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Title> model = db.Titles;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title1.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Title1).ToPagedList(page, pageSize);
        }
        public Title ViewDetail(int id)
        {
            return db.Titles.Find(id);
        }
    }
}