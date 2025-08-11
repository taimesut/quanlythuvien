using QuanLyThuVien.Repositories;
using System.Collections.Generic;

namespace QuanLyThuVien.Services
{
    public class ThongKeService
    {
        private readonly ThongKeRepository _repo;

        public ThongKeService()
        {
            _repo = new ThongKeRepository();
        }

        public int GetSoSachTonKho() => _repo.GetSoSachTonKho();
        public int GetSoSachDaMuon() => _repo.GetSoSachDaMuon();
        public int GetSoSachQuaHan() => _repo.GetSoSachQuaHan();
        public int GetSoDocGia() => _repo.GetSoDocGia();
        public int GetSoNhanVien() => _repo.GetSoNhanVien();
        public List<(string TheLoai, int SoLuong)> GetThongKeTheoTheLoai() => _repo.GetThongKeTheoTheLoai();
        public List<(string TenSach, int Tong)> GetTopSachMuon(int topN = 10) => _repo.GetTopSachMuon(topN);
        public List<(int MaSach, string TenSach)> GetSachChuaMuon() => _repo.GetSachChuaMuon();
    }
}
