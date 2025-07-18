using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMyPham.Models
{
    public class DonHang
    {
        public string MaDH { get; set; } 
        public string TenKH { get; set; }
        public string SDTKH { get; set; }
        public string Diachi {  get; set; }
        public DateTime NgayMua { get; set; }
        public string MaNV { get; set; } //Mã NV xử lý đơn
        public float TongTien { get; set; }

        // Danh sách các sản phẩm trong đơn hàng (chi tiết đơn hàng)
        public List<ChiTietDonHang> ChiTietDonHangList { get; set; }

        public DonHang()
        {
            NgayMua = DateTime.Now; // Mặc định thời gian tạo là hiện tại
            ChiTietDonHangList = new List<ChiTietDonHang>(); // Khởi tạo danh sách chi tiết
            MaDH = Guid.NewGuid().ToString(); // Tạo một GUID làm mã đơn hàng duy nhất mặc định
                                              // Hoặc bạn có thể có logic tạo mã riêng
        }

        // Phương thức tính tổng tiền
        public void TinhTongTien()
        {
            TongTien = 0;
            if (ChiTietDonHangList != null)
            {
                foreach (var chiTiet in ChiTietDonHangList)
                {
                    TongTien += chiTiet.ThanhTien;
                }
            }
        }
    }
}

