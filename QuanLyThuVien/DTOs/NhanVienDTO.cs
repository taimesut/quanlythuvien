using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTOs
{
    public class NhanVienDTO
    {
        public NhanVienDTO(int maNhanVien, string tenTaiKhoan, string matKhau, string hoVaTen, string diaChi, string gioiTinh, string soDienThoai, string chucVu)
        {
            MaNhanVien = maNhanVien;
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
            HoVaTen = hoVaTen;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
            ChucVu = chucVu;
        }

        public int MaNhanVien {  get; set; }
        public string TenTaiKhoan {  get; set; }
        public string MatKhau {  get; set; }
        public string HoVaTen {  get; set; }
        public string DiaChi {  get; set; }
        public string GioiTinh {  get; set; }
        public string SoDienThoai {  get; set; }
        public string ChucVu {  get; set; }
    }
}
