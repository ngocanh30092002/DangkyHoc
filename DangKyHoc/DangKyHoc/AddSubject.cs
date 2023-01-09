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

        private bool isNumberOrNot(string subNum)
        {
            return isNumber().
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
