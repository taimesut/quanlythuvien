using QuanLyThuVien;
using QuanLyThuVien.GUIs;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryDashboard
{
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }

        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            AddListItemMenuSiderbar();
        }

        private void AddListItemMenuSiderbar()
        {
            if (Session.NhanVien.ChucVu == "Admin")
            {
                AddSidebarButton("Nhân viên");
                AddSidebarButton("Quy định");
                AddSidebarButton("Thống kê");
            }

            AddSidebarButton("Thể loại");
            AddSidebarButton("Sách");
            AddSidebarButton("Độc giả");
            AddSidebarButton("Tạo Phiếu mượn");
            AddSidebarButton("Xem Phiếu mượn");
            AddSidebarButton("Đổi mật khẩu");
            AddSidebarButton("Đăng xuất");
        }

        private void AddSidebarButton(string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(33, 37, 41);
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.Dock = DockStyle.Top;
            btn.Height = 40;
            btn.Tag = text;

            btn.Click += SidebarButton_Click;

            panelSidebar.Controls.Add(btn);
            panelSidebar.Controls.SetChildIndex(btn, 0);
        }

        private void SidebarButton_Click(object sender, EventArgs e)
        {
            // Reset màu tất cả button
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button b)
                {
                    b.BackColor = Color.FromArgb(33, 37, 41);
                    b.ForeColor = Color.White;
                }
            }

            // Đổi màu nút click
            var btn = sender as Button;
            btn.BackColor = Color.FromArgb(52, 152, 219);
            btn.ForeColor = Color.White;

            string menu = btn.Tag.ToString();

            if (menu == "Đăng xuất")
            {
                this.Hide();
                FrmDangNhap loginForm = new FrmDangNhap();
                loginForm.ShowDialog();
                this.Close();
                return;
            }

            switch (menu)
            {
                case "Thể loại":
                    this.Text = "Quản lý Thể loại";
                    LoadFormToMainPanel(new frmTheLoai());
                    break;
                case "Sách":
                    this.Text = "Quản lý Sách";
                    LoadFormToMainPanel(new frmSach());
                    break;
                case "Quy định":
                    this.Text = "Quy định";
                    LoadFormToMainPanel(new frmQuyDinh());
                    break;
                case "Độc giả":
                    this.Text = "Quản lý Độc giả";
                    LoadFormToMainPanel(new frmDocGia());
                    break;
                case "Nhân viên":
                    this.Text = "Quản lý Nhân viên";
                    LoadFormToMainPanel(new frmNhanVien());
                    break;
                case "Tạo Phiếu mượn":
                    this.Text = "Tạo Phiếu mượn";
                    LoadFormToMainPanel(new frmPhieuMuon());
                    break;
                case "Xem Phiếu mượn":
                    this.Text = "Phiếu mượn";
                    LoadFormToMainPanel(new frmTraSach());
                    break;
                case "Đổi mật khẩu":
                    this.Text = "Đổi mật khẩu";
                    LoadFormToMainPanel(new frmDoiMatKhau());
                    break;
                case "Thống kê":
                    this.Text = "Thống kê";
                    LoadFormToMainPanel(new FrmThongKe());
                    break;
                default:
                    this.Text = "Dashbroad";
                    break;
            }
        }

        private void LoadFormToMainPanel(Form frm)
        {
            panelMain.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(frm);
            frm.Show();
        }
    }
}
