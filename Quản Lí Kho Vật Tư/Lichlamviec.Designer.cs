namespace Quản_Lí_Kho_Vật_Tư
{
    partial class Lichlamviec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.ca = new System.Windows.Forms.ComboBox();
            this.nhanvien = new System.Windows.Forms.ComboBox();
            this.xoa = new System.Windows.Forms.Button();
            this.sua = new System.Windows.Forms.Button();
            this.them = new System.Windows.Forms.Button();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ngaytk = new System.Windows.Forms.DateTimePicker();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.thongke = new System.Windows.Forms.Button();
            this.thoat = new System.Windows.Forms.Button();
            this.timkiem = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.xuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(49, 250);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(843, 328);
            this.dgv.TabIndex = 2;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ngay);
            this.groupBox1.Controls.Add(this.ca);
            this.groupBox1.Controls.Add(this.nhanvien);
            this.groupBox1.Controls.Add(this.xoa);
            this.groupBox1.Controls.Add(this.sua);
            this.groupBox1.Controls.Add(this.them);
            this.groupBox1.Controls.Add(this.ghichu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(916, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 458);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // ngay
            // 
            this.ngay.Location = new System.Drawing.Point(161, 117);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(208, 27);
            this.ngay.TabIndex = 13;
            // 
            // ca
            // 
            this.ca.FormattingEnabled = true;
            this.ca.Items.AddRange(new object[] {
            "Ca sáng",
            "Ca chiều",
            "Ca tối"});
            this.ca.Location = new System.Drawing.Point(161, 185);
            this.ca.Name = "ca";
            this.ca.Size = new System.Drawing.Size(208, 28);
            this.ca.TabIndex = 12;
            this.ca.Text = " Chọn ca";
            // 
            // nhanvien
            // 
            this.nhanvien.FormattingEnabled = true;
            this.nhanvien.Location = new System.Drawing.Point(161, 48);
            this.nhanvien.Name = "nhanvien";
            this.nhanvien.Size = new System.Drawing.Size(208, 28);
            this.nhanvien.TabIndex = 11;
            this.nhanvien.Text = "Chọn nhân viên";

            // 
            // xoa
            // 
            this.xoa.AutoSize = true;
            this.xoa.BackColor = System.Drawing.Color.Gray;
            this.xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoa.ForeColor = System.Drawing.Color.Bisque;
            this.xoa.Location = new System.Drawing.Point(280, 343);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(89, 44);
            this.xoa.TabIndex = 10;
            this.xoa.Text = "Xóa";
            this.xoa.UseVisualStyleBackColor = false;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // sua
            // 
            this.sua.AutoSize = true;
            this.sua.BackColor = System.Drawing.Color.Gray;
            this.sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sua.ForeColor = System.Drawing.Color.Bisque;
            this.sua.Location = new System.Drawing.Point(161, 343);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(89, 44);
            this.sua.TabIndex = 9;
            this.sua.Text = "Sửa ";
            this.sua.UseVisualStyleBackColor = false;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // them
            // 
            this.them.AutoSize = true;
            this.them.BackColor = System.Drawing.Color.Gray;
            this.them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.them.ForeColor = System.Drawing.Color.Bisque;
            this.them.Location = new System.Drawing.Point(35, 343);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(89, 44);
            this.them.TabIndex = 8;
            this.them.Text = "Thêm";
            this.them.UseVisualStyleBackColor = false;
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // ghichu
            // 
            this.ghichu.Location = new System.Drawing.Point(161, 261);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(208, 27);
            this.ghichu.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(9, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(9, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ca ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(9, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ghi chú";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhân viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ngaytk);
            this.groupBox2.Controls.Add(this.txttimkiem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(49, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 104);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ngày";
            // 
            // ngaytk
            // 
            this.ngaytk.Location = new System.Drawing.Point(241, 70);
            this.ngaytk.Name = "ngaytk";
            this.ngaytk.ShowCheckBox = true;
            this.ngaytk.Size = new System.Drawing.Size(268, 27);
            this.ngaytk.TabIndex = 15;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(241, 25);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(268, 27);
            this.txttimkiem.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mã nhân viên";
            // 
            // thongke
            // 
            this.thongke.AutoSize = true;
            this.thongke.BackColor = System.Drawing.Color.Gray;
            this.thongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongke.ForeColor = System.Drawing.Color.Bisque;
            this.thongke.Location = new System.Drawing.Point(951, 27);
            this.thongke.Name = "thongke";
            this.thongke.Size = new System.Drawing.Size(89, 44);
            this.thongke.TabIndex = 13;
            this.thongke.Text = "Thống kê";
            this.thongke.UseVisualStyleBackColor = false;
            this.thongke.Click += new System.EventHandler(this.thongke_Click);
            // 
            // thoat
            // 
            this.thoat.AutoSize = true;
            this.thoat.BackColor = System.Drawing.Color.Gray;
            this.thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoat.ForeColor = System.Drawing.Color.Bisque;
            this.thoat.Location = new System.Drawing.Point(1196, 27);
            this.thoat.Name = "thoat";
            this.thoat.Size = new System.Drawing.Size(89, 44);
            this.thoat.TabIndex = 14;
            this.thoat.Text = "Thoát";
            this.thoat.UseVisualStyleBackColor = false;
            this.thoat.Click += new System.EventHandler(this.thoat_Click);
            // 
            // timkiem
            // 
            this.timkiem.AutoSize = true;
            this.timkiem.BackColor = System.Drawing.Color.Gray;
            this.timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.ForeColor = System.Drawing.Color.Bisque;
            this.timkiem.Location = new System.Drawing.Point(626, 128);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(122, 44);
            this.timkiem.TabIndex = 15;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.UseVisualStyleBackColor = false;
            this.timkiem.Click += new System.EventHandler(this.timkiem_Click);
            // 
            // button7
            // 
            this.button7.AutoSize = true;
            this.button7.BackColor = System.Drawing.Color.Gray;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Bisque;
            this.button7.Location = new System.Drawing.Point(626, 183);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(122, 44);
            this.button7.TabIndex = 16;
            this.button7.Text = "Hiển thị tất cả";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // xuat
            // 
            this.xuat.AutoSize = true;
            this.xuat.BackColor = System.Drawing.Color.Gray;
            this.xuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuat.ForeColor = System.Drawing.Color.Bisque;
            this.xuat.Location = new System.Drawing.Point(1077, 27);
            this.xuat.Name = "xuat";
            this.xuat.Size = new System.Drawing.Size(96, 44);
            this.xuat.TabIndex = 17;
            this.xuat.Text = "Xuất file";
            this.xuat.UseVisualStyleBackColor = false;
            this.xuat.Click += new System.EventHandler(this.xuat_Click);
            // 
            // Lichlamviec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 684);
            this.Controls.Add(this.xuat);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.thoat);
            this.Controls.Add(this.thongke);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Name = "Lichlamviec";
            this.Text = "Lichlamviec";
            this.Load += new System.EventHandler(this.Lichlamviec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox nhanvien;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.TextBox ghichu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button thongke;
        private System.Windows.Forms.Button thoat;
        private System.Windows.Forms.ComboBox ca;
        private System.Windows.Forms.DateTimePicker ngay;
        private System.Windows.Forms.DateTimePicker ngaytk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button timkiem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button xuat;
    }
}