using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien_2
{
    class SinhVienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SinhVienDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllSinhVien()
        {
            //B1: tạo câu lệnh SQL để lấy toàn bộ sinh viên
            string sql = "SELECT * FROM tblSinhVien";
            //B2: tạo 1 kết nối đến với SQL
            SqlConnection con = dc.getConnect();
            //B3: khởi tạo đối tượng của lớp sqlDataAdapter
            da = new SqlDataAdapter(sql,con);
            //B4: mở kết nối
            con.Open();
            //B5: Đổ dữ liệu từ sqlDataAdapter vào DataTable
            DataTable dt = new DataTable();
             da.Fill(dt);
            //B6: Đóng kết nối
            con.Close();

            return dt;
        }

        public bool InsertSinhVien(tblSinhVien sv)
        {
            string sql = "INSERT INTO tblSinhVien(MaSV, TenSV, Lop, DiaChi) VALUES (@MaSV,@TenSV,@Lop,@DiaChi)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSv;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = sv.Diem;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                //Câu lệnh để thực thi
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
           
            
        }

        public bool UpdateSinhVien(tblSinhVien sv)
        {
            string sql = "UPDATE tblSinhVien SET MaSV = @MaSV, TenSV = @TenSV, Diem = @Diem, Lop =@Lop, DiaChi =@DiaChi WHERE id = @id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSv;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = sv.Diem;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                //Câu lệnh để thực thi
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }

        public bool DeleteSinhVien(tblSinhVien sv)
        {
            string sql = "DELETE tblSinhVien WHERE id =@id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;
               
                //Câu lệnh để thực thi
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable FindSinhVien(String sv)
        {
            String sql = "SELECT * FROM tblSinhVien WHERE TenSV like N'%" + sv + "%'OR  Lop like N'%" + sv + "%'";
            //B2: tạo 1 kết nối đến với SQL
            SqlConnection con = dc.getConnect();
            //B3: khởi tạo đối tượng của lớp sqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //B4: mở kết nối
            con.Open();
            //B5: Đổ dữ liệu từ sqlDataAdapter vào DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //B6: Đóng kết nối
            con.Close();

            return dt;
        }
    }
}
