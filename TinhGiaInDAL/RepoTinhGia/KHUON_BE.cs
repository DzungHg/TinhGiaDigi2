//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TinhGiaInDAL.RepoTinhGia
{
    using System;
    using System.Collections.Generic;
    
    public partial class KHUON_BE
    {
        public int ID { get; set; }
        public string ten { get; set; }
        public string dien_giai { get; set; }
        public Nullable<int> gia_mua { get; set; }
        public Nullable<int> thu_tu { get; set; }
        public Nullable<int> ID_MAY_BE { get; set; }
        public Nullable<int> so_lan_tieu_hao { get; set; }
    
        public virtual MAY_BE MAY_BE { get; set; }
    }
}