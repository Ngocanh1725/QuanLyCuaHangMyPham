using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string SDT { get; set; }
        public string QueQuan { get; set; }
        public string Email { get; set; }
        public string TenTK { get; set; }
        public string PhanQuyen { get; set; } // Thêm thuộc tính Phân Quyền

        public NhanVienDTO(string maNV, string tenNV, string sdt, string queQuan, string email, string tenTK)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.SDT = sdt;
            this.QueQuan = queQuan;
            this.Email = email;
            this.TenTK = tenTK;
        }

        public NhanVienDTO(DataRow row)
        {
            this.MaNV = row["MaNV"].ToString();
            this.TenNV = row["TenNV"].ToString();
            this.SDT = row["SDT"].ToString();
            this.QueQuan = row["QueQuan"].ToString();
            this.Email = row["Email"].ToString();
            this.TenTK = row["TenTK"].ToString();
            // Thêm: Lấy dữ liệu Phân Quyền từ DataRow
            if (row.Table.Columns.Contains("PhanQuyen"))
            {
                this.PhanQuyen = row["PhanQuyen"].ToString();
            }
        }
    }
}

