using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class DonHangDTO
    {
        public string MaDH { get; set; }
        public string TenKH { get; set; }
        public string SDTKH { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayMua { get; set; }
        public string MaNV { get; set; }

        public DonHangDTO(string maDH, string tenKH, string sdtkh, string diaChi, DateTime ngayMua, string maNV)
        {
            this.MaDH = maDH;
            this.TenKH = tenKH;
            this.SDTKH = sdtkh;
            this.DiaChi = diaChi;
            this.NgayMua = ngayMua;
            this.MaNV = maNV;
        }

        public DonHangDTO(DataRow row)
        {
            this.MaDH = row["MaDH"].ToString();
            this.TenKH = row["TenKH"].ToString();
            this.SDTKH = row["SDTKH"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.NgayMua = (DateTime)row["NgayMua"];
            this.MaNV = row["MaNV"].ToString();
        }
    }
}
