using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;
using TinhGiaInApp.DAL;

namespace TinhGiaInApp.Logic
{
    public class KhoSanPhamLogic
    {
        KhoSanPhamDAO khoSanPhamDAO = new KhoSanPhamDAO();
        public List<KhoSanPhamBDO> DocTatCa()
        {      
            var nguon = khoSanPhamDAO.DocTatCa().ToList();
            return nguon;
        }
        public KhoSanPhamBDO DocTheoId(int iD)
        {
            return khoSanPhamDAO.DocTheoId(iD);
        }
        public string Them(KhoSanPhamBDO khoSanPham)
        {
            return khoSanPhamDAO.Them(khoSanPham);
        }
        public string Sua(KhoSanPhamBDO khoSanPham)
        {
            return khoSanPhamDAO.Sua(khoSanPham);
        }
    }
}
