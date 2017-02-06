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
        string connString = "Data Source=(LocalDb)\v11.0;Initial Catalog=Tables;Integrated Security=True; Provider=SQLOLEDB";
        /// <summary>
        /// Send insert-query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
 
            OleDbConnection oldb = new OleDbConnection(connString);
            if (oldb != null)
            {
                button1.Text = "111111111111111";
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
