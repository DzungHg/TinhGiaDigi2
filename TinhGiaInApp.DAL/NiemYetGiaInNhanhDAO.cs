using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TinhGiaInApp.Common;
using Dapper;
using TinhGiaInApp.BDO;

namespace TinhGiaInApp.DAL
{
    public class NiemYetGiaInNhanhDAO : INiemYetGiaInNhanhDAO
    {
        string tenDB = "QuanLyGiaInDB";
        public IEnumerable<NiemYetGiaInNhanhBDO> DocTatCa()
        {
            IEnumerable<NiemYetGiaInNhanhBDO> output;
            //var str = GlobalConfig.CnnString(tenDB);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                output = connection.Query<NiemYetGiaInNhanhBDO>("dbo.spNiemYetGiaInNhanh_DocTatCa");
                return output;
            }

        }


        public NiemYetGiaInNhanhBDO DocTheoId(int iD)
        {
            NiemYetGiaInNhanhBDO output = null;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters();
                p.Add("@id", iD);
                output = connection.QueryFirstOrDefault<NiemYetGiaInNhanhBDO>("dbo.spNiemYetGiaInNhanh_DocTheoId", p, commandType: CommandType.StoredProcedure);//Thử              
                return output;
            }
        }

        public string Them(NiemYetGiaInNhanhBDO entityBDO)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters(); //Của dapper

                p.Add("@Ten", entityBDO.Ten);
                p.Add("@DienGiai", entityBDO.DienGiai);
                p.Add("@IdHangKhachHang", entityBDO.IdHangKhachHang);
                p.Add("@IdBangGia", entityBDO.IdBangGia);
                p.Add("@SoTrangToiDa", entityBDO.SoTrangToiDa);
                p.Add("@ThuTu", entityBDO.ThuTu);
                p.Add("@KhongSuDung", entityBDO.KhongSuDung);
                p.Add("@DaySoLuongNiemYet", entityBDO.DaySoLuongNiemYet);
                p.Add("@LoaiBangGia", entityBDO.LoaiBangGia);
                p.Add("@DuocGomTrang", entityBDO.DuocGomTrang);

                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //Excecute
                connection.Execute("dbo.spNiemYetGiaInNhanh_Them", p, commandType: CommandType.StoredProcedure);
                //xử lý id out
                entityBDO.Id = p.Get<int>("@id");
                ///nếu cần có thể
                ///đặt return ở đay cũng được
            }

            return "Đã thêm";
        }

        public bool Sua(ref string thongDiep, NiemYetGiaInNhanhBDO entityBDO)
        {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters(); //Của dapper
                p.Add("@id", entityBDO.Id);
                p.Add("@Ten", entityBDO.Ten);
                p.Add("@DienGiai", entityBDO.DienGiai);
                p.Add("@IdHangKhachHang", entityBDO.IdHangKhachHang);
                p.Add("@IdBangGia", entityBDO.IdBangGia);
                p.Add("@SoTrangToiDa", entityBDO.SoTrangToiDa);
                p.Add("@ThuTu", entityBDO.ThuTu);
                p.Add("@KhongSuDung", entityBDO.KhongSuDung);
                p.Add("@DaySoLuongNiemYet", entityBDO.DaySoLuongNiemYet);
                p.Add("@LoaiBangGia", entityBDO.LoaiBangGia);
                p.Add("@DuocGomTrang", entityBDO.DuocGomTrang);

                //Excecute
                connection.Execute("dbo.spNiemYetGiaInNhanh_SuaTheoId", p, commandType: CommandType.StoredProcedure);

            }
            thongDiep = "Đã sửa";
            return true;
        }
        public string Xoa(int iD)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters(); //Của dapper
                p.Add("@id", iD);

                //Excecute
                connection.Execute("dbo.spNiemYetGiaInNhanh_XoaTheoId", p, commandType: CommandType.StoredProcedure);

            }
            return "Đã xóa";
        }


    }
}
