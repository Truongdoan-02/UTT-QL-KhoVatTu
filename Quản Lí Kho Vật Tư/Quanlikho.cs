using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Quanlikho : Form
    {
        public Quanlikho()
        {
            InitializeComponent();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mavt = tkMavt.Text.Trim();
            string tenvt = tkTenvt.Text.Trim();
            string loaivt = tkLoaivt.Text.Trim();
            string mancc = tkNhacungcap.Text.Trim();

            Thuvien.load_KH(dgvQL_Kho, "Select k.Mavattu, k.Tenvattu, k.Loaivattu, n.Tendoitac, k.Donvitinh, k.Soluong, k.Gianhap, k.Ghichu FROM QL_Kho k JOIN Doitac_NCC n ON k.Madoitac = n.Madoitac where k.Mavattu like '%" + mavt + "%' " +
            "and k.Tenvattu like '%" + tenvt + "%' and k.Loaivattu like '%" + loaivt + "%' and k.Madoitac like '%" + mancc + "%'");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string loaivt;
            string ncc;
            string dvt;
            
            if (cboLoaivt.SelectedItem == null)
                loaivt = "";
            else
                loaivt = cboLoaivt.SelectedItem.ToString();

            if (cboNhacungcap.SelectedItem == null)
                ncc = "";
            else
                ncc = cboNhacungcap.SelectedItem.ToString();

            if (cboDonvt.SelectedItem == null)
                dvt = "";
            else
                dvt = cboDonvt.SelectedItem.ToString();

            if (Thuvien.checkTrong(txtMavt.Text.Trim()))
            {
                txtMavt.Focus();
                lbMavt.Text = "Mã vật tư không được để trống";
                lbMavt.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(txtTenvt.Text.Trim()))
            {
                txtTenvt.Focus();
                lbTenvt.Text = "Tên vật tư không được để trống";
                lbTenvt.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(loaivt))
            {
                cboLoaivt.Focus();
                lbLoaivt.Text = "Loại vật tư không được để trống";
                lbLoaivt.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(ncc))
            {
                cboNhacungcap.Focus();
                lbNcc.Text = "Nhà cung cấp không được để trống";
                lbNcc.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(dvt))
            {
                cboDonvt.Focus();
                lbDonvt.Text = "Đơn vị tính không được để trống";
                lbDonvt.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(txtSoluong.Text.Trim()))
            {
                txtSoluong.Focus();
                lbSoluong.Text = "Số lượng không được để trống";
                lbSoluong.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(txtGianhap.Text.Trim()))
            {
                txtGianhap.Focus();
                lbGianhap.Text = "Giá nhập không được để trống";
                lbGianhap.ForeColor = Color.Red;
                return;
            }
            

            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            string sql = "Insert into QL_Kho values (@mavt,@tenvt,@loaivt,@mancc,@dvt,@sl,@gn,@gc)";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.Add("@mavt", SqlDbType.VarChar, 50).Value = txtMavt.Text.Trim();
            cmd.Parameters.Add("@tenvt", SqlDbType.NVarChar, 100).Value = txtTenvt.Text.Trim();
            cmd.Parameters.Add("@loaivt", SqlDbType.NVarChar, 100).Value = cboLoaivt.SelectedItem.ToString();
            cmd.Parameters.Add("@mancc", SqlDbType.NVarChar, 50).Value = cboNhacungcap.SelectedValue;
            cmd.Parameters.Add("@dvt", SqlDbType.NVarChar, 50).Value = cboDonvt.SelectedItem.ToString();
            cmd.Parameters.Add("@sl", SqlDbType.Int).Value = int.Parse(txtSoluong.Text.Trim());
            cmd.Parameters.Add("@gn", SqlDbType.Decimal).Value = decimal.Parse(txtGianhap.Text.Trim());
            cmd.Parameters.Add("@gc", SqlDbType.NVarChar, 500).Value = txtGhichu.Text.Trim();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Thuvien.con.Close();
            MessageBox.Show("Thêm mới thành công");
            Load_Kho();
        }

        private void Quanlikho_Load(object sender, EventArgs e)
        {
            Load_Kho();
            Load_Nhacungcap();
            Load_TKNhacungcap();
        }
        private void Load_Kho()
        {
            string sql =
           "SELECT k.Mavattu, k.Tenvattu, k.Loaivattu, n.Tendoitac, k.Donvitinh, k.Soluong, k.Gianhap, k.Ghichu FROM QL_Kho k JOIN Doitac_NCC n ON k.Madoitac = n.Madoitac";

            Thuvien.load_KH(dgvQL_Kho, sql);
        }
        private void Load_Nhacungcap()
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = "SELECT Madoitac, Tendoitac FROM Doitac_NCC";
            SqlDataAdapter da = new SqlDataAdapter(sql, Thuvien.con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            // Thêm dòng mặc định
            DataRow r = tb.NewRow();
            r["Madoitac"] = "";
            r["Tendoitac"] = "-- Chọn nhà cung cấp --";
            tb.Rows.InsertAt(r, 0);

            cboNhacungcap.DataSource = tb;
            cboNhacungcap.DisplayMember = "Tendoitac";
            cboNhacungcap.ValueMember = "Madoitac";
            cboNhacungcap.SelectedIndex = 0;

            

            Thuvien.con.Close();
        }
        private void Load_TKNhacungcap()
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = "SELECT Madoitac, Tendoitac FROM Doitac_NCC";
            SqlDataAdapter da = new SqlDataAdapter(sql, Thuvien.con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            // Thêm dòng mặc định
            DataRow r = tb.NewRow();
            r["Madoitac"] = "";
            r["Tendoitac"] = "-- Chọn nhà cung cấp --";
            tb.Rows.InsertAt(r, 0);

            

            tkNhacungcap.DataSource = tb;
            tkNhacungcap.DisplayMember = "Tendoitac";
            tkNhacungcap.ValueMember = "Madoitac";
            tkNhacungcap.SelectedIndex = 0;

            Thuvien.con.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mavt = txtMavt.Text.Trim();
            string tenvt = txtTenvt.Text.Trim();
            string loaivt = cboLoaivt.SelectedItem.ToString();
            string mancc = cboNhacungcap.SelectedValue.ToString();
            string dvt = cboDonvt.SelectedItem.ToString();
            string sl = txtSoluong.Text.Trim();
            string gn = txtGianhap.Text.Trim();
            string gc = txtGhichu.Text.Trim();
            Thuvien.upd_del("UPDATE QL_Kho SET Tenvattu=N'" + tenvt + "',Loaivattu=N'" + loaivt + "',Madoitac='" + mancc + "',Donvitinh=N'" + dvt + "',Soluong ='" + sl + "',Gianhap='" + gn + "',Ghichu=N'" + gc + "' where Mavattu='" + mavt + "'");
            Thuvien.load_KH(dgvQL_Kho, "SELECT k.Mavattu, k.Tenvattu, k.Loaivattu, n.Tendoitac, k.Donvitinh, k.Soluong, k.Gianhap, k.Ghichu FROM QL_Kho k JOIN Doitac_NCC n ON k.Madoitac = n.Madoitac");
            MessageBox.Show("Cập nhật thành công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mavt = txtMavt.Text.Trim();
            DialogResult kq = MessageBox.Show("Ban chac chan muon xoa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            Thuvien.upd_del("DELETE FROM QL_KHO WHERE Mavattu='" + mavt + "'");
            Thuvien.load_KH(dgvQL_Kho, "SELECT k.Mavattu, k.Tenvattu, k.Loaivattu, n.Tendoitac, k.Donvitinh, k.Soluong, k.Gianhap, k.Ghichu FROM QL_Kho k JOIN Doitac_NCC n ON k.Madoitac = n.Madoitac");
            MessageBox.Show("Xóa thành công");
        }

        
    }
}
