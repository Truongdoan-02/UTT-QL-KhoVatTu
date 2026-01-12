using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class SuaKhachhang : Form
    {
        public string MaKH { get; private set; }
        public string TenKH { get; private set; }
        public string GioiTinh { get; private set; }
        public string SDT { get; private set; }
        public string Email { get; private set; }
        public string DiaChi { get; private set; }
        public string TrangThai { get; private set; }
        public string CCCD { get; private set; }
        public SuaKhachhang(string mkh,string ht,string gt,string sdt,string email,string tt, string diachi,string cccd)
        {
            InitializeComponent();
            txtMaKH.Text = mkh;
            txtTenKH.Text = ht;
            cboGioitinh.Text = gt;
            txtSDT.Text = sdt;
            txtEmail.Text = email;
            cboTrangthai.Text = tt;
            txtDiachi.Text = diachi;
            txtCCCD.Text = cccd;
            txtMaKH.ReadOnly = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH.Text.Trim();
            string ht = txtTenKH.Text.Trim();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string dc = txtDiachi.Text.Trim();
            string cccd_val = txtCCCD.Text.Trim();
            if (Thuvien.checkTrong(ht))
            {
                txtTenKH.Focus();
                txtTenKH.Text = "Tên khách hàng không được để trống";
                txtTenKH.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(dt))
            {
                txtSDT.Focus();
                txtSDT.Text = "Số điện thoại không được để trống";
                txtSDT.ForeColor = Color.Red;
                return;
            }
            if (!Thuvien.checkDienThoai(dt))
            {
                txtSDT.Focus();
                txtSDT.Text = "SĐT phải có 10 chữ số và chỉ chứa số";
                txtSDT.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(mail))
            {
                txtEmail.Focus();
                txtEmail.Text = "Email không được để trống";
                txtEmail.ForeColor = Color.Red;
                return;
            }
            if (!Thuvien.checkEmail(mail))
            {
                txtEmail.Focus();
                txtEmail.Text = "Email phải có đuôi @gmail.com";
                txtEmail.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(dc))
            {
                txtDiachi.Focus();
                txtDiachi.Text = "Địa chỉ không được để trống";
                txtDiachi.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(cccd_val))
            {
                txtCCCD.Focus();
                txtCCCD.Text = "CCCD không được để trống";
                txtCCCD.ForeColor = Color.Red;
                return;
            }
            if (!Thuvien.checkCCCD(cccd_val))
            {
                txtCCCD.Focus();
                txtCCCD.Text = "CCCD phải có đúng 12 chữ số";
                txtCCCD.ForeColor = Color.Red;
                return;
            }
            if (cboTrangthai.SelectedItem == null && string.IsNullOrEmpty(cboTrangthai.Text))
            {
                cboTrangthai.Focus();
                cboTrangthai.Text = "Trạng thái không được để trống";
                cboTrangthai.ForeColor = Color.Red;
                return;
            }
            if (cboGioitinh.SelectedItem == null && string.IsNullOrEmpty(cboGioitinh.Text))
            {
                cboGioitinh.Focus();
                cboGioitinh.Text = "Giới tính không được để trống";
                cboGioitinh.ForeColor = Color.Red;
                return;
            }
            MaKH = mkh;
            TenKH = ht;
            GioiTinh = cboGioitinh.Text;
            SDT = dt;
            Email = mail;
            TrangThai = cboTrangthai.Text;
            DiaChi = dc;
            CCCD = cccd_val;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            txtSDT.Text = "";
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            txtCCCD.Text = "";
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
