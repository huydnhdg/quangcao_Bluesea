using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class MailsystemDao
    {
        DichvuhoanhaoDbContext db = null;
        public MailsystemDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(Mailsystem entity)
        {
            db.Mailsystems.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public IEnumerable<Mailsystem> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Mailsystem> model = db.Mailsystems;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Email.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Email).ToPagedList(page, pageSize);
        }
        public Mailsystem ViewDetail(int id)
        {
            return db.Mailsystems.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Mailsystems.Find(id);
                db.Mailsystems.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Mailsystem GetById(string userName)
        {
            return db.Mailsystems.SingleOrDefault(x => x.Email == userName);
        }
    }
}