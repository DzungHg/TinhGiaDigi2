﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;

namespace TinhGiaInClient
{
    public partial class GiaInOffsetForm : Form, IViewGiaInOffset
    {
        GiaInOffsetPresenter giaInPres;
        public GiaInOffsetForm(int idHangKH, int soToChay, int idToInDigiChon)
        {
            InitializeComponent();
            //
            this.IdHangKH = idHangKH;
            this.SoToChay = soToChay;
            this.IdToInChon = idToInDigiChon;
            giaInPres = new GiaInOffsetPresenter(this);
            //Nạp bảng giá vô combo
          
            
            //-event            
           
            txtSoLuongToChay.KeyPress += new KeyPressEventHandler(InputValidator);
            rdbMotMat.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);           
            rdbTuTro.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbTuTroNhip.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbAB.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
           
            
        }
        #region implement Iview
        public int ID
        {
            get;
            set;
        }

        public int IdBaiIn
        {
            get;
            set;
        }

        int _kieuIn = 0;
        public int KieuInOffset
        {
            get {
                if (rdbMotMat.Checked)
                    _kieuIn = (int)Enumss.KieuInOffset.MotMat;

                if (rdbTuTro.Checked)
                    _kieuIn = (int)Enumss.KieuInOffset.TuTro;

                if (rdbTuTroNhip.Checked)
                    _kieuIn = (int)Enumss.KieuInOffset.TuTroNhip;

                if (rdbAB.Checked)
                    _kieuIn = (int)Enumss.KieuInOffset.AB;
               
               
                    return _kieuIn;

            }

            set { _kieuIn = value; }
        }

        public int IdHangKH
        {
            get;
            set;
        }
        public int PhiVanChuyen
        {
            get { return int.Parse(txtPhiVanChuyen.Text); }
            set { txtPhiVanChuyen.Text = value.ToString(); }
        }
        public int PhiCanhBai
        {
            get { return int.Parse(txtPhiCanhBai.Text); }
            set { txtPhiCanhBai.Text = value.ToString(); }
        }
        public int TyLeLoiNhuanTheoHangKH { get; set; }
        public int IdToInChon
        {
            get;
            set;
        }
        public int SoToChay
        {
            get { return int.Parse(txtSoLuongToChay.Text); }
            set {txtSoLuongToChay.Text = value.ToString();}
        }
        public string TenHangKH
        {
            get { return txtTenHangKH.Text; }
            set { txtTenHangKH.Text = value; }
        }

       
        public decimal TienIn
        {
            get;
            set;
        }
          
        public int FormState
        {
            get;
            set;
        }

        #endregion
       
        
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                
                
                if (t == txtSoLuongToChay)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
            }
        }
        private void GiaInForm_Load(object sender, EventArgs e)
        {
            
            //Ten hang KH
            if (this.IdHangKH > 0)
                this.TenHangKH = giaInPres.TenHangKH(this.IdHangKH);
            else
                this.TenHangKH = "";
            

            txtToInDigiChon.Text = giaInPres.TenToInOffsetChon();
            rdbTuTroNhip.Checked = true;
            rdbTuTro.Checked = true;
            //Để thủe
            if (this.FormState == (int)Enumss.FormState.View)
            {
                txtSoLuongToChay.Enabled = true;
                txtSoLuongToChay.ReadOnly = false;
            }
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            
        }
       
        private void TextBoxes_TextedChanged(object sender, EventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoLuongToChay)//
                {
                    decimal giaTBTrang = 0;
                    this.TienIn = giaInPres.TinhGiaCuoiCung(ref giaTBTrang);
                    lblThanhTien.Text = string.Format("{0:0,0.00}đ ", this.TienIn);
                
                }

            }
            
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();
           
            if (string.IsNullOrEmpty(txtSoLuongToChay.Text))
                loiS.Add("Số lượng A4 có thể = 0 nhưng không thể rỗng");
            

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }
        private void RadioButtons_CheckChanged(object sender, EventArgs e)
        {
            
           
        }
        private void GiaInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ms = "";
            if (!KiemTraHopLe(ref ms))
            {
                var dialogeR = MessageBox.Show(ms, "Dữ liệu điền chưa chuẩn đó! Điền tiếp?",
                     MessageBoxButtons.YesNo);
                if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
                else

                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void cboBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.TyLeLoiNhuanTheoHangKH = giaInPres.TyLeLoiNhuanTheoHangKH();
            
        }


        
    }
}
