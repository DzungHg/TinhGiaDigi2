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
            var logic = new BangGiaTheoBuocLogic();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaTheoBuoc, BangGiaTheoBuocBDO>());
            var mapper = config.CreateMapper();
            var objBDO = mapper.Map<BangGiaTheoBuocBDO>(bangGia);

            //Thêm
            if (objBDO != null)
            {
                logic.Them(objBDO); //Thành công Mapper được
            }
            return "Đã thêm";
        }
        public static string Sua(BangGiaTheoBuoc bangGia)
        {
            var logic = new BangGiaTheoBuocLogic();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaTheoBuoc, BangGiaTheoBuocBDO>());
            var mapper = config.CreateMapper();
            var objBDO = mapper.Map<BangGiaTheoBuocBDO>(bangGia);
            logic.Sua(objBDO);

            return "Sửa xong";
        }
        #endregion

    }
}
