using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinhVien_2
{
    public partial class ProfileUser : DevExpress.XtraEditors.XtraForm
    {
        public ProfileUser()
        {
            InitializeComponent();
        }

        private void ProfileUser_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            DanhSach ds = new DanhSach();
            ds.ShowDialog();
            this.Close();
        }
    }
}