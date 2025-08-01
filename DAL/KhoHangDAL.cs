﻿using QuanLyCuaHangMyPham.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCuaHangMyPham.DAL
{
    public class KhoHangDAL
    {
        private static KhoHangDAL instance;
        public static KhoHangDAL Instance
        {
            get { if (instance == null) instance = new KhoHangDAL(); return instance; }
            private set { instance = value; }
        }
        private KhoHangDAL() { }

        public DataTable GetListSanPhamTrongKho()
        {
            // Cập nhật: Thêm sp.HinhAnh vào câu truy vấn
            string query = @"
                SELECT kh.MaSP, sp.TenSP, kh.SoLuong, kh.NgayNhap, sp.DonGia, sp.HinhAnh 
                FROM KhoHang AS kh
                JOIN SanPham AS sp ON kh.MaSP = sp.MaSP";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateSoLuong(string maSP, int soLuongBan)
        {
            string query = "UPDATE KhoHang SET SoLuong = SoLuong - @soLuongBan WHERE MaSP = @maSP";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { soLuongBan, maSP });
            return result > 0;
        }

        public bool DeleteFromKho(string maSP)
        {
            // Chỉ xóa khỏi kho, không xóa sản phẩm gốc
            string query = "DELETE FROM KhoHang WHERE MaSP = @maSP";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSP });
            return result > 0;
        }

        public bool NhapHang(string maSP, int soLuong, DateTime ngayNhap)
        {
            // Sử dụng MERGE để vừa UPDATE (nếu đã có) vừa INSERT (nếu chưa có)
            string query = @"
                MERGE KhoHang AS target
                USING (SELECT @MaSP AS MaSP, @SoLuong AS SoLuong, @NgayNhap AS NgayNhap) AS source
                ON (target.MaSP = source.MaSP)
                WHEN MATCHED THEN
                    UPDATE SET SoLuong = target.SoLuong + source.SoLuong, NgayNhap = source.NgayNhap
                WHEN NOT MATCHED THEN
                    INSERT (MaSP, SoLuong, NgayNhap)
                    VALUES (source.MaSP, source.SoLuong, source.NgayNhap);";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSP, soLuong, ngayNhap });
            return result > 0;
        }
    }
}
