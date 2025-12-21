using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Themnhanvien : Form
    {
        public Themnhanvien()
        {
            InitializeComponent();
        }

        private void ibtnluu_Click(object sender, EventArgs e)
        {
            //1.Lay du lieu tu cac o nhap lieu 
            string Manv=txtmanv.Text;
            string Hoten=txthoten.Text;
            string Gioitinh=cbgioitinh.Text;
            string Ngaysinh=datengaysinh.Value.ToString("yyyy-MM-dd");
            string Sdt=txtsdt.Text;
            string Email=txtemail.Text; 
            string Diachi=txtdiachi.Text;
            string Ngaybatdaulamviec = datebatdau.Value.ToString("yyyy-MM-dd");
            string Chucdanh = cbchucdanh.Text;
            string Phongban = cbphongban.Text;  
            string Chinhanh = cbchinhanh.Text;
            string Trangthai=cbtrangthai.Text;
            string Mucluong=txtluong.Text;
            string Ghichu = tboxghichu.Text;
            //2.Tao cau lenh Sql Inser
            string sql=string.Format("INSERT INTO Danhsachnhanvien(Manv,Hoten,Gioitinh,Ngaysinh,Sdt,Email,Diachi,Ngaybatdaulamviec,Chucdanh,Phongban,Chinhanh,Trangthai,Mucluong,Ghichu)" + "VALUES('{0}',N'{1}',N'{2}','{3}','{4}','{5}',N'{6}','{7}',N'{8}',N'{9}',N'{10}',N'{11}','{12}',N'{13}')",Manv,Hoten,Gioitinh,Ngaysinh,Sdt,Email,Diachi, Ngaybatdaulamviec, Chucdanh, Phongban, Chinhanh, Trangthai, Mucluong, Ghichu);
            //3 Thuc hien luu thong qua lop thu vien
            try
            {
                Thuvien.upd_del(sql);
                MessageBox.Show("Them nhan vien thanh cong!");
                this.Close();//Dong form sau khi luu xong
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi luu:" + ex.Message);
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gbthemnv_Enter(object sender, EventArgs e)
        {

        }

        private void lbthemnv_Click(object sender, EventArgs e)
        {

        }

        private void Themnhanvien_Load(object sender, EventArgs e)
        {

        }

        private void panelfill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbngaybatdau_Click(object sender, EventArgs e)
        {

        }
    }
}
