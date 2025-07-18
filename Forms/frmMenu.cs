using QuanLyCuaHangMyPham.Forms;
using QuanLyCuaHangMyPham.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class frmMenu : Form
    {
        private TaiKhoan _currentUser; // Lưu trữ thông tin người dùng đã đăng nhập

        public frmMenu(Models.TaiKhoan user)
        {
            InitializeComponent();
            _currentUser = user; // Gán người dùng đã đăng nhập
            this.Text = $"Quản lý Cửa hàng Mỹ phẩm - Chào mừng: {user.Account}";

            // Tùy biến giao diện hoặc quyền truy cập dựa trên _currentUser.PhanQuyen
            // Ví dụ: if (_currentUser.PhanQuyen == "Admin") { /* hiển thị chức năng admin */ }
        }

        private void LoadForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.TopMost = true; // Đặt childForm ở trên cùng
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront(); // Đưa childForm lên trên cùng của panel
            panelMain.Controls.Clear(); // Corrected: Clear() does not take arguments
            panelMain.Controls.Add(childForm); // Add the child form to the panel
            childForm.Show();
        }
        // Phương thức đổi màu nút đang active
        private void ActiveColor(Button activeButton)
        {
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.LightGray; // Màu mặc định
                }
            }
            activeButton.BackColor = Color.SteelBlue; // Màu khi được chọn
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham a = new frmSanPham();
            LoadForm(a);
            ActiveColor(btnSanPham);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap a = new frmNhaCungCap();
            LoadForm(a);
            ActiveColor(btnNhaCungCap);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            frmDonHang a = new frmDonHang(_currentUser); // Truyền đối tượng người dùng đang đăng nhập
            LoadForm(a);
            ActiveColor(btnDonHang);
            
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            frmKhoHang a = new frmKhoHang();
            LoadForm(a);
            ActiveColor(btnKhoHang);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien a = new frmNhanVien();
            LoadForm(a);
            ActiveColor(btnNhanVien);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe a = new frmThongKe();
            LoadForm(a);
            ActiveColor(btnThongKe);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất tài khoản không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin a = new frmLogin();
                a.ShowDialog();
            }
        }

 
    }
}
