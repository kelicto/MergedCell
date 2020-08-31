namespace KeLi.MergedCell.App
{
    partial class MergedCellFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergedCellFrm));
            this.mdgvTest = new KeLi.MergedCell.App.MergedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.mdgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // mdgvTest
            // 
            this.mdgvTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mdgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mdgvTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdgvTest.Location = new System.Drawing.Point(0, 0);
            this.mdgvTest.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("mdgvTest.MergeColumnNames")));
            this.mdgvTest.Name = "mdgvTest";
            this.mdgvTest.RowTemplate.Height = 23;
            this.mdgvTest.Size = new System.Drawing.Size(800, 450);
            this.mdgvTest.TabIndex = 0;
            // 
            // MergedCellFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mdgvTest);
            this.Name = "MergedCellFrm";
            this.Text = "MergedCellFrm";
            ((System.ComponentModel.ISupportInitialize)(this.mdgvTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MergedDataGridView mdgvTest;
    }
}