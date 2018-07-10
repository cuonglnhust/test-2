using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace SinhVien_2
{
    public partial class DanhSach : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public void LockControl()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;

            
            txtTenSV.ReadOnly = true;
            txtMaSV.ReadOnly = true;
            txtLop.ReadOnly = true;
            txtDiem.ReadOnly = true;
            txtDiaChi.ReadOnly = true;


        }

        public void OpenControl()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            
            txtMaSV.Enabled = true;
            txtTenSV.ReadOnly = false;
            txtLop.ReadOnly = false;
            txtDiem.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            txtMaSV.Focus();
        }
        SinhVienBLL bllSV;
        public DanhSach()
        {
            InitializeComponent();
            bllSV = new SinhVienBLL();
        }
        public void ShowALLSinhVien()
        {
            DataTable dt = bllSV.getAllSinhVien();
            dataGridViewSinhVien.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DanhSach_Load(object sender, EventArgs e)
        {
            ShowALLSinhVien();
            txtMaSV.ReadOnly = true;
            txtTenSV.ReadOnly = true;
            txtLop.ReadOnly = true;
            txtDiem.ReadOnly = true;
            txtDiaChi.ReadOnly = true;


        }
        public bool CheckData()
        {
            if (String.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtTenSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenSV.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập Lớp sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLop.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiem.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnLuu.Enabled = true;
             
            txtMaSV.ReadOnly = false;
            txtTenSV.ReadOnly = false;
            txtLop.ReadOnly = false;
            txtDiem.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblSinhVien sv = new tblSinhVien();

                
                sv.id = ID;

                if (bllSV.DeleteSinhVien(sv))

                    ShowALLSinhVien();
                else
                    MessageBox.Show("đã có lỗi xảy ra xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            }
        }
        int ID;
        private void dataGridViewSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLuu.Enabled = false;

            txtMaSV.ReadOnly = false;
            txtTenSV.ReadOnly = false;
            txtLop.ReadOnly = false;
            txtDiem.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    ID = Int32.Parse(dataGridViewSinhVien.Rows[index].Cells["id"].Value.ToString());
                    txtMaSV.Text = dataGridViewSinhVien.Rows[index].Cells["MaSV"].Value.ToString();
                    txtTenSV.Text = dataGridViewSinhVien.Rows[index].Cells["TenSV"].Value.ToString();
                    txtLop.Text = dataGridViewSinhVien.Rows[index].Cells["Lop"].Value.ToString();
                    txtDiem.Text = dataGridViewSinhVien.Rows[index].Cells["Diem"].Value.ToString();
                    txtDiaChi.Text = dataGridViewSinhVien.Rows[index].Cells["DiaChi"].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("click chọn dòng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtMaSV.ReadOnly = true;
            txtTenSV.ReadOnly = true;
            txtLop.ReadOnly = true;
            txtDiem.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            if (CheckData())
            {
                tblSinhVien sv = new tblSinhVien();
                sv.id = ID;
                sv.MaSv = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.Lop = txtLop.Text;
                sv.Diem = double.Parse(txtDiem.Text);
                sv.DiaChi = txtDiaChi.Text;

                if (bllSV.UpdateSinhVien(sv))

                    ShowALLSinhVien();
                else
                    MessageBox.Show("đã có lỗi xảy ra xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtMaSV.ReadOnly = true;
            txtTenSV.ReadOnly = true;
            txtLop.ReadOnly = true;
            txtDiem.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            if (CheckData())
            {
                tblSinhVien sv = new tblSinhVien();
                sv.MaSv = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.Lop = txtLop.Text;
                sv.Diem = double.Parse( txtDiem.Text);
                sv.DiaChi = txtDiaChi.Text;

                if (bllSV.InsertSinhVien(sv))

                    ShowALLSinhVien();
                else
                    MessageBox.Show("đã có lỗi xảy ra xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            login lg = new login();
            lg.ShowDialog();
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtLop.Text = "";
            txtDiem.Text = "";
            txtDiaChi.Text = "";

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            ProfileUser prf = new ProfileUser();
            prf.ShowDialog();
            this.Close();

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            String value = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllSV.FindSinhVien(value);
                dataGridViewSinhVien.DataSource = dt;
            }
            else
            {
                ShowALLSinhVien();
            }
        }
    }
}