using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHDTNEWS.Areas.Admin.Models
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public int CountView { get; set; }
        public string FullContent { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
        public Nullable<long> CateId { get; set; }
        public string CateName { get; set; }
        public string tags { get; set; }
    }
}