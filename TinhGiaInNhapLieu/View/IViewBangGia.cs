using TinhGiaInApp.Common.Enums;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewBangGia
    {
        int ID { get; set; }
        string Ten { get; set; }
        string DienGiai { get; set; }
        string DaySoLuong { get; set; }
        string DayGiaTrang { get; set; }
        string DonViTinh { get; set; }      
        LoaiBangGiaS LoaiBangGia { get; set; }
        int ThuTu { get; set; }
       
        bool KhongSuDung { get; set; }
       
        FormStateS TinhTrangForm { get; set; }       
    }
}
