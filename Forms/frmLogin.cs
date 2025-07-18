using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;//Cần cho Color
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms; //Không cần import QuanLyCuaHangMyPham.Database trực tiếp ở đây nữa, vì LoginManager đã xử lý việc đó.
using QuanLyCuaHangMyPham.Database;
using QuanLyCuaHangMyPham.Models; //Cần thiết cho TaiKhoan

namespace QuanLyCuaHangMyPham
{
    public partial class frmLogin : Form
    {
        //Sử dụng một instance của LoginManager để xử lý logic đăng nhập

        //Định nghĩa chuỗi placeholder cho các Textbox
        private const string UsernamePlaceholder = "Nhập tài khoản...";
        private const string PasswordPlaceholder = "Nhập mật khẩu...";
        public frmLogin()
        {
            InitializeComponent(); // Ensure controls are initialized

            //Gán các sự kiện Enter và Leave cho txtUserName và txtPassWord
            txtUserName.Enter += new EventHandler(txtUserName_Enter);
            txtUserName.Leave += new EventHandler(txtUserName_Leave);
            txtPassWord.Enter += new EventHandler(txtPassWord_Enter);
            txtPassWord.Leave += new EventHandler(txtPassWord_Leave);

            //Thiết lập trạng thái ban đầu cho các TextBox với placeholder
            SetPlaceholder(txtUserName, UsernamePlaceholder);
            SetPlaceholder(txtPassWord, PasswordPlaceholder);
            txtPassWord.PasswordChar = '\0'; // Ban đầu không che ký tự khi placeholder hiện
        }
        //Phương thức hỗ trợ thiết lập Placeholder
        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = System.Drawing.Color.LightGray; // Màu chữ mờ
        }

        //Xử lý sự kiện Enter cho txtUserName
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == UsernamePlaceholder)
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = System.Drawing.SystemColors.WindowText; //Đặt lại màu chữ bình thường
            }
        }

        //Xử lý sự kiện Leave cho txtUserName
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                SetPlaceholder(txtUserName, UsernamePlaceholder);
            }
        }

        //Xử lý sự kiện Enter cho txtPassWord
        private void txtPassWord_Enter(object sender, EventArgs e)
        {
            if (txtPassWord.Text == PasswordPlaceholder)
            {
                txtPassWord.Text = "";
                txtPassWord.ForeColor = System.Drawing.SystemColors.WindowText;
                // Chỉ áp dụng PasswordChar nếu checkbox KHÔNG được chọn
                if (!checkViewPassWord.Checked)
                {
                    txtPassWord.PasswordChar = '*';
                }
            }
        }

        //Xử lý sự kiện Leave cho txtPassWord
        private void txtPassWord_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                SetPlaceholder(txtPassWord, PasswordPlaceholder);
                txtPassWord.PasswordChar = '\0'; // Placeholder không bị che
            }
            // Nếu có văn bản và checkbox KHÔNG được chọn, áp dụng PasswordChar
            else if (!checkViewPassWord.Checked)
            {
                txtPassWord.PasswordChar = '*';
            }
        }

        private void checkViewPassWord_CheckedChanged(object sender, EventArgs e)
        {
            //Nếu textbox đang hiển thị placeholder, không che kí tự
            if (txtPassWord.Text == PasswordPlaceholder)
            {
                txtPassWord.PasswordChar = '\0'; //Luôn hiển thị văn bản placehodler
                return; //Thoát vì không cần làm gì thêm
            }

            //Ngược lại, chuyển đổi kí tự mật khẩu dựa trên trạng thái của checkbox
            if (checkViewPassWord.Checked)
            {
                txtPassWord.PasswordChar = '\0'; //Hiển thị mật khẩu
            }
            else
            {
                txtPassWord.PasswordChar = '*'; //Ẩn mật khẩu bằng dấu *
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         SqlConnection connection = new SqlConnection("Server=ADMIN-PC;Database=QuanLyCuaHangMyPham;User Id=sa;Password=12345678;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM TaiKhoan WHERE TaiKhoan = @username AND MatKhau = @password", connection);
            cmd.Parameters.AddWithValue("@username", txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", txtPassWord.Text);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    // Nếu có kết quả, đăng nhập thành công
                    reader.Read(); // Đọc dòng đầu tiên
                    TaiKhoan user = new TaiKhoan
                    {
                        Account = reader["TaiKhoan"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        PhanQuyen = reader["PhanQuyen"].ToString()
                    };
                    frmMenu menuForm = new frmMenu(user);
                    menuForm.Show();
                    this.Hide(); // Ẩn form đăng nhập
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}