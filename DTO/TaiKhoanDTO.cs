using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class TaiKhoanDTO
    {
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public string PhanQuyen { get; set; }

        public TaiKhoanDTO(string tenTK, string matKhau, string phanQuyen)
        {
            this.TenTK = tenTK;
            this.MatKhau = matKhau;
            this.PhanQuyen = phanQuyen;
        }

        public TaiKhoanDTO(DataRow row)
        {
            this.TenTK = row["TenTK"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.PhanQuyen = row["PhanQuyen"].ToString();
        }
    }
}
