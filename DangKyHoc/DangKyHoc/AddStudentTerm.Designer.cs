namespace DangKyHoc
{
    partial class AddStudentTerm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.lbSubCode = new System.Windows.Forms.Label();
            this.lbStudentTerm = new System.Windows.Forms.Label();
            this.txtSubCode = new System.Windows.Forms.TextBox();
            this.txtStudentTerm = new System.Windows.Forms.TextBox();
            this.txtStudentYear = new System.Windows.Forms.TextBox();
            this.lbStudentYear = new System.Windows.Forms.Label();
            this.dangKyHocDataSet = new DangKyHoc.DangKyHocDataSet();
            this.studentsSemesterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsSemesterTableAdapter = new DangKyHoc.DangKyHocDataSetTableAdapters.StudentsSemesterTableAdapter();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnTotal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dangKyHocDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsSemesterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridView.Location = new System.Drawing.Point(0, 199);
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridView.Size = new System.Drawing.Size(714, 253);
            this.gridView.TabIndex = 0;
            // 
            // lbSubCode
            // 
            this.lbSubCode.AutoSize = true;
            this.lbSubCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbSubCode.Location = new System.Drawing.Point(22, 43);
            this.lbSubCode.Name = "lbSubCode";
            this.lbSubCode.Size = new System.Drawing.Size(88, 16);
            this.lbSubCode.TabIndex = 1;
            this.lbSubCode.Text = "Subject Code";
            // 
            // lbStudentTerm
            // 
            this.lbStudentTerm.AutoSize = true;
            this.lbStudentTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbStudentTerm.Location = new System.Drawing.Point(22, 72);
            this.lbStudentTerm.Name = "lbStudentTerm";
            this.lbStudentTerm.Size = new System.Drawing.Size(39, 16);
            this.lbStudentTerm.TabIndex = 2;
            this.lbStudentTerm.Text = "Term";
            // 
            // txtSubCode
            // 
            this.txtSubCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSubCode.Location = new System.Drawing.Point(122, 37);
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.Size = new System.Drawing.Size(546, 22);
            this.txtSubCode.TabIndex = 3;
            // 
            // txtStudentTerm
            // 
            this.txtStudentTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtStudentTerm.Location = new System.Drawing.Point(122, 66);
            this.txtStudentTerm.Name = "txtStudentTerm";
            this.txtStudentTerm.Size = new System.Drawing.Size(546, 22);
            this.txtStudentTerm.TabIndex = 4;
            this.txtStudentTerm.Leave += new System.EventHandler(this.txtStudentTerm_Leave);
            // 
            // txtStudentYear
            // 
            this.txtStudentYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtStudentYear.Location = new System.Drawing.Point(122, 94);
            this.txtStudentYear.Name = "txtStudentYear";
            this.txtStudentYear.Size = new System.Drawing.Size(546, 22);
            this.txtStudentYear.TabIndex = 7;
            this.txtStudentYear.Leave += new System.EventHandler(this.txtStudentYear_Leave);
            // 
            // lbStudentYear
            // 
            this.lbStudentYear.AutoSize = true;
            this.lbStudentYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbStudentYear.Location = new System.Drawing.Point(25, 100);
            this.lbStudentYear.Name = "lbStudentYear";
            this.lbStudentYear.Size = new System.Drawing.Size(36, 16);
            this.lbStudentYear.TabIndex = 6;
            this.lbStudentYear.Text = "Year";
            // 
            // dangKyHocDataSet
            // 
            this.dangKyHocDataSet.DataSetName = "DangKyHocDataSet";
            this.dangKyHocDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentsSemesterBindingSource
            // 
            this.studentsSemesterBindingSource.DataMember = "StudentsSemester";
            this.studentsSemesterBindingSource.DataSource = this.dangKyHocDataSet;
            // 
            // studentsSemesterTableAdapter
            // 
            this.studentsSemesterTableAdapter.ClearBeforeFill = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(122, 145);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(260, 145);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(132, 34);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(398, 145);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(132, 34);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(536, 145);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(132, 34);
            this.btnTotal.TabIndex = 11;
            this.btnTotal.Text = "Total";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // AddStudentTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 452);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtStudentYear);
            this.Controls.Add(this.lbStudentYear);
            this.Controls.Add(this.txtStudentTerm);
            this.Controls.Add(this.txtSubCode);
            this.Controls.Add(this.lbStudentTerm);
            this.Controls.Add(this.lbSubCode);
            this.Controls.Add(this.gridView);
            this.Name = "AddStudentTerm";
            this.Text = "AddStudentTerm";
            this.Load += new System.EventHandler(this.AddStudentTerm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dangKyHocDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsSemesterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Label lbSubCode;
        private System.Windows.Forms.Label lbStudentTerm;
        private System.Windows.Forms.TextBox txtSubCode;
        private System.Windows.Forms.TextBox txtStudentTerm;
        private System.Windows.Forms.TextBox txtStudentYear;
        private System.Windows.Forms.Label lbStudentYear;
        private DangKyHocDataSet dangKyHocDataSet;
        private System.Windows.Forms.BindingSource studentsSemesterBindingSource;
        private DangKyHocDataSetTableAdapters.StudentsSemesterTableAdapter studentsSemesterTableAdapter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnTotal;
    }
}