using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    // Lớp này dùng để hiển thị thông tin sản phẩm trong ComboBox và quản lý giỏ hàng
    public class SanPhamKhoDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongTon { get; set; }

        public SanPhamKhoDTO(DataRow row)
        {
            this.MaSP = row["MaSP"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.SoLuongTon = (int)row["SoLuong"];
        }

        // Dùng để hiển thị trong ComboBox
        public string Display => $"{TenSP} (Tồn: {SoLuongTon})";
    }
}
