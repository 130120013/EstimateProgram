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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tablesDataSet.TestTable". При необходимости она может быть перемещена или удалена.
            this.testTableTableAdapter.Fill(this.tablesDataSet.TestTable);

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

        /// <summary>
        /// On click delete seleted rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
