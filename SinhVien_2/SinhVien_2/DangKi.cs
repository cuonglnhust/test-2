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
    public partial class DangKi : DevExpress.XtraEditors.XtraForm
    {
        public DangKi()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            login lg = new login();
            lg.ShowDialog();
            this.Close();
        }

        private void DangKi_Load(object sender, EventArgs e)
        {

        }
    }
}