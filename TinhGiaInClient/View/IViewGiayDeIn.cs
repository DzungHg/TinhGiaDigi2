﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;
using TinhGiaInApp.Common.Enums;

namespace TinhGiaInClient.View
{
    public interface IViewGiayDeIn
    {
        int ID { get; set; }
        int IdBaiIn { get; set; }
        int IdHangKH { get; set; }
        string DienGiaiBaiInVaSoLuong { get; set; }
        string ThongTinBaiIn_CauHinh { get; set; }
        int IdGiay { get; set; }        
        string TenGiayIn { get; set; }
        float GiayLonRong { get; set; }
        float GiayLonCao { get; set; }
        bool GiayKhachDua { get; set; }

        PhuongPhapInS PhuongPhapIn { get; set; }
        float ToChayRong { get; set; }
        float ToChayDai { get; set; }
       
        int SoLuongSanPham { get; set; }
        float  SanPhamRong { get; set; }
        float SanPhamCao { get; set; }
        int SoConTrenToChay { get; set; }
        int SoLuongToChayLyThuyet { get; }
        int SoLuongToChayBuHao { get; set; }
        int SoLuongToChayTong { get; }
        int SoToChayTrenToLon { get; set; }
        decimal GiaBan { get; }
        int SoToGiayLon { get; }
        decimal ThanhTien { get; }
        FormStateS TinhTrangForm { get; set; }
    }
}
