using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;

namespace TinhGiaInApp.DAL
{
    public interface IBangGiaTheoGoiDAO
    {
        IEnumerable<BangGiaTheoGoiBDO> DocTatCa();
        BangGiaTheoGoiBDO DocTheoId(int iD);
        string Them(BangGiaTheoGoiBDO entityBDO);
        string Sua(BangGiaTheoGoiBDO entityBDO);
        string Xoa(int iD);     
    }
}
