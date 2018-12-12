using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;

namespace TinhGiaInApp.DAL
{
    public interface IBangGiaTheoBuocDAO
    {
        IEnumerable<BangGiaTheoBuocBDO> DocTatCa();
        BangGiaTheoBuocBDO DocTheoId(int iD);
        string Them(BangGiaTheoBuocBDO entityBDO);
        string Sua(BangGiaTheoBuocBDO entityBDO);
        string Xoa(int iD);     
    }
}
