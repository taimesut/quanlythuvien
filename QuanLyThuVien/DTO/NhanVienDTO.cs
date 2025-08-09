using System;

namespace QuanLyThuVien.DTO
{
    namespace QuanLyThuVien.DTO
    {
        public class NhanVienDTO
        {
            public NhanVienDTO()
            {
            }

            public NhanVienDTO(string tenTaiKhoan, string matKhau, string hoVaTen, DateTime ngaySinh, string diaChi, string gioiTinh, string soDienThoai, string chucVu, string role)
            {
                TenTaiKhoan = tenTaiKhoan;
                MatKhau = matKhau;
                HoVaTen = hoVaTen;
                NgaySinh = ngaySinh;
                DiaChi = diaChi;
                GioiTinh = gioiTinh;
                SoDienThoai = soDienThoai;
                ChucVu = chucVu;
                Role = role;
            }

            public string TenTaiKhoan { get; set; }
            public string MatKhau { get; set; }
            public string HoVaTen { get; set; }
            public DateTime NgaySinh { get; set; }
            public string DiaChi { get; set; }
            public string GioiTinh { get; set; }
            public string SoDienThoai { get; set; }
            public string ChucVu { get; set; }
            public string Role { get; set; }
        }
    }

}
