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
            ((System.ComponentModel.ISupportInitialize)(this.SimplexTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SimplexTable
            // 
            this.SimplexTable.AllowUserToAddRows = false;
            this.SimplexTable.AllowUserToDeleteRows = false;
            this.SimplexTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SimplexTable.Location = new System.Drawing.Point(301, 58);
            this.SimplexTable.MultiSelect = false;
            this.SimplexTable.Name = "SimplexTable";
            this.SimplexTable.ReadOnly = true;
            this.SimplexTable.Size = new System.Drawing.Size(714, 398);
            this.SimplexTable.TabIndex = 8;
            this.SimplexTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SimplexTable_CellClick);
            // 
            // SimplexMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 598);
            this.Controls.Add(this.SimplexTable);
            this.Name = "SimplexMethodForm";
            this.Text = "SimplexMethodForm";
            this.Load += new System.EventHandler(this.SimplexMethodForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SimplexTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SimplexTable;
    }
}