//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dichvuhoanhao.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quote
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Alt { get; set; }
        public string Text { get; set; }
        public string FileDownload { get; set; }
        public bool Status { get; set; }
        public long Service { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Url { get; set; }
    
        public virtual Service Service1 { get; set; }
    }
}
