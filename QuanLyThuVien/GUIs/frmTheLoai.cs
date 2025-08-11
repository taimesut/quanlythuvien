using QuanLyThuVien.DTOs;
using QuanLyThuVien.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUIs
{
    public partial class frmTheLoai : Form
    {
        private TheLoaiService theLoaiService = new TheLoaiService();

        public frmTheLoai()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            dgv.DataSource = theLoaiService.GetAll();
            dgv.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                theLoaiService.Add(txtTenTheLoai.Text);
                LoadData();
                ClearForm();
                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                int ma = int.Parse(txtMaTheLoai.Text);
                theLoaiService.Update(ma, txtTenTheLoai.Text);
                LoadData();
                ClearForm();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int ma = int.Parse(txtMaTheLoai.Text);
                theLoaiService.Delete(ma);
                LoadData();
                ClearForm();
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm()
        {
            txtMaTheLoai.Clear();
            txtTenTheLoai.Clear();
            txtTenTheLoai.Focus();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv.Rows[e.RowIndex];
                txtMaTheLoai.Text = row.Cells["MaTheLoai"].Value.ToString();
                txtTenTheLoai.Text = row.Cells["TenTheLoai"].Value.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var ketQua = theLoaiService.GetAll().Where(s =>
                s.MaTheLoai.ToString().Contains(keyword) ||
                s.TenTheLoai.ToString().Contains(keyword)
            ).ToList();

            dgv.DataSource = ketQua;
        }
    }
}

