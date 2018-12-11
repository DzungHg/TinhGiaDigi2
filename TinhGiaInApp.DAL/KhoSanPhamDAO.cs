using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using TinhGiaInApp.BDO;
using TinhGiaInApp.Common;

namespace TinhGiaInApp.DAL
{
    public class KhoSanPhamDAO:IKhoSanPhamDAO
    {
        string tenDB = "QuanLyGiaInDB";

        #region Emplement them sua xoa
        public IEnumerable<KhoSanPhamBDO> DocTatCa()
        {
            IEnumerable<KhoSanPhamBDO> output;
            var str = GlobalConfig.CnnString(tenDB);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                output = connection.Query<KhoSanPhamBDO>("dbo.spKhoSanPham_DocTatCa");
                return output;
            }
        }
       

        public KhoSanPhamBDO DocTheoId(int iD)
        {
            KhoSanPhamBDO output = null;
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                var p = new DynamicParameters();
                p.Add("@i", iD);

                IEnumerable<KhoSanPhamBDO> abc = connection.Query<KhoSanPhamBDO>("dbo.spKhoSanPham_DocTatCa", p);//Thử
                output = abc.SingleOrDefault();
                return output;
            }

           
        }

        public string Them(KhoSanPhamBDO entityBDO)
        {
            string kq = "";
            try
            {
                ;
            }
            catch (Exception e)
            {
                kq = string.Format("Thêm Khổ SP {0} bị lỗi: {1}!", entityBDO.ID, e.Message);
            }
            return kq;
        }

        public string Sua(KhoSanPhamBDO entityBDO)
        {
           
            string kq = "";
            /*if (entity != null)
            {
                try
                {
                  
                }
                catch
                {
                    kq = string.Format(" Sửa record {0} không thành công!", entity.ID);
                }
            }
            else
            {
                return kq = string.Format("Thông tin {0} không tồn tại!", entity.ID);
            }*/
            return kq;
        }

        public string Xoa(int iD)
        {
            throw new NotImplementedException();
        }
        #endregion
   
          private string KiemTraTrung(string tenKho, int id = 0)
          {
              string kq = "";
              /*var entity = db.KHO_SAN_PHAM.SingleOrDefault(x => x.Ten == tenKho );
              if (entity != null && entity.ID != id)
                  kq = string.Format(" Khổ này {0} đã có", tenKho);
                  */
              return kq;
          }
          

    }
}
