using QuanLyCuaHangMyPham.BLL;
using QuanLyCuaHangMyPham.DTO;
using QuanLyCuaHangMyPham.Forms;
using System;
using System.Collections.Generic;
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
            // Thiết lập năm mặc định cho bộ lọc
            numYear.Value = DateTime.Now.Year;
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

            var tongTienColumn = new DataGridViewTextBoxColumn { DataPropertyName = "TongTien", HeaderText = "Tổng Tiền (VNĐ)" };
            tongTienColumn.DefaultCellStyle.Format = "N0";
            dgvDonHang.Columns.Add(tongTienColumn);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddTicks(-1);
            int year = (int)numYear.Value;

            LoadThongKeChung(fromDate, toDate);
            LoadTopSanPhamChart(fromDate, toDate);
            LoadDoanhThuThangChart(year);
        }

        private void LoadThongKeChung(DateTime fromDate, DateTime toDate)
        {
            DataTable dtDonHang = ThongKeBLL.Instance.GetThongKeDonHang(fromDate, toDate);
            dgvDonHang.DataSource = dtDonHang;

            int soDonHang = dtDonHang.Rows.Count;
            decimal tongDoanhThu = 0;
            foreach (DataRow row in dtDonHang.Rows)
            {
                tongDoanhThu += Convert.ToDecimal(row["TongTien"]);
            }

            lblSoDonHang.Text = soDonHang.ToString();
            lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
        }

        private void LoadTopSanPhamChart(DateTime fromDate, DateTime toDate)
        {
            var topSanPham = ThongKeBLL.Instance.GetTopSanPham(fromDate, toDate);
            chartTopSP.Series.Clear();
            Series series = new Series
            {
                Name = "TopSanPham",
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
        }

        private void LoadDoanhThuThangChart(int year)
        {
            DataTable dtDoanhThu = ThongKeBLL.Instance.GetDoanhThuTheoThang(year);
            chartDoanhThu.Series["Doanh thu"].Points.Clear();
            chartDoanhThu.Titles["Title1"].Text = $"Doanh thu theo Tháng - Năm {year}";

            // Tạo một danh sách doanh thu cho 12 tháng, mặc định là 0
            decimal[] doanhThuThang = new decimal[12];
            foreach (DataRow row in dtDoanhThu.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                doanhThuThang[thang - 1] = doanhThu; // -1 vì mảng bắt đầu từ 0
            }

            // Vẽ biểu đồ cho 12 tháng
            for (int i = 0; i < 12; i++)
            {
                DataPoint dp = new DataPoint(i + 1, (double)doanhThuThang[i]);
                dp.Label = doanhThuThang[i].ToString("N0");
                dp.AxisLabel = $"T{i + 1}";
                chartDoanhThu.Series["Doanh thu"].Points.Add(dp);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count > 0)
            {
                DataRowView drv = dgvDonHang.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    DonHangDTO selectedDonHang = new DonHangDTO(drv);
                    FormChiTietDonHang f = new FormChiTietDonHang(selectedDonHang);
                    f.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaDonHang_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count > 0)
            {
                DataRowView drv = dgvDonHang.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    string maDH = drv["MaDH"].ToString();
                    string tenKH = drv["TenKH"].ToString();

                    if (MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn hàng {maDH} của khách hàng {tenKH} không?\nHành động này sẽ hoàn trả lại số lượng sản phẩm vào kho.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DonHangBLL.Instance.DeleteDonHang(maDH))
                        {
                            MessageBox.Show("Xóa đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnThongKe.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Xóa đơn hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
