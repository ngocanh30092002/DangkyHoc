using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DangKyHoc
{
    public partial class Form1 : Form
    {
        List<User> users = new List<User>();
        bool isValid = false;
        public const double tuitionFee = 440000;

        private SqlConnectionStringBuilder conStr;
        private SqlConnection connection;


        public Form1()
        {
            InitializeComponent();
            //openAddSubjectForm();
            openAddStudentTerm();
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

        public void openAddSubjectForm()
        {
            var addSubject = new AddSubject();
            addSubject.ShowDialog();
        }
        public void openAddStudentTerm()
        {
            var addStudentTerm = new AddStudentTerm();
            addStudentTerm.ShowDialog();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        #region Show đăng nhập
        private void btnDN_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
            }
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
            }
            else
            {
                users.ForEach(user =>
                {
                    if (User.userName == textBox1.Text && User.userPassword == textBox2.Text)
                    {
                        isValid = true;
                        return;
                    }
                    return;
                });
            }
        }
        #endregion
    }
}
