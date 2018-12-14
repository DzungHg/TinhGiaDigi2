using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;
using TinhGiaInApp.DAL;

namespace TinhGiaInApp.Logic
{
    public class HangKhachHangLogic
    {
        HangKhachHangDAO hangKhachHangDAO = new HangKhachHangDAO();
        public List<HangKhachHangBDO> DocTatCa()
        {
            var nguon = hangKhachHangDAO.DocTatCa().ToList();
            return nguon;
        }


        public HangKhachHangBDO DocTheoId(int iD)
        {
            return hangKhachHangDAO.DocTheoId(iD);
        }
    }
}
