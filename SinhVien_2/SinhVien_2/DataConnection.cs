using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SinhVien_2
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source=Admin;Initial Catalog=QLSV;Integrated Security=True ";
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
