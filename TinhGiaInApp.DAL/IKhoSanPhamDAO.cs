using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;

namespace TinhGiaInApp.DAL
{
    interface IKhoSanPhamDAO
    {
        IEnumerable<KhoSanPhamBDO> DocTatCa();
        KhoSanPhamBDO DocTheoId(int iD);
        string Them(KhoSanPhamBDO entityBDO);
        string Sua(KhoSanPhamBDO entityBDO);
        string Xoa(int iD);     
        
    }
}
