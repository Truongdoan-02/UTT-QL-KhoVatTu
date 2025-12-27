using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Lichlamviec : Form
    {
        string chuoiketnoi = @"Data Source=ANHTU\ANHTU;Initial Catalog=QL_KhoVatTu;Integrated Security=True";
        public Lichlamviec()
        {
            InitializeComponent();
        }

        private void Lichlamviec_Load(object sender, EventArgs e)
        {
            string sql = @"select 
                   
                    L.Manv AS [Mã nhân viên], 
                    N.Hoten AS [Họ Tên], 
                    L.Ngay AS [Ngày Làm], 
                    L.Ca AS [Ca Làm], 
                    L.Ghichu AS [Ghi chú]
                   from LichLamViec L, Danhsachnhanvien N 
                   where L.Manv = N.Manv
                   ORDER BY L.Ngay DESC";
            Thuvien.load_KH(dgv, sql);
            Taicomboboxnhanvien();
        }
        private void Taicomboboxnhanvien()
        {
            // Viết câu lệnh SQL
            string sql = "SELECT Manv, Hoten FROM Danhsachnhanvien";


            DataTable dt = Thuvien.LayDuLieu(sql);
            DataRow dr = dt.NewRow();
            dr["Manv"] = "";
            dr["Hoten"] = "Chọn nhân viên";
            dt.Rows.InsertAt(dr, 0);
            // Gán vào ComboBox
            nhanvien.DataSource = dt;
            nhanvien.DisplayMember = "Hoten";
            nhanvien.ValueMember = "Manv";

        }


        private void them_Click(object sender, EventArgs e)
        {
            if (nhanvien.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên cụ thể!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ca.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Ca làm việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string manv = nhanvien.SelectedValue.ToString();
                string ngayy = ngay.Value.ToString("yyyy-MM-dd");
                string caa = ca.Text;
                string ghichuu = ghichu.Text;
                string sqlCheck = "SELECT * FROM LichLamViec WHERE Manv = '" + manv + "' AND Ngay = '" + ngayy + "' AND Ca = N'" + caa + "'";
                DataTable dtCheck = Thuvien.LayDuLieu(sqlCheck);

                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show("Nhân viên này đã có lịch vào ca này rồi!", "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string sql = "INSERT INTO LichLamViec (Manv, Ngay, Ca, Ghichu) " +
                             "VALUES ('" + manv + "', '" + ngayy + "', N'" + caa + "', N'" + ghichuu + "')";
                Thuvien.upd_del(sql);
                MessageBox.Show("Thêm lịch thành công!");
                Lichlamviec_Load(sender, e);
                nhanvien.SelectedIndex = 0;   
                ngay.Value = DateTime.Now;  
                ca.SelectedIndex = -1;       
                ghichu.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}

