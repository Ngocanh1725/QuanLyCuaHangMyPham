using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMyPham.Models
{
    public class ChiTietDonHang
    {
        public int MACTDH{ get; set; }
        public string MaDH { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public float ThanhTien {  get; set; }
        public float GiaBan {  get; set; }

        public ChiTietDonHang() { }

        // Constructor có tham số để dễ dàng tạo đối tượng
        public ChiTietDonHang(string maDH, string maSP, float giaBan, int soLuong)
        {
            // MACTDH sẽ được CSDL tự động tăng (IDENTITY)
            MaDH = maDH;
            MaSP = maSP;
            GiaBan = giaBan;
            SoLuong = soLuong;
            ThanhTien = GiaBan * SoLuong; // Tính toán Thành tiền khi khởi tạo
        }
    }
}

