using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInApp.BDO;
using TinhGiaInApp.DAL;

namespace TinhGiaInApp.Logic
{
    public class LoaiBangGiaLogic
    {
        LoaiBangGiaDAO loaiBangGiaDAO = new LoaiBangGiaDAO();
        public List<LoaiBangGiaBDO> DocTatCa()
        {      
            var nguon = loaiBangGiaDAO.DocTatCa().ToList();
            return nguon;
        }
        public LoaiBangGiaBDO DocTheoTen(string ten)
        {
            var output = this.DocTatCa().Where(x => x.Ten.Trim() == ten.Trim()).SingleOrDefault();
            return output;
        }
    }
}
