//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EINVOICE_BLUESEA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Khachhang
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Taxcode { get; set; }
        public string Company { get; set; }
        public string Invoice { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
        public Nullable<System.DateTime> Editdate { get; set; }
        public int Status { get; set; }
    }
}
