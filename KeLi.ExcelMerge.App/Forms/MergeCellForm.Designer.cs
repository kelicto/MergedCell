using KeLi.ExcelMerge.App.Components;

namespace KeLi.ExcelMerge.App.Forms
{
    partial class MergeCellForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeCellForm));
            this.mdgvTest = new MergeDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.mdgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // mdgvTest
            // 
            this.mdgvTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdgvTest.Location = new System.Drawing.Point(0, 0);
            this.mdgvTest.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("mdgvTest.MergeColumnNames")));
            this.mdgvTest.Name = "mdgvTest";
            this.mdgvTest.RowTemplate.Height = 23;
            this.mdgvTest.Size = new System.Drawing.Size(1025, 448);
            this.mdgvTest.TabIndex = 0;
            // 
            // MergeCellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 448);
            this.Controls.Add(this.mdgvTest);
            this.Name = "MergeCellForm";
            this.Text = "测试可合并单元格控件";
            ((System.ComponentModel.ISupportInitialize)(this.mdgvTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MergeDataGridView mdgvTest;
    }
}