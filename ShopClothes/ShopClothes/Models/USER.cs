//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopClothes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        public int ID { get; set; }
        public int SDT { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public Nullable<int> ROLES { get; set; }
        public Nullable<int> CREATEBY { get; set; }
        public System.DateTime CREATEAT { get; set; }
        public Nullable<int> UPDATEBY { get; set; }
        public Nullable<System.DateTime> UPDATEAT { get; set; }
    
        public virtual ROLE ROLE { get; set; }
    }
}
