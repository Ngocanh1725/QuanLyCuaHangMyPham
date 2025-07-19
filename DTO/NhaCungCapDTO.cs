using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class NhaCungCapDTO
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }

        public NhaCungCapDTO(string maNCC, string tenNCC)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
        }

        public NhaCungCapDTO(DataRow row)
        {
            this.MaNCC = row["MaNCC"].ToString();
            this.TenNCC = row["TenNCC"].ToString();
        }
    }
}
