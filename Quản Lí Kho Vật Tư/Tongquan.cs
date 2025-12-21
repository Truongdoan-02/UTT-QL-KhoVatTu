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
    public partial class Tongquan : Form
    {
        public Tongquan()
        {
            InitializeComponent();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Doitac_Khachhang f = new Doitac_Khachhang();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void bÁNHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tongquan f = new Tongquan();
            f.Show();

        }

        private void nhàCungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Doitac_NCC f = new Doitac_NCC();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void qUẢNLÍKHOToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
