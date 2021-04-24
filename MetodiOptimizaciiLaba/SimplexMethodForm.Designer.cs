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
            ((System.ComponentModel.ISupportInitialize)(this.SimplexTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SimplexTable
            // 
            this.SimplexTable.AllowUserToAddRows = false;
            this.SimplexTable.AllowUserToDeleteRows = false;
            this.SimplexTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SimplexTable.Location = new System.Drawing.Point(32, 83);
            this.SimplexTable.MultiSelect = false;
            this.SimplexTable.Name = "SimplexTable";
            this.SimplexTable.ReadOnly = true;
            this.SimplexTable.Size = new System.Drawing.Size(992, 372);
            this.SimplexTable.TabIndex = 8;
            this.SimplexTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SimplexTable_CellClick);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Location = new System.Drawing.Point(561, 516);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(130, 46);
            this.btnNextStep.TabIndex = 9;
            this.btnNextStep.Text = "NextStep";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // btnPrevStep
            // 
            this.btnPrevStep.Location = new System.Drawing.Point(384, 516);
            this.btnPrevStep.Name = "btnPrevStep";
            this.btnPrevStep.Size = new System.Drawing.Size(130, 46);
            this.btnPrevStep.TabIndex = 10;
            this.btnPrevStep.Text = "Prev Step";
            this.btnPrevStep.UseVisualStyleBackColor = true;
            this.btnPrevStep.Click += new System.EventHandler(this.btnPrevStep_Click);
            // 
            // lblCurStep
            // 
            this.lblCurStep.AutoSize = true;
            this.lblCurStep.Location = new System.Drawing.Point(477, 477);
            this.lblCurStep.Name = "lblCurStep";
            this.lblCurStep.Size = new System.Drawing.Size(110, 13);
            this.lblCurStep.TabIndex = 11;
            this.lblCurStep.Text = "Текущий шаг: 0 из 0";
            // 
            // SimplexMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 598);
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
    }
}