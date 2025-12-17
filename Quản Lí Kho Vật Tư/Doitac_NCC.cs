using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanli_vattu;
namespace Quanli_vattu
{
    
    public partial class Doitac_NCC : Form
    {
        public Doitac_NCC()
        {
            InitializeComponent();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            // B1: Lấy dữ liệu trên các đk đưa vào biến
            string mdt = txtMadoitac.Text.Trim();
            string ht = txtTendoitac.Text.Trim();
            string nhom = cboNhomdoitac.SelectedItem.ToString();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string dc = txtDiachi.Text.Trim();
            string ghichu=txtGhichu.Text.Trim();
            //Kiem tra trung ma
            //B2:Kết nối DB

            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            //B3: Tạo đối tượng command để thực thi câu lệnh sql
            string sql = "";
            if(nhom=="Nhà cung cấp")
            {
                sql = "Insert Doitac_NCC values(@mdt,@ht,@dt,@mail,@dc,@ghichu)";
            }else if(nhom=="Giao hàng")
            {
                sql = "Insert Doitac_GH values(@mdt,@ht,@dt,@mail,@dc,@ghichu)";
            }
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.Add("@mdt", SqlDbType.NVarChar, 50).Value = mdt;
            cmd.Parameters.Add("@ht", SqlDbType.NVarChar, 50).Value = ht;
            cmd.Parameters.Add("@dt", SqlDbType.VarChar, 10).Value = dt;
            cmd.Parameters.Add("@mail", SqlDbType.NVarChar, 50).Value = mail;
            cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 50).Value = dc;
            cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 100).Value = ghichu;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Thuvien.con.Close();
            MessageBox.Show("Thêm mới thành công");
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC,Doitac_GH");

        }

        private void Doitac_NCC_Load(object sender, EventArgs e)
        {
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC,Doitac_GH");
        }
    }
}
