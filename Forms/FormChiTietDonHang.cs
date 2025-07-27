using QuanLyCuaHangMyPham.BLL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;

namespace QuanLyCuaHangMyPham.Forms
{
    public partial class FormChiTietDonHang : Form
    {
        private DonHangDTO currentDonHang;

        public FormChiTietDonHang(DonHangDTO donHang)
        {
            InitializeComponent();
            this.currentDonHang = donHang;
        }

        private void FormChiTietDonHang_Load(object sender, EventArgs e)
        {
            if (currentDonHang != null)
            {
                // Hiển thị thông tin chung của đơn hàng và khách hàng
                lblMaHoaDon.Text = currentDonHang.MaDH;
                lblMaNV.Text = currentDonHang.MaNV;
                lblTenKH.Text = currentDonHang.TenKH;
                lblSDT.Text = currentDonHang.SDTKH;
                lblDiaChi.Text = currentDonHang.DiaChi;
                lblNgayMua.Text = currentDonHang.NgayMua.ToString("dd/MM/yyyy HH:mm:ss");

                // Tải danh sách sản phẩm trong đơn hàng
                LoadChiTietDonHang();
            }
        }

        void LoadChiTietDonHang()
        {
            try
            {
                // Lấy danh sách chi tiết đơn hàng từ BLL
                DataTable dt = ChiTietDonHangBLL.Instance.GetListChiTietDonHang(currentDonHang.MaDH);
                dgvChiTiet.DataSource = dt;

                // Tính toán tổng tiền
                decimal tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                }

                // Hiển thị tổng tiền
                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
                lblThue.Text = "0 VNĐ"; // Giả sử thuế là 0
                lblPhaiTra.Text = tongTien.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTiet_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Bỏ chọn dòng đầu tiên sau khi tải dữ liệu
            dgvChiTiet.ClearSelection();
        }

        public void PrintInvoice()
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;
            printPreviewDialog.ShowDialog();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            PrintInvoice();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Định nghĩa các loại font chữ sẽ sử dụng
            Font headerFont = new Font("Arial", 18, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 12, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10, FontStyle.Regular);
            Font bodyFontBold = new Font("Arial", 10, FontStyle.Bold);

            // Định nghĩa lề và vị trí
            float yPos = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float rightMargin = e.MarginBounds.Right;
            float lineHeight = bodyFont.GetHeight(e.Graphics);
            float currentX = leftMargin;

            // --- Vẽ Tiêu đề ---
            string text = "PHIẾU HÓA ĐƠN";
            SizeF textSize = e.Graphics.MeasureString(text, headerFont);
            yPos = topMargin;
            e.Graphics.DrawString(text, headerFont, Brushes.Black, (e.PageBounds.Width - textSize.Width) / 2, yPos);
            yPos += textSize.Height + lineHeight * 2;

            // --- Vẽ Thông tin cửa hàng và khách hàng ---
            e.Graphics.DrawString("XÍNH ANH COSMETICS", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight * 2;

            e.Graphics.DrawString($"Mã Hóa Đơn: {currentDonHang.MaDH}", bodyFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString($"Ngày Mua: {currentDonHang.NgayMua:dd/MM/yyyy HH:mm}", bodyFont, Brushes.Black, rightMargin - 250, yPos);
            yPos += lineHeight;
            e.Graphics.DrawString($"Nhân viên: {currentDonHang.MaNV}", bodyFont, Brushes.Black, rightMargin - 250, yPos);
            yPos += lineHeight * 2;

            e.Graphics.DrawString("Thông tin khách hàng:", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight * 1.5f;
            e.Graphics.DrawString($"Họ và tên: {currentDonHang.TenKH}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight;
            e.Graphics.DrawString($"Số điện thoại: {currentDonHang.SDTKH}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight;
            e.Graphics.DrawString($"Địa chỉ: {currentDonHang.DiaChi}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight * 2;

            // --- Vẽ Tiêu đề bảng sản phẩm ---
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += lineHeight * 0.5f;

            currentX = leftMargin;
            e.Graphics.DrawString("Tên Sản Phẩm", bodyFontBold, Brushes.Black, currentX, yPos);
            currentX += 300;
            e.Graphics.DrawString("SL", bodyFontBold, Brushes.Black, currentX, yPos);
            currentX += 50;
            e.Graphics.DrawString("Đơn Giá", bodyFontBold, Brushes.Black, currentX, yPos);
            currentX += 150;
            e.Graphics.DrawString("Thành Tiền", bodyFontBold, Brushes.Black, currentX, yPos);
            yPos += lineHeight * 1.5f;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += lineHeight * 0.5f;

            // --- Vẽ Nội dung bảng sản phẩm ---
            decimal tongTien = 0;
            DataTable dt = (DataTable)dgvChiTiet.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                currentX = leftMargin;
                string tenSP = row["TenSP"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal giaBan = Convert.ToDecimal(row["GiaBan"]);
                decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);
                tongTien += thanhTien;

                e.Graphics.DrawString(tenSP, bodyFont, Brushes.Black, currentX, yPos);
                currentX += 300;
                e.Graphics.DrawString(soLuong.ToString(), bodyFont, Brushes.Black, currentX, yPos);
                currentX += 50;
                e.Graphics.DrawString(giaBan.ToString("N0"), bodyFont, Brushes.Black, currentX, yPos);
                currentX += 150;
                e.Graphics.DrawString(thanhTien.ToString("N0"), bodyFont, Brushes.Black, currentX, yPos);
                yPos += lineHeight;
            }
            yPos += lineHeight * 0.5f;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += lineHeight;

            // --- Vẽ Tổng tiền ---
            string totalText = $"Tổng tiền: {tongTien:N0} VNĐ";
            textSize = e.Graphics.MeasureString(totalText, bodyFontBold);
            e.Graphics.DrawString(totalText, bodyFontBold, Brushes.Black, rightMargin - textSize.Width, yPos);
            yPos += lineHeight;

            totalText = $"Thuế: 0 VNĐ";
            textSize = e.Graphics.MeasureString(totalText, bodyFont);
            e.Graphics.DrawString(totalText, bodyFont, Brushes.Black, rightMargin - textSize.Width, yPos);
            yPos += lineHeight;

            totalText = $"Phải trả: {tongTien:N0} VNĐ";
            textSize = e.Graphics.MeasureString(totalText, bodyFontBold);
            e.Graphics.DrawString(totalText, bodyFontBold, Brushes.Black, rightMargin - textSize.Width, yPos);
            yPos += lineHeight * 4;

            // --- Vẽ Chân trang ---
            text = "Cảm ơn quý khách!";
            textSize = e.Graphics.MeasureString(text, bodyFont);
            e.Graphics.DrawString(text, bodyFont, Brushes.Black, (e.PageBounds.Width - textSize.Width) / 2, yPos);
            yPos += lineHeight;
            text = "Hẹn gặp lại!";
            textSize = e.Graphics.MeasureString(text, bodyFont);
            e.Graphics.DrawString(text, bodyFont, Brushes.Black, (e.PageBounds.Width - textSize.Width) / 2, yPos);
        }
    }
}
