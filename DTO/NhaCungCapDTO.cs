using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string Email { get; set; }
        public string SDTLH { get; set; }

        public NhaCungCap(string maNCC, string tenNCC, string email, string sdtlh)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
            this.Email = email;
            this.SDTLH = sdtlh;
        }

        public NhaCungCap(DataRow row)
        {
            this.MaNCC = row["MaNCC"].ToString();
            this.TenNCC = row["TenNCC"].ToString();
            this.Email = row["Email"].ToString();
            this.SDTLH = row["SDTLH"].ToString();
        }
    }
}
