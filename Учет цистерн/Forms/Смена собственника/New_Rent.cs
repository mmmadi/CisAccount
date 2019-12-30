﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Учет_цистерн.Forms.Смена_собственника
{
    public partial class New_Rent : Form
    {
        string Status;
        int SelectItemRow;

        public New_Rent(string id_Status)
        {
            InitializeComponent();
            this.Status = id_Status;
        }

        private void New_Rent_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string new_row = "exec [dbo].[Rent_Add_Body] '"+ Status + "'";
            DbConnection.DBConnect(new_row);

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            string refresh = "Select Id,Number_Carriage [№ Вагона], Product [Продукт] from Rent_Carriage Where Status_Rent = '" + Status + "'" ;
            DataTable dt = DbConnection.DBConnect(refresh);
            gridControl1.DataSource = dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string Upadte_Rent_Body_1 = "exec dbo.Rent_Update_Body '" + gridView1.GetFocusedDataRow()[1] + "',1," + SelectItemRow;
            DbConnection.DBConnect(Upadte_Rent_Body_1);


            string Upadte_Rent_Body_2 = "exec dbo.Rent_Update_Body '" + gridView1.GetFocusedDataRow()[2] + "',2," + SelectItemRow;
            DbConnection.DBConnect(Upadte_Rent_Body_2);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string Id = gridView1.GetFocusedDataRow()[0].ToString();
            SelectItemRow = Convert.ToInt32(Id);
        }
    }
}
