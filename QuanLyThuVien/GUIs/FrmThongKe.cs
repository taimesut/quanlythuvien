using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.GUIs
{
    public partial class FrmThongKe : Form
    {
        private readonly ThongKeService _service;

        public FrmThongKe()
        {
            InitializeComponent();
            _service = new ThongKeService();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void LoadAll()
        {
            try
            {
                LoadSummaryGrid();
                LoadColumnChart();
                LoadPieChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load thống kê: " + ex.Message);
            }
        }

        private void LoadSummaryGrid()
        {
            var dt = new DataTable();
            dt.Columns.Add("Chỉ số");
            dt.Columns.Add("Giá trị");

            dt.Rows.Add("Số sách (tổng tồn kho)", _service.GetSoSachTonKho());
            dt.Rows.Add("Số sách đang mượn (chưa trả)", _service.GetSoSachDaMuon());
            dt.Rows.Add("Số sách quá hạn", _service.GetSoSachQuaHan());
            dt.Rows.Add("Số độc giả", _service.GetSoDocGia());
            dt.Rows.Add("Số nhân viên", _service.GetSoNhanVien());

            dgvSummary.DataSource = dt;
            dgvSummary.ClearSelection();
        }

        private void LoadColumnChart()
        {
            var data = _service.GetThongKeTheoTheLoai();

            chartColumn.Series.Clear();
            chartColumn.ChartAreas.Clear();
            var area = new ChartArea("area");
            chartColumn.ChartAreas.Add(area);

            var series = new Series("Số lượng sách")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            // Danh sách màu
            var colors = new[] {
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(231, 76, 60),
                Color.FromArgb(46, 204, 113),
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(241, 196, 15),
                Color.FromArgb(230, 126, 34)
            };

            int ci = 0;
            foreach (var item in data)
            {
                int idx = series.Points.AddXY(item.TheLoai, item.SoLuong);
                series.Points[idx].Color = colors[ci % colors.Length];
                ci++;
            }

            chartColumn.Series.Add(series);
            chartColumn.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }

        private void LoadPieChart()
        {
            var data = _service.GetThongKeTheoTheLoai();

            chartPie.Series.Clear();
            chartPie.ChartAreas.Clear();
            var area = new ChartArea("areaPie");
            chartPie.ChartAreas.Add(area);

            var series = new Series("Tỉ lệ theo thể loại")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            // Danh sách màu giống biểu đồ cột
            var colors = new[] {
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(231, 76, 60),
                Color.FromArgb(46, 204, 113),
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(241, 196, 15),
                Color.FromArgb(230, 126, 34)
            };

            int ci = 0;
            foreach (var item in data)
            {
                int idx = series.Points.AddXY(item.TheLoai, item.SoLuong);
                series.Points[idx].Label = $"{item.TheLoai}: {item.SoLuong}";
                series.Points[idx].Color = colors[ci % colors.Length];
                ci++;
            }

            chartPie.Series.Add(series);
            chartPie.Legends.Clear();
        }
    }
}
