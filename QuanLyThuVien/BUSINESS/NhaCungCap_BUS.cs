using QuanLyThuVien.DATA_ACCESS;
using QuanLyThuVien.DTO;
using System.Collections.Generic;

namespace QuanLyThuVien.BUSINESS
{
    public class NhaCungCap_BUS
    {
        private NhaCungCapDAL dal;

        public NhaCungCap_BUS()
        {
            dal = new NhaCungCapDAL();
        }

        public List<NhaCungCapDTO> GetAll()
        {
            return dal.GetAll();
        }

        public bool Add(NhaCungCapDTO ncc)
        {
            return dal.Insert(ncc);
        }

        public bool Update(NhaCungCapDTO ncc)
        {
            return dal.Update(ncc);
        }

        public bool Delete(int maNCC)
        {
            return dal.Delete(maNCC);
        }

        public NhaCungCapDTO GetById(int maNCC)
        {
            return dal.GetById(maNCC);
        }

        public List<NhaCungCapDTO> Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
