namespace MetodiOptimizaciiLaba
{
    partial class SimplexMethodForm
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
            this.SimplexTable = new System.Windows.Forms.DataGridView();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.btnPrevStep = new System.Windows.Forms.Button();
            this.lblCurStep = new System.Windows.Forms.Label();
            this.lblF = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMakeStepCurrent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SimplexTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SimplexTable
            // 
            this.SimplexTable.AllowUserToAddRows = false;
            this.SimplexTable.AllowUserToDeleteRows = false;
            this.SimplexTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SimplexTable.Location = new System.Drawing.Point(37, 127);
            this.SimplexTable.MultiSelect = false;
            this.SimplexTable.Name = "SimplexTable";
            this.SimplexTable.ReadOnly = true;
            this.SimplexTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SimplexTable.Size = new System.Drawing.Size(988, 364);
            this.SimplexTable.TabIndex = 8;
            this.SimplexTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SimplexTable_CellClick);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Location = new System.Drawing.Point(548, 543);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(108, 46);
            this.btnNextStep.TabIndex = 9;
            this.btnNextStep.Text = "Следующий Шаг";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // btnPrevStep
            // 
            this.btnPrevStep.Location = new System.Drawing.Point(371, 543);
            this.btnPrevStep.Name = "btnPrevStep";
            this.btnPrevStep.Size = new System.Drawing.Size(108, 46);
            this.btnPrevStep.TabIndex = 10;
            this.btnPrevStep.Text = "Педыдущий Шаг";
            this.btnPrevStep.UseVisualStyleBackColor = true;
            this.btnPrevStep.Click += new System.EventHandler(this.btnPrevStep_Click);
            // 
            // lblCurStep
            // 
            this.lblCurStep.AutoSize = true;
            this.lblCurStep.Location = new System.Drawing.Point(480, 508);
            this.lblCurStep.Name = "lblCurStep";
            this.lblCurStep.Size = new System.Drawing.Size(63, 13);
            this.lblCurStep.TabIndex = 11;
            this.lblCurStep.Text = "Шаг: 0 из 0";
            // 
            // lblF
            // 
            this.lblF.AutoSize = true;
            this.lblF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF.Location = new System.Drawing.Point(273, 28);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(52, 18);
            this.lblF.TabIndex = 12;
            this.lblF.Text = "F*(X)=";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(273, 71);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(33, 18);
            this.lblX.TabIndex = 13;
            this.lblX.Text = "X*=";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Location = new System.Drawing.Point(810, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(19, 18);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Aqua;
            this.panel2.Location = new System.Drawing.Point(810, 560);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 18);
            this.panel2.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(835, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "-Возможный опорный элемент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(835, 560);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "-Выбранный опорный элемент";
            // 
            // btnMakeStepCurrent
            // 
            this.btnMakeStepCurrent.Location = new System.Drawing.Point(37, 543);
            this.btnMakeStepCurrent.Name = "btnMakeStepCurrent";
            this.btnMakeStepCurrent.Size = new System.Drawing.Size(108, 46);
            this.btnMakeStepCurrent.TabIndex = 18;
            this.btnMakeStepCurrent.Text = "Сделать данный шаг текущим";
            this.btnMakeStepCurrent.UseVisualStyleBackColor = true;
            this.btnMakeStepCurrent.Click += new System.EventHandler(this.btnMakeStepCurrent_Click);
            // 
            // SimplexMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 620);
            this.Controls.Add(this.btnMakeStepCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.lblCurStep);
            this.Controls.Add(this.btnPrevStep);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.SimplexTable);
            this.Name = "SimplexMethodForm";
            this.Text = "SimplexMethodForm";
            this.Load += new System.EventHandler(this.SimplexMethodForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SimplexTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SimplexTable;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnPrevStep;
        private System.Windows.Forms.Label lblCurStep;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMakeStepCurrent;
    }
}