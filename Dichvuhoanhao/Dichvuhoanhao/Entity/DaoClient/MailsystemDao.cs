using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dichvuhoanhao.Entity.DaoClient
{
    public class MailsystemDao
    {
        DichvuhoanhaoDbContext db = null;
        public MailsystemDao()
        {
            db = new DichvuhoanhaoDbContext();
        }
        public Mailsystem get_mail_system(int keys = 0)
        {
            return db.Mailsystems.SingleOrDefault(x => x.Keys == keys);
        }
        public List<Mailsystem> get_mail_edit(int keys = 1)
        {
            return db.Mailsystems.Where(x => x.Keys == keys).ToList();
        }
    }
}