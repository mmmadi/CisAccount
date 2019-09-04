﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Учет_цистерн
{
    public partial class ServiceCostForm : Form
    {
        public ServiceCostForm()
        {
            InitializeComponent();
        }

        int SelectItemRow;
        int SelectServiceID;
        int SelectSeasonID;

        private void ServiceCostForm_Load(object sender, EventArgs e)
        {
            string Reffresh = "exec dbo.GetServiceCost";
            DataTable dataTable = new DataTable();
            dataTable = DbConnection.DBConnect(Reffresh);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            string Reffresh = "exec dbo.GetServiceCost";
            DataTable dataTable = new DataTable();
            dataTable = DbConnection.DBConnect(Reffresh);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            ServiceCostAddForm ServiceCostAddForm = new ServiceCostAddForm();
            ServiceCostAddForm.Show();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            string message = "Вы действительно хотите удалить эту запись?";
            string title = "Удаление";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.OK)
            {
                string Delete = "delete from d__ServiceCost where ID = " + SelectItemRow;
                DataTable dataTable = new DataTable();
                dataTable = DbConnection.DBConnect(Delete);
                MessageBox.Show("Запись удалена!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[
                    e.RowIndex];
                string Id = row.Cells["ID"].Value.ToString();
                string ServiceID = row.Cells["ServiceID"].Value.ToString();
                string SeasonID = row.Cells["SeasonID"].Value.ToString();
                SelectItemRow = Convert.ToInt32(Id);
                SelectServiceID = Convert.ToInt32(ServiceID);
                SelectSeasonID = Convert.ToInt32(SeasonID);
            }
        }

        private void Btn_Updt_Click(object sender, EventArgs e)
        {
            ServiceCostUpdtForm ServiceCostUpdtForm = new ServiceCostUpdtForm();
            ServiceCostUpdtForm.SelectID = SelectItemRow;
            ServiceCostUpdtForm.SelectServiceID = SelectServiceID;
            ServiceCostUpdtForm.SelectSeasonID = SelectSeasonID;
            ServiceCostUpdtForm.textBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            ServiceCostUpdtForm.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            ServiceCostUpdtForm.dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            ServiceCostUpdtForm.Show();
        }
    }
}
