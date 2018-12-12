using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Presenter;
using TinhGiaInApp.Common.Enums;


namespace TinhGiaInClient.Model
{
    public static class DanhSachBangGia
    {
        public static List<BangGiaBase> DanhSachS()
        {
            var lst = new List<BangGiaBase>();
            //
            foreach(BangGiaLuyTien bg in BangGiaLuyTien.DocTatCa())
            {
                lst.Add(bg);

            }
            //Bảng giá tiếp
            foreach (BangGiaTheoBuoc bg in BangGiaTheoBuoc.DocTatCa())
            {
                lst.Add(bg);

            }
            return lst;
        }
        
        public static BangGiaBase DocTheoIDvaLoai(int id, LoaiBangGiaS loai)
        {
            BangGiaBase bg = null;
            bg = DanhSachBangGia.DanhSachS().Where(x => x.ID == id && x.LoaiBangGia.Trim() == loai.ToString() ).SingleOrDefault();
            return bg;
        }
        public static Dictionary<string, string> TrinhBayBangGiaTuDB(int idBangGia, LoaiBangGiaS loaiBangGia)
        {
            Dictionary<string, string> kq = null;
            if (idBangGia <= 0)
                return kq;


            var bangGiaChon = DanhSachBangGia.DocTheoIDvaLoai(idBangGia, loaiBangGia);
            switch (loaiBangGia)
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
        public static Dictionary<string, string> TrinhBayBangGia(string daySoLuong, string dayGia,
                LoaiBangGiaS loaiBangGia, string donViTinh = "trang A4")
        {
            Dictionary<string, string> kq = null;
            //Kiểm tra bản giá có hợp lệ
            
            string[] daySoLuongArr;
            string[] dayGiaArr;
            try
            {
                daySoLuongArr = daySoLuong.Split(';');
                dayGiaArr = dayGia.Split(';');
            }
            catch
            {
                
                return kq;
            }
            //kiểm tiếp n

            if (!(daySoLuongArr.Length == dayGiaArr.Length))
                return kq;
            //Vượt

            
            switch (loaiBangGia)
            {
                case LoaiBangGiaS.LuyTien:

                    kq = HoTro.TrinhBayBangGiaLuyTien(daySoLuong,
                        dayGia, donViTinh);
                    break;

                case LoaiBangGiaS.Buoc:

                    kq = HoTro.TrinhBayBangGiaBuoc(daySoLuong,
                        dayGia, donViTinh);
                    break;
                case LoaiBangGiaS.Goi:

                    kq = HoTro.TrinhBayBangGiaGoi(daySoLuong,
                        dayGia, donViTinh);
                    break;
            }
            return kq;
        }
    }
}
