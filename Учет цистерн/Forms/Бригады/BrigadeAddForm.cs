﻿using System;
using System.Data;
using System.Windows.Forms;

namespace Учет_цистерн
{
    public partial class BrigadeAddForm : Form
    {
        public string connectionString = "Data Source=POTITPC-01\\PLMLOCAL;Initial Catalog=Batys;User ID=sa;Password=!sql123;";
        public BrigadeAddForm()
        {
            InitializeComponent();
        }

        int yes;
        int not;
        string AddNewBrigade;

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                yes = 1;
                AddNewBrigade = "insert into d__Brigade values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox3.Text.Trim() + ' ' + textBox1.Text.Substring(0, 1) + '.' + textBox2.Text.Substring(0, 1) + '.' + "'," + yes + ")";
            }
            else
            {
                not = 0;
                AddNewBrigade = "insert into d__Brigade values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox3.Text.Trim() + ' ' + textBox1.Text.Substring(0, 1) + '.' + textBox2.Text.Substring(0, 1) + '.' + "'," + not + ")";
            }
            DataTable dataTable = new DataTable();
            dataTable = DbConnection.DBConnect(AddNewBrigade);
            this.Close();
            MessageBox.Show("Сотрудник добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
