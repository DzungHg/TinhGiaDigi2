using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using TinhGiaInApp.Common;
using TinhGiaInApp.BDO;

namespace TinhGiaInApp.DAL
{
    public class HangKhachHangDAO : IHangKhachHangDAO
    {
        string tenDB = "QuanLyGiaInDB";
        public IEnumerable<HangKhachHangBDO> DocTatCa()
        {
            IEnumerable<HangKhachHangBDO> output;
            //var str = GlobalConfig.CnnString(tenDB);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                output = connection.Query<HangKhachHangBDO>("dbo.spHangKhachHang_DocTatCa");
                return output;
            }
        }

        public HangKhachHangBDO DocTheoId(int iD)
        {
            HangKhachHangBDO output = null;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters();
                p.Add("@id", iD);
                output = connection.QueryFirstOrDefault<HangKhachHangBDO>("dbo.spHangKhachHang_DocTheoId", p, commandType: CommandType.StoredProcedure);//Thử              
                return output;
            }
        }

        public void Them(HangKhachHangBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(HangKhachHangBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
