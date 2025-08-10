using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTOs
{
    public class ChiTietPhieuMuonDTO
    {
        public ChiTietPhieuMuonDTO(int maSach, int maPhieuMuon, int soLuong)
        {
            MaSach = maSach;
            MaPhieuMuon = maPhieuMuon;
            SoLuong = soLuong;
        }

        public int MaSach {  get; set; }
        public int MaPhieuMuon {  get; set; }
        public int SoLuong {  get; set; }
    }
}
