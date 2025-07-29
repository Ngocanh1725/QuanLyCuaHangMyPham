using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class LoaiSanPhamDTO
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }

        public LoaiSanPhamDTO(string maLoai, string tenLoai)
        {
            this.MaLoai = maLoai;
            this.TenLoai = tenLoai;
        }

        public LoaiSanPhamDTO(DataRow row)
        {
            this.MaLoai = row["MaLoai"].ToString();
            this.TenLoai = row["TenLoai"].ToString();
        }
    }
}