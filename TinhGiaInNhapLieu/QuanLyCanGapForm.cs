﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInNhapLieu.View;
using TinhGiaInNhapLieu.Presenter;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInNhapLieu
{
    public partial class QuanLyCanGapForm : Telerik.WinControls.UI.RadForm, IViewQuanLyCanGap
    {

        public QuanLyCanGapForm()
        {
            InitializeComponent();
            quanLyThanPhamPres = new QuanLyCanGapPresenter(this);
            LoadThanhPham();
           

            lstThanhPham.SelectedIndex = -1;
            lstThanhPham.SelectedIndex = 0;
            //Event
            txtTen.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtBHR.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTocDo.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThoiGianChuanBi.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDonViTinh.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThoiGianTangKhiThemMotDuongCan.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuongCB.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDayLoiNhuanCB.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuongNiemYet.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);
                    
      
            txtBHR.KeyPress += new KeyPressEventHandler(InputValidator);
            txtTocDo.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThoiGianChuanBi.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThoiGianTangKhiThemMotDuongCan.KeyPress += new KeyPressEventHandler(InputValidator);


        }
        QuanLyCanGapPresenter quanLyThanPhamPres;
        #region implementIView
        int _idToInMayDigi = 0;
        public int ID
        {
            get { if (lstThanhPham.SelectedValue != null)
                int.TryParse(lstThanhPham.SelectedValue.ToString(), out _idToInMayDigi) ;
            return _idToInMayDigi;
            }
            set { _idToInMayDigi = value;
            
            }
        }
        public string Ten
        {
            get
            {
                return txtTen.Text;
            }
            set
            {
                txtTen.Text = value;
            }
        }

        public string DonViTinh
        {
            get
            {
                return txtDonViTinh.Text;
            }
            set
            {
                txtDonViTinh.Text = value;
            }
        }

    

        public float ThoiGianChuanBi
        {
            get
            {
                return float.Parse(txtThoiGianChuanBi.Text);
            }
            set
            {
                txtThoiGianChuanBi.Text = value.ToString();
            }
        }
        public int TocDo
        {
            get {
                return int.Parse(txtTocDo.Text);
            }
            set
            {
                txtTocDo.Text = value.ToString();
            }
        }

        public int ThuTu
        {
            get
            {
                return int.Parse(txtThuTu.Text);
            }
            set
            {
                txtThuTu.Text = value.ToString();
            }
        }

       

        public FormStateS TinhTrangForm
        {
            get;
            set;
        }

        public bool DuLieuDaThayDoi
        {
            get;
            set;
        }

        public float ThoiGianTangKhiThemMotDungCan 
        { 
            get {return float.Parse(txtThoiGianTangKhiThemMotDuongCan.Text);}
            set {txtThoiGianTangKhiThemMotDuongCan.Text = value.ToString(); }
        }
        

        public string DaySoLuongCoBan
        {
            get
            {
                return txtDaySoLuongCB.Text;
            }
            set
            {
                txtDaySoLuongCB.Text = value;
            }
        }

        public string DayLoiNhuanCoBan
        {
            get
            {
                return txtDayLoiNhuanCB.Text;
            }
            set
            {
                txtDayLoiNhuanCB.Text = value;
            }
        }

        public string DaySoLuongNiemYet
        {
            get
            {
                return txtDaySoLuongNiemYet.Text;
            }
            set
            {
                txtDaySoLuongNiemYet.Text = value.ToString();
            }
        }

            
        public int BHR
        {
            get
            {
                return int.Parse(txtBHR.Text);
            }
            set
            {
                txtBHR.Text = value.ToString();
            }
        }
        #endregion
        private void LoadThanhPham()
        {

            lstThanhPham.DataSource = quanLyThanPhamPres.ThanhPhamS();
            lstThanhPham.ValueMember = "ID";
            lstThanhPham.DisplayMember = "Ten";                
            
            
        }
       
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTen.ReadOnly = readOnly;
            txtBHR.ReadOnly = readOnly;             
            txtDonViTinh.ReadOnly = readOnly;
            txtTocDo.ReadOnly = readOnly;
            txtThoiGianChuanBi.ReadOnly = readOnly;
            txtThoiGianTangKhiThemMotDuongCan.ReadOnly = readOnly;
            txtDaySoLuongCB.IsReadOnly = readOnly;
            txtDayLoiNhuanCB.IsReadOnly = readOnly;
            txtDaySoLuongNiemYet.ReadOnly = readOnly;
            txtThuTu.ReadOnly = readOnly;
           
          
            
        }
        private void XoaSachNoiDungTatCaTextBox()
        {
            quanLyThanPhamPres.TrinhBayThemMoi();
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                //Xử lý dữ liệu thay đổi
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTen || tb == txtTocDo ||
                    tb == txtBHR || tb == txtThuTu ||
                    tb == txtThoiGianChuanBi || tb == txtDonViTinh ||
                    tb == txtDaySoLuongNiemYet || tb == txtThoiGianTangKhiThemMotDuongCan
                    )
                {
                    this.DuLieuDaThayDoi = true;
                }
                //Xử lý xóa hêt
                if (tb == txtBHR)
                    if (string.IsNullOrEmpty(txtBHR.Text.Trim()))
                        txtBHR.Text = "1";

                if (tb == txtTocDo)
                    if (string.IsNullOrEmpty(txtTocDo.Text.Trim()))
                        txtTocDo.Text = "1";

                if (tb == txtThoiGianChuanBi)
                    if (string.IsNullOrEmpty(txtThoiGianChuanBi.Text.Trim()))
                        txtThoiGianChuanBi.Text = "1";

                if (tb == txtThoiGianTangKhiThemMotDuongCan)
                    if (string.IsNullOrEmpty(txtThoiGianTangKhiThemMotDuongCan.Text.Trim()))
                        txtThoiGianTangKhiThemMotDuongCan.Text = "0";


              

                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        txtThuTu.Text = "0";

            }
            Telerik.WinControls.UI.RadTextBoxControl tbc;
            if (sender is Telerik.WinControls.UI.RadTextBoxControl)
            {
                tbc = (Telerik.WinControls.UI.RadTextBoxControl)sender;

                if (tbc == txtDayLoiNhuanCB || tbc == txtDaySoLuongCB)
                {
                    this.DuLieuDaThayDoi = true;
                }               

            }
            
            btnLuu.Enabled = this.DuLieuDaThayDoi;

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                //Chỉ thêm số chẵn      
                if ( tb == txtThuTu || tb == txtTocDo ||
                    tb == txtBHR   )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (tb == txtThoiGianChuanBi || tb == txtThoiGianTangKhiThemMotDuongCan)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
              
              
               
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu

            //Kiểm tra xong
            var thongDiep = "";
            quanLyThanPhamPres.Luu(ref thongDiep);
            MessageBox.Show(thongDiep);
            //Lưu xong:
            this.DuLieuDaThayDoi = false;
            this.TinhTrangForm =FormStateS.View;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);
            lstThanhPham.Enabled = true;
            LoadThanhPham();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            lstThanhPham.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            XoaSachNoiDungTatCaTextBox();
            this.DuLieuDaThayDoi = false;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
        }

        private void QuanLyMayInDigiFrom_Load(object sender, EventArgs e)
        {
            //Bật tắt các nút
            btnDong.Enabled = true;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.Edit;
            lstThanhPham.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            quanLyThanPhamPres.TrinhBayChiTietMayIn();
            this.DuLieuDaThayDoi = false;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
            lblIDBanGia.Text = this.ID.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnDong.Enabled = true;
            this.DuLieuDaThayDoi = false;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            DatReadOnlyTextBox(true);
            quanLyThanPhamPres.TrinhBayChiTietMayIn();
            lstThanhPham.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnXemMayIn_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyMayInDigiForm(this.TocDo);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý máy in Digital";
            frm.ShowDialog();
        }

        private void cboHangKH_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
        }

        private void btnKiemTraDaySoluongLoiNhuan_Click(object sender, EventArgs e)
        {
            if (!quanLyThanPhamPres.KiemTraDaySoLuongVaLoiNhuan())
                MessageBox.Show("Lỗi!");
            else
                MessageBox.Show("Đã khớp 2 số lượng! OK");
        }










       
    }
}
