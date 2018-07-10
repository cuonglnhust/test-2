using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien_2
{
    class SinhVienBLL
    {
        //Lớp xử lý nghiệp vụ
        SinhVienDAL dalSV;
        public SinhVienBLL()
        {
            dalSV = new SinhVienDAL();
        }
        public DataTable getAllSinhVien()
        {
            return dalSV.getAllSinhVien();
        }
        public bool InsertSinhVien(tblSinhVien sv)
        {
            return dalSV.InsertSinhVien(sv);
        }
        public bool UpdateSinhVien(tblSinhVien sv)
        {
            return dalSV.UpdateSinhVien(sv);
        }
        public bool DeleteSinhVien(tblSinhVien sv)
        {
            return dalSV.DeleteSinhVien(sv);
        }
        public DataTable FindSinhVien(String sv)
        {
            return dalSV.FindSinhVien(sv);
        }
    }
}
