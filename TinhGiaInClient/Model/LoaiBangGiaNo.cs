using System.Collections.Generic;
using AutoMapper;
using TinhGiaInApp.BDO;
using TinhGiaInApp.Logic;

namespace TinhGiaInClient.Model
{
    public class LoaiBangGiaNo
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        //---
        public static List<LoaiBangGiaNo> DocTatCa()
        {
            //Xài automapper
            var logic = new LoaiBangGiaLogic();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LoaiBangGiaBDO, LoaiBangGiaNo>());
            var mapper = config.CreateMapper();
            List<LoaiBangGiaNo> nguon = mapper.Map<List<LoaiBangGiaBDO>, List<LoaiBangGiaNo>>(logic.DocTatCa());
            return nguon;

        }
        public static LoaiBangGiaNo DocTheoTen(string ten)
        {
            var logic = new LoaiBangGiaLogic();

            var objBDO = logic.DocTheoTen(ten);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<LoaiBangGiaBDO, LoaiBangGiaNo>()
                        );
            var mapper = config.CreateMapper();

            var objModel = mapper.Map<LoaiBangGiaNo>(objBDO);

            //Trả về
            return objModel;
        }
    }
}
