﻿using System;
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

namespace DangKyHoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openAddSubjectForm();
        }

        public void openAddSubjectForm()
        {
            var addSubject = new AddSubject();
            addSubject.ShowDialog();
        }
    }
}
