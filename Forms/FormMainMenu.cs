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
            PhanQuyen();
        }

        // Methods
        void PhanQuyen()
        {
            if (loginAccount.PhanQuyen.Equals("Nhân viên", StringComparison.OrdinalIgnoreCase))
            {
                btnNhanVien.Visible = false;
                btnThongKe.Visible = false;
            }
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = Color.White;
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.DeepPink;
                    currentButton.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                    previousBtn.BackColor = Color.FromArgb(255, 192, 203);
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
            OpenChildForm(new FormNhaCungCap(), sender);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDonHang(loginAccount), sender);
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKhoHang(), sender);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien(), sender);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe(), sender);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Thêm hộp thoại xác nhận trước khi đăng xuất
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Khi form này đóng, FormLogin sẽ tự động hiển thị lại
            // do cách gọi f.ShowDialog() trong FormLogin.
        }
    }
}
