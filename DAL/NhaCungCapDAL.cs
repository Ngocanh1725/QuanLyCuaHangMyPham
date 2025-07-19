using QuanLyCuaHangMyPham.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCuaHangMyPham.DAL
{
    public class NhaCungCapDAL
    {
        private static NhaCungCapDAL instance;

        public static NhaCungCapDAL Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAL(); return instance; }
            private set { instance = value; }
        }

        private NhaCungCapDAL() { }

        public List<NhaCungCapDTO> GetListNhaCungCap()
        {
            List<NhaCungCapDTO> list = new List<NhaCungCapDTO>();
            string query = "SELECT * FROM NhaCungCap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO(item);
                list.Add(ncc);
            }
            return list;
        }
    }
}
