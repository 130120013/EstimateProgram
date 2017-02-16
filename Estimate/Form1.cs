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

namespace Estimate
{
    /// <summary>
    /// Main form with grid and common functions
    /// </summary>
    public partial class Form1 : Form
    {
        private ADGV.AdvancedDataGridView dataGridView1 = new ADGV.AdvancedDataGridView();
        private Cache memoryCache;
        private PleaseWaitForm f3 = new PleaseWaitForm();
        private List<bool> initialized = new List<bool>();
        private int columnIndex;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.Location = new System.Drawing.Point(12, button1.Location.Y);
            this.dataGridView1.Size = new Size(1869, button1.Height);
            //this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellValueNeeded += new
                DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
            this.dataGridView1.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.CellMouseUp += new DataGridViewCellMouseEventHandler(dataGridView1_DataSourceComplete);
            this.dataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(cell);
            //this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView1_ColumnHeaderMouseClick);
            this.Controls.Add(dataGridView1);
            try
            {
                DataRetriever retriever =
                    new DataRetriever(@"Data Source=(LocalDb)\v11.0;Initial Catalog=Tables;Integrated Security=True", "TestTable");
                memoryCache = new Cache(retriever, 10000);
                foreach (DataColumn column in retriever.Columns)
                {
                    dataGridView1.Columns.Add(
                        column.ColumnName, column.ColumnName);
                    initialized.Add(false);
                }
                this.dataGridView1.RowCount = retriever.RowCount;
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection could not be established. " +
                    "Verify that the connection string is valid.");
                Application.Exit();
            }

            // Adjust the column widths based on the displayed values.
            this.dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.DisplayedCells);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tablesDataSet.TestTable". При необходимости она может быть перемещена или удалена.
            // this.testTableTableAdapter.Fill(this.tablesDataSet.TestTable);

            
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == 0)
            columnIndex = e.ColumnIndex;
        }
        private void dataGridView1_ColumnHeaderMouseClick(object sender, EventArgs e)
        {
            if (columnIndex != 0 && initialized[columnIndex] == false)
            {
                initialized[columnIndex] = true;
                if (!f3.IsHandleCreated)
                {
                    f3 = new PleaseWaitForm();
                    f3.Show();
                    f3.Update();
                    System.Threading.Thread.Sleep(3000);
                    this.Focus();
                }
            }

        }

        private void dataGridView1_DataSourceComplete(object sender, EventArgs e)
        {
            if(f3.IsHandleCreated)
            f3.Close();
        }

        private void dataGridView1_CellValueNeeded(object sender,
     DataGridViewCellValueEventArgs e)
        {
            e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }


  

        /// <summary>
        /// Make shorter grid, move button and create sub-form for presenting information of row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox IDObject = new TextBox();
            TextBox NameObject = new TextBox();
            if (button1.Text == ">")
            {            
                button1.Text = "<";
                dataGridView1.Width -= Form1.ActiveForm.Width / 100 * 45; 
                button1.Location = new System.Drawing.Point(button1.Location.X - Form1.ActiveForm.Width / 100 * 45, dataGridView1.Location.Y);
               
               // Splitter split = new Splitter();
                
                IDObject.Size = NameObject.Size = new System.Drawing.Size(51, 51);
                Form1.ActiveForm.Controls.Add(IDObject);
                Form1.ActiveForm.Controls.Add(NameObject);
                //split.Location = new System.Drawing.Point(button1.Location.X+ 60, button1.Location.Y);
                IDObject.Location = new System.Drawing.Point(button1.Location.X + button1.Width * 2, button1.Location.Y);
                NameObject.Location = new System.Drawing.Point(IDObject.Location.X + IDObject.Width*2, IDObject.Location.Y);
                
            }
            else
            { 

                button1.Text = ">";
                dataGridView1.Width += Form1.ActiveForm.Width / 100 * 45;
                button1.Location = new System.Drawing.Point(dataGridView1.Location.X + dataGridView1.Width, dataGridView1.Location.Y);

            }
                //            Form1.ActiveForm.Controls.Remove(IDObject);
                //Form1.ActiveForm.Controls.Remove(NameObject);
                //IDObject.Dispose();
                //NameObject.Dispose();
        }

        /// <summary>
        /// On click show form for adding row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// On click delete selected rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable someDataTable = new DataTable();

            string connString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=Tables;Integrated Security=True";
            SqlConnection oldb = new SqlConnection(connString);
            try
            {
                oldb.Open();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Ошибка подключения:{0}", se.Message);
                return;
            }
            SqlCommand cmd = new SqlCommand("Delete From TestTable" +
               " where TestID = @TestID", oldb);
            SqlParameter param = new SqlParameter();
            //задаем имя параметра
            param.ParameterName = "@TestID";
            //задаем значение параметра
            var removed = dataGridView1.CurrentRow;
            param.Value = dataGridView1.CurrentRow.Cells[0].Value;
            //задаем тип параметра
            param.SqlDbType = SqlDbType.Int;
            //передаем параметр объекту класса SqlCommand
            cmd.Parameters.Add(param);
            try
            {
                cmd.ExecuteNonQuery();

                //обновление таблицы
                dataGridView1.Rows.Remove(removed);
                dataGridView1.Refresh();
            }
            catch
            {
                Console.Write("(((");
            }


            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.testTableTableAdapter.FillBy(this.tablesDataSet.TestTable);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// On click compares some rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow c in dataGridView1.SelectedRows)
            {
                var q = c.Cells;
                string rrrrr = "";
                foreach (DataGridViewCell m in q)
                {
                    rrrrr = rrrrr + m.Value;
                }
                MessageBox.Show(null, rrrrr, "1111");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void advancedDataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
