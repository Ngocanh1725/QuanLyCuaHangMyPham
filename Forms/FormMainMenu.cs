using QuanLyCuaHangMyPham.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormMainMenu : Form
    {
        // Fields
        private Button currentButton;
        private Form activeForm;
        private TaiKhoanDTO loginAccount;

        // Constructor
        public FormMainMenu(TaiKhoanDTO acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            // Phân quyền sẽ được xử lý ở đây nếu cần
            // PhanQuyen(); 
        }

        // Methods
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = Color.White; // Màu khi button được chọn
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.DeepPink;
                    currentButton.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    // Thay đổi Title
                    lblTitle.Text = currentButton.Text.Trim().ToUpper();
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(255, 192, 203); // Màu nền mặc định của menu
                    previousBtn.ForeColor = Color.FromArgb(64, 64, 64);
                    previousBtn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // --- Event Handlers for Buttons ---
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSanPham(), sender);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng 'Nhà cung cấp' sẽ được phát triển ở bước tiếp theo.", "Thông báo");
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng 'Tạo đơn hàng' sẽ được phát triển ở bước tiếp theo.", "Thông báo");
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng 'Kho hàng' sẽ được phát triển ở bước tiếp theo.", "Thông báo");
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng 'Nhân viên' sẽ được phát triển ở bước tiếp theo.", "Thông báo");
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng 'Thống kê' sẽ được phát triển ở bước tiếp theo.", "Thông báo");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close(); // Sẽ kích hoạt FormClosing event của FormLogin để hiển thị lại
        }

        private void FormMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Khi FormMainMenu đóng, FormLogin sẽ được hiển thị lại
        }
    }
}
