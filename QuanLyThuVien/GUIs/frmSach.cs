using QuanLyThuVien.DTOs;
using QuanLyThuVien.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUIs
{
    public partial class frmSach : Form
    {
        private SachService sachService = new SachService();
        private TheLoaiService theLoaiService = new TheLoaiService();

        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            LoadTheLoai();
            LoadSach();
        }

        private void LoadTheLoai()
        {
            var dsTheLoai = theLoaiService.GetAll();
            cboTheLoai.DataSource = dsTheLoai;
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
        }

        private void LoadSach()
        {
            dgvSach.DataSource = sachService.GetAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var sach = new SachDTO(
               0,
                (int)cboTheLoai.SelectedValue,
                txtNhaXuatBan.Text,
                txtTacGia.Text,
                txtTenSach.Text,
                int.Parse(txtNamXuatBan.Text),
                int.Parse(txtSoLuong.Text)
            );

            sachService.Add(sach);
            LoadSach();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var sach = new SachDTO(
                int.Parse(txtMaSach.Text),
                (int)cboTheLoai.SelectedValue,
                txtNhaXuatBan.Text,
                txtTacGia.Text,
                txtTenSach.Text,
                int.Parse(txtNamXuatBan.Text),
                int.Parse(txtSoLuong.Text)
            );

            sachService.Update(sach);
            LoadSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSach = int.Parse(txtMaSach.Text);
            sachService.Delete(maSach);
            LoadSach();
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                cboTheLoai.SelectedValue = row.Cells["MaTheLoai"].Value;
                txtTacGia.Text = row.Cells["TacGia"].Value.ToString();
                txtNhaXuatBan.Text = row.Cells["NhaXuatBan"].Value.ToString();
                txtNamXuatBan.Text = row.Cells["NamXuatBan"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var ketQua = sachService.GetAll().Where(s =>
                s.MaSach.ToString().Contains(keyword) ||
                s.MaTheLoai.ToString().Contains(keyword) ||
                s.TenSach.ToLower().Contains(keyword) ||
                s.TacGia.ToLower().Contains(keyword) ||
                s.NhaXuatBan.ToLower().Contains(keyword) ||
                s.NamXuatBan.ToString().Contains(keyword) ||
                s.SoLuong.ToString().Contains(keyword)
            ).ToList();

            dgvSach.DataSource = ketQua;
        }
    }
}
