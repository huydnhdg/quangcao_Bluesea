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
    
    public partial class Function
    {
        public long Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Alt { get; set; }
        public long Service { get; set; }
        public string LinkDetail { get; set; }
    
        public virtual Service Service1 { get; set; }
    }
}
