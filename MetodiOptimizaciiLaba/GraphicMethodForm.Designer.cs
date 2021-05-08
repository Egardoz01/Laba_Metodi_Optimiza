namespace MetodiOptimizaciiLaba
{
    partial class GraphicMethodForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelRestr1 = new System.Windows.Forms.Label();
            this.panelRestr1 = new System.Windows.Forms.Panel();
            this.lavel1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAllRestrs = new System.Windows.Forms.RadioButton();
            this.rbCommunizm = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Location = new System.Drawing.Point(29, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // LabelRestr1
            // 
            this.LabelRestr1.AutoSize = true;
            this.LabelRestr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRestr1.Location = new System.Drawing.Point(677, 184);
            this.LabelRestr1.Name = "LabelRestr1";
            this.LabelRestr1.Size = new System.Drawing.Size(51, 16);
            this.LabelRestr1.TabIndex = 1;
            this.LabelRestr1.Text = "label1";
            this.LabelRestr1.Click += new System.EventHandler(this.LabelRestr1_Click);
            // 
            // panelRestr1
            // 
            this.panelRestr1.Location = new System.Drawing.Point(656, 184);
            this.panelRestr1.Name = "panelRestr1";
            this.panelRestr1.Size = new System.Drawing.Size(15, 15);
            this.panelRestr1.TabIndex = 2;
            // 
            // lavel1
            // 
            this.lavel1.AutoSize = true;
            this.lavel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lavel1.Location = new System.Drawing.Point(653, 156);
            this.lavel1.Name = "lavel1";
            this.lavel1.Size = new System.Drawing.Size(98, 18);
            this.lavel1.TabIndex = 3;
            this.lavel1.Text = "Ограничения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(652, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Целевая Функция";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunction.Location = new System.Drawing.Point(677, 63);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(83, 16);
            this.lblFunction.TabIndex = 5;
            this.lblFunction.Text = "lblFunction";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Location = new System.Drawing.Point(656, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 15);
            this.panel2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCommunizm);
            this.groupBox1.Controls.Add(this.rbAllRestrs);
            this.groupBox1.Location = new System.Drawing.Point(656, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 39);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rbAllRestrs
            // 
            this.rbAllRestrs.AutoSize = true;
            this.rbAllRestrs.Location = new System.Drawing.Point(7, 16);
            this.rbAllRestrs.Name = "rbAllRestrs";
            this.rbAllRestrs.Size = new System.Drawing.Size(110, 17);
            this.rbAllRestrs.TabIndex = 0;
            this.rbAllRestrs.Text = "все ограничения";
            this.rbAllRestrs.UseVisualStyleBackColor = true;
            this.rbAllRestrs.CheckedChanged += new System.EventHandler(this.rbAllRestrs_CheckedChanged);
            // 
            // rbCommunizm
            // 
            this.rbCommunizm.AutoSize = true;
            this.rbCommunizm.Checked = true;
            this.rbCommunizm.Location = new System.Drawing.Point(123, 16);
            this.rbCommunizm.Name = "rbCommunizm";
            this.rbCommunizm.Size = new System.Drawing.Size(125, 17);
            this.rbCommunizm.TabIndex = 1;
            this.rbCommunizm.TabStop = true;
            this.rbCommunizm.Text = "общее ограничение";
            this.rbCommunizm.UseVisualStyleBackColor = true;
            this.rbCommunizm.CheckedChanged += new System.EventHandler(this.rbAllRestrs_CheckedChanged);
            // 
            // GraphicMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1040, 643);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lavel1);
            this.Controls.Add(this.panelRestr1);
            this.Controls.Add(this.LabelRestr1);
            this.Controls.Add(this.panel1);
            this.Name = "GraphicMethodForm";
            this.Text = "GraphicMethodForm";
            this.Load += new System.EventHandler(this.GraphicMethodForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelRestr1;
        private System.Windows.Forms.Panel panelRestr1;
        private System.Windows.Forms.Label lavel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCommunizm;
        private System.Windows.Forms.RadioButton rbAllRestrs;
    }
}