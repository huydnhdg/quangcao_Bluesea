using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class PartnerDao
    {
        DichvuhoanhaoDbContext db = null;
        public PartnerDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public long Insert(Partner entity)
        {
            db.Partners.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Partner entity)
        {
            try
            {
                var user = db.Partners.Find(entity.Id);
                user.PartnerName = entity.PartnerName;
                user.WebsiteAddress = entity.WebsiteAddress;
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
        public IEnumerable<Partner> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Partner> model = db.Partners;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.PartnerName.Contains(searchString));
            }

            return model.OrderByDescending(x => x.PartnerName).ToPagedList(page, pageSize);
        }
        public Partner GetById(string userName)
        {
            return db.Partners.SingleOrDefault(x => x.PartnerName == userName);
        }
        public Partner ViewDetail(int id)
        {
            return db.Partners.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Partners.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Partners.Find(id);
                db.Partners.Remove(user);
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