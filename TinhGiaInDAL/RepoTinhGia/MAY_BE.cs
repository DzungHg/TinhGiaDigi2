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
    
    public partial class MAY_BE
    {
        public MAY_BE()
        {
            this.KHUON_BE = new HashSet<KHUON_BE>();
        }
    
        public int ID { get; set; }
        public string ten { get; set; }
        public Nullable<int> BHR { get; set; }
        public Nullable<int> toc_do_con { get; set; }
        public Nullable<double> thoi_gian_chuan_bi { get; set; }
        public Nullable<int> phi_ngvl_chuan_bi { get; set; }
        public string day_so_luong { get; set; }
        public string day_loi_nhuan { get; set; }
        public Nullable<int> thu_tu { get; set; }
        public string don_vi_tinh { get; set; }
        public string day_so_luong_niem_yet { get; set; }
    
        public virtual ICollection<KHUON_BE> KHUON_BE { get; set; }
    }
}