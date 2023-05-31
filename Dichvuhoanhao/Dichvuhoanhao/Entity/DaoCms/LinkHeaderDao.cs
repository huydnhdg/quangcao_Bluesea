using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class LinkHeaderDao
    {
        DichvuhoanhaoDbContext db = null;
        public LinkHeaderDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(LinkHeader entity)
        {
            db.LinkHeaders.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(LinkHeader entity)
        {
            try
            {
                var user = db.LinkHeaders.Find(entity.Id);
                user.Link = entity.Link;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<LinkHeader> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<LinkHeader> model = db.LinkHeaders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
        public LinkHeader GetById(string userName)
        {
            return db.LinkHeaders.SingleOrDefault(x => x.Name == userName);
        }
        public LinkHeader ViewDetail(int id)
        {
            return db.LinkHeaders.Find(id);
        }
    }
}