using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TinhGiaInApp.BDO;
using TinhGiaInApp.Logic;

namespace TinhGiaInClient.Model
{
    public class HangKhachHang
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string DienGiai { get; set; }
        public int GiaTriHang { get; set; }
        public int LoiNhuanChenhLech { get; set; }
        public int LoiNhuanOffsetGiaCong { get; set; }
        public string MaHieu { get; set; }
        public int ThuTu { get; set; }
        //==
        #region Các hàm static
        public static List<HangKhachHang> DocTatCa()
        {
            //Xài automapper
            var logic = new HangKhachHangLogic();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HangKhachHangBDO, HangKhachHang>());
            var mapper = config.CreateMapper();
            List<HangKhachHang> nguon = mapper.Map<List<HangKhachHangBDO>, List<HangKhachHang>> (logic.DocTatCa());
            return nguon;

        }
        public static HangKhachHang DocTheoId(int iD)
        {
            var logic = new HangKhachHangLogic();

            var objBDO = logic.DocTheoId(iD);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<HangKhachHangBDO, HangKhachHang>()
                        );
            var mapper = config.CreateMapper();

            var objModel = mapper.Map<HangKhachHang>(objBDO);

            //Trả về
            return objModel;
        }
      
        #endregion
        #region  hàm tính giá in nhanh
        public static decimal TinhGiaInNhanh(BangGiaInNhanh bangGia, int soTrangA4)
        {
            if (bangGia == null || soTrangA4 <= 0)
                return 0;

            string[] soLuongs = bangGia.DaySoLuong.Split(';'); //[1,11,51,101];
            string [] giaTheos = bangGia.DayGia.Split(';'); //[15000,5000,3000,2500];
            var result = 0;
            var soTrangGoc = soTrangA4;//lưu để tính cuối.

            //tạo bản dãy chứa block trang
            int[] page_blocks = {0, 0, 0, 0};
            var i = 0;
            for (i = 0; i < page_blocks.Length - 1; i++)
            {
                if (soTrangA4 <= int.Parse(soLuongs[i + 1]) - int.Parse(soLuongs[i]))
                {
                    page_blocks[i] = soTrangA4;
                    soTrangA4 = 0;//ngăn không cho cộng thêm ở cuối
                    break;
                }
                else
                {
                    page_blocks[i] = int.Parse(soLuongs[i + 1]) - int.Parse(soLuongs[i]);
                    //page num còn lại
                    soTrangA4 -= page_blocks[i];
                }
            }

            if (soTrangA4 > 0)
            {
                page_blocks[i] = soTrangA4;
            }
            //tính giá theo các blocks trang đã có

            for (i = 0; i < page_blocks.Length; i++)
            {
                result += page_blocks[i] * int.Parse(giaTheos[i]);
            }


            return result;
        }

        #endregion
    }
}
