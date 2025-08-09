using QuanLyThuVien.DATA_ACCESS;
using QuanLyThuVien.DTO.QuanLyThuVien.DTO;
using System.Collections.Generic;

namespace QuanLyThuVien.BUSINESS
{
    public class NhanVien_BUS
    {
        private readonly NhanVienDAL dal;

        public NhanVien_BUS()
        {
            dal = new NhanVienDAL();
        }

        public List<NhanVienDTO> GetAllNguoiDung()
        {
            return dal.GetAll();
        }

        public bool ThemNguoiDung(NhanVienDTO nd)
        {
  
            return dal.Insert(nd);
        }

        public bool SuaNguoiDung(NhanVienDTO nd)
        {
            return dal.Update(nd);
        }

        public bool XoaNguoiDung(string tenTaiKhoan)
        {
            return dal.Delete(tenTaiKhoan);
        }

        public NhanVienDTO LayNguoiDungTheoId(string tenTaiKhoan)
        {
            return dal.GetById(tenTaiKhoan);
        }
        public bool KiemTraDangNhap(string tenTaiKhoan, string matKhau)
        {
            var nd = dal.GetById(tenTaiKhoan);
            if (nd == null) return false;
            return nd.MatKhau == matKhau;
        }

        public List<NhanVienDTO> GetNhanVien()
        {
            return dal.GetNhanVien();
        }


    }
}
