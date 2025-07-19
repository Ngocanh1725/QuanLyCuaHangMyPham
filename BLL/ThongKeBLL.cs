using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCuaHangMyPham.BLL
{
    public class ThongKeBLL
    {
        private static ThongKeBLL instance;
        public static ThongKeBLL Instance
        {
            get { if (instance == null) instance = new ThongKeBLL(); return instance; }
            private set { instance = value; }
        }
        private ThongKeBLL() { }

        public DataTable GetThongKeDonHang(DateTime fromDate, DateTime toDate)
        {
            return ThongKeDAL.Instance.GetThongKeDonHang(fromDate, toDate);
        }

        public List<TopSanPhamDTO> GetTopSanPham(DateTime fromDate, DateTime toDate)
        {
            List<TopSanPhamDTO> list = new List<TopSanPhamDTO>();
            DataTable data = ThongKeDAL.Instance.GetTopSanPham(fromDate, toDate);
            foreach (DataRow item in data.Rows)
            {
                list.Add(new TopSanPhamDTO(item));
            }
            return list;
        }
    }
}
