using QuanLyThuVien.DTOs;
using QuanLyThuVien.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class NhanVienService
    {
        private readonly NhanVienRepository _repository;

        public NhanVienService()
        {
            _repository = new NhanVienRepository();
        }

        public List<NhanVienDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Add(NhanVienDTO nv)
        {
            if (string.IsNullOrWhiteSpace(nv.TenTaiKhoan) || string.IsNullOrWhiteSpace(nv.MatKhau))
            {
                throw new ArgumentException("Tên tài khoản và mật khẩu không được để trống");
            }
            return _repository.Add(nv);
        }

        public bool Update(NhanVienDTO nv)
        {
            return _repository.Update(nv);
        }

        public bool Delete(int maNhanVien)
        {
            return _repository.Delete(maNhanVien);
        }

        public NhanVienDTO GetById(int maNhanVien)
        {
            return _repository.GetById(maNhanVien);
        }

        public NhanVienDTO GetByUsername(string username)
        {
            return _repository.GetByUsername(username);
        }
    }
}
