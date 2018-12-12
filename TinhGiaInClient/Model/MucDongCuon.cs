﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.Common.Enums;

namespace TinhGiaInClient.Model
{ ///Mục đóng cuốn này gồm keo, kim, nẹp vít
    public class MucDongCuon: MucThanhPham
    {           
        public KieuDongCuonS KieuDongCuon { get; set; }
        public float GayCao { get; set; }
        public float GayDay { get; set; }
        public string TieuDe { get; set; }
      
      
    }
}
