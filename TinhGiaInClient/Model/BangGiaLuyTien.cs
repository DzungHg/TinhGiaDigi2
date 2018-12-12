using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TinhGiaInApp.BDO;
using TinhGiaInApp.Logic;

namespace TinhGiaInClient.Model
{
    public class BangGiaLuyTien: BangGiaBase
    {
        //Thêm ở đây
       
        //==
        #region Các hàm static
        public static List<BangGiaLuyTien> DocTatCa()
        {
            var logic = new BangGiaLuyTienLogic();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaLuyTienBDO, BangGiaLuyTien>());
            var mapper = config.CreateMapper();
            List<BangGiaLuyTien> nguon = mapper.Map<List<BangGiaLuyTienBDO>, List<BangGiaLuyTien>>(logic.DocTatCa());
            return nguon;
        }

        public static BangGiaLuyTien DocTheoId(int idBangGia)
        {
            var logic = new BangGiaLuyTienLogic();

            var objBDO = logic.DocTheoId(idBangGia);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaLuyTienBDO, BangGiaLuyTien>()
                        );
            var mapper = config.CreateMapper();

            var objModel = mapper.Map<BangGiaLuyTien>(objBDO);

            //Trả về
            return objModel;
        }

        
        public static string Them(BangGiaLuyTien bangGia)
        {
            var bangGiaLogic = new BangGiaLuyTienLogic();
            var itemBDO = new BangGiaLuyTienBDO();
            
            return bangGiaLogic.Them(itemBDO);
        }
        public static string Sua(BangGiaLuyTien bangGia)
        {
            var bangGiaLogic = new BangGiaLuyTienLogic();
            var itemBDO = new BangGiaLuyTienBDO();
            
            return bangGiaLogic.Sua(itemBDO);
        }
        #endregion
       
        

    }
}
