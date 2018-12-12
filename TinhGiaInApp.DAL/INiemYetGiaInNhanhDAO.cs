using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;

namespace TinhGiaInApp.DAL
{
    public interface INiemYetGiaInNhanhDAO
    {
        IEnumerable<NiemYetGiaInNhanhBDO> DocTatCa();

        NiemYetGiaInNhanhBDO DocTheoId(int iD);
        string Them(NiemYetGiaInNhanhBDO entityBDO);
        bool Sua(ref string thongDiep, NiemYetGiaInNhanhBDO entityBDO);
        string Xoa(int iD);
    }
}
