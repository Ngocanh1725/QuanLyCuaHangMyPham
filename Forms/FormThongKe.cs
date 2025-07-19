using QuanLyCuaHangMyPham.BLL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangMyPham
{
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            // Mặc định thống kê trong tháng hiện tại
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;
            btnThongKe.PerformClick();
        }

        void SetupDataGridView()
        {
            dgvDonHang.AutoGenerateColumns = false;
            dgvDonHang.Columns.Clear();

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDH", HeaderText = "Mã Đơn Hàng" });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenKH", HeaderText = "Tên Khách Hàng" });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayMua", HeaderText = "Ngày Mua" });
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNV", HeaderText = "Nhân Viên" });

            var tongTienColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TongTien",
                HeaderText = "Tổng Tiền (VNĐ)"
            };
            tongTienColumn.DefaultCellStyle.Format = "N0"; // Định dạng số
            dgvDonHang.Columns.Add(tongTienColumn);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddTicks(-1); // Lấy đến cuối ngày

            LoadThongKe(fromDate, toDate);
        }

        private void LoadThongKe(DateTime fromDate, DateTime toDate)
        {
            // Load danh sách đơn hàng
            DataTable dtDonHang = ThongKeBLL.Instance.GetThongKeDonHang(fromDate, toDate);
            dgvDonHang.DataSource = dtDonHang;

            // Tính toán và hiển thị các chỉ số
            int soDonHang = dtDonHang.Rows.Count;
            decimal tongDoanhThu = 0;
            foreach (DataRow row in dtDonHang.Rows)
            {
                tongDoanhThu += Convert.ToDecimal(row["TongTien"]);
            }

            lblSoDonHang.Text = soDonHang.ToString();
            lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";

            // Load biểu đồ top sản phẩm
            var topSanPham = ThongKeBLL.Instance.GetTopSanPham(fromDate, toDate);
            chartTopSP.Series.Clear();
            chartTopSP.Titles.Clear();

            chartTopSP.Titles.Add("Top 5 Sản phẩm bán chạy");
            Series series = new Series
            {
                Name = "seriesTopSP",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Pie
            };
            chartTopSP.Series.Add(series);

            if (topSanPham.Any())
            {
                foreach (var item in topSanPham)
                {
                    series.Points.AddXY(item.TenSP, item.SoLuongBan);
                }
            }
            else
            {
                // Hiển thị thông báo nếu không có dữ liệu
                series.Points.AddXY("Không có dữ liệu", 1);
                series.Points[0].IsValueShownAsLabel = false;
                series.Points[0].Label = " ";
            }
            chartTopSP.Invalidate();
        }
    }
}