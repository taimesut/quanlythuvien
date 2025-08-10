using QuanLyThuVien.DTOs;
using QuanLyThuVien.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class SachService
    {
        private SachRepository sachRepository = new SachRepository();

        public List<SachDTO> GetAll()
        {
            return sachRepository.GetAll();
        }

        public SachDTO GetById(int maSach)
        {
            return sachRepository.GetById(maSach);
        }

        public void Add(SachDTO sach)
        {
            sachRepository.Add(sach);
        }

        public void Update(SachDTO sach)
        {
            sachRepository.Update(sach);
        }

        public void Delete(int maSach)
        {
            sachRepository.Delete(maSach);
        }
    }
}
