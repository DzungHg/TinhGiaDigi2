using System.Collections.Generic;
using AutoMapper;
using TinhGiaInApp.BDO;
using TinhGiaInApp.Logic;

namespace TinhGiaInClient.Model
{
    public class BangGiaTheoBuoc: BangGiaBase
    {
        //Thêm ở đây

        //==
        #region Các hàm static
        public static List<BangGiaTheoBuoc> DocTatCa()
        {
            var logic = new BangGiaTheoBuocLogic();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaTheoBuocBDO, BangGiaTheoBuoc>());
            var mapper = config.CreateMapper();
            List<BangGiaTheoBuoc> nguon = mapper.Map<List<BangGiaTheoBuocBDO>, List<BangGiaTheoBuoc>>(logic.DocTatCa());
            return nguon;
        }

        public static BangGiaTheoBuoc DocTheoId(int idBangGia)
        {
            var logic = new BangGiaTheoBuocLogic();

            var objBDO = logic.DocTheoId(idBangGia);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaTheoBuocBDO, BangGiaTheoBuoc>()
                        );
            var mapper = config.CreateMapper();

            var objModel = mapper.Map<BangGiaTheoBuoc>(objBDO);

            //Trả về
            return objModel;
        }


        public static string Them(BangGiaTheoBuoc bangGia)
        {
            var bangGiaLogic = new BangGiaTheoBuocLogic();
            var itemBDO = new BangGiaTheoBuocBDO();

            return bangGiaLogic.Them(itemBDO);
        }
        public static string Sua(BangGiaTheoBuoc bangGia)
        {
            var bangGiaLogic = new BangGiaTheoBuocLogic();
            var itemBDO = new BangGiaTheoBuocBDO();

            return bangGiaLogic.Sua(itemBDO);
        }
        #endregion

    }
}
