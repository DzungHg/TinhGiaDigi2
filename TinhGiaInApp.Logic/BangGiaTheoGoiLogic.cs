using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;
using TinhGiaInApp.DAL;

namespace TinhGiaInApp.Logic
{
    public class BangGiaTheoGoiLogic
    {
        BangGiaTheoGoiDAO bangGiaDAO = new BangGiaTheoGoiDAO();
        public List<BangGiaTheoGoiBDO> DocTatCa()
        {
            var nguon = bangGiaDAO.DocTatCa().ToList();
            return nguon;
        }
       
        public BangGiaTheoGoiBDO DocTheoId(int iD)
        {
            return bangGiaDAO.DocTheoId(iD);
        }
        public string Them(BangGiaTheoGoiBDO bangGiaBDO)
        {
            return bangGiaDAO.Them(bangGiaBDO);
        }
        public string Sua(BangGiaTheoGoiBDO bangGiaBDO)
        {
            return bangGiaDAO.Sua(bangGiaBDO);
        }
    }
}
