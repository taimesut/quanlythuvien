using QuanLyThuVien.DTOs;
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
    public partial class frmPhieuMuon : Form
    {
        DocGiaService docGiaService = new DocGiaService();
        SachService sachService = new SachService();
        TheLoaiService theLoaiService = new TheLoaiService();

        List<ChiTietPhieuMuonDTO> listChiTietMuon = new List<ChiTietPhieuMuonDTO>();
        DocGiaDTO docGiaCB;

        PhieuMuonRepository phieuMuonRepository = new PhieuMuonRepository();
        ChiTietPhieuMuonRepository chiTietPhieuMuonRepository = new ChiTietPhieuMuonRepository();

        QuyDinhRepository QuyDinhRepository = new QuyDinhRepository();

        public frmPhieuMuon()
        {
            InitializeComponent();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            var listSach = sachService.GetAll();
            var listTheLoai = theLoaiService.GetAll();

            

            var sachWithTenTheLoai = from s in listSach
                                     join tl in listTheLoai on s.MaTheLoai equals tl.MaTheLoai
                                     select new
                                     {
                                         s.MaSach,
                                         s.TenSach,
                                         TenTheLoai = tl.TenTheLoai,
                                         s.TacGia,
                                         s.NhaXuatBan,
                                         s.SoLuong,
                                     };
            dgvSach.DataSource = sachWithTenTheLoai.ToList();

            nudSoLuong.Minimum = 1;
            nudSoLuong.Maximum = 100;
        }

        private void loadThongTinDocGia()
        {
            if (txtNhapMaDocGia.Text.Length == 0)
            {
                return;
            }
            DocGiaDTO docGia = docGiaService.LayDocGiaTheoId(int.Parse(txtNhapMaDocGia.Text));
            docGiaCB = docGia;
            if (docGia != null)
            {
                txtMaDocGia.Text = docGia.MaDocGia.ToString();
                txtHoTen.Text = docGia.HoVaTen.ToString();
                txtDiaChi.Text = docGia.DiaChi.ToString();
                txtGioiTinh.Text = docGia.GioiTinh.ToString();
                txtSoDienThoai.Text = docGia.SoDienThoai.ToString();
              
            }
            else
            {
                MessageBox.Show("Mã đọc giả không tồn tại");
            }


           
        }


        List<ChiTietPhieuMuonDTO> listchitietmuon = new List<ChiTietPhieuMuonDTO>();


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sách.");
                return;
            }

            dynamic item = dgvSach.CurrentRow.DataBoundItem;
            if (item != null)
            {
                int maSach = item.MaSach;
                string tenSach = item.TenSach;
                int soLuongMuon = (int)nudSoLuong.Value;
                Console.WriteLine(maSach);
                Console.WriteLine(tenSach);
                Console.WriteLine(soLuongMuon);

                if (soLuongMuon > item.SoLuong)
                {
                    MessageBox.Show("Số lượng mượn vượt quá tồn kho.");
                    return;
                }

                var chitietmuon = new ChiTietPhieuMuonDTO(maSach, 0, soLuongMuon);
                listchitietmuon.Add(chitietmuon);
                var listSach = sachService.GetAll();


                var listnew = from s in listchitietmuon
                              join ls in listSach on s.MaSach equals ls.MaSach
                              select new
                              {
                                  s.MaSach,
                                  ls.TenSach,
                                  s.SoLuong,
                              };

                dgvChiTietPhieuMuon.DataSource = null;
                dgvChiTietPhieuMuon.DataSource = listnew.ToList();
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNhapMaDocGia.Text.Length > 0) {
                int? maphieu = phieuMuonRepository.AddAndGetId(new PhieuMuonDTO(0, Session.NhanVien.MaNhanVien, docGiaCB.MaDocGia, DateTime.Now
                    ,DateTime.Now.AddDays(QuyDinhRepository.GetById(1).SoNgayMuonToiDa), 1));

                if (maphieu.HasValue)
                {
                    foreach (var item in listchitietmuon)
                    {
                        item.MaPhieuMuon = maphieu.Value;
                        chiTietPhieuMuonRepository.Add(item);
                    }
                }
                MessageBox.Show("Lưu phiếu mượn thành công!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            loadThongTinDocGia();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuMuon.CurrentRow != null)
            {
                int maSach = Convert.ToInt32(dgvChiTietPhieuMuon.CurrentRow.Cells["MaSach"].Value);

                var itemToRemove = listchitietmuon.FirstOrDefault(x => x.MaSach == maSach);
                if (itemToRemove != null)
                {
                    listchitietmuon.Remove(itemToRemove);
                }

                var listSach = sachService.GetAll();
                var listnew = from s in listchitietmuon
                              join ls in listSach on s.MaSach equals ls.MaSach
                              select new
                              {
                                  s.MaSach,
                                  ls.TenSach,
                                  s.SoLuong,
                              };

                dgvChiTietPhieuMuon.DataSource = null;
                dgvChiTietPhieuMuon.DataSource = listnew.ToList();
            }
        }
    }
}
