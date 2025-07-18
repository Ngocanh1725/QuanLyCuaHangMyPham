using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form được tải
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Thiết lập để mật khẩu hiển thị dưới dạng dấu '*'
            txtPassword.PasswordChar = '*';
        }

        // Sự kiện khi nhấn nút "Login"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã nhập liệu chưa
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // 2. Xác thực với cơ sở dữ liệu
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT PhanQuyen FROM TaiKhoan WHERE TaiKhoan = @username AND MatKhau = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Sử dụng Parameters để tránh lỗi SQL Injection
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        // Thực thi câu lệnh và lấy kết quả
                        object result = cmd.ExecuteScalar();

                        if (result != null) // Nếu tìm thấy tài khoản
                        {
                            string phanQuyen = result.ToString();

                            // Mở Form Menu chính và truyền quyền hạn qua
                            FormMenu mainMenu = new FormMenu(phanQuyen, txtUsername.Text);
                            mainMenu.FormClosed += (s, args) => this.Show(); // Hiển thị lại form login khi form menu đóng
                            mainMenu.Show();
                            this.Hide(); // Ẩn form đăng nhập
                        }
                        else // Nếu không tìm thấy
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có vấn đề kết nối CSDL
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi thay đổi trạng thái của CheckBox "Hiển thị mật khẩu"
        private void checkViewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkViewPassword.Checked)
            {
                // Hiển thị mật khẩu dưới dạng văn bản thường
                txtPassword.PasswordChar = '\0'; // Ký tự null
            }
            else
            {
                // Ẩn mật khẩu bằng dấu '*'
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
