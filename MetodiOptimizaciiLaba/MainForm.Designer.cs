namespace MetodiOptimizaciiLaba
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.RestrAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.VariablesAmount = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSve = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RestrAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1043, 584);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImport);
            this.tabPage1.Controls.Add(this.btnSve);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.RestrAmount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.VariablesAmount);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1035, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количство Ограничений";
            // 
            // RestrAmount
            // 
            this.RestrAmount.Location = new System.Drawing.Point(142, 73);
            this.RestrAmount.Name = "RestrAmount";
            this.RestrAmount.ReadOnly = true;
            this.RestrAmount.Size = new System.Drawing.Size(57, 20);
            this.RestrAmount.TabIndex = 3;
            this.RestrAmount.ValueChanged += new System.EventHandler(this.RestrAmount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количство Переменных";
            // 
            // VariablesAmount
            // 
            this.VariablesAmount.Location = new System.Drawing.Point(142, 47);
            this.VariablesAmount.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.VariablesAmount.Name = "VariablesAmount";
            this.VariablesAmount.ReadOnly = true;
            this.VariablesAmount.Size = new System.Drawing.Size(57, 20);
            this.VariablesAmount.TabIndex = 1;
            this.VariablesAmount.ValueChanged += new System.EventHandler(this.VariablesAmount_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(244, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(785, 347);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1035, 558);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSve
            // 
            this.btnSve.Location = new System.Drawing.Point(918, 369);
            this.btnSve.Name = "btnSve";
            this.btnSve.Size = new System.Drawing.Size(86, 34);
            this.btnSve.TabIndex = 5;
            this.btnSve.Text = "Сохранить";
            this.btnSve.UseVisualStyleBackColor = true;
            this.btnSve.Click += new System.EventHandler(this.btnSve_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(804, 369);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(96, 34);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Импортировать";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 596);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Методы оптимизации, Климов";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RestrAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RestrAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown VariablesAmount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSve;
        private System.Windows.Forms.Button btnImport;
    }
}

