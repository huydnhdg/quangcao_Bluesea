using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoCms
{
    public class UserDao
    {
        DichvuhoanhaoDbContext db = null;
        public UserDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public int Login(string username, string password)
        {
            var result = db.Usercms.SingleOrDefault(x => x.UserName == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        public Usercm GetById(string username)
        {
            return db.Usercms.SingleOrDefault(x => x.UserName == username);
        }
        public long Insert(Usercm entity)
        {
            db.Usercms.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(Usercm entity)
        {
            try
            {
                var user = db.Usercms.Find(entity.Id);
                user.UserName = entity.UserName;
                user.FullName = entity.FullName;
                user.Role = entity.Role;
                user.Status = entity.Status;
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
                var user = db.Usercms.Find(Id);
                db.Usercms.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Usercm> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Usercm> model = db.Usercms;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.FullName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.FullName).ToPagedList(page, pageSize);
        }
        public Usercm ViewDetail(long id)
        {
            return db.Usercms.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Usercms.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool UpdateProfile(Usercm entity)
        {
            try
            {
                var user = db.Usercms.Find(entity.Id);
                user.UserName = entity.UserName;
                user.FullName = entity.FullName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}