﻿using System;
using System.Data;
using System.Windows.Forms;

namespace Учет_цистерн
{
    public partial class OwnerAddForm : Form
    {
        public OwnerAddForm()
        {
            InitializeComponent();
            textBox3.Visible = false;
            label3.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string AddNewOwner = "insert into d__Owner " +
                                 "values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "',NULL)";
            DataTable dataTable = new DataTable();
            dataTable = DbConnection.DBConnect(AddNewOwner);
            this.Close();
            MessageBox.Show("Запись добавлена!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
