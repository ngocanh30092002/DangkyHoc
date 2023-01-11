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
    public partial class Summary : Form
    {
        private SqlConnectionStringBuilder conStr;
        private SqlConnection connection;
        private string userName = "A38809";
        public Summary()
        {
            InitializeComponent();
        }
        public Summary(string userName)
        {
            this.userName = userName;
            InitializeComponent();
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
        private string getNameUser()
        {
            connection.Open();
            if(connection.State == ConnectionState.Open)
            {
                var sqlCmd = new SqlCommand($"Select studentName from Students where userName = '{userName}'" , connection);
                var reader = sqlCmd.ExecuteScalar();
                connection.Close();
                return reader.ToString();
            }
            else
            {
                MessageBox.Show("Không thể kết nối với Database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            return "";

        }
        private void loadGridView()
        {
            connection.Open();
            if(connection.State == ConnectionState.Open)
            {
                var sqlCmd = new SqlCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = $" Select s.studentTerm ,s.studentYear, count(s.subCode) as 'Total Subjects'," +
                    $" SUM(sj.subNum) as 'Total Credits' , sum(sj.subNum * sj.subFactor * {Form1.tuitionFee}) as 'Total'" +
                    $" From StudentsSemester S Inner join Subjects Sj On S.subCode = Sj.subCode " +
                    $" Where S.userName = '{userName}'" +
                    $" Group By s.studentTerm, s.studentYear";

                var da = new SqlDataAdapter(sqlCmd);
                var dt = new DataTable();

                da.Fill(dt);

                loadTotalTuitionFee(dt);
                dt.Columns.Remove("Total");
                gridView.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không thể kết nối với Database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void loadHeader()
        {
            lbUsrName.Text = userName;
            lbStudentName.Text = getNameUser();
        }
        private void Summary_Load(object sender, EventArgs e)
        {
            ConnectionDataBase();
            loadGridView();
            loadHeader();
            loadNumberSubject();
            loadTotalCredits();
        }

        private void loadTotalCredits()
        {
            var table = (DataTable)gridView.DataSource;
            var res = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                res += (int)table.Rows[i]["Total Credits"];
            }

            lbTotalCredits.Text = res.ToString();
        }
        private void loadTotalTuitionFee(DataTable dt)
        {
            double total = 0;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                total += (double)dt.Rows[i]["Total"];
            }

            lbTuitionFee.Text = total.ToString();
        }

        private void loadNumberSubject()
        {
            var table = (DataTable) gridView.DataSource;
            var res = 0;
            for( int i = 0; i < table.Rows.Count; i++)
            {
                res += (int)table.Rows[i]["Total Subjects"];
            }

            lbNumberSubjects.Text = res.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbTotalCredits_Click(object sender, EventArgs e)
        {

        }
    }
}
