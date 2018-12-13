using System.Collections.Generic;
using AutoMapper;
using TinhGiaInApp.BDO;
using TinhGiaInApp.Logic;

namespace TinhGiaInClient.Model
{
    public class BangGiaTheoGoi: BangGiaBase
    {
        //Thêm ở đây

        //==
        #region Các hàm static
        public static List<BangGiaTheoGoi> DocTatCa()
        {
            var logic = new BangGiaTheoGoiLogic();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaTheoGoiBDO, BangGiaTheoGoi>());
            var mapper = config.CreateMapper();
            List<BangGiaTheoGoi> nguon = mapper.Map<List<BangGiaTheoGoiBDO>, List<BangGiaTheoGoi>>(logic.DocTatCa());
            return nguon;
        }

        public static BangGiaTheoGoi DocTheoId(int idBangGia)
        {
            var logic = new BangGiaTheoGoiLogic();

            var objBDO = logic.DocTheoId(idBangGia);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaTheoGoiBDO, BangGiaTheoGoi>()
                        );
            var mapper = config.CreateMapper();

            var objModel = mapper.Map<BangGiaTheoGoi>(objBDO);

            //Trả về
            return objModel;
        }


        public static string Them(BangGiaTheoGoi bangGia)
        {
            var logic = new BangGiaTheoGoiLogic();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaTheoGoi, BangGiaTheoGoiBDO>());
            var mapper = config.CreateMapper();
            var objBDO = mapper.Map<BangGiaTheoGoiBDO>(bangGia);

            //Thêm
            if (objBDO != null)
            {
                logic.Them(objBDO); //Thành công Mapper được
            }
            return "Đã thêm";
        }
        public static string Sua(BangGiaTheoGoi bangGia)
        {
            var logic = new BangGiaTheoGoiLogic();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BangGiaTheoGoi, BangGiaTheoGoiBDO>());
            var mapper = config.CreateMapper();
            var objBDO = mapper.Map<BangGiaTheoGoiBDO>(bangGia);
            logic.Sua(objBDO);

            return "Sửa xong";
        }
        #endregion

    }
}
