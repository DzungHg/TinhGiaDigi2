using System.Collections.Generic;
using System.Linq;
using TinhGiaInApp.BDO;
using TinhGiaInApp.DAL;
namespace TinhGiaInApp.Logic
{
    public class BangGiaLuyTienLogic
    {
        BangGiaLuyTienDAO bangGiaDAO = new BangGiaLuyTienDAO();
        public List<BangGiaLuyTienBDO> DocTatCa()
        {
            var nguon = bangGiaDAO.DocTatCa().ToList();
            return nguon;
        }
       
        public BangGiaLuyTienBDO DocTheoId(int iD)
        {
            return bangGiaDAO.DocTheoId(iD);
        }
        public string Them(BangGiaLuyTienBDO bangGiaBDO)
        {
            return bangGiaDAO.Them(bangGiaBDO);
        }
        public string Sua(BangGiaLuyTienBDO bangGiaBDO)
        {
            return bangGiaDAO.Sua(bangGiaBDO);
        }
    }
}
