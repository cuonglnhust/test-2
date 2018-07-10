using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SinhVien_2
{
    public partial class login : DevExpress.XtraEditors.XtraForm
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=Admin;Initial Catalog=QLSV ;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txtTaiKhoan.Text;
                string mk = txtMatKhau.Text;
                string sql = "select * from tblAccount where TaiKhoan = '" + tk + "' and MatKhau ='" + mk + "'  ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();// nếu các câu lệnh là Insert, delete thì dùng excutenon
                if (dta.Read() == true)
                {
                    // MessageBox.Show("Đăng nhập thành công","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    DanhSach form2 = new DanhSach();
                    form2.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKi dk = new DangKi();
            dk.ShowDialog();
            this.Close();
        }
    }
}
