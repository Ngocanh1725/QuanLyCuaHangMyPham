using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DAL
{
    public class LoaiSanPhamDAL
    {
        private static LoaiSanPhamDAL instance;

        public static LoaiSanPhamDAL Instance
        {
            get { if (instance == null) instance = new LoaiSanPhamDAL(); return instance; }
            private set { instance = value; }
        }

        private LoaiSanPhamDAL() { }

        public DataTable GetListLoaiSanPham()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM LoaiSanPham");
        }
    }
}
