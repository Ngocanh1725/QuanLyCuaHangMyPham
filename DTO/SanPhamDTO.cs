using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class SanPhamDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string HangSP { get; set; }
        public string XuatXu { get; set; }
        public string TheLoai { get; set; }
        public string MaNCC { get; set; }

        public SanPhamDTO(string maSP, string tenSP, string hangSP, string xuatXu, string theLoai, string maNCC)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.HangSP = hangSP;
            this.XuatXu = xuatXu;
            this.TheLoai = theLoai;
            this.MaNCC = maNCC;
        }

        public SanPhamDTO(DataRow row)
        {
            this.MaSP = row["MaSP"].ToString();
            this.TenSP = row["TenSP"].ToString();
            this.HangSP = row["HangSP"].ToString();
            this.XuatXu = row["XuatXu"].ToString();
            this.TheLoai = row["TheLoai"].ToString();
            this.MaNCC = row["MaNCC"].ToString();
        }
    }
}
