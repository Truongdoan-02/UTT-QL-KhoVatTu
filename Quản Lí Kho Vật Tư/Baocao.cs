using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartSeries = System.Windows.Forms.DataVisualization.Charting.Series;
using Excel = Microsoft.Office.Interop.Excel;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Baocao : Form
    {
        public Baocao()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void Baocao_Load(object sender, EventArgs e)
        {
        }
        private System.Data.DataTable Getthongkexuatnhapton(DateTime tuNgay,DateTime denNgay)
        {
            System.Data.DataTable dt=new System.Data.DataTable();
            string sql = @"Select 
            vt.Mavattu AS MAVT,
            vt.Tenvattu AS TenVT,
            ISNULL(SUM(pnct.Soluong),0) AS TONGNHAP,
            ISNULL(SUM(pxct.Soluong),0) AS TONGXUAT,
            ISNULL(SUM(pnct.Soluong),0)-ISNULL(SUM(pxct.Soluong),0) AS TONKHO
            FROM QL_Kho vt
            LEFT JOIN Phieunhap_CT pnct ON vt.Mavattu=pnct.MaVT
            LEFT JOIN Phieunhap pn ON pnct.MaHD=pn.MaHD
            LEFT JOIN Phieuxuat_CT pxct ON vt.Mavattu=pxct.MaVT
            LEFT JOIN Phieuxuat px ON pxct.MAHD=px.MAHD
            where 
            (pn.Ngaytao BETWEEN @TuNgay AND @DenNgay OR pn.Ngaytao IS NULL)
            AND 
            (px.Ngaytao BETWEEN @TuNgay AND @DenNgay OR px.Ngaytao IS NULL)
            GROUP BY vt.Mavattu,vt.Tenvattu";
            SqlConnection conn = new SqlConnection(
      ConfigurationManager.ConnectionStrings["QL_KhoVatTu"].ConnectionString
  );

            SqlCommand cmd = new SqlCommand(sql, conn); 
            cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
            cmd.Parameters.AddWithValue("@DenNgay", denNgay);
             SqlDataAdapter da=new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        private void Loadchartnhapxuatton(System.Data.DataTable dt)
        {
          chart.Series.Clear();
            ChartSeries sNhap = new ChartSeries("Nhập");
            ChartSeries sXuat = new ChartSeries("Xuất");
            ChartSeries sTon = new ChartSeries("Tồn");

            sNhap.ChartType = SeriesChartType.Column;
            sXuat.ChartType = SeriesChartType.Column;
            sTon.ChartType = SeriesChartType.Line;
            sTon.BorderWidth = 3;
            sTon.MarkerStyle = MarkerStyle.Circle;
            sTon.MarkerSize = 8;
            sTon.Color = Color.Red;
            sTon.IsXValueIndexed = true;   // cho chấm nằm giữa cột

             // 1. TÍNH TRỤC Y TỰ GIÃN (>= 200)
            int maxValue = 0;
            foreach (DataRow row in dt.Rows)
            {
                maxValue = Math.Max(maxValue, Convert.ToInt32(row["TONGNHAP"]));
                maxValue = Math.Max(maxValue, Convert.ToInt32(row["TONGXUAT"]));
                maxValue = Math.Max(maxValue, Convert.ToInt32(row["TONKHO"]));
            }

            int axisMax = ((maxValue / 20) + 1) * 20;
            if (axisMax < 200) axisMax = 200;

            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = axisMax;
            chart.ChartAreas[0].AxisY.Interval = 20;
            chart.ChartAreas[0].AxisY.Title = "Số lượng";
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;

            // ❌ TẮT HOÀN TOÀN TRỤC Y PHỤ
            chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;

            foreach (DataRow row in dt.Rows)
            {
                string tenVT = row["TenVT"].ToString();

                sNhap.Points.AddXY(tenVT, Convert.ToInt32(row["TONGNHAP"]));
                sXuat.Points.AddXY(tenVT, Convert.ToInt32(row["TONGXUAT"]));
                sTon.Points.AddXY(tenVT, Convert.ToInt32(row["TONKHO"]));
            }

            chart.Series.Add(sNhap);
            chart.Series.Add(sXuat);
            chart.Series.Add(sTon);
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            System.Data.DataTable dt = Getthongkexuatnhapton(tuNgay, denNgay);

            //Đổ bảng
            dgvbaocao.DataSource = dt;
            dgvbaocao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Đổ Chart 
            Loadchartnhapxuatton(dt);
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            if (dgvbaocao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet xlSheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;

            xlApp.Visible = true;

            int colCount = dgvbaocao.Columns.Count;

            // 1. TIÊU ĐỀ
            xlSheet.Cells[1, 1] = "BÁO CÁO NHẬP – XUẤT – TỒN";
            Excel.Range titleRange = xlSheet.Range[xlSheet.Cells[1, 1], xlSheet.Cells[1, colCount]];
            titleRange.Merge();
            titleRange.Font.Bold = true;
            titleRange.Font.Size = 16;
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // 2. THỜI GIAN
            xlSheet.Cells[2, 1] = $"Từ ngày: {dtpTuNgay.Value:dd/MM/yyyy}  -  Đến ngày: {dtpDenNgay.Value:dd/MM/yyyy}";
            Excel.Range timeRange = xlSheet.Range[xlSheet.Cells[2, 1], xlSheet.Cells[2, colCount]];
            timeRange.Merge();
            timeRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // 3. HEADER
            int rowStart = 4;
            for (int i = 0; i < colCount; i++)
            {
                xlSheet.Cells[rowStart, i + 1] = dgvbaocao.Columns[i].HeaderText;
                Excel.Range headerCell = xlSheet.Cells[rowStart, i + 1];
                headerCell.Font.Bold = true;
                headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            // 4. DATA
            for (int i = 0; i < dgvbaocao.Rows.Count; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    xlSheet.Cells[i + rowStart + 1, j + 1] =
                        dgvbaocao.Rows[i].Cells[j].Value?.ToString();
                }
            }
            // 5. AUTO FIT
            xlSheet.Columns.AutoFit();

            MessageBox.Show("Xuất Excel thành công!", "Thông báo");
        }
    }
    }
