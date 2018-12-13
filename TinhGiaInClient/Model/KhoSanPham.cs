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
    public class KhoSanPham
    {
        //Class
        public int ID { get; set; }
        public string Ten { get; set; }
        public float KhoCatRong { get; set; }
        public float KhoCatCao { get; set; }
        public string DienGiai { get; set; }
        public float TranLeTren { get; set; }
        public float TranLeDuoi { get; set; }
        public float TranLeTrong { get; set; }
        public float TranLeNgoai { get; set; }
        public int ThuTu { get; set; }  
   //Hàm static
        public static List<KhoSanPham> DocTatCa()
        {
            //Xài automapper
            var logic = new KhoSanPhamLogic();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<KhoSanPhamBDO, KhoSanPham>());
            var mapper = config.CreateMapper();
            List<KhoSanPham> nguon = mapper.Map<List<KhoSanPhamBDO>, List<KhoSanPham>>(logic.DocTatCa());
            return nguon;
           
        }
        public static KhoSanPham DocTheoId(int iD)
        {
            var logic = new KhoSanPhamLogic();

            var objBDO = logic.DocTheoId(iD);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<KhoSanPhamBDO, KhoSanPham>()
                        );
            var mapper = config.CreateMapper();

            var objModel = mapper.Map<KhoSanPham>(objBDO);

            //Trả về
            return objModel;
        }

        //-TODO-- Đổi qua automap không cần 
        #region them, sua
        public static string Them(KhoSanPham item)
        {
            var logic = new KhoSanPhamLogic();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<KhoSanPham, KhoSanPhamBDO>());
            var mapper = config.CreateMapper();
            var objBDO = mapper.Map<KhoSanPhamBDO>(item);
           
            //Thêm
            if (objBDO != null)
            {
                logic.Them(objBDO); //Thành công Mapper được
            }
            return "";
        }

        public static string Sua(KhoSanPham item)
        {
            var logic = new KhoSanPhamLogic();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<KhoSanPham, KhoSanPhamBDO>());
            var mapper = config.CreateMapper();
            var objBDO = mapper.Map<KhoSanPhamBDO>(item);
            logic.Sua(objBDO);
            return "Sửa xong";
        }
        #endregion

      
        
    }
}
