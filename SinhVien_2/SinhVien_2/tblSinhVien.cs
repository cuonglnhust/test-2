using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien_2
{
    class tblSinhVien
    {
        //class ánh xạ lại những thuộc tính có trong SQL server
        public int id { set; get; }
        public string MaSv { set; get; }
        public string TenSV { set; get; }
        public string Lop { set; get; }
        public double Diem { set; get; }
        public string DiaChi { set; get; }
    }
}
