using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Common;
using TinhGiaInApp.Common.Enums;
using TinhGiaInClient.Model;



namespace TinhGiaInClient.Presenter
{
    public class GiaInNhanhPresenter
    {
        IViewGiaInNhanh View;
        private MucGiaIn _mucGiaInNhanh;
        public GiaInNhanhPresenter(IViewGiaInNhanh view, MucGiaIn mucGiaIn)
        {
            View = view;

            this._mucGiaInNhanh = mucGiaIn;

        }
        public void CapNhatMucGiaInVoView()
        {
            View.Id = _mucGiaInNhanh.ID;
            View.IdMayInOrToIn = _mucGiaInNhanh.IdMayIn;
            View.IdNiemYetChon = _mucGiaInNhanh.IdNiemYetGiaInNhanh;
            View.ChoTinhGopTrang = _mucGiaInNhanh.ChoTinhGopTrang;
            View.IdBaiIn = _mucGiaInNhanh.IdBaiIn;
            View.IdHangKH = _mucGiaInNhanh.IdHangKhachHang;
            View.SoToChay = _mucGiaInNhanh.SoToChay;
            View.SoMatIn = _mucGiaInNhanh.SoMatIn;

        }
        public string TenHangKH (int idHangKH)
        {
            return HangKhachHang.DocTheoId(idHangKH).Ten;
        }
        public int TyLeLoiNhuanTheoHangKH()
        {
            
            return HangKhachHang.DocTheoId(View.IdHangKH).LoiNhuanChenhLech;
           
        }
        public List<NiemYetGiaInNhanh>NiemYetGiaTheoHangKH()
        {
            
            var id = View.IdHangKH;
            return NiemYetGiaInNhanh.DocTheoIdHangKHConDung(View.IdHangKH);
        }
        public List<HangKhachHang>HangKhachHangS()
        {
            return HangKhachHang.DocTatCa();
        }
        private BangGiaBase DocBangGiaChonTheoNiemYetGia()
        {
            BangGiaBase kq = null;
            if (View.IdNiemYetChon > 0)
            {
                var niemYetGia = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChon);

                LoaiBangGiaS loaiBangGia;
                Enum.TryParse(niemYetGia.LoaiBangGia, out loaiBangGia);
                kq = DanhSachBangGia.DocTheoIdVaLoai(niemYetGia.IdBangGia,
                    loaiBangGia);
            }
            return kq;
        }
        public void TrinhBayChiTietNiemYet()
        {
            if (View.IdNiemYetChon > 0)
            {
                var niemYet = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChon);
                View.SoTrangToiDaTheoBangGia = niemYet.SoTrangToiDa;
                View.LoaiBangGiaNiemYet = niemYet.LoaiBangGia.Trim();
                View.TenLoaiBangGia = niemYet.TenLoaiBangGia;
                View.DienGiaiNiemYet = niemYet.DienGiai;
                View.ChoTinhGopTrang = niemYet.DuocGomTrang;
            }
        }
        public int SoTrangToiDaTheoBangGia()
        {
            
            return NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChon).SoTrangToiDa;
        }
        public string TenToInDigiChon()
        {
            var kq = "";
            if (View.IdMayInOrToIn > 0)
                kq = ToInMayDigi.DocTheoId(View.IdMayInOrToIn).Ten;

            return kq;
        }
      
        public int SoTrangA4 ()
        {            
            var toChayDigi = ToInMayDigi.DocTheoId(View.IdMayInOrToIn);
            int result = 0;

            result = View.SoToChay * toChayDigi.QuiA4 * View.SoMatIn;            
            return result;
        }
       
        public Dictionary<string, string> TrinhBayBangGia()
        {
            Dictionary<string, string> kq = null;
            if(string.IsNullOrEmpty(View.LoaiBangGiaNiemYet))
                return kq;

            var bangGiaChon = this.DocBangGiaChonTheoNiemYetGia();
            if (bangGiaChon != null)
            {
                LoaiBangGiaS loaiBangGia;
                Enum.TryParse(View.LoaiBangGiaNiemYet.Trim(), out loaiBangGia);

                /* kq = DanhSachBangGia.TrinhBayBangGia(bangGiaChon.DaySoLuong,
                     bangGiaChon.DayGia, loaiBangGia, bangGiaChon.DonViTinh);
                     */

                kq = DanhSachBangGia.TrinhBayBangGiaTuDB(bangGiaChon.Id, loaiBangGia);
            }
            
            return kq;
        }
       
        public decimal GiaInNhanhTheoBang(ref decimal giaTBTrang)//Chưa xài tới
        {
            decimal kq = 0;
            giaTBTrang = 0;
            if (this.DocBangGiaChonTheoNiemYetGia() == null || View.SoTrangA4 <= 0)
            {
                return kq;
            }
            //Vượt tiép
            LoaiBangGiaS loaiBangGia;
            var bGiaInNhanh = this.DocBangGiaChonTheoNiemYetGia();
            Enum.TryParse(bGiaInNhanh.LoaiBangGia.Trim(), out loaiBangGia);
           
                
                switch (loaiBangGia)
                { 
                    case LoaiBangGiaS.LuyTien:                
                        kq = TinhToan.GiaInLuyTien(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, View.SoTrangA4);
                        break;
                    case LoaiBangGiaS.Buoc:
                        kq = TinhToan.GiaBuoc(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, View.SoTrangA4);
                        break;
                    case LoaiBangGiaS.Goi:
                         kq = TinhToan.GiaGoi3(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, View.SoTrangA4);
                        break;
                }

                giaTBTrang = Math.Round(kq / View.SoTrangA4);
            
            return kq;
        }
        public decimal TinhGiaCuoiCung(ref decimal giaTBTrang) //Ngưng dùng
        {   /*         
            var giaInKetHop = new GiaInNhanhKetHopBangGia_May(View.SoTrangA4, this.DocBangGiaChonTheoNiemYetGia(),
                            View.SoTrangToiDaTheoBangGia, View.IdMayInOrToIn, TyLeLoiNhuanTheoHangKH());

            giaTBTrang = giaInKetHop.GiaTBTrenDonViTinh();
            return giaInKetHop.GiaBan();
            */// Trên không còn phù hợp nữa //Do đã cài đăt các loại bảng giá cho phù hợp

            return GiaInNhanhTheoBang(ref giaTBTrang);
        }

    
        private void CapNhatMucGiaInNhanh()
        {
            if (this._mucGiaInNhanh != null)
            {
                _mucGiaInNhanh.IdBaiIn = View.IdBaiIn;
                _mucGiaInNhanh.PhuongPhapIn = View.PhuongPhapIn;
                _mucGiaInNhanh.IdMayIn = View.IdMayInOrToIn;
                _mucGiaInNhanh.IdNiemYetGiaInNhanh = View.IdNiemYetChon;
                _mucGiaInNhanh.ChoTinhGopTrang = View.ChoTinhGopTrang;
                _mucGiaInNhanh.SoTrangIn = View.SoTrangA4;
                _mucGiaInNhanh.IdHangKhachHang = View.IdHangKH;
                _mucGiaInNhanh.SoToChay = View.SoToChay;
                _mucGiaInNhanh.SoMatIn = View.SoMatIn;
              
                decimal giaTBTrang = 0;
                _mucGiaInNhanh.TienIn = this.TinhGiaCuoiCung(ref giaTBTrang);
            }
        }
        public MucGiaIn DocMucGiaIn() 
        {
            CapNhatMucGiaInNhanh();//cập nhật đã
            return this._mucGiaInNhanh;

        }
    }
}
