﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public static class TinhToan
    {
        /*public static int GiaTriTheoKhoang(string daySoLuong, string dayGiaTri, int soLuong)
        {
            int result = 0;
            if (string.IsNullOrEmpty(daySoLuong) || string.IsNullOrEmpty(daySoLuong) ||
                soLuong <= 0)
                return result;
            
            //Tạo bản dãy số lượng

            var daySoLuongS = daySoLuong.Split(';');
            var dayGiaTriS = dayGiaTri.Split(';');

            var tmpI = 0;
            //trường hợp soluong< Số lượng đầu tiên:
            if (soLuong < int.Parse(daySoLuongS[0]))
            {
                tmpI = 0;
                result = int.Parse(dayGiaTriS[tmpI]);
                return result;
            }
            //Trường họp số lượng >= số lượng cuối (lớn nhất)
            if (soLuong >= int.Parse(daySoLuongS[daySoLuongS.Length-1]))
            {
                tmpI = daySoLuongS.Length - 1;
                result = int.Parse(dayGiaTriS[tmpI]);
                return result;
            }
            //Lặp tiếp chỉ đến phẩn tử kế cuối
            for (int i = 0; i < daySoLuongS.Length - 1; i++) // chỉ đến kế cuối
            {               
                //Tiếp tục
                if (int.Parse(daySoLuongS[i]) <= soLuong && soLuong < int.Parse(daySoLuongS[i + 1]))
                {
                    tmpI = i;
                    break;
                }
            }
            
            result = int.Parse(dayGiaTriS[tmpI]);
            return result;
        }*/

        /*public static decimal GiaDanhThiep(int soLuong, string daySoLuongS, string dayGiaS)
        {
            //Nguyên lý: tính theo số cuối
            //var dayGias = [70000,65000,60000];
            //var daySoLuongs = [4,9,1000];
            var dayGias = dayGiaS.Split(';');
            var daySoLuongs = daySoLuongS.Split(';');
            var soLuongMax = int.Parse(daySoLuongs[daySoLuongs.Length - 1]); //Xử lý item cuối vì nó không có khoảng thêm
            var result = 0;
            var soLuongCheck = 0;
            var donGiaTheoKhoang = 0;

            if (soLuong > soLuongMax)
            {
                soLuongCheck = soLuongMax;
            }
            else
                soLuongCheck = soLuong;


            //Xem khoảng số lượng rớt vô đâu rồi lấy giá ở đó tính
            var tmpI = 0;
            var soBatDau = 1;
            for (int i = 0; i < daySoLuongs.Length; i++)
            {
                if (soLuongCheck >= soBatDau && soLuongCheck <= int.Parse(daySoLuongs[i]))
                {
                    tmpI = i;
                    break;
                }
                soBatDau = int.Parse(daySoLuongs[i]) + 1;
            }
            donGiaTheoKhoang = int.Parse(dayGias[tmpI]);
            //Tính
            result = soLuong * donGiaTheoKhoang;
            return result;
        }
         */

        public static int GiaTriTheoKhoang(string daySoLuong, string dayGiaTri, int soLuong)
        {//Bắt buộc phải bắt đầu từ 1
            int result = 0;
            if (string.IsNullOrEmpty(daySoLuong) || string.IsNullOrEmpty(daySoLuong) ||
                soLuong <= 0)
                return result;

            //Tạo bản dãy số lượng

            var daySoLuongS = daySoLuong.Split(';');
            var dayGiaTriS = dayGiaTri.Split(';');

            var tmpI = 0;
            /*
            //trường hợp soluong< Số lượng đầu tiên:
            if (soLuong < int.Parse(daySoLuongS[0]))
            {
                tmpI = 0;
                result = int.Parse(dayGiaTriS[tmpI]);
                return result;
            }
             */
            //Trường họp số lượng >= số lượng cuối (lớn nhất)
            if (soLuong >= int.Parse(daySoLuongS[daySoLuongS.Length - 1]))
            {
                tmpI = daySoLuongS.Length - 1;
                result = int.Parse(dayGiaTriS[tmpI]);
                return result;
            }
            //Lặp tiếp chỉ đến phẩn tử kế cuối
            for (int i = 0; i < daySoLuongS.Length - 1; i++) // chỉ đến kế cuối
            {
                //Tiếp tục
                if (int.Parse(daySoLuongS[i]) <= soLuong && soLuong < int.Parse(daySoLuongS[i + 1]))
                {
                    tmpI = i;
                    break;
                }
            }

            result = int.Parse(dayGiaTriS[tmpI]);
            return result;

        }
        public static decimal GiaInLuyTien(string khoangSoLuong, string khoangGia, int soTrangA4)
        {

            if (string.IsNullOrEmpty(khoangSoLuong) || string.IsNullOrEmpty(khoangGia) || soTrangA4 <= 0)
                return 0;

            string[] soLuongs = khoangSoLuong.Split(';'); //[1,11,51,101];
            string[] giaTheos = khoangGia.Split(';'); //[15000,5000,3000,2500];

            var result = 0;
            var soTrangGoc = soTrangA4;//lưu để tính cuối.

            //tạo bản dãy chứa block trang theo độ dài
            int[] page_blocks = new int[soLuongs.Length];
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
        public static decimal GiaBuoc(string daySoLuong, string dayGia, int soLuong)
        {///Dò số lượng lấy giá
            ///Sau đó lấy giá tại khoảng đó nhân số lượng

            decimal result = 0;

            if (string.IsNullOrEmpty(daySoLuong) || string.IsNullOrEmpty(daySoLuong) ||
                soLuong <= 0)
                return result;
          
            var giaTheoKhoang = TinhToan.GiaTriTheoKhoang(daySoLuong, dayGia, soLuong);

            result = giaTheoKhoang * soLuong;

            return result;
        }
        /*public static decimal GiaGoi (string daySoLuong, string dayGia, int soLuong)
        {
            decimal kq = 0;
            if (string.IsNullOrEmpty(daySoLuong) || string.IsNullOrEmpty(dayGia) ||
                soLuong <= 0)
                return 0;
            ///V dụ 100 trang 100k, 200tr 400.000 k
            ///nếu  nhỏ hơn số lượng
            ///đầu tien
           
            var dayGiaS = dayGia.Split(';');
            var daySLuongS = daySoLuong.Split(';');
            decimal giaTBTrang = 0;
            decimal giaMin = decimal.Parse(dayGiaS[0]);
            var i = 0;
            for (i = 0; i < daySLuongS.Length; i++)
            {

                if ((soLuong - int.Parse(daySLuongS[i])) < 0)
                {
                    //Thoát xử lý vị trí i kể cả khi lớn hơn cuối cùng
                    break;
                }

            }
            var arI = i;
            //Xác định số lượng vả giá
            var soTrangChenhLechTaiI = 0;
            decimal giaGoiTaiI = 0;
            if (arI <= 0) //mục đầu tiên
            {
                kq = decimal.Parse(dayGiaS[arI]);
            }
            else
            {
                soTrangChenhLechTaiI = soLuong - int.Parse(daySLuongS[arI - 1]) ;
                giaGoiTaiI = decimal.Parse(dayGiaS[arI - 1]);

                //giá TB trang sẽ cao nếu khách lấy lẻ
                giaTBTrang = giaGoiTaiI / int.Parse(daySLuongS[arI - 1]);                
                kq = giaGoiTaiI + giaTBTrang * soTrangChenhLechTaiI;

            }

            return kq;
        }*/
       /* public static decimal GiaGoi2(string daySoLuong, string dayGia, int soLuong)
        {
            ///Đặt số lượng và giá như sau
            ///100, 200, 300, 400, 500
            ///5000, 3000, 2000, 1000, 800
            ///Khi đạt 100 tính 5000, đạt 200 tính 3000, đạt 300 tính 2000 v..v.
            decimal kqTinhGia = 0;

            var daySoLuongS = daySoLuong.Split(';');
            var dayGiaS = dayGia.Split(';');
            //--Tìm khoảng:
            
           
            //làm lại dãy số lượng
            string[] daySoLuongExt = new string[daySoLuongS.Length + 1];
            //1. Thêm 1 vô đầu tiên để tạo bản dãy số lượng mới cho phù hợp
            daySoLuongExt[0] = 1.ToString();
            //2. Thêm còn lại từ bản dãy daySoLuongS
            for (int i = 1; i <= daySoLuongS.Length; i++)//Không lố
                daySoLuongExt[i] = daySoLuongS[i - 1];

            //3. Bắt đầu tính
            var indexDayGia = 0;
            //Trường họp số lượng >= số lượng cuối (lớn nhất)
            if (soLuong >= int.Parse(daySoLuongExt[daySoLuongS.Length - 1]))
            {
                indexDayGia = daySoLuongExt.Length - 1;
               
               
            }
            else //chạy từ đầu đến cuối
            {
                //Lặp tiếp chỉ đến phẩn tử kế cuối
                for (int i = 0; i < daySoLuongExt.Length - 1; i++) // chỉ đến kế cuối
                {
                    //Tiếp tục
                    if (int.Parse(daySoLuongExt[i]) <= soLuong && soLuong < int.Parse(daySoLuongS[i + 1]))
                    {
                        indexDayGia = i;
                        break;
                    }
                }
            }
            //Tính toán giá:
            //1. Nếu số lượng vô < số lượng đầu tiên sẽ kết quả tính giá là - 1 vì không chấp nhận
            if (soLuong < int.Parse(daySoLuongS[0]))
                return -1;
            else
              
                kqTinhGia = decimal.Parse(dayGiaS[indexDayGia]) * soLuong;

            return kqTinhGia;
        }*/
        public static decimal GiaGoi3(string daySoLuong, string dayGia, int soLuong)
        {
            ///Đặt số lượng và giá như sau
            ///100, 200, 300, 400, 500
            ///5000, 3000, 2000, 1000, 800
            ///Khi đạt 100 tính 5000, đạt 200 tính 3000, đạt 300 tính 2000 v..v.
            decimal kqTinhGia = 0;

            var daySoLuongS = daySoLuong.Split(';');
            var dayGiaS = dayGia.Split(';');
            //--Tìm khoảng

            //1. Điều kiểm tra mức thấp nhất
            if (soLuong < int.Parse(daySoLuongS[0]))
                return -1; //vô nghĩa
            //2. Nếu không thì kiểm tiếp từ cao tới thấp
            var indexDayGia = 0;

            for (int i = daySoLuongS.Length-1; i >= 0; i--)
                if ( (soLuong - int.Parse(daySoLuongS[i])) >= 0)
                {
                    indexDayGia = i;
                    break;
                }
            

            //3. Tính giá
            
           
            kqTinhGia = decimal.Parse(dayGiaS[indexDayGia]) * soLuong;

            return kqTinhGia;
        }
        public static decimal GiaTheNhua(string daySoLuong, string dayGia, int soLuong)
        {///Dò số lượng lấy giá
            ///Sau đó lấy giá tại khoảng đó nhân số lượng

            int result = 0;

            if (string.IsNullOrEmpty(daySoLuong) || string.IsNullOrEmpty(dayGia) ||
                soLuong <= 0)
                return result;
          
            var giaTheoKhoang = TinhToan.GiaTriTheoKhoang(daySoLuong, dayGia, soLuong);

            result = giaTheoKhoang * soLuong;

            return result;
        }
        public static decimal GiaInNhanhTheoKhoang(BangGiaInNhanh bangGiaInNhanh, int soTrangA4)
        {///Dò số lượng lấy giá
            ///Sau đó lấy giá tại khoảng đó nhân số lượng

            var ketQua = 0;

            if (!bangGiaInNhanh.GiaTheoKhoang)
                return 0;


            var giaTheoKhoang = TinhToan.GiaTriTheoKhoang(bangGiaInNhanh.DaySoLuong,
                bangGiaInNhanh.DayGia, soTrangA4);

            ketQua = giaTheoKhoang * soTrangA4;

            return ketQua;
        }
        public static int SoConTrenToChayDigi(float giayRong, float giayDai,
            float conRong, float conDai )
        {
            if (giayRong <= 0 || giayDai <= 0 ||
                conRong <= 0 || conDai <= 0)
                return 0;

            int kq = 0;
            int a1 = (int)(giayDai / conDai); //Theo chiều dài
            int a2 = (int)(giayRong / conRong);
            int A = a1 * a2;
            int b1 = (int)(giayDai / conRong);
            int b2 = (int)(giayRong / conDai);
            int B = b1 * b2;

            kq = A >= B ? A : B;
            return kq;

        }
    }
}
