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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.testIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomFieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablesDataSet = new Estimate.TablesDataSet();
            this.testTableTableAdapter = new Estimate.TablesDataSetTableAdapters.TestTableTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.testIDDataGridViewTextBoxColumn,
            this.randomFieldDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.testTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(905, 445);
            this.dataGridView1.TabIndex = 0;
            // 
            // testIDDataGridViewTextBoxColumn
            // 
            this.testIDDataGridViewTextBoxColumn.DataPropertyName = "TestID";
            this.testIDDataGridViewTextBoxColumn.HeaderText = "TestID";
            this.testIDDataGridViewTextBoxColumn.Name = "testIDDataGridViewTextBoxColumn";
            this.testIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // randomFieldDataGridViewTextBoxColumn
            // 
            this.randomFieldDataGridViewTextBoxColumn.DataPropertyName = "RandomField";
            this.randomFieldDataGridViewTextBoxColumn.HeaderText = "RandomField";
            this.randomFieldDataGridViewTextBoxColumn.Name = "randomFieldDataGridViewTextBoxColumn";
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
            this.button1.Location = new System.Drawing.Point(914, 162);
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
            this.button3.Location = new System.Drawing.Point(196, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 88);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить запись";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 619);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private TablesDataSet tablesDataSet;
        private System.Windows.Forms.BindingSource testTableBindingSource;
        private TablesDataSetTableAdapters.TestTableTableAdapter testTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn testIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomFieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

