using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class SanPhamDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string XuatXu { get; set; }
        public string MaLoai { get; set; }
        public string MaNCC { get; set; }
        public float DonGia { get; set; }
        public byte[] HinhAnh { get; set; }
        public string TenNCC { get; set; } // Thêm: Để hiển thị tên hãng/nhà cung cấp

        public SanPhamDTO(string maSP, string tenSP, string xuatXu, string maLoai, string maNCC, float donGia, byte[] hinhAnh)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.XuatXu = xuatXu;
            this.MaLoai = maLoai;
            this.MaNCC = maNCC;
            this.DonGia = donGia;
            this.HinhAnh = hinhAnh;
        }

        public SanPhamDTO(DataRow row)
        {
            this.MaSP = row["MaSP"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.XuatXu = row["XuatXu"].ToString();
            this.MaLoai = row["MaLoai"].ToString();
            this.MaNCC = row["MaNCC"].ToString();
            this.DonGia = Convert.ToSingle(row["DonGia"]);

            if (row.Table.Columns.Contains("TenNCC"))
            {
                this.TenNCC = row["TenNCC"].ToString();
            }

            if (row["HinhAnh"] != DBNull.Value)
            {
                this.HinhAnh = (byte[])row["HinhAnh"];
            }
        }
    }
}
