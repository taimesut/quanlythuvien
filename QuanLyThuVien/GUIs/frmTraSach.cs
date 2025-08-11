using LibraryDashboard;
using QuanLyThuVien.Repositories;
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
    public partial class frmTraSach : Form
    {

        private PhieuMuonRepository phieuMuonRepository = new PhieuMuonRepository();
        public frmTraSach()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            var list = phieuMuonRepository.GetAll();

            dgv.DataSource = null;

            var listWithStatusText = list.Select(p => new
            {
                p.MaPhieuMuon,
                p.MaNhanVien,
                p.MaDocGia,
                p.NgayMuon,
                p.HanTra,
                TrangThai = p.TrangThai == 1 ? "Đang mượn" : "Đã trả"
            }).ToList();

            dgv.DataSource = listWithStatusText;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text.Length > 0)
            {
                phieuMuonRepository.UpdateStatus(int.Parse(txtMaPhieu.Text), 0);
                LoadData();
            }
           
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv.Rows[e.RowIndex];
                txtMaPhieu.Text = row.Cells["MaPhieuMuon"].Value.ToString();
                txtMaDocGia.Text = row.Cells["MaDocGia"].Value.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var ketQua = phieuMuonRepository.GetAll().Where(s =>
                s.MaNhanVien.ToString().Contains(keyword) ||
                s.MaPhieuMuon.ToString().Contains(keyword) ||
                s.MaDocGia.ToString().Contains(keyword)
            ).ToList();

            var listWithStatusText = ketQua.Select(p => new
            {
                p.MaPhieuMuon,
                p.MaNhanVien,
                p.MaDocGia,
                p.NgayMuon,
                p.HanTra,
                TrangThai = p.TrangThai == 1 ? "Đang mượn" : "Đã trả"
            }).ToList();

            dgv.DataSource = listWithStatusText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtMaPhieu.Text.Length > 0)
            {
                using (ChiTietPhieuMuon dashboard = new ChiTietPhieuMuon(int.Parse(txtMaPhieu.Text)))
                {
                    dashboard.ShowDialog();
                }
            }
            
        }
    }
}
