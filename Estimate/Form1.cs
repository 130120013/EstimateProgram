using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estimate
{
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

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = (button1.Text == "<") ? {">"  } : { "<"};

            if (button1.Text == ">")
            {
                button1.Text = "<";
                button1.Location = new System.Drawing.Point(12, 0);
            }
            else
            {
                button1.Text = ">";
                button1.Location = new System.Drawing.Point(dataGridView1.Width, dataGridView1.Location.Y);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
