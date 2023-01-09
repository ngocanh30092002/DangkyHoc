using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangKyHoc
{
    public partial class DangNhap : Form
    {
        private SqlConnectionStringBuilder conStr;

        private SqlConnection connection;
        public DangNhap()
        {
            InitializeComponent();
            ConnectionDataBase();
        }
        private void ConnectionDataBase()
        {
            conStr = new SqlConnectionStringBuilder();
            conStr["Server"] = ".";
            conStr["Database"] = "DangKyHoc";
            conStr["UID"] = "sa";
            conStr["PWD"] = "123";
            connection = new SqlConnection(conStr.ToString());
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
