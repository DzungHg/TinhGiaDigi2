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
    
    public partial class GIA_TUY_CHON_THE_NHUA
    {
        public int ID_BANG_GIA_THE_NHUA { get; set; }
        public int ID_TUY_CHON_THE_NHUA { get; set; }
        public Nullable<int> gia_ban { get; set; }
    
        public virtual BANG_GIA_THE_NHUA BANG_GIA_THE_NHUA { get; set; }
        public virtual TUY_CHON_THE_NHUA TUY_CHON_THE_NHUA { get; set; }
    }
}
