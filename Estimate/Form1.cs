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
    /// <summary>
    /// Main form with grid and common functions
    /// </summary>
    public partial class Form1 : Form
    {

        private PleaseWaitForm f3 = new PleaseWaitForm();
        private WebBrowserForm wb;
        private RichTextBox logTable;
        private int sizeBefore = 0;
        private int sizeDif = 0;

        private bool firstStart = true;
        private List<bool> initialized = new List<bool>();
        private int columnIndex = 0;
        private int rowIndex = 0;
        private int columnIndexPrev = -1;
        private int rowIndexPrev = -1;
        private bool isDroped = false; //flag of droped prev selection or not
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.zUADVSTableAdapter.Fill(this._advs_2_restored_АлинаDataSet.ZUADVS);
            this.advancedDataGridView1.CellClick += new
            DataGridViewCellEventHandler(datagridview_cellClick);
            this.advancedDataGridView1.CellContentClick += new DataGridViewCellEventHandler(datagridview_cellClick);
            this.advancedDataGridView1.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_ColumnHeaderMouseClick);
            this.advancedDataGridView1.CellMouseUp += new DataGridViewCellMouseEventHandler(dataGridView1_DataSourceComplete);
            this.advancedDataGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(dataGridView1_MouseDown);
            this.advancedDataGridView1.RowHeaderCellChanged += new DataGridViewRowEventHandler(dataGridView1_RowClick);
            this.advancedDataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
            this.advancedDataGridView1.FilterStringChanged += new EventHandler(dataGridView1_FilterStringChanged);
            this.advancedDataGridView1.SortStringChanged += new EventHandler(dataGridView1_SortStringChanged);
            this.advancedDataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(datagridview_Click);
            for (int i = 0; i < advancedDataGridView1.ColumnCount; i++)
            {
                initialized.Add(false);
            }
            for (int i = 0; i < advancedDataGridView1.RowCount; i++)
            {
                this.advancedDataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
            FilteredCount.Text = "0";
            TotalCount.Text = this.advancedDataGridView1.RowCount.ToString();

            this.advancedDataGridView1.Rows[0].Selected = true;
            sizeBefore = this.Width;
        }
        private void datagridview_Click(object sender, DataGridViewCellEventArgs cell)
        {
            string AdvNum = advancedDataGridView1.SelectedRows[0].Cells[46].Value.ToString();
            FullAdvView full = new FullAdvView(AdvNum);

            full.Show();
            if (advancedDataGridView1.Rows[cell.RowIndex].Selected != true)
            {
                advancedDataGridView1.Rows[0].Selected = false;
                advancedDataGridView1.Rows[cell.RowIndex].Selected = true;
            }
        }
        private void dataGridView1_RowClick(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show(e.Row.Index.ToString());
        }
        private void dataGridView1_MouseDown(object sender, EventArgs mousecoord)
        {
            if (this.advancedDataGridView1.CurrentCell.Selected)
            {
                columnIndexPrev = columnIndex;
                columnIndex = this.advancedDataGridView1.CurrentCell.ColumnIndex;
                rowIndexPrev = rowIndex;
                isDroped = false;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int s = this.advancedDataGridView1.SelectedCells.Count;
            //s - count of selected cells.
            //if selected row
            if (s != 0)
            { 
            try
            {
                rowIndex = this.advancedDataGridView1.SelectedCells[0].RowIndex;
            }
            catch
            {
                rowIndex = 0;
            }
        }
            //if user click on cell
            if (s == 1)
            {
                //if prev selection doesn't clear
                if (rowIndexPrev != -1 && isDroped == false)
                {
                    this.advancedDataGridView1.Rows[rowIndexPrev].Selected = false;
                    isDroped = true;
                }
                this.advancedDataGridView1.Rows[rowIndex].Selected = true;
            }
            if (s > 1)
            {
                if (rowIndexPrev != -1 && isDroped == false)
                {
                    this.advancedDataGridView1.Rows[rowIndexPrev].Selected = false;
                    isDroped = true;
                }
                this.advancedDataGridView1.Rows[rowIndex].Selected = true;
                if (txtHistory != null)
                {
                    if (advancedDataGridView1.SelectedRows[0].Cells[33] != null)
                    {
                        string mes = advancedDataGridView1.SelectedRows[0].Cells[33].Value.ToString();
                        string sourcefile;
                        string mess = sourcefile = mes.TrimEnd('.', 'h', 't', 'm', 'l', ' ');
                        mess += "_files";
                        sourcefile += ".txt";
                        if (File.Exists(sourcefile))
                        {
                            txtHistory.Text = File.ReadAllText(sourcefile);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку объявления!");
                    }
                }

                if (txt1 != null)
                {
                    txt1.Text = advancedDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                }
                if (txtnumob != null)
                {
                    txtnumob.Text = advancedDataGridView1.SelectedRows[0].Cells[46].Value.ToString();
                }
                if (txtName != null)
                {
                    txtName.Text = advancedDataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                }
                if (txtLink != null)
                {
                    txtLink.Text = advancedDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                }
                if (txtFile != null)
                {
                    txtFile.Text = advancedDataGridView1.SelectedRows[0].Cells[33].Value.ToString();
                    try
                    {
                        if (wb.Created == true)
                        {
                            wb.ChangeWebBrowserSource(txtFile.Text);
                        }
                    }
                    catch
                    {

                    }
                }
                if (txtSug != null)
                {
                    string n = advancedDataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                    if (n != null)
                    {
                        if (n.Equals("false"))
                        {
                            txtSug.Text = "От частного лица";
                        }
                        else
                        {
                            txtSug.Text = "От агентства недвижимости";
                        }
                    }
                    else
                    {
                        txt1.Text = "";
                    }

                }
                if (txtAdded != null)
                {
                    txtAdded.Text = advancedDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                }
                if (txtAct != null)
                {
                    txtAct.Text = advancedDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                }
                if (txtPlace != null)
                {
                    txtPlace.Text = advancedDataGridView1.SelectedRows[0].Cells[24].Value.ToString();
                }
                if (txtCost != null)
                {
                    txtCost.Text = (advancedDataGridView1.SelectedRows[0].Cells[10].Value.ToString() != null) ? (advancedDataGridView1.SelectedRows[0].Cells[10].Value.ToString()) : "0";
                }
                if (txtSquareOne != null)
                {
                    txtSquare.Text = advancedDataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                }
                if (txtSquare != null)
                {
                    string val = advancedDataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    if (val.Contains("сот"))
                    {
                        int m = 0;
                        m = Convert.ToInt32(val.TrimEnd('с', 'о', 'т', '.'));
                        m *= 100;
                        txtSquareOne.Text = m.ToString();
                    }
                    else
                    {
                        if (val.Contains("кв.м."))
                        {
                            int m = 0;
                            m = Convert.ToInt32(val.TrimEnd('к', 'в', '.', 'м'));
                            txtSquareOne.Text = m.ToString();
                        }
                    }

                }
                if (txtPriceOne != null)
                {
                    try
                    {
                        txtPriceOne.Text = (Convert.ToInt32(txtCost.Text) / Convert.ToInt32(txtSquareOne.Text)).ToString();
                    }
                    catch
                    {
                        txtPriceOne.Text = "0";
                    }
                }

                if (txtOgran != null)
                {
                    txtOgran.Text = advancedDataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                }
                if (txtCadastr != null)
                {
                    txtCadastr.Text = advancedDataGridView1.SelectedRows[0].Cells[31].Value.ToString();
                }
                if (txtCard != null)
                {
                    txtCard.Text = advancedDataGridView1.SelectedRows[0].Cells[32].Value.ToString();
                }
                if (txtPage != null)
                {
                    txtPage.Text = advancedDataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                }

                if (txtWater != null)
                {
                    string w = advancedDataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                    if (w == "True")
                    {
                        txtWater.Text = "Есть";
                    }
                    else
                    {
                        if (w == "False")
                        {
                            txtWater.Text = "Нет";
                        }
                        else
                        {
                            txtWater.Text = "";
                        }
                    }
                }
                if (txtWay != null)
                {
                    string w = advancedDataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                    if (w == "True")
                    {
                        txtWay.Text = "Есть";
                    }
                    else
                    {
                        if (w == "False")
                        {
                            txtWay.Text = "Нет";
                        }
                        else
                        {
                            txtWay.Text = "";
                        }
                    }
                }
                if (logTable != null)
                {
                    string lnk = string.Format(@"'{0}'", txtFile.Text);
                    var query = "SELECT * FROM changeLogTable where advFk = " +lnk;
                        DataTable someDataTable = new DataTable();

                    string connString = @"Data Source=SQL;Initial Catalog=Log_base;Integrated Security=True";
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
                        List<string> columnData = new List<string>();

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        columnData.Add(
                                            " Редактор: " + reader.GetString(3) + " Поле: " + reader.GetString(4)
                                            + " Текст: " + reader.GetString(2) + "\n");
                                    }
                                }

                        logTable.Text = "";

                        foreach (var row in columnData)
                        {
                            logTable.AppendText(row);
                        }

                    }
                    catch
                    {
                        Console.Write("(((");
                    }
                }
            }
        }
    
        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.zUADVSBindingSource.Sort = this.advancedDataGridView1.SortString;
        }

        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.zUADVSBindingSource.Filter = this.advancedDataGridView1.FilterString;
            FilteredCount.Text = this.advancedDataGridView1.RowCount.ToString();
            //Again fill column Номер with numbers
            for (int i = 0; i < advancedDataGridView1.RowCount; i++)
            {
                this.advancedDataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != 0 || rowIndexPrev != -1)
            {
                    columnIndexPrev = columnIndex;
                    rowIndexPrev = rowIndex;
                    columnIndex = e.ColumnIndex;
                    rowIndex = e.RowIndex;
            }
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

        public RichTextBox txtHistory; 
        public Button saveHistoryButton; 
        public TabControl tabControl1; 
        public Label lbl1;
        public Label lblnumob;
        public Label lblName;
        public Label lblLink;
        public Label lblFile;
        public Label lblSug;
        public Label lblAdded;
        public Label lblAct;

        public Label lblPlace;
        public Label lblCost;
        public Label lblSquare;
        public Label lblSquareOne;
        public Label lblPriceOne;
        public Label lblMission;
        public Label lblOgran;
        public Label lblCadastr;
        public Label lblCard;
        public Label lblPage;
        public Label lblWater;
        public Label lblWay;

        public TextBox txt1 { get; set; }
        public TextBox txtnumob { get; set; }
        public TextBox txtName { get; set; }
        public TextBox txtLink { get; set; }
        public TextBox txtFile { get; set; }
        public TextBox txtSug { get; set; }
        public TextBox txtAdded { get; set; }
        public TextBox txtAct { get; set; }

        public TextBox txtPlace { get; set; }
        public TextBox txtCost { get; set; }
        public TextBox txtSquare { get; set; }
        public TextBox txtSquareOne { get; set; }
        public TextBox txtPriceOne { get; set; }
        public TextBox txtMission { get; set; }
        public TextBox txtOgran { get; set; }
        public TextBox txtCadastr { get; set; }
        public TextBox txtCard { get; set; }
        public TextBox txtPage { get; set; }
        public TextBox txtWater { get; set; }
        public TextBox txtWay { get; set; }
        public Button saveBtn { get; set; }
        public Button fullBtn;
        //WebBrowser wb;

        private void saveBtn_Click(object sender, EventArgs e)
        {

            string validSug = "";
            string validWater = "";
            string validWay = "";

            //sug, water and way are bool in database
            //need to check 
            if (txtSug.Text == "От частного лица")
            {
                validSug = "False";
            }
            else
            {
                if (txtSug.Text == "От агентства недвижимости")
                {
                    validSug = "True";
                }
                else
                {
                    MessageBox.Show("Недопустимое значение поля \"Предложение\". Введите От частного лица или От агентства недвижимости");
                }
            }

            if (txtWater.Text == "Есть")
            {
                validWater = "True";
            }
            else
            {
                if (txtWater.Text == "Нет")
                {
                    validWater = "False";
                }
                else
                {
                    MessageBox.Show("Недопустимое значение поля \"Вода\". Введите Есть или Нет");
                }
            }

            if (txtWay.Text == "Есть")
            {
                validWay = "True";
            }
            else
            {
                if (txtWay.Text == "Нет")
                {
                    validWay = "False";
                }
                else
                {
                    MessageBox.Show("Недопустимое значение поля \"Объездной путь\". Введите Есть или Нет");
                }
            }
            
            var query = "UPDATE ZUADVS SET DateCreating = '"+txt1.Text + "', AdvNumber = '" + txtnumob.Text + "', AdvName = '" + txtName.Text + "', Source = '" + txtLink.Text + "', "
                + "SourceFile = '" + txtFile.Text + "', Offert = '" + validSug + "', DateAdd = '" + txtAdded.Text + "', DateActual = '" + txtAct.Text + "', addr_01_City = '" + txtPlace.Text
                + "', Cost = '" + txtCost.Text + "', AdvArea = '" + txtSquare.Text + "', AdvPurpose = '" + txtMission.Text + "', BordAdv = '" + txtOgran.Text + "', addr_06_KadNumber = '" 
                + txtCadastr.Text + "', addr_07_MapLoc = '" + txtCard.Text + "', Water = '" + validWater + "', Road = '" + validWay + "' where SourceFile = '" + advancedDataGridView1.SelectedRows[0].Cells[33].Value.ToString() + "'";
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
                AddLog();
                cmd.ExecuteNonQuery();
                this.zUADVSTableAdapter.Fill(this._advs_2_restored_АлинаDataSet.ZUADVS);
                for (int i = 0; i < advancedDataGridView1.RowCount; i++)
                {
                    this.advancedDataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
                advancedDataGridView1.Refresh();

            }
            catch
            {
                Console.Write("(((");
            }
        }
        private void datagridview_cellClick(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                if (rowIndexPrev != -1)
                {
                    this.advancedDataGridView1.Rows[rowIndexPrev].Selected = false;
                }
                this.advancedDataGridView1.Rows[rowIndex].Selected = true; //-1 header
            }
        }
        
        private void fullBtn_Click(object sender, EventArgs e)
        {
            if (wb == null || wb.Created == false)
            {
                wb = new WebBrowserForm(advancedDataGridView1.SelectedRows[0].Cells[33].Value.ToString());
            wb.Show();
            } 

        }

        /// <summary>
        /// write log of messages with client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHistory_Create(object sender, EventArgs e)
        {
            int indexSource = 33;
            if (advancedDataGridView1.SelectedRows[0].Cells[indexSource] != null)
            {
                string mes = advancedDataGridView1.SelectedRows[0].Cells[indexSource].Value.ToString();
                string sourcefile;
                string mess = sourcefile = mes.TrimEnd('.', 'h', 't', 'm', 'l', ' ');
                mess += "_files";
                sourcefile += ".txt";
                    if (File.Exists(sourcefile))
                    {
                        txtHistory.Text = File.ReadAllText(sourcefile);
                    }
            }
            else
            {
                MessageBox.Show("Выберите строку объявления!");
            }
        }
        private void saveHistoryButton_Click(object sender, EventArgs e)
        {
            int indexSource = 33;
            if (advancedDataGridView1.SelectedRows[0].Cells[indexSource] != null)
            {
                string mes = advancedDataGridView1.SelectedRows[0].Cells[indexSource].Value.ToString();
                string sourcefile;
                string mess = sourcefile = mes.TrimEnd('.', 'h', 't', 'm', 'l', ' ');
                mess += "_files";
                sourcefile += ".txt"; //по номеру объявления 
                if (Directory.Exists(mess))
                {
                    if (!File.Exists(sourcefile))
                    {
                        File.Create(sourcefile);
                        File.WriteAllText(sourcefile, txtHistory.Text);
                    }
                    else
                    {
                        File.WriteAllText(sourcefile, txtHistory.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку объявления!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Equality eq = new Equality();
            eq.Show();
        }
       
        private void link_dblclick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(advancedDataGridView1.SelectedRows[0].Cells[5].Value.ToString());
        }
        private void file_dblclick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(advancedDataGridView1.SelectedRows[0].Cells[33].Value.ToString());
        }
        struct changedInfo
        {
            public string adv { get; set; }
            public string ChangedField { get; set; }
            public string ChangedText { get; set; }
            public DateTime DateAdd { get; set; }
            public string Changer { get; set; }
        }

        public void AddLog()
        {
            List<changedInfo> listLog = new List<changedInfo>();
            if (txt1 != null)
            {
                if (txt1.Text != advancedDataGridView1.SelectedRows[0].Cells[2].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Создано",
                        ChangedText = txt1.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtnumob != null)
            {
                if (txtnumob.Text != advancedDataGridView1.SelectedRows[0].Cells[46].Value.ToString())
                {
                    listLog.Add(new changedInfo
                {
                    adv = txtFile.Text,
                    ChangedField = "Номер Объявления",
                    ChangedText = txtnumob.Text,
                    DateAdd = DateTime.Now,
                    Changer = "1"
                });
                }
            }
            if (txtName != null)
            {
                if (txtName.Text != advancedDataGridView1.SelectedRows[0].Cells[7].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Название",
                        ChangedText = txtName.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtLink != null)
            {
                if (txtLink.Text != advancedDataGridView1.SelectedRows[0].Cells[5].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Ссылка",
                        ChangedText = txtLink.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtFile != null)
            {
                if (txtFile.Text != advancedDataGridView1.SelectedRows[0].Cells[33].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Файл",
                        ChangedText = txtFile.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }

            }
            if (txtSug != null)
            {
                string n = advancedDataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                string dbtext;
                if (n != null)
                {
                    if (n.Equals("false"))
                    {
                        dbtext = "От частного лица";
                    }
                    else
                    {
                        dbtext = "От агентства недвижимости";
                    }
                }
                else
                {
                    dbtext = "";
                }
                if (dbtext != txtSug.Text)
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Предложение",
                        ChangedText = txtSug.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }

            }
            if (txtAdded != null)
            {
                if (txtAdded.Text != advancedDataGridView1.SelectedRows[0].Cells[3].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Добавлено",
                        ChangedText = txtAdded.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtAct != null)
            {
                if (txtAct.Text != advancedDataGridView1.SelectedRows[0].Cells[4].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Актуально",
                        ChangedText = txtAct.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtPlace != null)
            {
                if (txtPlace.Text != advancedDataGridView1.SelectedRows[0].Cells[24].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Район",
                        ChangedText = txtPlace.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtCost != null)
            {
                txtCost.Text = (advancedDataGridView1.SelectedRows[0].Cells[10].Value.ToString() != null) ? (advancedDataGridView1.SelectedRows[0].Cells[10].Value.ToString()) : "0";
                if (txtCost.Text != advancedDataGridView1.SelectedRows[0].Cells[10].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Цена",
                        ChangedText = txtCost.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtSquareOne != null)
            {
                if (txtSquare.Text != advancedDataGridView1.SelectedRows[0].Cells[8].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Площадь",
                        ChangedText = txtSquare.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }

            if (txtOgran != null)
            {
                if (txtOgran.Text != advancedDataGridView1.SelectedRows[0].Cells[19].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Ограничение",
                        ChangedText = txtOgran.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }

            }
            if (txtCadastr != null)
            {
                if (txtCadastr.Text != advancedDataGridView1.SelectedRows[0].Cells[31].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Кадастровый номер",
                        ChangedText = txtCadastr.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtCard != null)
            {
                if (txtCard.Text != advancedDataGridView1.SelectedRows[0].Cells[32].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Карта",
                        ChangedText = txtCard.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtPage != null)
            {
                if (txtPage.Text != advancedDataGridView1.SelectedRows[0].Cells[12].Value.ToString())
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Статус",
                        ChangedText = txtPage.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }

            if (txtWater != null)
            {
                string w = advancedDataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                string wstring;
                if (w == "True")
                {
                    wstring = "Есть";
                }
                else
                {
                    if (w == "False")
                    {
                        wstring = "Нет";
                    }
                    else
                    {
                        wstring = "";
                    }
                }
                if (wstring != txtWater.Text)
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Вода",
                        ChangedText = txtWater.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
            if (txtWay != null)
            {
                string w = advancedDataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                string wstring;
                if (w == "True")
                {
                    wstring = "Есть";
                }
                else
                {
                    if (w == "False")
                    {
                        wstring = "Нет";
                    }
                    else
                    {
                        wstring = "";
                    }
                }
                if (wstring != txtWay.Text)
                {
                    listLog.Add(new changedInfo
                    {
                        adv = txtFile.Text,
                        ChangedField = "Объездные пути",
                        ChangedText = txtWay.Text,
                        DateAdd = DateTime.Now,
                        Changer = "1"
                    });
                }
            }
                string connString = @"Data Source=SQL;Initial Catalog=Log_base;Integrated Security=True";
            SqlConnection oldb = new SqlConnection(connString);

            foreach (var it in listLog)
            {
                var query = "Insert changeLogTable (DateCreate, LogText, Changer, change, advFk) values ('"
                    + it.DateAdd + "', '" + it.ChangedText + "', '" + it.Changer + "', '" + it.ChangedField + "', '"
                    + it.adv + "')";
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
                    oldb.Close();
                }
                catch
                {
                    Console.Write("(((");
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (firstStart == true)
            {
                sizeDif = 0;
                firstStart = false;
            }
            else
            {
                sizeDif = this.Width - sizeBefore;
                advancedDataGridView1.Width -= sizeDif / 100 * 45;
            }
            sizeBefore = this.Width;
        }
    }
}

