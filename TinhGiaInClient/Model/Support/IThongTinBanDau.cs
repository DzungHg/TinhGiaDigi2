﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.Common.Enums;

namespace TinhGiaInClient.Model.Support
{
    public interface IThongTinBanDau
    {
        string ThongDiepCanThiet { get; set; }
        FormStateS TinhTrangForm { get; set; }

        string TieuDeForm { get; set; }
      
       
     
       
    }
}
