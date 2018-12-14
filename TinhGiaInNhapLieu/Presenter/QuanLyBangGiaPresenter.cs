using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;

using TinhGiaInApp.Common.Enums;
using TinhGiaInClient.Common;
using TinhGiaInClient.Presenter;

namespace TinhGiaInNhapLieu.Presenter
{
    public class QuanLyBangGiaPresenter
    {
        IViewQuanLyBangGia View;
        public QuanLyBangGiaPresenter(IViewQuanLyBangGia view)
        {
            View = view;

            View.SoTrangTinhThu = 100;
        }       
        public List<BangGiaBase>BangGiaTheoLoai()
        {
            List<BangGiaBase> lst = null;
            switch (View.LoaiBangGia)
            {
                case LoaiBangGiaS.LuyTien:
                    
                    lst = DanhSachBangGia.DanhSachS().Where(x => x.LoaiBangGia.Trim() == LoaiBangGiaS.LuyTien.ToString()).ToList();
                    
                    
                    break;
                case LoaiBangGiaS.Buoc:
                    lst = DanhSachBangGia.DanhSachS().Where(x => x.LoaiBangGia.Trim() == LoaiBangGiaS.Buoc.ToString()).ToList();
                    break;
                case LoaiBangGiaS.Goi:
                    lst = DanhSachBangGia.DanhSachS().Where(x => x.LoaiBangGia.Trim() == LoaiBangGiaS.Goi.ToString()).ToList();
                    break;
            }
          
            return lst;
        }
        /*public string LoaiBanGiaStr()
        {
            //Loại bảng giá
            var loaiBG = "";
            switch (View.LoaiBangGia)
            {
                case LoaiBangGiaS.LuyTien:
                    loaiBG = Global.cBangGiaLuyTien;
                    break;
                case LoaiBangGiaS.Buoc:
                    loaiBG = Global.cBangGiaBuoc;
                    break;
                case LoaiBangGiaS.Goi:
                    loaiBG = Global.cBangGiaGoi;
                    break;
            }
            return loaiBG;
        }*/
        public Dictionary<string, string> TrinhBayBangGia()
        {
            Dictionary<string, string> kq = null;
            if (View.IdBangGiaChon <= 0 )
                return kq;

            

            var bangGiaChon = DanhSachBangGia.DocTheoIDvaLoai(View.IdBangGiaChon, View.LoaiBangGia);
            

            switch (View.LoaiBangGia)
            {
                case LoaiBangGiaS.LuyTien:

                    kq = HoTro.TrinhBayBangGiaLuyTien(bangGiaChon.DaySoLuong,
                        bangGiaChon.DayGia, bangGiaChon.DonViTinh);
                    break;

                case LoaiBangGiaS.Buoc:

                    kq = HoTro.TrinhBayBangGiaBuoc(bangGiaChon.DaySoLuong,
                        bangGiaChon.DayGia, bangGiaChon.DonViTinh);
                    break;
                case LoaiBangGiaS.Goi:

                    kq = HoTro.TrinhBayBangGiaGoi(bangGiaChon.DaySoLuong,
                        bangGiaChon.DayGia, bangGiaChon.DonViTinh);
                    break;
            }
            return kq;
        }
        public string DienGiaiBangGia()
        {
            var kq = "";
            if (View.IdBangGiaChon <= 0)
                return kq;
            //
            var bangGia = DanhSachBangGia.DocTheoIDvaLoai(View.IdBangGiaChon, View.LoaiBangGia);
            kq = bangGia.DienGiai;
            return kq;
        }
        public decimal TinhThuSoTrang(ref string giaTBA4)
        {
            var kq = 0m;
            if (View.IdBangGiaChon <= 0 || View.SoTrangTinhThu <=0)
            {
                giaTBA4 = "0đ";
                return kq;
            }
            //
            var bangGia = DanhSachBangGia.DocTheoIDvaLoai(View.IdBangGiaChon, View.LoaiBangGia);
            /* var giaInNhanhNiemYet = new GiaInNhanhNiemYet(View.SoTrangTinhThu, bangGia);
             kq = giaInNhanhNiemYet.ThanhTienSales(); */
            //Tính thử theo giá của bảng giá chứ không phải niêm yết
            LoaiBangGiaS loaiBangGia;            
            Enum.TryParse(bangGia.LoaiBangGia.Trim(), out loaiBangGia);
            switch(loaiBangGia)
            {
                case LoaiBangGiaS.LuyTien:
                    kq = TinhToan.GiaInLuyTien(bangGia.DaySoLuong, bangGia.DayGia, View.SoTrangTinhThu);
                    break;
                case LoaiBangGiaS.Buoc:
                    kq = TinhToan.GiaBuoc(bangGia.DaySoLuong, bangGia.DayGia, View.SoTrangTinhThu);
                    break;
                case LoaiBangGiaS.Goi://Gói cũ giống Bước
                    kq = TinhToan.GiaGoi3(bangGia.DaySoLuong, bangGia.DayGia, View.SoTrangTinhThu);
                    break;
            }


            giaTBA4 = string.Format("{0:0,0}đ/A4", Math.Round(kq / View.SoTrangTinhThu));
            return kq;

        }
    }
}
