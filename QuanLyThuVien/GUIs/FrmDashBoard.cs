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
            AddListItemMenuSiderbar();

        }

        private void AddListItemMenuSiderbar()
        {
            
            AddSidebarButton("Thể loại");
            AddSidebarButton("Sách");
            AddSidebarButton("Quy định");
            AddSidebarButton("Độc giả");
            //AddSidebarButton("Đọc giả");
            //AddSidebarButton("Nhân viên");
            //AddSidebarButton("Sách");
            //AddSidebarButton("Nhà xuất bản");
            //AddSidebarButton("Phiếu mượn");
            //AddSidebarButton("Nhà cung cấp");
            AddSidebarButton("Đăng xuất");

        }


        private void AddSidebarButton(string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(33, 37, 41); // Màu xám đen
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.Dock = DockStyle.Top;
            btn.Height = 40;

            // Sự kiện click
            btn.Click += SidebarButton_Click;

            // Thêm vào panel sidebar
            panelSidebar.Controls.Add(btn);
        }

        private void LoadFormToMainPanel(Form frm)
        {
            panelMain.Controls.Clear();        // Xóa control cũ
            frm.TopLevel = false;                // Không phải form độc lập
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;           // Fill toàn bộ panel
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void SidebarButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string menu = btn.Text;

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
                    LoadFormToMainPanel(new QuanLyThuVien.GUIs.frmTheLoai());
                    break;
                case "Sách":
                    LoadFormToMainPanel(new QuanLyThuVien.GUIs.frmSach());
                    break;
                case "Quy định":
                    LoadFormToMainPanel(new QuanLyThuVien.GUIs.frmQuyDinh());
                    break;
                case "Độc giả":
                    LoadFormToMainPanel(new QuanLyThuVien.GUIs.frmDocGia());
                    break;
                default:
                    break;
            }
        }

    }
}
