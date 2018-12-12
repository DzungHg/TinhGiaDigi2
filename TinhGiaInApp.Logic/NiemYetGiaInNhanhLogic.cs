using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;
using TinhGiaInApp.DAL;

namespace TinhGiaInApp.Logic
{
    public class NiemYetGiaInNhanhLogic
    {
        NiemYetGiaInNhanhDAO niemYetGiaInNhanhDAO = new NiemYetGiaInNhanhDAO();
        public List<NiemYetGiaInNhanhBDO> DocTatCa()
        {
            var nguon = niemYetGiaInNhanhDAO.DocTatCa().ToList();
            return nguon;
        }
        public List<NiemYetGiaInNhanhBDO> DocTatCaConDung()
        {
            var nguon = niemYetGiaInNhanhDAO.DocTatCa().Where(x=>x.KhongSuDung == false).ToList();
            return nguon;
        }
        public List<NiemYetGiaInNhanhBDO> DocTheoIdHangKH(int iDHangKH)
        {
            var nguon = niemYetGiaInNhanhDAO.DocTatCa().Where(x => x.IdHangKhachHang == iDHangKH);
            return nguon.ToList();
        }
     
        public NiemYetGiaInNhanhBDO DocTheoId(int iD)
        {
            return niemYetGiaInNhanhDAO.DocTheoId(iD);
        }
        public string Them (NiemYetGiaInNhanhBDO niemYetGiaBDO)
        {
            return niemYetGiaInNhanhDAO.Them(niemYetGiaBDO);
        }
        public bool Sua(ref string thongDiep, NiemYetGiaInNhanhBDO niemYetGiaBDO)
        {
            return niemYetGiaInNhanhDAO.Sua(ref thongDiep, niemYetGiaBDO);
        }
    }
}
