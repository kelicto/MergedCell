namespace KeLi.ExcelMerge.App.Forms
{
    partial class MergeExcelForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvFile1 = new System.Windows.Forms.DataGridView();
            this.dgvFile2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvFile1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvFile2);
            this.splitContainer1.Size = new System.Drawing.Size(767, 715);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvFile1
            // 
            this.dgvFile1.AllowUserToAddRows = false;
            this.dgvFile1.AllowUserToDeleteRows = false;
            this.dgvFile1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFile1.Location = new System.Drawing.Point(0, 0);
            this.dgvFile1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvFile1.Name = "dgvFile1";
            this.dgvFile1.ReadOnly = true;
            this.dgvFile1.RowTemplate.Height = 23;
            this.dgvFile1.Size = new System.Drawing.Size(767, 351);
            this.dgvFile1.TabIndex = 0;
            // 
            // dgvFile2
            // 
            this.dgvFile2.AllowUserToAddRows = false;
            this.dgvFile2.AllowUserToDeleteRows = false;
            this.dgvFile2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFile2.Location = new System.Drawing.Point(0, 0);
            this.dgvFile2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvFile2.Name = "dgvFile2";
            this.dgvFile2.ReadOnly = true;
            this.dgvFile2.RowTemplate.Height = 23;
            this.dgvFile2.Size = new System.Drawing.Size(767, 359);
            this.dgvFile2.TabIndex = 0;
            // 
            // MergeExcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 715);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MergeExcelForm";
            this.Text = "合并测试";
            this.Load += new System.EventHandler(this.MergeForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvFile1;
        private System.Windows.Forms.DataGridView dgvFile2;
    }
}

