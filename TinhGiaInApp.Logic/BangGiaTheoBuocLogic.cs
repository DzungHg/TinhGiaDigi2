using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;
using TinhGiaInApp.DAL;

namespace TinhGiaInApp.Logic
{
    public class BangGiaTheoBuocLogic
    {
        BangGiaTheoBuocDAO bangGiaDAO = new BangGiaTheoBuocDAO();
        public List<BangGiaTheoBuocBDO> DocTatCa()
        {
            var nguon = bangGiaDAO.DocTatCa().ToList();
            return nguon;
        }
       
        public BangGiaTheoBuocBDO DocTheoId(int iD)
        {
            return bangGiaDAO.DocTheoId(iD);
        }
        public string Them(BangGiaTheoBuocBDO bangGiaBDO)
        {
            return bangGiaDAO.Them(bangGiaBDO);
        }
        public string Sua(BangGiaTheoBuocBDO bangGiaBDO)
        {
            return bangGiaDAO.Sua(bangGiaBDO);
        }
    }
}
