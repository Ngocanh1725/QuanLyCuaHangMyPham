using QuanLyCuaHangMyPham.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class frmHoaDon : Form
    {
        private readonly DonHang _donHang;
        private readonly List<SanPham> _allSanPhams;
        public frmHoaDon(DonHang donHang, List<SanPham> allSanPhams)
        {
            InitializeComponent();
            _donHang = donHang;
            _allSanPhams = allSanPhams;
        }

        private void frmHienThiHoaDon_Load(object sender, EventArgs e)
        {
            this.Text = $"Hóa Đơn: {_donHang.MaDH}";
            BuildInvoice();
        }

        private void BuildInvoice()
        {
            var sb = new StringBuilder();
            sb.AppendLine("         CỬA HÀNG MỸ PHẨM GEMINI");
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("                HÓA ĐƠN BÁN HÀNG");
            sb.AppendLine();
            sb.AppendLine($"Mã HĐ: {_donHang.MaDH}");
            sb.AppendLine($"Ngày: {_donHang.NgayMua:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Nhân viên: {_donHang.MaNV}");
            sb.AppendLine();
            sb.AppendLine($"Khách hàng: {_donHang.TenKH}");
            sb.AppendLine($"Số điện thoại: {_donHang.SDTKH}");
            sb.AppendLine($"Địa chỉ: {_donHang.Diachi}");
            sb.AppendLine("==================================================");
            sb.AppendLine(String.Format("{0,-20} | {1,5} | {2,10} | {3,12}", "Tên Sản Phẩm", "SL", "Đơn Giá", "Thành Tiền"));
            sb.AppendLine("==================================================");

            foreach (var item in _donHang.ChiTietDonHangList)
            {
                // Sử dụng TenSP đã gán trước đó
                sb.AppendLine(String.Format("{0,-20} | {1,5} | {2,10:N0} | {3,12:N0}", item.TenSP, item.SoLuong, item.GiaBan, item.ThanhTien));
            }
            sb.AppendLine("==================================================");
            sb.AppendLine(String.Format("Tổng cộng: {0,35:N0} VNĐ", _donHang.TongTien));
            sb.AppendLine();
            sb.AppendLine("          Cảm ơn quý khách và hẹn gặp lại!");

            rtbHoaDon.Text = sb.ToString();
            rtbHoaDon.Font = new Font("Courier New", 10);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng in đang được phát triển!");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
