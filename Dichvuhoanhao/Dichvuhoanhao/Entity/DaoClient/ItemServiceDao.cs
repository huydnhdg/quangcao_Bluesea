using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class ItemServiceDao
    {
        DichvuhoanhaoDbContext db = null;
        public ItemServiceDao()
        {
            db = new DichvuhoanhaoDbContext();
        }

        // DAIPA sua get5Item thanh get6Item
        public List<ItemService> get6Item()
        {
            IQueryable<ItemService> a = db.ItemServices.Where(x => x.Service == 1);
            var b = a.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            IQueryable<ItemService> a2 = db.ItemServices.Where(x => x.Service == 2);
            var b2 = a2.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            IQueryable<ItemService> a3 = db.ItemServices.Where(x => x.Service == 3);
            var b3 = a3.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            IQueryable<ItemService> a4 = db.ItemServices.Where(x => x.Service == 4);
            var b4 = a4.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            IQueryable<ItemService> a5 = db.ItemServices.Where(x => x.Service == 5);
            var b5 = a5.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            IQueryable<ItemService> a6 = db.ItemServices.Where(x => x.Service == 6);
            var b6 = a6.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            IQueryable<ItemService> a7 = db.ItemServices.Where(x => x.Service == 7);
            var b7 = a7.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            IQueryable<ItemService> a8 = db.ItemServices.Where(x => x.Service == 8);
            var b8 = a8.OrderByDescending(x => x.CreateDate).Take(3).ToList();
            List<ItemService> model = new List<ItemService>();
            model.AddRange(b);
            model.AddRange(b2);
            model.AddRange(b3);
            model.AddRange(b4);
            model.AddRange(b5);
            model.AddRange(b6);
            model.AddRange(b7);
            model.AddRange(b8);
            return model;
        }
        public List<ItemService> getAllItem()
        {
            return db.ItemServices.Where(x => x.Status).ToList();
        }
        public List<ItemService> get_AllItem_ById(long serviceId)
        {
            return db.ItemServices.Where(x => x.Service == serviceId).ToList();
        }
        public List<ItemService> get_10_ById(long serviceId)
        {
            IQueryable<ItemService> a = db.ItemServices.Where(x => x.Service == serviceId);
            var b = a.OrderByDescending(x => x.CreateDate).Take(10).ToList();
            return b;
        }
        public IEnumerable<ItemService> ListAllPaging(long serviceId, string searchString, int page, int pageSize)
        {
            IQueryable<ItemService> model = db.ItemServices.Where(x => x.Service == serviceId && x.Status == true);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString) || x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<ItemService> Search(string searchString, int page, int pageSize)
        {
            IQueryable<ItemService> model = db.ItemServices;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public ItemService get_Item_in_Service(long id, long service)
        {
            var model = db.ItemServices.Where(x => x.Service == service).SingleOrDefault(x => x.Id == id);
            return model;
        }

    }
}