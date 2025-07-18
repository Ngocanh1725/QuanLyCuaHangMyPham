using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMyPham.Models
{
    //Lớp NhaCungCap (Model) định nghĩa cấu trúc dữ liệu cho một nhà cung cấp.
    public class NhaCungCap
    {
        public string MaNCC {  get; set; }
        public string TenNCC { get; set; }
        public string Email { get; set; }
        public string SDTLH { get; set; }
    }
}
