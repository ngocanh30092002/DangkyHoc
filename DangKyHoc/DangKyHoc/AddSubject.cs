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
    public partial class AddSubject : Form
    {
        private SqlConnectionStringBuilder conStr;
       
        private SqlConnection connection;

        public AddSubject()
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
        private void AddSubject_Load(object sender, EventArgs e)
        {
            fillDataInTable("Subjects");

        }

        private void fillDataInTable(string tableName)
        {
            connection.Open();

            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"Select * from {tableName}";

            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet(tableName);

            da.Fill(ds);

            ds.Tables[0].Columns[0].ColumnName = "Subject Code";
            ds.Tables[0].Columns[1].ColumnName = "Subject Name";
            ds.Tables[0].Columns[2].ColumnName = "Subject Number";
            ds.Tables[0].Columns[3].ColumnName = "Subject Factor";

            gridView.DataSource = ds.Tables[0];
            connection.Close();


        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var dataGridView = (DataGridView)sender;
            var subCode = dataGridView.Rows[e.RowIndex].Cells[0].Value;
            var subName = dataGridView.Rows[e.RowIndex].Cells[1].Value;
            var subNum = dataGridView.Rows[e.RowIndex].Cells[2].Value;
            var subFactor = dataGridView.Rows[e.RowIndex].Cells[3].Value;

            txtSubNum.Text = subNum.ToString();
            txtSubName.Text = subName.ToString();
            txtSubCode.Text = subCode.ToString();
            txtSubFactor.Text = subFactor.ToString();
        }

        private bool checkEmptyString(string subCode, string subName, string subNum , string subFactor)
        {
            return String.IsNullOrEmpty(subCode) && String.IsNullOrEmpty(subName) && String.IsNullOrEmpty(subNum) && String.IsNullOrEmpty(subFactor);
        }
        private bool checkExistSubCode(string subCode)
        {
            
            for(int i = 0; i  < gridView.Rows.Count; i++ ) {
                var col = gridView.Rows[i].Cells[0].Value;
                if(subCode == col.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private bool isIntNumber(string subNum)
        {
            int number;
            return int.TryParse(subNum, out number);
        }
        private bool isDoubleNumber(string subFactor)
        {
            int number;
            double number1;
            return int.TryParse(subFactor, out number) || double.TryParse(subFactor,out number1);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string subCode = txtSubCode.Text;
            string subName = txtSubName.Text;
            string subNum = txtSubNum.Text;
            string subFactor = txtSubFactor.Text;

            if (checkEmptyString(subCode, subName, subNum, subFactor)){
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (checkExistSubCode(subCode)){
                MessageBox.Show("Thông tin đã tồn tại", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (!isIntNumber(subNum))
            {
                MessageBox.Show("Số tín phải là một số nguyên", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if(!isDoubleNumber(subFactor)){
                MessageBox.Show("Hệ số phải là một số ", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if(subCode.Length != 5)
            {
                MessageBox.Show("Mã môn học phải dài 5 kí tự", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.CommandText = $"Insert Into Subjects (subCode, subName, subNum, subFactor) values ('{subCode}', '{subName}' , {subNum} , {subFactor})";
                cmd.Connection = connection;

                var rowAffects = cmd.ExecuteNonQuery();

                if (rowAffects <= 0)
                {
                    MessageBox.Show("Có lỗi xảy ra", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                connection.Close();
                fillDataInTable("Subjects");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string subCode = txtSubCode.Text;
            string subName = txtSubName.Text;
            string subNum = txtSubNum.Text;
            string subFactor = txtSubFactor.Text;

            if (checkEmptyString(subCode, subName, subNum, subFactor))
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.CommandText = $"Update Subjects Set subName = '{subName}', subNum = '{subNum}' , subFactor = '{subFactor}' Where subCode = '{subCode}'";
                cmd.Connection = connection;

                var rowAffects = cmd.ExecuteNonQuery();

                if (rowAffects <= 0)
                {
                    MessageBox.Show("Có lỗi xảy ra", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                connection.Close();
                fillDataInTable("Subjects");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            string subCode = txtSubCode.Text;
            string subName = txtSubName.Text;
            string subNum = txtSubNum.Text;
            string subFactor = txtSubFactor.Text;

            if (checkEmptyString(subCode, subName, subNum, subFactor))
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.CommandText = $"Delete From Subjects Where subCode = '{subCode}'";
                cmd.Connection = connection;

                var rowAffects = cmd.ExecuteNonQuery();

                if (rowAffects <= 0)
                {
                    MessageBox.Show("Có lỗi xảy ra", "Subject Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                connection.Close();
                fillDataInTable("Subjects");

                txtSubName.Text = "";
                txtSubCode.Text = "";
                txtSubFactor.Text = "";
                txtSubNum.Text = "";
            }
        }
    }
}
