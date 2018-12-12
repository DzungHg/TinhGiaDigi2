﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TinhGiaInApp.BDO;
using TinhGiaInClient.Common;
using TinhGiaInApp.Logic;

namespace TinhGiaInClient.Model
{

    public class NiemYetGiaInNhanh
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string DienGiai { get; set; }
        public int IdBangGia { get; set; }
        public int IdHangKhachHang { get; set; }
        public int SoTrangToiDa { get; set; }
        public int ThuTu { get; set; }
        public bool KhongSuDung { get; set; }
        public string DaySoLuongNiemYet { get; set; }
        public string LoaiBangGia { get; set; }//CONTS
        public bool DuocGomTrang { get; set; }

        string _tenMR = "";
        public string TenMR
        {
            get
            {
                if (this.LoaiBangGia.Trim() == Global.cBangGiaLuyTien)
                    _tenMR = string.Format("[L. Tiến] {0}", this.Ten);
                if (this.LoaiBangGia.Trim() == Global.cBangGiaBuoc)
                    _tenMR = string.Format("[Bước] {0}", this.Ten);
                if (this.LoaiBangGia.Trim() == Global.cBangGiaGoi)
                    _tenMR = string.Format("[Gói] {0}", this.Ten);
                return _tenMR;

            }
        }

        string _tenLoaiBG = "";

        public string TenLoaiBangGia
        {
            get
            {
                if (this.LoaiBangGia.Trim() == Global.cBangGiaLuyTien)
                    _tenLoaiBG = "Lũy tiến";
                if (this.LoaiBangGia.Trim() == Global.cBangGiaBuoc)
                    _tenLoaiBG = "Theo Bước";
                if (this.LoaiBangGia.Trim() == Global.cBangGiaGoi)
                    _tenLoaiBG = " Theo Gói";
                return _tenLoaiBG;

            }
        }
        //==
        #region Các hàm static
        public static List<NiemYetGiaInNhanh> DocTatCa()
        {
            var logic = new NiemYetGiaInNhanhLogic();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<NiemYetGiaInNhanhBDO, NiemYetGiaInNhanh>());
            var mapper = config.CreateMapper();
            List<NiemYetGiaInNhanh> nguon = mapper.Map<List<NiemYetGiaInNhanhBDO>, List<NiemYetGiaInNhanh>>(logic.DocTatCa());
            return nguon;
        }
        public static List<NiemYetGiaInNhanh> DocTatCaConDung()
        {
            var nguon = DocTatCa().Where(x => !x.KhongSuDung).OrderBy(x => x.ThuTu);
            return nguon.ToList();
        }

        public static List<NiemYetGiaInNhanh> DocTheoIdHangKHConDung(int idHangKH)
        {
            var logic = new NiemYetGiaInNhanhLogic();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<NiemYetGiaInNhanhBDO, NiemYetGiaInNhanh>());
            var mapper = config.CreateMapper();
            List<NiemYetGiaInNhanh> nguon = mapper.Map<List<NiemYetGiaInNhanhBDO>, List<NiemYetGiaInNhanh>>(logic.DocTatCaConDung());

            return nguon.Where(x => x.IdHangKhachHang == idHangKH).ToList();
        }
        public static List<NiemYetGiaInNhanh> DocTheoIdHangKH(int idHangKH)
        {
            var logic = new NiemYetGiaInNhanhLogic();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<NiemYetGiaInNhanhBDO, NiemYetGiaInNhanh>());
            var mapper = config.CreateMapper();
            List<NiemYetGiaInNhanh> nguon = mapper.Map<List<NiemYetGiaInNhanhBDO>, List<NiemYetGiaInNhanh>>(logic.DocTheoIdHangKH(idHangKH));
            return nguon;
        }
        public static NiemYetGiaInNhanh DocTheoId(int idNiemYetGia)
        {
            var logic = new NiemYetGiaInNhanhLogic();

            var objBDO = logic.DocTheoId(idNiemYetGia);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<NiemYetGiaInNhanhBDO, NiemYetGiaInNhanh>()
                        );
            var mapper = config.CreateMapper();

            var objModel = mapper.Map<NiemYetGiaInNhanh>(objBDO);

            //Trả về
            return objModel;
        }
        #region them sua xoa
        public static string Them(NiemYetGiaInNhanh toInMayDigi)
        {
            var NiemYetGiaInNhanhLogic = new NiemYetGiaInNhanhLogic();
            var itemBDO = new NiemYetGiaInNhanhBDO();

            return NiemYetGiaInNhanhLogic.Them(itemBDO);
        }
        public static bool Sua(ref string thongDiep, NiemYetGiaInNhanh toInMayDigi)
        {
            var NiemYetGiaInNhanhLogic = new NiemYetGiaInNhanhLogic();
            var itemBDO = new NiemYetGiaInNhanhBDO();
            return NiemYetGiaInNhanhLogic.Sua(ref thongDiep, itemBDO);
        }
        #endregion

        #endregion

    }
}
