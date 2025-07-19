using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormNhanVien : Form
    {
        // TODO: Thay thế chuỗi kết nối này bằng chuỗi kết nối thực tế của bạn.
        // Bạn nên lưu chuỗi kết nối trong file App.config để dễ dàng quản lý.
        private string connectionString = "Data Source=ADMIN-PC;Initial Catalog=QL_MyPham;Integrated Security=True";

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Tải dữ liệu nhân viên từ CSDL và hiển thị lên DataGridView.
        /// </summary>
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Truy vấn kết hợp thông tin từ bảng NhanVien và TaiKhoan
                    string query = @"SELECT 
                                        nv.MaNV, 
                                        nv.TenNV, 
                                        nv.SDT, 
                                        nv.QueQuan, 
                                        nv.Email, 
                                        tk.TaiKhoan, 
                                        tk.MatKhau 
                                     FROM NhanVien nv 
                                     JOIN TaiKhoan tk ON nv.TenTK = tk.TaiKhoan";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvNhanVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa trắng các ô nhập liệu.
        /// </summary>
        private void ResetFields()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtQueQuan.Clear();
            txtEmail.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtTimKiem.Clear();
            txtMaNV.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
            LoadData();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Lấy dữ liệu từ các ô của dòng được chọn và hiển thị lên các TextBox
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                txtHoTen.Text = row.Cells["TenNV"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["SDT"].Value?.ToString();
                txtQueQuan.Text = row.Cells["QueQuan"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtTaiKhoan.Text = row.Cells["TaiKhoan"].Value?.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường thông tin có được nhập đầy đủ
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtTaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường Mã NV, Họ Tên, Tài Khoản và Mật Khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Bắt đầu một transaction để đảm bảo cả hai thao tác (thêm tài khoản và thêm nhân viên)
                    // đều thành công hoặc thất bại cùng nhau.
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Thêm vào bảng TaiKhoan trước
                        string queryTaiKhoan = "INSERT INTO TaiKhoan (TaiKhoan, MatKhau, PhanQuyen) VALUES (@TaiKhoan, @MatKhau, @PhanQuyen)";
                        SqlCommand cmdTaiKhoan = new SqlCommand(queryTaiKhoan, conn, transaction);
                        cmdTaiKhoan.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                        cmdTaiKhoan.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                        cmdTaiKhoan.Parameters.AddWithValue("@PhanQuyen", "NhanVien"); // Mặc định là Nhân Viên
                        cmdTaiKhoan.ExecuteNonQuery();

                        // 2. Thêm vào bảng NhanVien
                        string queryNhanVien = "INSERT INTO NhanVien (MaNV, TenNV, SDT, QueQuan, Email, TenTK) VALUES (@MaNV, @TenNV, @SDT, @QueQuan, @Email, @TenTK)";
                        SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn, transaction);
                        cmdNhanVien.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                        cmdNhanVien.Parameters.AddWithValue("@TenNV", txtHoTen.Text);
                        cmdNhanVien.Parameters.AddWithValue("@SDT", txtSoDienThoai.Text);
                        cmdNhanVien.Parameters.AddWithValue("@QueQuan", txtQueQuan.Text);
                        cmdNhanVien.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmdNhanVien.Parameters.AddWithValue("@TenTK", txtTaiKhoan.Text); // Khóa ngoại trỏ tới bảng TaiKhoan
                        cmdNhanVien.ExecuteNonQuery();

                        // Nếu tất cả thành công, commit transaction
                        transaction.Commit();

                        MessageBox.Show("Thêm nhân viên mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Tải lại dữ liệu
                        ResetFields(); // Xóa các ô nhập
                    }
                    catch (SqlException sqlEx)
                    {
                        // Nếu có lỗi, rollback transaction
                        transaction.Rollback();
                        if (sqlEx.Number == 2627) // Lỗi trùng khóa chính
                        {
                            MessageBox.Show("Mã nhân viên hoặc Tên tài khoản đã tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi CSDL: " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        // Cập nhật bảng NhanVien
                        string queryNhanVien = @"UPDATE NhanVien 
                                               SET TenNV = @TenNV, SDT = @SDT, QueQuan = @QueQuan, Email = @Email 
                                               WHERE MaNV = @MaNV";
                        SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn, transaction);
                        cmdNhanVien.Parameters.AddWithValue("@TenNV", txtHoTen.Text);
                        cmdNhanVien.Parameters.AddWithValue("@SDT", txtSoDienThoai.Text);
                        cmdNhanVien.Parameters.AddWithValue("@QueQuan", txtQueQuan.Text);
                        cmdNhanVien.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmdNhanVien.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                        cmdNhanVien.ExecuteNonQuery();

                        // Cập nhật bảng TaiKhoan
                        string queryTaiKhoan = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE TaiKhoan = @TaiKhoan";
                        SqlCommand cmdTaiKhoan = new SqlCommand(queryTaiKhoan, conn, transaction);
                        cmdTaiKhoan.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                        cmdTaiKhoan.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                        cmdTaiKhoan.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ResetFields();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không? Thao tác này cũng sẽ xóa tài khoản liên kết.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();
                        try
                        {
                            // 1. Xóa từ bảng NhanVien trước (vì có khóa ngoại)
                            string queryNhanVien = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                            SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn, transaction);
                            cmdNhanVien.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                            cmdNhanVien.ExecuteNonQuery();

                            // 2. Xóa từ bảng TaiKhoan
                            string queryTaiKhoan = "DELETE FROM TaiKhoan WHERE TaiKhoan = @TaiKhoan";
                            SqlCommand cmdTaiKhoan = new SqlCommand(queryTaiKhoan, conn, transaction);
                            cmdTaiKhoan.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                            cmdTaiKhoan.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ResetFields();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Tìm kiếm trên nhiều cột: MaNV, TenNV, SDT, Email, TaiKhoan
                    string query = @"SELECT 
                                        nv.MaNV, nv.TenNV, nv.SDT, nv.QueQuan, nv.Email, tk.TaiKhoan, tk.MatKhau 
                                     FROM NhanVien nv 
                                     JOIN TaiKhoan tk ON nv.TenTK = tk.TaiKhoan
                                     WHERE nv.MaNV LIKE @keyword 
                                        OR nv.TenNV LIKE @keyword 
                                        OR nv.SDT LIKE @keyword 
                                        OR nv.Email LIKE @keyword
                                        OR tk.TaiKhoan LIKE @keyword";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvNhanVien.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên nào phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvNhanVien.DataSource = null; // Hoặc giữ lại dữ liệu cũ tùy ý
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
