using QuanLyThuVien.BUSINESS;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryDashboard
{
    public partial class FrmDashBoard : Form
    {
        private DataGridView dgv;

        public FrmDashBoard()
        {
            InitializeComponent();
            LoadSidebarButtons();
            LoadDashboardCards();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.Visible = false; // Ẩn mặc định
            this.Controls.Add(dgv);
            dgv.BringToFront();

            // Đặt vị trí và kích thước dgv trùng với tableLayoutPanel1
            dgv.Location = tableLayoutPanel1.Location;
            dgv.Size = tableLayoutPanel1.Size;
        }

        private void LoadSidebarButtons()
        {
            string[] menuItems = { "Thể loại", "Tác giả", "Sách", "Đọc giả", "Nhân viên", "Logout" };

            foreach (string item in menuItems)
            {
                var btn = new Button();
                btn.Text = item;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.FromArgb(33, 37, 41);
                btn.Font = new Font("Segoe UI", 10F);
                btn.Dock = DockStyle.Top;
                btn.Height = 40;
                btn.Click += SidebarButton_Click;
                sidebar.Controls.Add(btn);
                sidebar.Controls.SetChildIndex(btn, 0);
            }
        }

        private void SidebarButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string menu = btn.Text;

            if (menu == "Logout")
            {
                this.Close();
                return;
            }

            // Ẩn bảng card, hiện DataGridView
            tableLayoutPanel1.Visible = false;
            dgv.Visible = true;

            switch (menu)
            {
                case "Thể loại":
                    var theLoaiBUS = new TheLoai_BUS();
                    dgv.DataSource = theLoaiBUS.GetAll();
                    break;
                case "Tác giả":
                    var tacGiaBUS = new TacGia_BUS();
                    dgv.DataSource = tacGiaBUS.GetAll();
                    break;
                case "Sách":
                    var sachBUS = new Sach_BUS();
                    dgv.DataSource = sachBUS.GetAll();
                    break;
                case "Đọc giả":
                    var docGiaBUS = new DocGia_BUS();
                    dgv.DataSource = docGiaBUS.GetAll();
                    break;
                case "Nhân viên":
                    var nguoiDungBUS = new NhanVien_BUS();
                    dgv.DataSource = nguoiDungBUS.GetNhanVien();
                    break;
                default:
                    dgv.DataSource = null;
                    break;
            }
        }

        private void LoadDashboardCards()
        {
            var nguoiDungBUS = new NhanVien_BUS();
            var docGiaBUS = new DocGia_BUS();
            var sachBUS = new Sach_BUS();
            var nhaCungCapBUS = new NhaCungCap_BUS();
            var theLoaiBUS = new TheLoai_BUS();

            int soNhanVien = nguoiDungBUS.GetNhanVien().Count;
            int soDocGia = docGiaBUS.GetAll().Count;
            int soSach = sachBUS.GetAll().Count;
            int tongTonKho = sachBUS.GetAll().Sum(s => s.SoLuong);
            int soNhaCungCap = nhaCungCapBUS.GetAll().Count;
            int soTheLoai = theLoaiBUS.GetAll().Count;

            AddCard(soNhanVien.ToString(), "Nhân viên", Color.RoyalBlue);
            AddCard(soDocGia.ToString(), "Đọc giả", Color.Gold);
            AddCard(soSach.ToString(), "Sách", Color.IndianRed);
            AddCard(tongTonKho.ToString(), "Tổng tồn kho", Color.SeaGreen);
            AddCard(soNhaCungCap.ToString(), "Nhà cung cấp", Color.MediumPurple);
            AddCard(soTheLoai.ToString(), "Thể loại", Color.DarkOrange);
        }

        private void AddCard(string number, string text, Color bgColor)
        {
            var card = new Panel();
            card.BackColor = bgColor;
            card.Margin = new Padding(10);
            card.Dock = DockStyle.Fill;

            var lblNumber = new Label();
            lblNumber.Text = number;
            lblNumber.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblNumber.ForeColor = Color.White;
            lblNumber.Dock = DockStyle.Top;
            lblNumber.Height = 40;
            lblNumber.TextAlign = ContentAlignment.MiddleCenter;

            var lblText = new Label();
            lblText.Text = text;
            lblText.Font = new Font("Segoe UI", 10F);
            lblText.ForeColor = Color.White;
            lblText.Dock = DockStyle.Fill;
            lblText.TextAlign = ContentAlignment.MiddleCenter;

            card.Controls.Add(lblText);
            card.Controls.Add(lblNumber);

            tableLayoutPanel1.Controls.Add(card);
        }
    }
}
