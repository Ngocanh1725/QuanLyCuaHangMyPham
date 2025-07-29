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
        public float DonGia { get; set; }
        public byte[] HinhAnh { get; set; } // Thêm: Dữ liệu hình ảnh

        public SanPhamKhoDTO(DataRow row)
        {
            this.MaSP = row["MaSP"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.SoLuongTon = (int)row["SoLuong"];
            this.DonGia = Convert.ToSingle(row["DonGia"]);

            // Thêm: Lấy dữ liệu hình ảnh
            if (row.Table.Columns.Contains("HinhAnh") && row["HinhAnh"] != DBNull.Value)
            {
                this.HinhAnh = (byte[])row["HinhAnh"];
            }
        }

        // Dùng để hiển thị trong ComboBox
        public string Display => $"{TenSP} (Tồn: {SoLuongTon})";
    }
}
