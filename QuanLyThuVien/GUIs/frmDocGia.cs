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
    public partial class frmDocGia : Form
    {
        private DocGiaService docGiaService = new DocGiaService();

        public frmDocGia()
        {
            InitializeComponent();

            LoadData();

        }

        private void LoadData()
        {
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");


            LoadDocGia();
        }

        private void LoadDocGia()
        {
            var list = docGiaService.LayTatCaDocGia();

            dgvDocGia.DataSource = null;
            dgvDocGia.DataSource = list;

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var ketQua = docGiaService.LayTatCaDocGia().Where(d =>
                d.MaDocGia.ToString().Contains(keyword) ||
                d.HoVaTen.ToLower().Contains(keyword) ||
                d.DiaChi.ToLower().Contains(keyword) ||
                d.GioiTinh.Contains(keyword) ||
                d.SoDienThoai.Contains(keyword)
            ).ToList();

            dgvDocGia.DataSource = null;
            dgvDocGia.DataSource = ketQua;
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
    {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];

                txtMaDocGia.Text = row.Cells["MaDocGia"].Value.ToString();
                txtHoTen.Text = row.Cells["HoVaTen"].Value.ToString();


                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                string gt = row.Cells["GioiTinh"].Value?.ToString();
                cboGioiTinh.SelectedItem = gt;

                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var sach = new DocGiaDTO(
               0,
                txtHoTen.Text.ToString(),
                cboGioiTinh.SelectedItem.ToString(),
                txtDiaChi.Text.ToString(),
                txtSoDienThoai.Text.ToString()
            );

            docGiaService.ThemDocGia(sach);
            LoadDocGia();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var sach = new DocGiaDTO(
               int.Parse(txtMaDocGia.Text),
                txtHoTen.Text.ToString(),
                cboGioiTinh.SelectedItem.ToString(),
                txtDiaChi.Text.ToString(),
                txtSoDienThoai.Text.ToString()
            );

            docGiaService.CapNhatDocGia(sach);
            LoadDocGia();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDocGia.Text.Length > 0)
            {
                int maSach = int.Parse(txtMaDocGia.Text);
                docGiaService.XoaDocGia(maSach);
                LoadDocGia();
            }
            
        }

    }
}
