using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTOs
{
    public class SachDTO
    {
        public SachDTO(int maSach, int maTheLoai, string nhaXuatBan, string tacGia, string tenSach, int namXuatBan, int soLuong, string anh)
        {
            MaSach = maSach;
            MaTheLoai = maTheLoai;
            NhaXuatBan = nhaXuatBan;
            TacGia = tacGia;
            TenSach = tenSach;
            NamXuatBan = namXuatBan;
            SoLuong = soLuong;
            Anh = anh;

        }

        public int MaSach {  get; set; }
        public int MaTheLoai { get; set; }
        public string NhaXuatBan {  get; set; }
        public string TacGia {  get; set; }
        public string TenSach {  get; set; }
        public int NamXuatBan {  get; set; }
        public int SoLuong {  get; set; }
        public string Anh {  get; set; }    
    }
}
