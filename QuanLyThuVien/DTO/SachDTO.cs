using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class SachDTO
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public int MaTacGia { get; set; }
        public int MaTheLoai { get; set; }
        public int MaNhaXuatBan { get; set; }
        public int MaNhaCungCap {  get; set; }
        public int NamXuatBan { get; set; }
        public int SoLuong { get; set; }

        public SachDTO() { }

        public SachDTO(int maSach, string tenSach, int maTacGia, int maTheLoai, int maNhaXuatBan, int maNhaCungCap, int namXuatBan, int soLuong)
        {
            MaSach = maSach;
            TenSach = tenSach;
            MaTacGia = maTacGia;
            MaTheLoai = maTheLoai;
            MaNhaXuatBan = maNhaXuatBan;
            MaNhaCungCap = maNhaCungCap;
            NamXuatBan = namXuatBan;
            SoLuong = soLuong;
        }
    }
}
