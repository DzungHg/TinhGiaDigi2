using System;
using System.Collections.Generic;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;
using TinhGiaInApp.Common.Enums;

namespace TinhGiaInNhapLieu.Presenter
{

    public class BangGiaPresenter
    {
        IViewBangGia View;
        public BangGiaPresenter(IViewBangGia view)
        { 
            View = view;
            //
            if (View.TinhTrangForm == FormStateS.New)
                TrinhBayThemMoi();
            else if (View.TinhTrangForm == FormStateS.Edit)
                TrinhBayChiTietBangGia();
            else if (view.TinhTrangForm == FormStateS.View)
                TrinhBayChiTietBangGia();

        }
       
        public void TrinhBayThemMoi()
        {
            View.Id = 0;
            View.Ten = "";
            View.DienGiai = "Diễn giải";
                    
                  
            View.DaySoLuong = ";";
            View.DayGiaTrang = ";";
      
            View.ThuTu = 100;
            View.DonViTinh = "trang a4";
       
            View.KhongSuDung = false;
        }
        public void TrinhBayChiTietBangGia()
        {
            if (View.Id <= 0)
                return;
            //Đọc theo từng bảng
            BangGiaBase bangGiaIn = null;
            LoaiBangGiaS loaiBangGia;
            Enum.TryParse(View.LoaiBangGia, out loaiBangGia);
            switch (loaiBangGia)
            {
                case LoaiBangGiaS.LuyTien:
                    bangGiaIn = BangGiaLuyTien.DocTheoId(View.Id);
                    break;
                case LoaiBangGiaS.Buoc:
                    bangGiaIn = BangGiaTheoBuoc.DocTheoId(View.Id);
                    break;
                case LoaiBangGiaS.Goi:
                    bangGiaIn = BangGiaTheoGoi.DocTheoId(View.Id);
                    break;
               
            }
            
            //View.ID = bangGiaIn.Id;
            View.Ten = bangGiaIn.Ten;
            View.DienGiai = bangGiaIn.DienGiai;
            View.DaySoLuong = bangGiaIn.DaySoLuong;
            View.DayGiaTrang = bangGiaIn.DayGia;      
            View.ThuTu = bangGiaIn.ThuTu;          
            View.KhongSuDung = bangGiaIn.KhongCon;
            View.DonViTinh = bangGiaIn.DonViTinh;
        }


        public void Luu(ref string thongDiep)
        {
            var bangGiaLT = new BangGiaLuyTien
            {
                Id = View.Id,
                Ten = View.Ten,
                DienGiai = View.DienGiai,
                LoaiBangGia = View.LoaiBangGia.ToString(),
                DaySoLuong = View.DaySoLuong,
                DayGia = View.DayGiaTrang,
                DonViTinh = View.DonViTinh,
                ThuTu = View.ThuTu,
                KhongCon = View.KhongSuDung
            };
            var bangGiaBuoc = new BangGiaTheoBuoc
            {
                Id = View.Id,
                Ten = View.Ten,
                DienGiai = View.DienGiai,
                LoaiBangGia = View.LoaiBangGia.ToString(),
                DaySoLuong = View.DaySoLuong,
                DayGia = View.DayGiaTrang,
                DonViTinh = View.DonViTinh,
                ThuTu = View.ThuTu,
                KhongCon = View.KhongSuDung
            };
            var bangGiaGoi = new BangGiaTheoGoi
            {
                Id = View.Id,
                Ten = View.Ten,
                DienGiai = View.DienGiai,
                LoaiBangGia = View.LoaiBangGia.ToString(),
                DaySoLuong = View.DaySoLuong,
                DayGia = View.DayGiaTrang,
                DonViTinh = View.DonViTinh,
                ThuTu = View.ThuTu,
                KhongCon = View.KhongSuDung
            };
           
            LoaiBangGiaS loaiBangGia;
            Enum.TryParse(View.LoaiBangGia, out loaiBangGia);
            switch (loaiBangGia)
            {
                case LoaiBangGiaS.LuyTien:
                    switch (View.TinhTrangForm)
                    {
                        case FormStateS.Edit:                            
                            thongDiep = BangGiaLuyTien.Sua(bangGiaLT);
                            break;
                        case FormStateS.New:
                            thongDiep = BangGiaLuyTien.Them(bangGiaLT);
                            break;
                    }

                    break;

                case LoaiBangGiaS.Buoc:
                    switch (View.TinhTrangForm)
                    {
                        case FormStateS.Edit:
                            thongDiep = BangGiaTheoBuoc.Sua(bangGiaBuoc);
                            break;
                        case FormStateS.New:
                            thongDiep = BangGiaTheoBuoc.Them(bangGiaBuoc);
                            break;
                    }

                    break;
                case LoaiBangGiaS.Goi:
                    switch (View.TinhTrangForm)
                    {
                        case FormStateS.Edit:
                            thongDiep = BangGiaTheoGoi.Sua(bangGiaGoi);
                            break;
                        case FormStateS.New:
                            thongDiep = BangGiaTheoGoi.Them(bangGiaGoi);
                            break;
                    }

                    break;

            }

        }
        public Dictionary<string, string> TrinhBayBangGia()
        {
            Dictionary<string, string> kq = null;

            // làm treenform là được
            LoaiBangGiaS loaiBangGia;
            Enum.TryParse(View.LoaiBangGia, out loaiBangGia);
            kq = DanhSachBangGia.TrinhBayBangGia(View.DaySoLuong, View.DayGiaTrang,
                loaiBangGia, View.DonViTinh);

            return kq;
        }
    }
}
