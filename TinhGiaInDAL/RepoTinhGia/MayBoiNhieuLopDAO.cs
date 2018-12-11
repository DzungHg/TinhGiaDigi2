﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class MayBoiNhieuLopDAO : IMayBoiNhieuLopDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<MayBoiNhieuLopBDO> DocTatCa()
        {
            List<MayBoiNhieuLopBDO> list = null;
            try
            {
                var nguon = db.MAY_BOI_NHIEU_LOP.Select(x => new MayBoiNhieuLopBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    DienGiai = x.dien_giai,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.thoi_gian_chuan_bi,
                    TocDoTamGio = (int)x.toc_do_tam_gio,
                    PhiKeoMetVuong = (int)x.phi_keo_met_vuong,   
                    DaySoLuong = x.day_so_luong,
                    DayLoiNhuan = x.day_loi_nhuan,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    Ma_01 = x.ma_01,                    
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public MayBoiNhieuLopBDO DocTheoId(int iD)
        {
            MayBoiNhieuLopBDO dm = null;
            try
            {
                var nguon = db.MAY_BOI_NHIEU_LOP.Where(x => x.ID == iD).Select(x => new MayBoiNhieuLopBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    DienGiai = x.dien_giai,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.thoi_gian_chuan_bi,
                    TocDoTamGio = (int)x.toc_do_tam_gio,
                    PhiKeoMetVuong = (int)x.phi_keo_met_vuong,                   
                    DaySoLuong = x.day_so_luong,
                    DayLoiNhuan = x.day_loi_nhuan,
                    Ma_01 = x.ma_01,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,                    
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                dm = nguon;
            }
            catch { }

            return dm;
        }
        #region Them, sưa, xoa
        public string Them(MayBoiNhieuLopBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                MAY_BOI_NHIEU_LOP entity = new MAY_BOI_NHIEU_LOP();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.MAY_BOI_NHIEU_LOP.Add(entity);
                db.SaveChanges();
                kq = string.Format("Mục tin:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Mục tin {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(MayBoiNhieuLopBDO entityBDO)
        {
            MAY_BOI_NHIEU_LOP entity = db.MAY_BOI_NHIEU_LOP.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
            var kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kq != "")
                        return kq;

                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Lưu mục tin {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    kq = string.Format("Sửa mục tin {0} không thành công!", entity.ID);
                }
            }
            else
            {
                return kq = string.Format("Mục tin {0} không tồn tại!", entity.ID);
            }
            return kq;
        }

        public string Xoa(int iD)
        {
            throw new NotImplementedException();
        }
        private string KiemTraTrung(string value, int id = 0)
        {
            string kq = "";
            var entity = db.MAY_BOI_NHIEU_LOP.SingleOrDefault(x => x.ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(MayBoiNhieuLopBDO entityBDO, MAY_BOI_NHIEU_LOP entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.dien_giai = entityBDO.DienGiai;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.toc_do_tam_gio = entityBDO.TocDoTamGio;
            entityDAO.phi_keo_met_vuong = entityBDO.PhiKeoMetVuong;
            entityDAO.thoi_gian_chuan_bi = entityBDO.ThoiGianChuanBi;
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.day_loi_nhuan = entityBDO.DayLoiNhuan;
            entityDAO.ma_01 = entityBDO.Ma_01;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;            
            entityDAO.thu_tu = entityBDO.ThuTu;
        }
        #endregion
    }
}
