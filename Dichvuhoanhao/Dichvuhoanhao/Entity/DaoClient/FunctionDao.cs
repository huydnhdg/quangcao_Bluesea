using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class FunctionDao
    {
        DichvuhoanhaoDbContext db = null;
        public FunctionDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public List<Function> get_AllFunction_ById(long serviceId)
        {
            return db.Functions.Where(x => x.Service == serviceId).ToList();
        }
    }
}