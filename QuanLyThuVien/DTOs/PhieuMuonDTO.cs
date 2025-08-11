using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTOs
{
    public class PhieuMuonDTO
    {
        public PhieuMuonDTO(int maPhieuMuon, int maNhanVien, int maDocGia, DateTime ngayMuon, DateTime hanTra, int trangThai)
        {
            MaPhieuMuon = maPhieuMuon;
            MaNhanVien = maNhanVien;
            MaDocGia = maDocGia;
            NgayMuon = ngayMuon;
            HanTra = hanTra;
            TrangThai = trangThai;
        }

        public int MaPhieuMuon {  get; set; }
        public int MaNhanVien {  get; set; }
        public int MaDocGia {  get; set; }
        public DateTime NgayMuon {  get; set; }
        public DateTime HanTra {  get; set; }
        public int TrangThai{  get; set; }
    }
}
