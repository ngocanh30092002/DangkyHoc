using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangKyHoc
{
    public partial class AddStudentTerm : Form
    {
        private SqlConnectionStringBuilder conStr;
        private SqlConnection connection;
        private string userName = "A38809";
        public AddStudentTerm()
        {
            InitializeComponent();
        }

        public AddStudentTerm(string userName)
        {
            InitializeComponent();
            this.userName = userName;
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
        private void AddStudentTerm_Load(object sender, EventArgs e)
        {
            ConnectionDataBase();
        }

        private void changeNameHeaderColumns(DataSet ds)
        {
            ds.Tables[0].Columns[0].ColumnName = "Student Code";
            ds.Tables[0].Columns[1].ColumnName = "Subject Code";
            ds.Tables[0].Columns[2].ColumnName = "Term";
            ds.Tables[0].Columns[3].ColumnName = "Year";
        }
        private void fillDataInTable(string userName)
        {
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                var sqlCmd = new SqlCommand();
                var term = txtStudentTerm.Text;
                var year = txtStudentYear.Text;
                sqlCmd.Connection = connection;

                string cmdText = $"Select userName, subCode, studentTerm, studentYear from StudentsSemester Where userName ='{userName}' ";

                if (term != "" || year != "")
                {

                    if (term != "" && year != "")
                    {
                        cmdText += $" And studentTerm = '{term}'  And studentYear = '{year}'";
                    }
                    else
                    {
                        var text = term != "" ? $" And studentTerm = '{term}'" : $" And studentYear = '{year}'";
                        cmdText += text;
                    }

                }
                sqlCmd.CommandText = cmdText;
                var da = new SqlDataAdapter(sqlCmd);
                var ds = new DataSet();

                da.Fill(ds);
                changeNameHeaderColumns(ds);
                gridView.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Không thể kết nối với Database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            fillDataInTable("A38809");
        }
        private bool isExistSubject(string subject)
        {
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                var sqlCmd = new SqlCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = "Select subCode from Subjects";

                var reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["subCode"]?.ToString() == subject)
                    {
                        connection.Close();
                        return true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể kết nối với Database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            return false;

        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var subCode = txtSubCode.Text;
            var term = txtStudentTerm.Text;
            var year = txtStudentYear.Text;
            if (isNotEmptyField(subCode, term, year))
            {
                if (isExistSubject(subCode))
                {
                    var sqlCmd = new SqlCommand();
                    sqlCmd.Connection = connection;
                    sqlCmd.CommandText = $"Insert into StudentsSemester (userName, subCode, studentTerm , studentYear) Values ('{this.userName}' , '{subCode}' , {term} , {year})";
                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        int rowAffected = sqlCmd.ExecuteNonQuery();
                        if (rowAffected <= 0)
                        {
                            MessageBox.Show("Register Failure");
                        }
                        MessageBox.Show("Register Success");
                        connection.Close();
                        fillDataInTable(userName);
                    }
                    else
                    {
                        MessageBox.Show("Không thể kết nối với Database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Môn học này không tồn tại", "Subject Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Các trường không được để trống", "Field Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool isNotEmptyField(string subCode, string term, string year)
        {
            return subCode != "" && term != "" && year != "";
        }

        private void txtStudentTerm_Leave(object sender, EventArgs e)
        {
            int number;
            if (txtStudentTerm.Text != "" && !int.TryParse(txtStudentTerm.Text, out number))
            {
                MessageBox.Show("Kì học phải là một số", "Term Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentTerm.Text = "";
            }
        }

        private void txtStudentYear_Leave(object sender, EventArgs e)
        {
            int number;
            if (txtStudentYear.Text != "" && !int.TryParse(txtStudentYear.Text, out number))
            {
                MessageBox.Show("Năm học phải là một số", "Term Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentYear.Focus();
                txtStudentYear.Text = "";
            }
        }
        private DataTable getSubjectsTable()
        {
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                var sqlCmd = new SqlCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = "Select * from Subjects";

                var da = new SqlDataAdapter(sqlCmd);
                var dt = new DataTable();
                da.Fill(dt);
                connection.Close();
                return dt;
            }
            connection.Close();
            return null;
        }

        private DataTable createNewTableForCalculate()
        {
            var dt = new DataTable();
            dt.Columns.Add("Student Code", typeof(string) );
            dt.Columns.Add("Subject Code" , typeof(string) );
            dt.Columns.Add("Term" , typeof(int) );
            dt.Columns.Add("Year", typeof(int) );
            dt.Columns.Add("Tuition Fee" , typeof(double) );

            return dt;
        }
        private IEnumerable<TuitionFeeTable>  calculateEachSubject()
        {
            var stSemester = (DataTable)gridView.DataSource;

            var subjects = getSubjectsTable();
            var res = from table1 in stSemester.AsEnumerable()
                      join table2 in subjects.AsEnumerable() on table1["Subject Code"].ToString() equals table2["subCode"].ToString()
                      select new TuitionFeeTable()
                      {
                          studentCode = table1["Student Code"].ToString(),
                          subCode = table1["Subject Code"].ToString(),
                          studentTerm = (int) table1["Term"],
                          studentYear = (int) table1["Year"],
                          subNum = (int) table2["subNum"],
                          subFactor = (double) table2["subFactor"]
                      };

            return res;
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var res = calculateEachSubject();

            var newTable = createNewTableForCalculate();


            foreach (var row in res)
            {
                var fee = Form1.tuitionFee *row.subNum *row.subFactor;
                DataRow rowTable = newTable.NewRow();
                object[] arr = { row.studentCode, row.subCode, row.studentTerm, row.studentYear, Math.Round(fee) };
                rowTable.ItemArray = arr;
                newTable.Rows.Add(rowTable);
            }

            gridView.DataSource = newTable;
            gridView.Refresh();
        }
        private void totalTuitionFee(DataTable stSemester)
        {
            double total = 0;
            for (int i = 0 ; i < stSemester.Rows.Count; i++){
                total += (double) stSemester.Rows[i]["Tuition Fee"];
            }

            var row = stSemester.NewRow();
            row["Tuition Fee"] = total;
            row[0] = "Total";

            stSemester.Rows.Add(row);

        }
        private void btnTotal_Click(object sender, EventArgs e)
        {
            var stSemester = (DataTable)gridView.DataSource;

            if (stSemester.Columns.IndexOf("Tuition Fee") != -1)
            {
                totalTuitionFee(stSemester);
            }
            else
            {
                this.btnCalculate_Click(sender, e);
                var newStSemester = (DataTable) gridView.DataSource;
                totalTuitionFee(newStSemester);
            }
        }
    }

    public struct TuitionFeeTable
    {
        public string studentCode { set; get; }
        public string subCode { set; get; }
        
        public int studentTerm { set; get; }
        public int studentYear { set; get; }
        public int subNum { set; get; }
        public double subFactor { set; get; }

    }
}
