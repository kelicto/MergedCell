using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeLi.Common.Drive.Excel;
using KeLi.ExcelMerge.App.Entities;
using KeLi.ExcelMerge.App.Utils;

namespace KeLi.ExcelMerge.App.Forms
{
    /// <summary>
    /// 合并Excel窗体
    /// </summary>
    public partial class MergeExcelForm : Form
    {
        /// <summary>
        /// Test1
        /// </summary>
        private const string TEST1 = @"E:\My Unfiled\Test1.xlsx";

        /// <summary>
        /// Test2
        /// </summary>
        private const string TEST2 = @"E:\My Unfiled\Test2.xlsx";

        /// <summary>
        /// Test3
        /// </summary>
        private const string TEST3 = @"E:\My Unfiled\Test3.xlsx";

        /// <summary>
        /// 默认模板路径
        /// </summary>
        public const string DEF_TEMPLATE_PATH = "Template.xlsx";

        /// <summary>
        /// 数据容器
        /// </summary>
        private readonly List<AreaKpi> _spaces = new List<AreaKpi>();

        /// <summary>
        /// 初始化
        /// </summary>
        public MergeExcelForm()
        {
            InitializeComponent();

            var param1 = new ExcelParam(TEST1, DEF_TEMPLATE_PATH);

            dgvFile1.ImportDgv<AreaKpi>(param1);
            _spaces.AddRange(param1.AsList<AreaKpi>());

            var param2 = new ExcelParam(TEST2, DEF_TEMPLATE_PATH);

            dgvFile2.ImportDgv<AreaKpi>(param2);
            _spaces.AddRange(param2.AsList<AreaKpi>());
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MergeForm_Load(object sender, EventArgs e)
        {
            dgvFile1.ClearSelection();
            dgvFile2.ClearSelection();

            var param3 = new ExcelParam(TEST3, DEF_TEMPLATE_PATH);

            param3.ToExcel(_spaces);
        }
    }
}