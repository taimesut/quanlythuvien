using QuanLyThuVien.DATA_ACCESS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUSINESS
{
    public class Sach_BUS
    {
        private SachDAL dal;

        public Sach_BUS()
        {
            dal = new SachDAL();
        }

        public List<SachDTO> GetAll()
        {
            return dal.GetAll();
        }

        public bool Add(SachDTO s)
        {
            return dal.Insert(s);
        }

        public bool Update(SachDTO s)
        {
            return dal.Update(s);
        }

        public bool Delete(int maSach)
        {
            return dal.Delete(maSach);
        }

        public SachDTO GetById(int maSach)
        {
            return dal.GetById(maSach);
        }

        public List<SachDTO> Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
