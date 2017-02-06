using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace Estimate
{
    /// <summary>
    /// Form for adding new row
    /// </summary>
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Send insert-query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand("Insert into TestTable" +
               "(RandomField) Values (@RandomField)", oldb);
            SqlParameter param = new SqlParameter();
            //задаем имя параметра
            param.ParameterName = "@RandomField";
            //задаем значение параметра
            param.Value = textBox2.Text;
            //задаем тип параметра
            param.SqlDbType = SqlDbType.NVarChar;
            //передаем параметр объекту класса SqlCommand
            cmd.Parameters.Add(param);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.Write("(((");
            }

        }

        /// <summary>
        /// Clear the fields 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
