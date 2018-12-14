using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;

namespace TinhGiaInApp.DAL
{
    public interface IHangKhachHangDAO
    {
        IEnumerable<HangKhachHangBDO> DocTatCa();
        HangKhachHangBDO DocTheoId(int iD);
        void Them(HangKhachHangBDO entityBDO);
        void Sua(HangKhachHangBDO entityBDO);
        void Xoa(int iD);     
    }
}
