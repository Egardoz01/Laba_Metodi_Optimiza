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
            this.rbSolutionMethod = new System.Windows.Forms.RadioButton();
            this.rbBasisMethod = new System.Windows.Forms.RadioButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cbAutoSteps = new System.Windows.Forms.CheckBox();
            this.rbGraphicMethod = new System.Windows.Forms.RadioButton();
            this.lblExample = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RestrAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(33, 125);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(96, 34);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "Импортировать";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSve
            // 
            this.btnSve.Location = new System.Drawing.Point(147, 125);
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
            this.label2.Location = new System.Drawing.Point(30, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Количство Ограничений";
            // 
            // RestrAmount
            // 
            this.RestrAmount.Location = new System.Drawing.Point(164, 82);
            this.RestrAmount.Name = "RestrAmount";
            this.RestrAmount.ReadOnly = true;
            this.RestrAmount.Size = new System.Drawing.Size(57, 20);
            this.RestrAmount.TabIndex = 10;
            this.RestrAmount.ValueChanged += new System.EventHandler(this.RestrAmount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Количство Переменных";
            // 
            // VariablesAmount
            // 
            this.VariablesAmount.Location = new System.Drawing.Point(164, 56);
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
            this.dataGridView1.Location = new System.Drawing.Point(311, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(848, 347);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.Location = new System.Drawing.Point(61, 132);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(111, 41);
            this.btnSolve.TabIndex = 14;
            this.btnSolve.Text = "Решать задачу";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbGraphicMethod);
            this.groupBox1.Controls.Add(this.cbAutoSteps);
            this.groupBox1.Controls.Add(this.btnSolve);
            this.groupBox1.Controls.Add(this.rbSolutionMethod);
            this.groupBox1.Controls.Add(this.rbBasisMethod);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 179);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Как решать";
            // 
            // rbSolutionMethod
            // 
            this.rbSolutionMethod.AutoSize = true;
            this.rbSolutionMethod.Checked = true;
            this.rbSolutionMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSolutionMethod.Location = new System.Drawing.Point(28, 44);
            this.rbSolutionMethod.Name = "rbSolutionMethod";
            this.rbSolutionMethod.Size = new System.Drawing.Size(196, 17);
            this.rbSolutionMethod.TabIndex = 16;
            this.rbSolutionMethod.Text = "Заданные базисные переменные";
            this.rbSolutionMethod.UseVisualStyleBackColor = true;
            this.rbSolutionMethod.CheckedChanged += new System.EventHandler(this.BasicSolutionRadioButton_CheckedChanged);
            // 
            // rbBasisMethod
            // 
            this.rbBasisMethod.AutoSize = true;
            this.rbBasisMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBasisMethod.Location = new System.Drawing.Point(28, 21);
            this.rbBasisMethod.Name = "rbBasisMethod";
            this.rbBasisMethod.Size = new System.Drawing.Size(180, 17);
            this.rbBasisMethod.TabIndex = 15;
            this.rbBasisMethod.Text = "Метод искусственного базиса";
            this.rbBasisMethod.UseVisualStyleBackColor = true;
            this.rbBasisMethod.CheckedChanged += new System.EventHandler(this.BasicSolutionRadioButton_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(311, 402);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(848, 79);
            this.dataGridView2.TabIndex = 16;
            // 
            // cbAutoSteps
            // 
            this.cbAutoSteps.AutoSize = true;
            this.cbAutoSteps.Location = new System.Drawing.Point(28, 90);
            this.cbAutoSteps.Name = "cbAutoSteps";
            this.cbAutoSteps.Size = new System.Drawing.Size(179, 20);
            this.cbAutoSteps.TabIndex = 17;
            this.cbAutoSteps.Text = "Решать автоматически";
            this.cbAutoSteps.UseVisualStyleBackColor = true;
            this.cbAutoSteps.CheckedChanged += new System.EventHandler(this.cbAutoSteps_CheckedChanged);
            // 
            // rbGraphicMethod
            // 
            this.rbGraphicMethod.AutoSize = true;
            this.rbGraphicMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGraphicMethod.Location = new System.Drawing.Point(29, 67);
            this.rbGraphicMethod.Name = "rbGraphicMethod";
            this.rbGraphicMethod.Size = new System.Drawing.Size(125, 17);
            this.rbGraphicMethod.TabIndex = 18;
            this.rbGraphicMethod.Text = "графический метод";
            this.rbGraphicMethod.UseVisualStyleBackColor = true;
            this.rbGraphicMethod.CheckedChanged += new System.EventHandler(this.BasicSolutionRadioButton_CheckedChanged);
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExample.Location = new System.Drawing.Point(9, 194);
            this.lblExample.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(289, 140);
            this.lblExample.TabIndex = 17;
            this.lblExample.Text = "A11*X1 + A12*X2 +... +A1n*Xn <= b1\r\n\r\nA21*X1 + A22*X2 +... +A2n*Xn <= b2\r\n\r\n     " +
    "                           . . .\r\n\r\nAm1*X1 + Am2*X2 +... +Amn*Xn <= bm\r\n";
            // 
            // InputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 567);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSve);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RestrAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VariablesAmount);
            this.Controls.Add(this.dataGridView1);
            this.Name = "InputDialog";
            this.Text = "InputDialog";
            ((System.ComponentModel.ISupportInitialize)(this.RestrAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.RadioButton rbSolutionMethod;
        private System.Windows.Forms.RadioButton rbBasisMethod;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox cbAutoSteps;
        private System.Windows.Forms.RadioButton rbGraphicMethod;
        private System.Windows.Forms.Label lblExample;
    }
}