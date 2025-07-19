using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class ChiTietDonHangDTO
    {
        public int MaCTDH { get; set; }
        public string MaDH { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public float GiaBan { get; set; }
        public float ThanhTien { get; set; }

        public ChiTietDonHangDTO(string maDH, string maSP, int soLuong, float giaBan)
        {
            this.MaDH = maDH;
            this.MaSP = maSP;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
            this.ThanhTien = soLuong * giaBan;
        }

        public ChiTietDonHangDTO(DataRow row)
        {
            this.MaCTDH = (int)row["MaCTDH"];
            this.MaDH = row["MaDH"].ToString();
            this.MaSP = row["MaSP"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.GiaBan = (float)Convert.ToDouble(row["GiaBan"].ToString());
            this.ThanhTien = (float)Convert.ToDouble(row["ThanhTien"].ToString());
        }
    }
}
