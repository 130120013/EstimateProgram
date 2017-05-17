using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estimate
{
    public partial class FullAdvView : Form
    {
        public FullAdvView()
        {
            InitializeComponent();
        }
        public SqlDataReader read;
        public string row;
        private bool buttonClicked = false;

        public FullAdvView(string rowid)
        {
            InitializeComponent();
            row = rowid;
            string mes = "";
            mes = @"F:\Perepiska\" + row + ".txt";
            if (File.Exists(mes))
            {
                richTextBox1.Text = File.ReadAllText(mes); 
            }
            var query = "SELECT DateCreating, DateAdd, AdvName, Source, SourceFile, Offert, DateAdd, DateActual, (GETDATE()-DateAdd), addr_01_City, Cost, AdvArea, AreaKvm, CostKvm, AdvPurpose, BordAdv, addr_06_KadNumber, addr_07_MapLoc, State, Water, Road, AdvText, userName, contactMail, contactTel, NumOfAdv FROM ZUADVS where AdvNumber = '" + rowid + "'";

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
                read =
                   cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        textBox1.Text = read[0].ToString();
                        textBox2.Text = read[1].ToString();
                        textBox3.Text = read[2].ToString();
                        textBox4.Text = read[3].ToString();
                        textBox4.Font = new Font(textBox4.Font, FontStyle.Underline);
                        textBox4.ForeColor = Color.Blue;
                        textBox4.DoubleClick += new EventHandler(sourcelink_dblclick);

                        textBox5.Text = read[4].ToString();
                        textBox5.Font = new Font(textBox4.Font, FontStyle.Underline);
                        textBox5.ForeColor = Color.Blue;
                        textBox5.DoubleClick += new EventHandler(sourcefile_dblclick);
                        textBox6.Text = (read[5].ToString().Equals("false")) ? "От частного лица" : "От агентства недвижимости";
                        textBox7.Text = read[6].ToString();
                        textBox8.Text = read[7].ToString();

                        textBox10.Text = read[9].ToString();
                        textBox11.Text = read[10].ToString();
                        textBox12.Text = read[11].ToString();

                        textBox13.Text = read[12].ToString();
                        textBox14.Text = read[13].ToString();
                        textBox15.Text = read[14].ToString();
                        textBox16.Text = read[15].ToString();
                        textBox17.Text = read[16].ToString();
                        textBox18.Text = read[17].ToString();
                        textBox19.Text = read[18].ToString();
                        textBox20.Text = (read[19].ToString().Equals("false")) ? "Нет" : "Есть";
                        textBox21.Text = (read[20].ToString().Equals("false")) ? "Нет" : "Есть";
                        textBox9.Text = ((DateTime.Now.Date - DateTime.Parse(read[6].ToString())).Days).ToString();
                        read[4].ToString();

                        textBox22.Text = read[22].ToString();
                        textBox23.Text = read[23].ToString();
                        richTextBox2.Text = read[24].ToString();
                        textBox24.Text = read[25].ToString();
                        Uri uri = new Uri(read[4].ToString());
                        webBrowser1.Navigate(uri);
                    }
                }

            }
            catch (Exception e)
            {
                Console.Write("((( " + e.Message);
            }

            oldb.Close();
        }

        private void sourcefile_dblclick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox5.Text);
        }
        private void sourcelink_dblclick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox4.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonClicked == false)
            {
                buttonClicked = true;
            var query = "SELECT AdvText FROM ZUADVS where AdvNumber = '" + row + "'";
            string text = "";

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

            read =
               cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    text = read[0].ToString();
                }
                this.Height += 120;
                this.webBrowser1.Height += 120;
                RichTextBox rtext = new RichTextBox();
                rtext.Location = new Point(button1.Location.X, button1.Location.Y + button1.Height + 20);
                rtext.Height = 100;
                rtext.Width = button1.Width;
                rtext.Text = text;
                this.Controls.Add(rtext);
                oldb.Close();
            }
        }
        else
        {
                buttonClicked = false;
                this.Height -= 120;
                this.webBrowser1.Height -= 120;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string validSug = "";
            string validWater = "";
            string validWay = "";

            //sug, water and way are bool in database
            //need to check 
            if (textBox6.Text == "От частного лица")
            {
                validSug = "False";
            }
            else
            {
                if (textBox6.Text == "От агентства недвижимости")
                {
                    validSug = "True";
                }
                else
                {
                    MessageBox.Show("Недопустимое значение поля \"Предложение\". Введите От частного лица или От агентства недвижимости");
                }
            }

            if (textBox19.Text == "Есть")
            {
                validWater = "True";
            }
            else
            {
                if (textBox19.Text == "Нет")
                {
                    validWater = "False";
                }
                else
                {
                    MessageBox.Show("Недопустимое значение поля \"Вода\". Введите Есть или Нет");
                }
            }

            if (textBox20.Text == "Есть")
            {
                validWay = "True";
            }
            else
            {
                if (textBox20.Text == "Нет")
                {
                    validWay = "False";
                }
                else
                {
                    MessageBox.Show("Недопустимое значение поля \"Объездной путь\". Введите Есть или Нет");
                }
            }

            var query = "UPDATE ZUADVS SET DateCreating = '" + textBox1.Text + "', AdvName = '" + textBox3.Text + "', Source = '" + textBox4.Text + "', "
                + "SourceFile = '" + textBox5.Text + "', Offert = '" + validSug + "', DateAdd = '" + textBox2.Text + "', DateActual = '" + textBox8.Text + "', addr_01_City = '" + textBox10.Text
                + "', Cost = '" + textBox11.Text + "', AdvArea = '" + textBox12.Text + "', AdvPurpose = '" + textBox13.Text + "', BordAdv = '" + textBox14.Text + "', addr_06_KadNumber = '"
                + textBox15.Text + "', addr_07_MapLoc = '" + textBox16.Text + "', Water = '" + validWater + "', Road = '" + validWay + "' where Source = '" + textBox14.Text + "' and DateCreating = '" + textBox1.Text + "'";



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
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.Write("(((");
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
                
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            string mes = "";

            mes = @"F:\Perepiska\" + row + ".txt";

                if (!File.Exists(mes))
                    {
                       // File.Create(mes);
                        File.WriteAllText(mes, richTextBox1.Text);
                    }
                    else
                    {
                        File.WriteAllText(mes, richTextBox1.Text);
                    }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = "UPDATE ZUADVS SET   userName = " + textBox22.Text + ", contactMail = " + textBox23.Text + ", contactTel = " + richTextBox2.Text + ", NumOfAdv = " + textBox24.Text +" FROM ZUADVS where AdvNumber = '" + row + "'";


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
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.Write("(((");
            }

        }
    }
}
