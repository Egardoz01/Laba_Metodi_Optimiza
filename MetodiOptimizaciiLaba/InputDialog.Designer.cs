namespace MetodiOptimizaciiLaba
{
    partial class InputDialog
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
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RestrAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.VariablesAmount = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSolve = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.RestrAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(800, 378);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(96, 34);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "Импортировать";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSve
            // 
            this.btnSve.Location = new System.Drawing.Point(914, 378);
            this.btnSve.Name = "btnSve";
            this.btnSve.Size = new System.Drawing.Size(86, 34);
            this.btnSve.TabIndex = 12;
            this.btnSve.Text = "Сохранить";
            this.btnSve.UseVisualStyleBackColor = true;
            this.btnSve.Click += new System.EventHandler(this.btnSve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Количство Ограничений";
            // 
            // RestrAmount
            // 
            this.RestrAmount.Location = new System.Drawing.Point(138, 82);
            this.RestrAmount.Name = "RestrAmount";
            this.RestrAmount.ReadOnly = true;
            this.RestrAmount.Size = new System.Drawing.Size(57, 20);
            this.RestrAmount.TabIndex = 10;
            this.RestrAmount.ValueChanged += new System.EventHandler(this.RestrAmount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Количство Переменных";
            // 
            // VariablesAmount
            // 
            this.VariablesAmount.Location = new System.Drawing.Point(138, 56);
            this.VariablesAmount.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.VariablesAmount.Name = "VariablesAmount";
            this.VariablesAmount.ReadOnly = true;
            this.VariablesAmount.Size = new System.Drawing.Size(57, 20);
            this.VariablesAmount.TabIndex = 8;
            this.VariablesAmount.ValueChanged += new System.EventHandler(this.VariablesAmount_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(240, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(785, 347);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(35, 78);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(111, 41);
            this.btnSolve.TabIndex = 14;
            this.btnSolve.Text = "Решать задачу";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.btnSolve);
            this.groupBox1.Location = new System.Drawing.Point(701, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 136);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(35, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(196, 17);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Заданные базисные переменные";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(35, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(180, 17);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Метод искусственного базиса";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // InputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 567);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSve);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RestrAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VariablesAmount);
            this.Controls.Add(this.dataGridView1);
            this.Name = "InputDialog";
            this.Text = "ImputDialog";
            ((System.ComponentModel.ISupportInitialize)(this.RestrAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RestrAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown VariablesAmount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}