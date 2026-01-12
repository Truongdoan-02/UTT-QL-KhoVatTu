using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ex_cel = Microsoft.Office.Interop.Excel;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Doitac_Khachhang : Form
    {
        public Doitac_Khachhang()
        {
            InitializeComponent();
        }
        public DataGridView DgvKH => dgvKH;

        private void Doitac_Khachhang_Load(object sender, EventArgs e)
        {
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKH.CurrentRow == null) return;
            int i = dgvKH.CurrentRow.Index;
            if (i < 0) return;
            string mkh = dgvKH.Rows[i].Cells["MaKH"].Value?.ToString();

            DialogResult kq = MessageBox.Show("Ban chac chan muon xoa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            Thuvien.upd_del("Delete from Khachhang where Makhachhang='" + mkh + "'");
            MessageBox.Show("Xoa thanh cong");
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH_tk.Text.Trim();
            string ht = txtTenKH_tk.Text.Trim();
            string sdt = txtSDT_tk.Text.Trim();
            string tt = cboTrangthai_tk.Text.Trim();
            Thuvien.load_KH(dgvKH, "Select * from Khachhang where Makhachhang like '%" + mkh + "%' and " +
                "Tenkhachhang like N'%" + ht + "%' and " +
                "SDT like N'%" + sdt + "%' and " +
                "Trangthai like N'%" + tt + "%'");
        }

        private void btnXuatExcel_Click_1(object sender, EventArgs e)
        {
            using (FileExcecl_KH f = new FileExcecl_KH())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    Thuvien.load_KH(dgvKH, "Select * from Khachhang");
                }
            }
        }
        public void ExportExcel(DataTable tb, string sheetname)
        {
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbooks oBooks;
            ex_cel.Sheets oSheets;
            ex_cel.Workbook oBook;
            ex_cel.Worksheet oSheet;
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (ex_cel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (ex_cel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;
            ex_cel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH KHÁCH HÀNG";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ KHÁCH HÀNG";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN KHÁCH HÀNG";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "GIỚI TÍNH";
            cl4.ColumnWidth = 15.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "ĐIỆN THOẠI";
            cl5.ColumnWidth = 20.0;

            ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "EMAIL";
            cl6.ColumnWidth = 40.0;

            ex_cel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "TRẠNG THÁI";
            cl7.ColumnWidth = 20.0;

            ex_cel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "ĐỊA CHỈ";
            cl8.ColumnWidth = 50.0;

            ex_cel.Range cl9 = oSheet.get_Range("K3", "K3");
            cl9.Value2 = "CCCD";
            cl9.ColumnWidth = 20.0;

            ex_cel.Range rowHead = oSheet.get_Range("A3", "K3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];

            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    if (c == 4 || c == 8)
                        arr[r, c] = "'" + dr[c];
                    else
                        arr[r, c] = dr[c];

                }
            }

            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, columnStart];
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, columnEnd];
            ex_cel.Range range = oSheet.get_Range(c1, c2);
            range.Value2 = arr;

            range.Borders.LineStyle = ex_cel.Constants.xlSolid;
            ex_cel.Range c3 = (ex_cel.Range)oSheet.Cells[rowEnd, columnStart];
            ex_cel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            ex_cel.Range cl_ngs = oSheet.get_Range("D" + rowStart, "D" + rowEnd);
            cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";

        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH_tk.Text.Trim();
            string ht = txtTenKH_tk.Text.Trim();
            string sdt = txtSDT_tk.Text.Trim();
            string tt = cboTrangthai_tk.Text.Trim();
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            string sql = "Select ROW_NUMBER() over(order by Makhachhang) STT,* from Khachhang where Makhachhang like '%" + mkh + "%' and " +
                "Tenkhachhang like N'%" + ht + "%' and " +
                "SDT like N'%" + sdt + "%' and " +
                "Trangthai like N'%" + tt + "%'";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            Thuvien.con.Close();
            ExportExcel(tb, "DSDoitac");
        }

        private void nhàCungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Doitac_NCC f = new Doitac_NCC();

            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void sẢNPHẢMDỊCHVỤToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Sanphamdichvu f = new Sanphamdichvu();

            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void tỒNKHOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Quanlikho f = new Quanlikho();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void nHẬPKHOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Nhapkho f = new Nhapkho();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void xUẤTKHOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Xuatkho f = new Xuatkho();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void qUẢNLÍTHUCHIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Quanlithuchi f = new Quanlithuchi();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void dANHSÁCHNHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Danhsachnhanvien f = new Danhsachnhanvien();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void lỊCHLÀMVIỆCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Lichlamviec f = new Lichlamviec();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void dgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;
            string mkh = Convert.ToString(dgvKH.Rows[i].Cells["MaKH"].Value);
            string ht = Convert.ToString(dgvKH.Rows[i].Cells["Hoten"].Value);
            string gt = Convert.ToString(dgvKH.Rows[i].Cells["Gioitinh"].Value);
            string sdt = Convert.ToString(dgvKH.Rows[i].Cells["SDT"].Value);
            string email = Convert.ToString(dgvKH.Rows[i].Cells["Email"].Value);
            string tt = Convert.ToString(dgvKH.Rows[i].Cells["Trangthai"].Value);
            string diachi = Convert.ToString(dgvKH.Rows[i].Cells["Diachinhanhang"].Value);
            string cccd = Convert.ToString(dgvKH.Rows[i].Cells["CCCD"].Value);

            using (SuaKhachhang dlg = new SuaKhachhang(mkh, ht, gt, sdt, email, tt, diachi, cccd))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    mkh = dlg.MaKH;
                    ht = dlg.TenKH;
                    gt = dlg.GioiTinh;
                    sdt = dlg.SDT;
                    email = dlg.Email;
                    tt = dlg.TrangThai;
                    diachi = dlg.DiaChi;
                    cccd = dlg.CCCD;
                    Thuvien.upd_del("Update Khachhang set Tenkhachhang=N'" + ht + "',Gioitinh=N'" + gt + "',SDT='" + sdt + "',Email='" + email + "',Trangthai=N'" + tt + "',Diachinhanhang=N'" + diachi + "',CCCD=N'" + cccd + "' where Makhachhang='" + mkh + "'");
                    Thuvien.load_KH(dgvKH, "Select* from Khachhang");

                }
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            ThemKhachhang f = new ThemKhachhang();
            f.ShowDialog();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Makhachhang, Tenkhachhang, Gioitinh, SDT, Email, Trangthai, Diachinhanhang, CCCD FROM Khachhang";

            Thuvien.load_KH(dgvKH, sql);
            txtMaKH_tk.Clear();
            txtSDT_tk.Clear();
            txtTenKH_tk.Clear();
            cboTrangthai_tk.Text = "";
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dgvKH.CurrentRow == null) return;
            int i = dgvKH.CurrentRow.Index;
            if (i < 0) return;
            string mkh = dgvKH.Rows[i].Cells["MaKH"].Value?.ToString();

            DialogResult kq = MessageBox.Show("Ban chac chan muon xoa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            Thuvien.upd_del("Delete from Khachhang where Makhachhang= N'" + mkh + "'");
            MessageBox.Show("Xoa thanh cong");
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }
    }
}

    
    
    

