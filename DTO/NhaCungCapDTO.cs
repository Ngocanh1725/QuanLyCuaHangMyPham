using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DTO
{
    public class NhaCungCapDTO
    {
        // --- Các thuộc tính tương ứng với các cột trong bảng NhaCungCap ---
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string Email { get; set; }
        public string SDTLH { get; set; }

        // --- Hàm khởi tạo để tạo một đối tượng mới từ các tham số ---
        public NhaCungCapDTO(string maNCC, string tenNCC, string email, string sdtlh)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
            this.Email = email;
            this.SDTLH = sdtlh;
        }

        // --- Hàm khởi tạo để tạo một đối tượng từ một dòng dữ liệu (DataRow) ---
        public NhaCungCapDTO(DataRow row)
        {
            this.MaNCC = row["MaNCC"].ToString();
            this.TenNCC = row["TenNCC"].ToString();
            this.Email = row["Email"].ToString();
            this.SDTLH = row["SDTLH"].ToString();
        }
    }
}