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
    
    public partial class HANG_KHACH_HANG
    {
        public HANG_KHACH_HANG()
        {
            this.BANG_GIA_IN_NHANH = new HashSet<BANG_GIA_IN_NHANH>();
            this.MARK_UP_LOI_NHUAN_GIAY = new HashSet<MARK_UP_LOI_NHUAN_GIAY>();
            this.BANG_GIA_DANH_THIEP = new HashSet<BANG_GIA_DANH_THIEP>();
            this.BANG_GIA_THE_NHUA = new HashSet<BANG_GIA_THE_NHUA>();
            this.NY_GIA_IN_NHANH = new HashSet<NY_GIA_IN_NHANH>();
        }
    
        public int ID { get; set; }
        public string Ten { get; set; }
        public Nullable<int> Hang_khach_hang { get; set; }
        public Nullable<int> Loi_nhuan_chenh_lech { get; set; }
        public Nullable<int> Thu_tu { get; set; }
        public string Dien_giai { get; set; }
        public Nullable<int> Loi_nhuan_offset_gia_cong { get; set; }
        public string ma_hieu { get; set; }
    
        public virtual ICollection<BANG_GIA_IN_NHANH> BANG_GIA_IN_NHANH { get; set; }
        public virtual ICollection<MARK_UP_LOI_NHUAN_GIAY> MARK_UP_LOI_NHUAN_GIAY { get; set; }
        public virtual ICollection<BANG_GIA_DANH_THIEP> BANG_GIA_DANH_THIEP { get; set; }
        public virtual ICollection<BANG_GIA_THE_NHUA> BANG_GIA_THE_NHUA { get; set; }
        public virtual ICollection<NY_GIA_IN_NHANH> NY_GIA_IN_NHANH { get; set; }
    }
}
