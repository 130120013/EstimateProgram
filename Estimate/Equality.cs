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
    public partial class Equality : Form
    {
        public Equality()
        {
            InitializeComponent();
        }

        private void Equality_Load(object sender, EventArgs e)
        {
            var query = "SELECT AdvNumber, count(*) FROM ZUADVS Group by AdvNumber having count(*)>1";
            DataTable someDataTable = new DataTable();

            string connString = @"Data Source=SQL;Initial Catalog=advs_2_restored-Алина;Integrated Security=True";
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
            SqlCommand cmd = new SqlCommand(query, oldb);
            try
            {
                //cmd.ExecuteNonQuery();
                  someDataTable.Load(cmd.ExecuteReader());

                dataGridView1.DataSource = someDataTable;
                dataGridView1.Refresh();
            }
            catch
            {
                Console.Write("(((");
            }

            //dataGridView1.DataSource = qq; 
        }
    }
}
