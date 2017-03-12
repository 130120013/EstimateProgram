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
        //private ADGV.AdvancedDataGridView dataGridView1 = new ADGV.AdvancedDataGridView();
        //private Cache memoryCache;
        private PleaseWaitForm f3 = new PleaseWaitForm();
        private List<bool> initialized = new List<bool>();
        private int columnIndex = 0;
        private int rowIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_advs_2_restored_АлинаDataSet.ZUADVS". При необходимости она может быть перемещена или удалена.
            this.zUADVSTableAdapter.Fill(this._advs_2_restored_АлинаDataSet.ZUADVS);
            this.advancedDataGridView1.CellClick += new
            DataGridViewCellEventHandler(datagridview_cellClick);
            //this.advancedDataGridView1.CellClick += new DataGridViewCellEventHandler(datagridview_cellClick);
            this.advancedDataGridView1.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_ColumnHeaderMouseClick);
            this.advancedDataGridView1.CellMouseUp += new DataGridViewCellMouseEventHandler(dataGridView1_DataSourceComplete);
            this.advancedDataGridView1.CellMouseEnter += new DataGridViewCellEventHandler(cell);
            this.advancedDataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged); 
            ////this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView1_ColumnHeaderMouseClick);
            for(int i = 0; i< advancedDataGridView1.ColumnCount; i++)
            {
            initialized.Add(false);
            }
            this.advancedDataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.DisplayedCells);

            this.advancedDataGridView1.Rows[0].Selected = true;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (rowIndex != 0)
            {
                this.advancedDataGridView1.Rows[rowIndex].Selected = true;
            }
            int indexSource = 32;
            if (txtHistory != null)
            {
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
                if (txt1 != null)
                {
                    txt1.Text = advancedDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                }
                if (txtnumob != null)
                {
                    txtnumob.Text = advancedDataGridView1.SelectedRows[0].Cells[45].Value.ToString();
                }
                if (txtName != null)
                {
                    txtName.Text = advancedDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                }
                if (txtLink != null)
                {
                    txtLink.Text = advancedDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                }
                if (txtFile != null)
                {
                    txtFile.Text = advancedDataGridView1.SelectedRows[0].Cells[32].Value.ToString();
                }
                if (txtSug != null)
                {
                    string n = advancedDataGridView1.SelectedRows[0].Cells[19].Value.ToString();
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
                    txtAdded.Text = advancedDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                }
                if (txtAct != null)
                {
                    txtAct.Text = advancedDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                }
                if (txtPlace != null)
                {
                    txtPlace.Text = advancedDataGridView1.SelectedRows[0].Cells[23].Value.ToString();
                }
                if (txtCost != null)
                {
                    txtCost.Text = advancedDataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                }
                if (txtSquareOne != null)
                {
                    txtSquare.Text = advancedDataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                }
                if (txtSquare != null)
                {
                    string val = advancedDataGridView1.SelectedRows[0].Cells[7].Value.ToString();
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
                            m = Convert.ToInt32(val.TrimEnd('к','в','.', 'м'));
                            txtSquareOne.Text = m.ToString();
                        }
                    }

                }
                if (txtPriceOne != null)
                {
                    txtPriceOne.Text = (Convert.ToInt32(txtCost.Text)/ Convert.ToInt32(txtSquareOne.Text)).ToString();
                }

                if (txtOgran != null)
                {
                    txtOgran.Text = advancedDataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                }
                if (txtCadastr != null)
                {
                    txtCadastr.Text = advancedDataGridView1.SelectedRows[0].Cells[30].Value.ToString();
                }
                if (txtCard != null)
                {
                    txtCard.Text = advancedDataGridView1.SelectedRows[0].Cells[31].Value.ToString();
                }
                if (txtPage != null)
                {
                    txtPage.Text = advancedDataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                }
                if (txtWater != null)
                {
                    string w = advancedDataGridView1.SelectedRows[0].Cells[14].Value.ToString();
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
                    string w = advancedDataGridView1.SelectedRows[0].Cells[15].Value.ToString();
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

            }
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == 0)
            columnIndex = e.ColumnIndex;
            rowIndex = e.RowIndex;
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

        //   private void dataGridView1_CellValueNeeded(object sender,
        //DataGridViewCellValueEventArgs e)
        //   {
        //       e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        //   }


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

        public TextBox txt1;
        public TextBox txtnumob;
        public TextBox txtName;
        public TextBox txtLink;
        public TextBox txtFile;
        public TextBox txtSug;
        public TextBox txtAdded;
        public TextBox txtAct;

        public TextBox txtPlace;
        public TextBox txtCost;
        public TextBox txtSquare;
        public TextBox txtSquareOne;
        public TextBox txtPriceOne;
        public TextBox txtMission;
        public TextBox txtOgran;
        public TextBox txtCadastr;
        public TextBox txtCard;
        public TextBox txtPage;
        public TextBox txtWater;
        public TextBox txtWay;
        public Button saveBtn;

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

            //public TextBox txtSug;
            //public TextBox txtAdded;
            //public TextBox txtAct;

            //public TextBox txtPlace;
            //public TextBox txtCost;
            //public TextBox txtSquare;
            //public TextBox txtSquareOne;
            //public TextBox txtPriceOne;
            //public TextBox txtMission;
            //public TextBox txtOgran;
            //public TextBox txtCadastr;
            //public TextBox txtCard;
            //public TextBox txtPage;
            //public TextBox txtWater;
            //public TextBox txtWay;
            var query = "UPDATE ZUADVS SET DateCreating = "+txt1.Text + ", AdvNumber = " + txtnumob.Text + ", AdvName = " + txtName.Text + ", Source = " + txtLink.Text + ", "
                + "SourceFile = " + txtFile.Text + ", Offert = " + validSug + ", DateAdd = " + txtAdded.Text + ", DateActual = " + txtAct.Text + ", addr_01_City = " + txtPlace.Text
                + ", Cost = " + txtCost.Text + ", AdvArea = " + txtSquare.Text + ", AdvPurpose = " + txtMission.Text + ", BordAdv = " + txtOgran.Text + ", addr_06_KadNumber = " 
                + txtCadastr.Text + ", addr_07_MapLoc = " + txtCard.Text + ", Water = " + validWater + ", Road = " + validWay;
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
                cmd.ExecuteNonQuery();
                //someDataTable.Load(cmd.ExecuteReader());
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
                this.advancedDataGridView1.Rows[rowIndex].Selected = true; //-1 header
            }
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
                tabControl1 = new TabControl();

                button1.Text = "<";
                advancedDataGridView1.Width -= Form1.ActiveForm.Width / 100 * 45; 
                button1.Location = new System.Drawing.Point(button1.Location.X - Form1.ActiveForm.Width / 100 * 45, advancedDataGridView1.Location.Y);

                tabControl1.Size = new System.Drawing.Size(Form1.ActiveForm.Width / 100 * 43, button1.Size.Height);
                tabControl1.TabPages.Add("Информация");
                tabControl1.TabPages.Add("Контакты");
                tabControl1.TabPages.Add("История общения");
                tabControl1.TabPages.Add("Фото");
                tabControl1.TabPages.Add("Источник");
                Form1.ActiveForm.Controls.Add(tabControl1);
                // tab Информация

                lbl1 = new Label();
                txt1 = new TextBox();
                lbl1.Text = "Cоздано ";
                lbl1.Size = new System.Drawing.Size(80, 20);
                txt1.Location = new Point(lbl1.Location.X, lbl1.Location.Y + 20);
                txt1.Text = advancedDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lbl1);
                tabControl1.TabPages[0].Controls.Add(txt1);
                lblnumob = new Label();
                txtnumob = new TextBox();
                lblnumob.Text = "Номер объявления на Фарпосте";
                lblnumob.Size = new System.Drawing.Size(300, 20);
                lblnumob.Location = new System.Drawing.Point(lbl1.Location.X + 120, lbl1.Location.Y);
                txtnumob.Location = new Point(lblnumob.Location.X, lblnumob.Location.Y + 20);
                txtnumob.Text = advancedDataGridView1.SelectedRows[0].Cells[45].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblnumob);
                tabControl1.TabPages[0].Controls.Add(txtnumob);

                lblName = new Label();
                txtName = new TextBox();
                lblName.Text = "Название объявления";
                lblName.Size = new System.Drawing.Size(500, 20);
                lblName.Location = new System.Drawing.Point(txt1.Location.X, txt1.Location.Y + 5 + txtName.Size.Height);
                txtName.Location = new Point(lblName.Location.X, lblName.Location.Y + 20);
                txtName.Text = advancedDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblName);
                tabControl1.TabPages[0].Controls.Add(txtName);

                lblLink = new Label();
                txtLink = new TextBox();
                lblLink.Text = "Ссылка";
                lblLink.Size = new System.Drawing.Size(500, 20);
                lblLink.Location = new System.Drawing.Point(txtName.Location.X, txtName.Location.Y + 5 + txtName.Size.Height);
                txtLink.Location = new Point(lblLink.Location.X, lblLink.Location.Y + 20);
                txtLink.Text = advancedDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblLink);
                tabControl1.TabPages[0].Controls.Add(txtLink);

                lblFile = new Label();
                txtFile = new TextBox();
                lblFile.Text = "Файл";
                lblFile.Size = new System.Drawing.Size(500, 20);
                lblFile.Location = new System.Drawing.Point(txtLink.Location.X, txtLink.Location.Y + 5 + txtLink.Size.Height);
                txtFile.Location = new Point(lblFile.Location.X, lblFile.Location.Y + 20);
                txtFile.Text = advancedDataGridView1.SelectedRows[0].Cells[32].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblFile);
                tabControl1.TabPages[0].Controls.Add(txtFile);

                lblSug = new Label();
                txtSug = new TextBox();
                lblSug.Text = "Предложение";
                lblSug.Size = new System.Drawing.Size(100, 20);
                lblSug.Location = new System.Drawing.Point(txtFile.Location.X, txtFile.Location.Y + 5 + txtFile.Size.Height);
                txtSug.Location = new Point(lblSug.Location.X, lblSug.Location.Y + 20);
                if (advancedDataGridView1.SelectedRows[0].Cells[19].Value.ToString() != null)
                {
                    if (advancedDataGridView1.SelectedRows[0].Cells[19].Value.ToString().Equals("false"))
                    {
                        txtSug.Text = "От частного лица";
                    }
                    else
                    {
                        txtSug.Text = "От агенства недвижимости";
                    }
                }
                else
                {
                    txtSug.Text = "";
                }
                tabControl1.TabPages[0].Controls.Add(lblSug);
                tabControl1.TabPages[0].Controls.Add(txtSug);

                lblAdded = new Label();
                txtAdded = new TextBox();
                lblAdded.Text = "Добавлено";
                lblAdded.Size = new System.Drawing.Size(100, 20);
                lblAdded.Location = new System.Drawing.Point(lblSug.Location.X + 120, lblSug.Location.Y);
                txtAdded.Location = new Point(lblAdded.Location.X, lblAdded.Location.Y + 20);
                txtAdded.Text = advancedDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblAdded);
                tabControl1.TabPages[0].Controls.Add(txtAdded);

                lblAct = new Label();
                txtAct = new TextBox();
                lblAct.Text = "Актуально";
                lblAct.Size = new System.Drawing.Size(100, 20);
                lblAct.Location = new System.Drawing.Point(lblAdded.Location.X + 120, lblAdded.Location.Y);
                txtAct.Location = new Point(lblAct.Location.X, lblAct.Location.Y + 20);
                txtAct.Text = advancedDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblAct);
                tabControl1.TabPages[0].Controls.Add(txtAct);

                //---------
                Label spl = new Label();
                spl.Text = "Характеристики";
                spl.Location = new Point(txtSug.Location.X, txtSug.Location.Y + txtSug.Size.Height + 10);
                tabControl1.TabPages[0].Controls.Add(spl);

                lblPlace = new Label();
                txtPlace = new TextBox();
                lblPlace.Text = "Район";
                lblPlace.Size = new System.Drawing.Size(100, 20);
                lblPlace.Location = new System.Drawing.Point(spl.Location.X, spl.Location.Y + 40);
                txtPlace.Location = new Point(lblPlace.Location.X, lblPlace.Location.Y + 20);
                    txtPlace.Text = advancedDataGridView1.SelectedRows[0].Cells[23].Value.ToString();
                    tabControl1.TabPages[0].Controls.Add(lblPlace);
                tabControl1.TabPages[0].Controls.Add(txtPlace);

                lblCost = new Label();
                txtCost = new TextBox();
                lblCost.Text = "Цена";
                lblCost.Size = new System.Drawing.Size(100, 20);
                lblCost.Location = new System.Drawing.Point(txtPlace.Location.X, txtPlace.Location.Y + 5 + txtPlace.Size.Height);
                txtCost.Location = new Point(lblCost.Location.X, lblCost.Location.Y + 20);
                txtCost.Text = advancedDataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblCost);
                tabControl1.TabPages[0].Controls.Add(txtCost);

                lblSquare = new Label();
                txtSquareOne = new TextBox();
                lblSquare.Text = "Распознанная площадь";
                lblSquare.Size = new System.Drawing.Size(140, 20);
                lblSquare.Location = new System.Drawing.Point(lblCost.Location.X + 120, lblCost.Location.Y);
                txtSquareOne.Location = new Point(lblSquare.Location.X + 150, lblSquare.Location.Y + 20);
                txtSquareOne.Text = advancedDataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblSquare);
                tabControl1.TabPages[0].Controls.Add(txtSquareOne);

                lblSquareOne = new Label();
                txtSquare = new TextBox();
                lblSquareOne.Text = "Площадь в кв.м.";
                lblSquareOne.Size = new System.Drawing.Size(140, 20);
                lblSquareOne.Location = new System.Drawing.Point(lblSquare.Location.X + 150, lblSquare.Location.Y);
                txtSquare.Location = new Point(lblSquare.Location.X, lblSquare.Location.Y + 20);
                txtSquare.ReadOnly = true;
                string val = advancedDataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                if (val.Contains(" сот."))
                {
                    int m = 0;
                        m = Convert.ToInt32(val);
                    m *= 100;
                    txtSquare.Text = m.ToString();
                }
                else
                {
                    if (val.Contains("кв"))
                    {
                        int m = 0;

                        txtSquare.Text = m.ToString();
                    }
                }
                tabControl1.TabPages[0].Controls.Add(lblSquareOne);
                tabControl1.TabPages[0].Controls.Add(txtSquare);

                lblPriceOne = new Label();
                txtPriceOne = new TextBox();
                lblPriceOne.Text = "Цена за кв.м.";
                lblPriceOne.Size = new System.Drawing.Size(200, 20);
                lblPriceOne.Location = new System.Drawing.Point(lblSquareOne.Location.X + 150, lblSquareOne.Location.Y);
                txtPriceOne.Location = new Point(lblPriceOne.Location.X, lblPriceOne.Location.Y + 20);
                txtPriceOne.Text = (!Convert.ToInt32(txtSquare.Text).Equals(0))?((Convert.ToInt32(txtCost.Text) / Convert.ToInt32(txtSquare.Text)).ToString()):("0");
                txtPriceOne.ReadOnly = true;
                tabControl1.TabPages[0].Controls.Add(lblPriceOne);
                tabControl1.TabPages[0].Controls.Add(txtPriceOne);

                lblMission = new Label();
                txtMission = new TextBox();
                lblMission.Text = "Назначение";
                lblMission.Size = new System.Drawing.Size(100, 20);
                lblMission.Location = new System.Drawing.Point(txtCost.Location.X, txtPriceOne.Location.Y + 20);
                txtMission.Location = new Point(lblMission.Location.X, lblMission.Location.Y + 20);
                txtMission.Text = advancedDataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblMission);
                tabControl1.TabPages[0].Controls.Add(txtMission);

                lblOgran = new Label();
                txtOgran = new TextBox();
                lblOgran.Text = "Ограничение по использованию";
                lblOgran.Size = new System.Drawing.Size(300, 20);
                lblOgran.Location = new System.Drawing.Point(lblMission.Location.X + 120, lblMission.Location.Y);
                txtOgran.Location = new Point(lblOgran.Location.X, lblOgran.Location.Y + 20);
                tabControl1.TabPages[0].Controls.Add(lblOgran);
                tabControl1.TabPages[0].Controls.Add(txtOgran);

                lblCadastr = new Label();
                txtCadastr = new TextBox();
                lblCadastr.Text = "Кадастровый номер участка";
                lblCadastr.Size = new System.Drawing.Size(200, 20);
                lblCadastr.Location = new System.Drawing.Point(txtMission.Location.X, txtMission.Location.Y + 20);
                txtCadastr.Location = new Point(lblCadastr.Location.X, lblCadastr.Location.Y + 20);
                txtCadastr.Text = advancedDataGridView1.SelectedRows[0].Cells[30].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblCadastr);
                tabControl1.TabPages[0].Controls.Add(txtCadastr);

                lblCard = new Label();
                txtCard = new TextBox();
                lblCard.Text = "Расположение на карте";
                lblCard.Size = new System.Drawing.Size(200, 20);
                lblCard.Location = new System.Drawing.Point(lblCadastr.Location.X + 220, lblCadastr.Location.Y);
                txtCard.Location = new Point(lblCard.Location.X, lblCard.Location.Y + 20);
                txtCard.Text = advancedDataGridView1.SelectedRows[0].Cells[31].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblCard);
                tabControl1.TabPages[0].Controls.Add(txtCard);

                lblPage = new Label();
                txtPage = new TextBox();
                lblPage.Text = "Статус";
                lblPage.Size = new System.Drawing.Size(100, 20);
                lblPage.Location = new System.Drawing.Point(txtCadastr.Location.X, txtCadastr.Location.Y + 20);
                txtPage.Location = new Point(lblPage.Location.X, lblPage.Location.Y + 20);
                txtPage.Text = advancedDataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblPage);
                tabControl1.TabPages[0].Controls.Add(txtPage);

                lblWater = new Label();
                txtWater = new TextBox();
                lblWater.Text = "Вода";
                lblWater.Size = new System.Drawing.Size(100, 20);
                lblWater.Location = new System.Drawing.Point(lblPage.Location.X+120, lblPage.Location.Y);
                txtWater.Location = new Point(lblWater.Location.X, lblWater.Location.Y + 20);
                string w = advancedDataGridView1.SelectedRows[0].Cells[14].Value.ToString();
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
                tabControl1.TabPages[0].Controls.Add(lblWater);
                tabControl1.TabPages[0].Controls.Add(txtWater);

                lblWay = new Label();
                txtWay = new TextBox();
                lblWay.Text = "Объездные пути";
                lblWay.Size = new System.Drawing.Size(120, 20);
                lblWay.Location = new System.Drawing.Point(lblWater.Location.X + 120, lblWater.Location.Y);
                txtWay.Location = new Point(lblWay.Location.X, lblWay.Location.Y + 20);
                string er = advancedDataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                if (er == "True")
                {
                    txtWater.Text = "Есть";
                }
                else
                {
                    if (er == "False")
                    {
                        txtWater.Text = "Нет";
                    }
                    else
                    {
                        txtWater.Text = "";
                    }
                }
                txtWay.Text = advancedDataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                tabControl1.TabPages[0].Controls.Add(lblWay);
                tabControl1.TabPages[0].Controls.Add(txtWay);

                saveBtn = new Button();
                saveBtn.Text = "Сохранить изменения";
                saveBtn.Click += new EventHandler(saveBtn_Click);
                saveBtn.Location = new System.Drawing.Point(txtPage.Location.X, txtPage.Location.Y+ 30);
                saveBtn.Size = new System.Drawing.Size(120, 20);
                tabControl1.TabPages[0].Controls.Add(saveBtn);

                //Контакты

                Label lbluser = new Label();
                Label lblemail = new Label();
                Label lblphone = new Label();
                Label lblsug = new Label();

                lbluser.Text = "Пользователь";
                lblemail.Text = "Email";
                lblphone.Text = "Телефоны";
                lblsug.Text = "Количество предложений";

                lbluser.Location = new Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 10);
                lblemail.Location = new Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 80);
                lblphone.Location = new Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 150);
                lblsug.Location = new Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 350);

                tabControl1.TabPages[1].Controls.Add(lbluser);
                tabControl1.TabPages[1].Controls.Add(lblemail);
                tabControl1.TabPages[1].Controls.Add(lblphone);
                tabControl1.TabPages[1].Controls.Add(lblsug);

                TextBox txtuser = new TextBox();
                TextBox txtemail = new TextBox();
                RichTextBox txtphone = new RichTextBox();
                TextBox txtsug = new TextBox();

                txtuser.Size = new Size(250, 20);
                txtemail.Size = new Size(250, 20);
                txtphone.Size = new Size(250, 150);
                txtsug.Size = new Size(250, 20);

                txtuser.Location = new Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 35);
                txtemail.Location = new Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 105);
                txtphone.Location = new Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 175);
                txtsug.Location = new Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 375);

                tabControl1.TabPages[1].Controls.Add(txtuser);
                tabControl1.TabPages[1].Controls.Add(txtemail);
                tabControl1.TabPages[1].Controls.Add(txtphone);
                tabControl1.TabPages[1].Controls.Add(txtsug);
                //История

               txtHistory = new RichTextBox();
                txtHistory.Location = new System.Drawing.Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 10);
                txtHistory.Size = new System.Drawing.Size(tabControl1.Size.Width - 20, tabControl1.Size.Height - 60);
                txtHistory.HandleCreated += new EventHandler(txtHistory_Create); 
                saveHistoryButton = new Button();
                saveHistoryButton.Size = new Size(tabControl1.Size.Width - 20, 20);
                saveHistoryButton.Location = new Point(tabControl1.Location.X+10, txtHistory.Size.Height + 10);
                saveHistoryButton.Text = "Сохранить историю";
                saveHistoryButton.Click += new EventHandler(saveHistoryButton_Click);
                tabControl1.TabPages[2].Controls.Add(txtHistory);
                tabControl1.TabPages[2].Controls.Add(saveHistoryButton);

                //Фото



                //Источник
                WebBrowser wb = new WebBrowser();
                Uri uri = new Uri(@"file://C:\Users\Jack\Desktop\Шикарный ОФИС на Фуникулёре — 105 кв. метров. [2].html");
                wb.Navigate(uri);
                wb.Location = new System.Drawing.Point(tabControl1.Location.X + 10, tabControl1.Location.Y + 10);
                wb.Size = new System.Drawing.Size(tabControl1.Size.Width - 20, tabControl1.Size.Height - 40);
                tabControl1.TabPages[4].Controls.Add(wb);

                //----------------------------------------------------------------------------------------------------------------------------------------
                tabControl1.Location = new System.Drawing.Point(button1.Location.X + button1.Width * 2, button1.Location.Y);


            }
            else
            {
                txtHistory.Dispose();
                saveHistoryButton.Dispose();
                tabControl1.Dispose();
                lbl1.Dispose();
        button1.Text = ">";
                advancedDataGridView1.Width += Form1.ActiveForm.Width / 100 * 45;
                button1.Location = new System.Drawing.Point(advancedDataGridView1.Location.X + advancedDataGridView1.Width, advancedDataGridView1.Location.Y);


            }
        }

        private void txtHistory_Create(object sender, EventArgs e)
        {
            int indexSource = 32;
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
            int indexSource = 32;
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
            Equality eq = new Equality();
            eq.Show();
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
            var removed = advancedDataGridView1.CurrentRow;
            param.Value = advancedDataGridView1.CurrentRow.Cells[0].Value;
            //задаем тип параметра
            param.SqlDbType = SqlDbType.Int;
            //передаем параметр объекту класса SqlCommand
            cmd.Parameters.Add(param);
            try
            {
                cmd.ExecuteNonQuery();

                //обновление таблицы
                advancedDataGridView1.Rows.Remove(removed);
                advancedDataGridView1.Refresh();
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
            foreach (DataGridViewRow c in advancedDataGridView1.SelectedRows)
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
