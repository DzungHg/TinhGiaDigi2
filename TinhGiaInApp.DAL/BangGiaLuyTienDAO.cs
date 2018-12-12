using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using TinhGiaInApp.Common;
using TinhGiaInApp.BDO;

namespace TinhGiaInApp.DAL
{
    public class BangGiaLuyTienDAO : IBangGiaLuyTienDAO
    {
        string tenDB = "QuanLyGiaInDB";
        public IEnumerable<BangGiaLuyTienBDO> DocTatCa()
        {
            IEnumerable<BangGiaLuyTienBDO> output;
            //var str = GlobalConfig.CnnString(tenDB);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                output = connection.Query<BangGiaLuyTienBDO>("dbo.spBangGiaLuyTien_DocTatCa");
                return output;
            }
        }


        public BangGiaLuyTienBDO DocTheoId(int iD)
        {
            BangGiaLuyTienBDO output = null;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters();
                p.Add("@id", iD);
                output = connection.QueryFirstOrDefault<BangGiaLuyTienBDO>("dbo.spBangGiaLuyTien_DocTheoId", p, commandType: CommandType.StoredProcedure);//Thử              
                return output;
            }

        }
        #region them, sua, xoa
        public string Them(BangGiaLuyTienBDO entityBDO)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters(); //Của dapper

                p.Add("@Ten", entityBDO.Ten);
                p.Add("@DienGiai", entityBDO.DienGiai);
                p.Add("@DaySoLuong", entityBDO.DaySoLuong);
                p.Add("@DayGia", entityBDO.DayGia);
                p.Add("@DonViTinh", entityBDO.DonViTinh);
                p.Add("@ThuTu", entityBDO.ThuTu);
                p.Add("@KhongCon", entityBDO.KhongCon);
                p.Add("@LoaiBangGia", entityBDO.LoaiBangGia);


                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //Excecute
                connection.Execute("dbo.spBangGiaLuyTien_Them", p, commandType: CommandType.StoredProcedure);
                //xử lý id out
                entityBDO.Id = p.Get<int>("@id");
                ///nếu cần có thể
                ///đặt return ở đay cũng được
            }

            return "Đã thêm";
        }

        public string Sua(BangGiaLuyTienBDO entityBDO)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters(); //Của dapper
                p.Add("@id", entityBDO.Id);
                p.Add("@Ten", entityBDO.Ten);
                p.Add("@DienGiai", entityBDO.DienGiai);
                p.Add("@DaySoLuong", entityBDO.DaySoLuong);
                p.Add("@DayGia", entityBDO.DayGia);
                p.Add("@DonViTinh", entityBDO.DonViTinh);
                p.Add("@ThuTu", entityBDO.ThuTu);
                p.Add("@KhongCon", entityBDO.KhongCon);
                p.Add("@LoaiBangGia", entityBDO.LoaiBangGia);

                connection.Execute("dbo.spBangGiaLuyTien_SuaTheoId", p, commandType: CommandType.StoredProcedure);

            }

            return $"Đã sửa {entityBDO.Id}";
        }

        public string Xoa(int iD)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters(); //Của dapper
                p.Add("@id", iD);


                connection.Execute("dbo.spBangGiaLuyTien_XoaTheoId", p, commandType: CommandType.StoredProcedure);

            }

            return $"Đã sửa {iD}";
        }
        #endregion
    }
}
