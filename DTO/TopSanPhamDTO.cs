using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class TopSanPhamDTO
    {
        public string TenSP { get; set; }
        public int SoLuongBan { get; set; }

        public TopSanPhamDTO(DataRow row)
        {
            this.TenSP = row["TenSP"].ToString();
            this.SoLuongBan = (int)row["SoLuongBan"];
        }
    }
}
