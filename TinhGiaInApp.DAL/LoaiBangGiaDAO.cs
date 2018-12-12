using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using TinhGiaInApp.BDO;
using TinhGiaInApp.Common;

namespace TinhGiaInApp.DAL
{
    public class LoaiBangGiaDAO
    {
        string tenDB = "QuanLyGiaInDB";

       
        public IEnumerable<LoaiBangGiaBDO> DocTatCa()
        {
            IEnumerable<LoaiBangGiaBDO> output;
            //var str = GlobalConfig.CnnString(tenDB);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(tenDB)))
            {
                output = connection.Query<LoaiBangGiaBDO>("dbo.spLoaiBangGia_DocTatCa");
                return output;
            }
        }
       

    }
}
