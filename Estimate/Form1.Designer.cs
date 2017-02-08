using System.Windows.Forms;

namespace Estimate
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.testTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablesDataSet = new Estimate.TablesDataSet();
            this.testTableTableAdapter = new Estimate.TablesDataSetTableAdapters.TestTableTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.searchToolBar1 = new ADGV.SearchToolBar();
            this.dataGridView1 = new ADGV.AdvancedDataGridView();
            this.testIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomFieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.testTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // testTableBindingSource
            // 
            this.testTableBindingSource.DataMember = "TestTable";
            this.testTableBindingSource.DataSource = this.tablesDataSet;
            // 
            // tablesDataSet
            // 
            this.tablesDataSet.DataSetName = "TablesDataSet";
            this.tablesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testTableTableAdapter
            // 
            this.testTableTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1044, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 445);
            this.button1.TabIndex = 1;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 88);
            this.button2.TabIndex = 2;
            this.button2.Text = "Добавить запись";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(160, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 88);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить запись";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(304, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 88);
            this.button4.TabIndex = 4;
            this.button4.Text = "Экспорт в Excel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(914, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 88);
            this.button5.TabIndex = 5;
            this.button5.Text = "Поиск дублирующихся записей\r\n";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(758, 35);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(128, 88);
            this.button6.TabIndex = 6;
            this.button6.Text = "Мои выборки";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(605, 35);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 88);
            this.button7.TabIndex = 7;
            this.button7.Text = "Сравнить";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(452, 35);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(128, 88);
            this.button8.TabIndex = 8;
            this.button8.Text = "Статистика";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // searchToolBar1
            // 
            this.searchToolBar1.AllowMerge = false;
            this.searchToolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.searchToolBar1.Location = new System.Drawing.Point(0, 0);
            this.searchToolBar1.MaximumSize = new System.Drawing.Size(0, 27);
            this.searchToolBar1.MinimumSize = new System.Drawing.Size(0, 27);
            this.searchToolBar1.Name = "searchToolBar1";
            this.searchToolBar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.searchToolBar1.Size = new System.Drawing.Size(1083, 27);
            this.searchToolBar1.TabIndex = 9;
            this.searchToolBar1.Text = "searchToolBar1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoGenerateContextFilters = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.testIDDataGridViewTextBoxColumn,
            this.randomFieldDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.testTableBindingSource;
            this.dataGridView1.DateWithTime = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1030, 445);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.TimeFilter = false;
            // 
            // testIDDataGridViewTextBoxColumn
            // 
            this.testIDDataGridViewTextBoxColumn.DataPropertyName = "TestID";
            this.testIDDataGridViewTextBoxColumn.HeaderText = "TestID";
            this.testIDDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.testIDDataGridViewTextBoxColumn.Name = "testIDDataGridViewTextBoxColumn";
            this.testIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.testIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // randomFieldDataGridViewTextBoxColumn
            // 
            this.randomFieldDataGridViewTextBoxColumn.DataPropertyName = "RandomField";
            this.randomFieldDataGridViewTextBoxColumn.HeaderText = "RandomField";
            this.randomFieldDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.randomFieldDataGridViewTextBoxColumn.Name = "randomFieldDataGridViewTextBoxColumn";
            this.randomFieldDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 619);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchToolBar1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.testTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TablesDataSet tablesDataSet;
        private System.Windows.Forms.BindingSource testTableBindingSource;
        private TablesDataSetTableAdapters.TestTableTableAdapter testTableTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private ADGV.SearchToolBar searchToolBar1;
        private ADGV.AdvancedDataGridView dataGridView1;
        private DataGridViewTextBoxColumn testIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn randomFieldDataGridViewTextBoxColumn;
    }
}

