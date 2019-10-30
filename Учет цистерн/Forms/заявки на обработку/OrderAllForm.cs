﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Учет_цистерн.Forms.заявки_на_обработку
{
    public partial class OrderAllForm : Form
    {
        TradeWright.UI.Forms.TabControlExtra TabControlExtra;
        int SelectItemRow;
        BindingSource source = new BindingSource();

        public OrderAllForm(TradeWright.UI.Forms.TabControlExtra tabControl1)
        {
            InitializeComponent();
            TabControlExtra = tabControl1;
        }
        private void GetDocument()
        {
            try
            {
                string DateFrom = dateTimePicker1.Text;
                string DateTo = dateTimePicker2.Text;
                string GetDocument = "exec dbo.GetRenderedServiceDoc '" + DateFrom + "','" + DateTo + "'";
                DataTable dt = DbConnection.DBConnect(GetDocument);
                source.DataSource = dt;
                dataGridView1.DataSource = source;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetDocumentGlobalFilter()
        {
            try
            {
                int yes = 1;
                string DateFrom = dateTimePicker1.Text;
                string DateTo = dateTimePicker2.Text;
                string GetDocument = "exec [dbo].[GetRenderedServiceDocGlobalFilter] '" + DateFrom + "','" + DateTo + "','" + yes + "'";
                DataTable dt = DbConnection.DBConnect(GetDocument);
                source.DataSource = dt;
                dataGridView1.DataSource = source;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetDocumentBody()
        {
            try
            {
                string DateFrom = dateTimePicker1.Text;
                string DateTo = dateTimePicker2.Text;
                string GetDocumentBody = "exec dbo.GetRenderedServiceDoc_Body '" + DateFrom + "','" + DateTo + "'";
                DataTable dt = DbConnection.DBConnect(GetDocumentBody);
                source.DataSource = dt;
                dataGridView2.DataSource = source;
                dataGridView2.Columns[0].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetDocumentBodyGlobalFilter()
        {
            try
            {
                int yes = 1;
                string DateFrom = dateTimePicker1.Text;
                string DateTo = dateTimePicker2.Text;
                string GetDocumentBody = "exec [dbo].[GetRenderedServiceDocGlobalFilter_Body] '" + DateFrom + "','" + DateTo + "','" + yes + "'";
                DataTable dt = DbConnection.DBConnect(GetDocumentBody);
                source.DataSource = dt;
                dataGridView2.DataSource = source;
                dataGridView2.Columns[0].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderAllForm_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                dateTimePicker1.Value = startDate;
                dateTimePicker2.Value = endDate;

                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                panel14.Visible = false;
                panel15.Visible = false;
                panel16.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    if (checkBox1.Checked)
                    {
                        GetDocumentGlobalFilter();
                    }
                    else
                    {
                        GetDocument();
                    }
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                    if (checkBox1.Checked)
                    {
                        GetDocumentBodyGlobalFilter();
                    }
                    else
                    {
                        GetDocumentBody();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Кнопка Добавить
        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewDocument();
        }
        //Форма нового документа
        private void CreateNewDocument()
        {
            try
            {
                string DocNum;
                string GetDate = System.DateTime.Now.ToShortDateString();
                string GetDocNum = "exec dbo.GetDocNum 1";
                DataTable dt = new DataTable();
                dt = DbConnection.DBConnect(GetDocNum);
                DocNum = dt.Rows[0][0].ToString();

                string CreateDocHead = "exec dbo.RenderedServiceHeadCreate " + DocNum + ", '" + GetDate + "'";
                DbConnection.DBConnect(CreateDocHead);

                OrderAddForm OrderAddForm = new OrderAddForm(this.TabControlExtra);
                TabControlExtra.Show();
                TabPage OrderAddTabPage = new TabPage("Заявка на обработку № " + DocNum + " от " + GetDate);
                OrderAddForm.GetStatus = DocNum;
                OrderAddForm.GetDate = GetDate;
                TabControlExtra.TabPages.Add(OrderAddTabPage);
                TabControlExtra.SelectedTab = OrderAddTabPage;
                OrderAddForm.TopLevel = false;
                OrderAddForm.Visible = true;
                OrderAddForm.FormBorderStyle = FormBorderStyle.None;
                OrderAddForm.Dock = DockStyle.Fill;
                OrderAddTabPage.Controls.Add(OrderAddForm);
                OrderAddForm.dateTimePicker1.Text = GetDate;
                OrderAddForm.textBox1.Text = DocNum;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    if (checkBox1.Checked)
                    {
                        GetDocumentGlobalFilter();
                    }
                    else
                    {
                        GetDocument();
                    }
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    if (checkBox1.Checked)
                    {
                        GetDocumentBodyGlobalFilter();
                    }
                    else
                    {
                        GetDocumentBody();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[
                        e.RowIndex];
                    string Id = row.Cells["HeadID"].Value.ToString();
                    SelectItemRow = Convert.ToInt32(Id);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //кнопка изменить
        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                GetCurrentDocument();
            }
        }
        //форма имеющегося документа
        private void GetCurrentDocument()
        {
            try
            {
                string GetData = "select NUM, ServiceDate,Contragent_ID, Brigade_ID, Station_ID from d__RenderedServiceHead where ID = " + SelectItemRow;
                DataTable dt = DbConnection.DBConnect(GetData);
                string DocNum = dt.Rows[0][0].ToString();
                string GetDate = dt.Rows[0][1].ToString();
                string Contr = dt.Rows[0][2].ToString();
                string Brigade = dt.Rows[0][3].ToString();
                string Station = dt.Rows[0][4].ToString();
                OrderUpdateForm orderUpdateForm = new OrderUpdateForm(this.TabControlExtra);
                orderUpdateForm.GetStatus = DocNum;
                orderUpdateForm.SelectedID = SelectItemRow;
                orderUpdateForm.SelectContrID = Contr;
                orderUpdateForm.SelectBrigadeID = Brigade;
                orderUpdateForm.SelectStationID = Station;
                TabPage OrderAddTabPage = new TabPage("Заявка на обработку № " + DocNum + " от " + GetDate);
                TabControlExtra.TabPages.Add(OrderAddTabPage);
                TabControlExtra.SelectedTab = OrderAddTabPage;
                orderUpdateForm.TopLevel = false;
                orderUpdateForm.Visible = true;
                orderUpdateForm.FormBorderStyle = FormBorderStyle.None;
                orderUpdateForm.Dock = DockStyle.Fill;
                OrderAddTabPage.Controls.Add(orderUpdateForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Для редактирования записи, необходимо указать строку!", "Исключение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Кнопка удалить, работает только в tabPage1
        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                DeleteDoc();
            }
        }
        //удаление документа
        private void DeleteDoc()
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string DeleteDoc = "exec dbo.DeleteRenderedServiceDoc " + SelectItemRow;
                    DbConnection.DBConnect(DeleteDoc);
                    GetDocument();
                    MessageBox.Show("Документ удалён!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }       
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                Decimal sum = 0;
                int Count = 0;
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() != string.Empty)
                    {
                        sum += Convert.ToDecimal(this.dataGridView1[4, i].Value);
                    }
                    Count = dataGridView1.RowCount;
                }

                panel1.Width = this.dataGridView1.RowHeadersWidth;
                panel1.Location = new Point(5, this.dataGridView1.Height - (panel1.Height - 15));
                panel1.Visible = true;

                int Xdgvx = this.dataGridView1.GetCellDisplayRectangle(0, -1, true).Location.X;
                panel2.Width = this.dataGridView1.Columns[1].Width + 1;
                Xdgvx = this.dataGridView1.GetCellDisplayRectangle(1, -1, true).Location.X;
                panel2.Location = new Point(Xdgvx, this.dataGridView1.Height - (panel2.Height - 15));
                panel2.Visible = true;

                textBox1.Text = "Всего строк: " + Count.ToString();
                int Xdgvx1 = this.dataGridView1.GetCellDisplayRectangle(1, -1, true).Location.X;
                textBox1.Width = this.dataGridView1.Columns[2].Width + 1;
                Xdgvx1 = this.dataGridView1.GetCellDisplayRectangle(2, -1, true).Location.X;
                textBox1.Location = new Point(Xdgvx1, this.dataGridView1.Height - (textBox1.Height - 15));
                textBox1.Visible = true;

                int Xdgvx3 = this.dataGridView1.GetCellDisplayRectangle(2, -1, true).Location.X;
                panel3.Width = this.dataGridView1.Columns[3].Width + 1;
                Xdgvx3 = this.dataGridView1.GetCellDisplayRectangle(3, -1, true).Location.X;
                panel3.Location = new Point(Xdgvx3, this.dataGridView1.Height - (panel3.Height - 15));
                panel3.Visible = true;

                textBox2.Text = "Сумма: " + sum.ToString();
                int Xdgvx4 = this.dataGridView1.GetCellDisplayRectangle(3, -1, true).Location.X;
                textBox2.Width = this.dataGridView1.Columns[4].Width + 1;
                Xdgvx4 = this.dataGridView1.GetCellDisplayRectangle(4, -1, true).Location.X;
                textBox2.Location = new Point(Xdgvx4, this.dataGridView1.Height - (textBox2.Height - 15));
                textBox2.Visible = true;

                int Xdgvx5 = this.dataGridView1.GetCellDisplayRectangle(4, -1, true).Location.X;
                panel4.Width = this.dataGridView1.Columns[5].Width + 1;
                Xdgvx5 = this.dataGridView1.GetCellDisplayRectangle(5, -1, true).Location.X;
                panel4.Location = new Point(Xdgvx5, this.dataGridView1.Height - (panel4.Height - 15));
                panel4.Visible = true;

                int Xdgvx6 = this.dataGridView1.GetCellDisplayRectangle(5, -1, true).Location.X;
                panel5.Width = this.dataGridView1.Columns[6].Width + 1;
                Xdgvx6 = this.dataGridView1.GetCellDisplayRectangle(6, -1, true).Location.X;
                panel5.Location = new Point(Xdgvx6, this.dataGridView1.Height - (panel5.Height - 15));
                panel5.Visible = true;

                int Xdgvx7 = this.dataGridView1.GetCellDisplayRectangle(6, -1, true).Location.X;
                panel6.Width = this.dataGridView1.Columns[7].Width + 3;
                Xdgvx7 = this.dataGridView1.GetCellDisplayRectangle(7, -1, true).Location.X;
                panel6.Location = new Point(Xdgvx7, this.dataGridView1.Height - (panel6.Height - 15));
                panel6.Visible = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.source.Sort = this.dataGridView1.SortString;
        }

        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.source.Filter = this.dataGridView1.FilterString;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetCurrentDocument();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewDocument();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCurrentDocument();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDoc();
            GetDocument();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDocument();
        }

        private void провестиДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string GetDocState = "exec dbo.GetDocState " + SelectItemRow;
                DataTable DocStateDt = DbConnection.DBConnect(GetDocState);
                int DocState = Convert.ToInt32(DocStateDt.Rows[0][0]);
                if (DocState > 0 && DocState < 2)
                {
                    string UpdateDocState = "update d__RenderedServiceHead set ID_DocState = 2 where ID = " + SelectItemRow;
                    DbConnection.DBConnect(UpdateDocState);
                    MessageBox.Show("Документ проведен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetDocument();
                }
                else
                {
                    MessageBox.Show("Документ проведен!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void отменитьПроведениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string GetDocState = "exec dbo.GetDocState " + SelectItemRow;
                DataTable DocStateDt = DbConnection.DBConnect(GetDocState);
                int DocState = Convert.ToInt32(DocStateDt.Rows[0][0]);
                if (DocState > 1 && DocState < 3)
                {
                    string UpdateDocState = "update d__RenderedServiceHead set ID_DocState = 1 where ID = " + SelectItemRow;
                    DbConnection.DBConnect(UpdateDocState);
                    MessageBox.Show("Проведение документа отменено!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetDocument();
                }
                else
                {
                    MessageBox.Show("Документ не проведен!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                Decimal sum = 0;
                int Count = 0;
                for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[4].Value.ToString() != string.Empty)
                    {
                        sum += Convert.ToDecimal(this.dataGridView2[4, i].Value);
                    }
                    Count = dataGridView2.RowCount;
                }

                panel7.Width = this.dataGridView2.RowHeadersWidth;
                panel7.Location = new Point(5, this.dataGridView2.Height - (panel7.Height - 15));
                panel7.Visible = true;

                textBox3.Text = "Всего строк: " + Count.ToString();
                int Xdgvx1 = this.dataGridView2.GetCellDisplayRectangle(0, -1, true).Location.X;
                textBox3.Width = this.dataGridView2.Columns[1].Width + 1;
                Xdgvx1 = this.dataGridView2.GetCellDisplayRectangle(1, -1, true).Location.X;
                textBox3.Location = new Point(Xdgvx1, this.dataGridView2.Height - (textBox3.Height - 15));
                textBox3.Visible = true;

                int Xdgvx = this.dataGridView2.GetCellDisplayRectangle(1, -1, true).Location.X;
                panel8.Width = this.dataGridView2.Columns[2].Width + 1;
                Xdgvx = this.dataGridView2.GetCellDisplayRectangle(2, -1, true).Location.X;
                panel8.Location = new Point(Xdgvx, this.dataGridView2.Height - (panel8.Height - 15));
                panel8.Visible = true;

                int Xdgvx3 = this.dataGridView2.GetCellDisplayRectangle(2, -1, true).Location.X;
                panel9.Width = this.dataGridView2.Columns[3].Width + 1;
                Xdgvx3 = this.dataGridView2.GetCellDisplayRectangle(3, -1, true).Location.X;
                panel9.Location = new Point(Xdgvx3, this.dataGridView2.Height - (panel9.Height - 15));
                panel9.Visible = true;

                textBox4.Text = "Сумма: " + sum.ToString();
                int Xdgvx4 = this.dataGridView2.GetCellDisplayRectangle(3, -1, true).Location.X;
                textBox4.Width = this.dataGridView2.Columns[4].Width + 1;
                Xdgvx4 = this.dataGridView2.GetCellDisplayRectangle(4, -1, true).Location.X;
                textBox4.Location = new Point(Xdgvx4, this.dataGridView2.Height - (textBox4.Height - 15));
                textBox4.Visible = true;

                int Xdgvx5 = this.dataGridView2.GetCellDisplayRectangle(4, -1, true).Location.X;
                panel10.Width = this.dataGridView2.Columns[5].Width + 1;
                Xdgvx5 = this.dataGridView2.GetCellDisplayRectangle(5, -1, true).Location.X;
                panel10.Location = new Point(Xdgvx5, this.dataGridView2.Height - (panel10.Height - 15));
                panel10.Visible = true;

                int Xdgvx2 = this.dataGridView2.GetCellDisplayRectangle(5, -1, true).Location.X;
                panel16.Width = this.dataGridView2.Columns[6].Width + 1;
                Xdgvx2 = this.dataGridView2.GetCellDisplayRectangle(6, -1, true).Location.X;
                panel16.Location = new Point(Xdgvx2, this.dataGridView2.Height - (panel16.Height - 15));
                panel16.Visible = true;

                int Xdgvx6 = this.dataGridView2.GetCellDisplayRectangle(6, -1, true).Location.X;
                panel11.Width = this.dataGridView2.Columns[7].Width + 1;
                Xdgvx6 = this.dataGridView2.GetCellDisplayRectangle(7, -1, true).Location.X;
                panel11.Location = new Point(Xdgvx6, this.dataGridView2.Height - (panel11.Height - 15));
                panel11.Visible = true;

                int Xdgvx7 = this.dataGridView2.GetCellDisplayRectangle(7, -1, true).Location.X;
                panel12.Width = this.dataGridView2.Columns[8].Width + 1;
                Xdgvx7 = this.dataGridView2.GetCellDisplayRectangle(8, -1, true).Location.X;
                panel12.Location = new Point(Xdgvx7, this.dataGridView2.Height - (panel12.Height - 15));
                panel12.Visible = true;

                int Xdgvx8 = this.dataGridView2.GetCellDisplayRectangle(8, -1, true).Location.X;
                panel13.Width = this.dataGridView2.Columns[9].Width + 1;
                Xdgvx8 = this.dataGridView2.GetCellDisplayRectangle(9, -1, true).Location.X;
                panel13.Location = new Point(Xdgvx8, this.dataGridView2.Height - (panel13.Height - 15));
                panel13.Visible = true;

                int Xdgvx9 = this.dataGridView2.GetCellDisplayRectangle(9, -1, true).Location.X;
                panel14.Width = this.dataGridView2.Columns[10].Width + 1;
                Xdgvx9 = this.dataGridView2.GetCellDisplayRectangle(10, -1, true).Location.X;
                panel14.Location = new Point(Xdgvx9, this.dataGridView2.Height - (panel14.Height - 15));
                panel14.Visible = true;

                int Xdgvx10 = this.dataGridView2.GetCellDisplayRectangle(10, -1, true).Location.X;
                panel15.Width = this.dataGridView2.Columns[11].Width + 3;
                Xdgvx10 = this.dataGridView2.GetCellDisplayRectangle(11, -1, true).Location.X;
                panel15.Location = new Point(Xdgvx10, this.dataGridView2.Height - (panel15.Height - 15));
                panel15.Visible = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int rowSelected = e.RowIndex;
                    if (e.RowIndex != -1)
                    {
                        this.dataGridView1.ClearSelection();
                        this.dataGridView1.Rows[rowSelected].Selected = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
