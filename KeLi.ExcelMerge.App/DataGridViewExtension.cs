/*
 * MIT License
 *
 * Copyright(c) 2019 KeLi
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

/*
             ,---------------------------------------------------,              ,---------,
        ,----------------------------------------------------------,          ,"        ,"|
      ,"                                                         ,"|        ,"        ,"  |
     +----------------------------------------------------------+  |      ,"        ,"    |
     |  .----------------------------------------------------.  |  |     +---------+      |
     |  | C:\>FILE -INFO                                     |  |  |     | -==----'|      |
     |  |                                                    |  |  |     |         |      |
     |  |                                                    |  |  |/----|`---=    |      |
     |  |              Author: KeLi                          |  |  |     |         |      |
     |  |              Email: kelistudy@163.com              |  |  |     |         |      |
     |  |              Creation Time: 11/24/2019 01:22:04 AM |  |  |     |         |      |
     |  | C:\>_                                              |  |  |     | -==----'|      |
     |  |                                                    |  |  |   ,/|==== ooo |      ;
     |  |                                                    |  |  |  // |(((( [66]|    ,"
     |  `----------------------------------------------------'  |," .;'| |((((     |  ,"
     +----------------------------------------------------------+  ;;  | |         |,"
        /_)_________________________________________________(_/  //'   | +---------+
           ___________________________/___  `,
          /  oooooooooooooooo  .o.  oooo /,   \,"-----------
         / ==ooooooooooooooo==.o.  ooo= //   ,`\--{)B     ,"
        /_==__==========__==_ooo__ooo=_/'   /___________,"
*/

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using KeLi.Power.Drive.Excel;

using OfficeOpenXml;

namespace KeLi.ExcelMerge.App
{
    public static class DataGridViewExtension
    {
        public static void ToDgv<T>(this DataGridView dgv, ExcelParameter param)
        {
            var data = param.AsList<T>();

            dgv.ToDgv(data);
        }

        public static void ToDgv<T>(this DataGridView dgv, List<T> objs)
        {
            if (dgv.ColumnCount == 0)
            {
                for (var i = 0; i < typeof(T).GetProperties().Length; i++)
                {
                    var p = typeof(T).GetProperties()[i];

                    var pDcrp = p.GetDcrp();

                    var column = new DataGridViewTextBoxColumn
                    {
                        Name = p.Name,

                        DataPropertyName = p.Name,

                        HeaderText = pDcrp,

                        FillWeight = GetColumnWeight(pDcrp)
                    };

                    dgv.Columns.Add(column);
                }
            }

            dgv.DataSource = objs;

            dgv.SetDgvStyle();
        }

        public static void ToMergeDgv<TTitle, TModel>(this MergeDataGridView mdgv, ExcelParameter param)
        {
            var data = param.AsList<TModel>();

            mdgv.ToMergeDgv<TTitle, TModel>(data);
        }

        public static void ToMergeDgv<TTitle, TModel>(this MergeDataGridView mdgv, List<TModel> objs)
        {
            if (mdgv.MergeColumnNames == null)
                mdgv.MergeColumnNames = new List<string>();

            if (mdgv.ColumnCount == 0)
            {
                var ps = typeof(TModel).GetProperties();

                foreach (var p in ps)
                {
                    var pDcrp = p.GetDcrp();

                    var column = new DataGridViewTextBoxColumn
                    {
                        Name = p.Name,

                        Tag = p.GetReference(),

                        DataPropertyName = p.Name,

                        HeaderText = pDcrp,

                        FillWeight = GetColumnWeight(pDcrp)
                    };

                    mdgv.Columns.Add(column);

                    mdgv.MergeColumnNames.Add(p.Name);
                }
            }

            mdgv.DataSource = objs;

            mdgv.SetMdgvStyle();

            MergeHeaders<TTitle>(mdgv);

            mdgv.SetCellInfos();
        }

        public static ExcelPackage ToExcel(this DataGridView dgv, ExcelParameter param, bool createHeader = true)
        {
            if (!File.Exists(param.FilePath))
                File.Copy(param.TemplatePath, param.FilePath);

            var excel = param.GetExcelPackage(out var sheet);
            var columns = dgv.Columns.Cast<DataGridViewColumn>().Where(w => w.Visible).ToList();

            if (createHeader)
            {
                // Title row.
                for (var i = 0; i < columns.Count; i++)
                    sheet.Column(i + param.ColumnIndex).Width = GetSheetWidth(columns[i].HeaderText);
            }

            // Content cell.
            for (var i = 0; i < dgv.RowCount; i++)
            {
                for (var j = 0; j < columns.Count; j++)
                {
                    var column = columns[j];

                    // If dgv cell value is null, sheet cell should value.
                    var val = dgv.Rows[i].Cells[column.Name].Value;

                    var tag = dgv.Rows[i].Cells[column.Name].Tag;

                    var isNull = string.IsNullOrWhiteSpace(val?.ToString());

                    sheet.Cells[i + param.RowIndex + 1, j + param.ColumnIndex].Value = isNull ? tag : val;
                }
            }

            sheet.SetExcelStyle();
            excel.Save();

            return excel;
        }

        public static ExcelPackage ToExcel<TTitle>(this MergeDataGridView mdgv, ExcelParameter param, bool createHeader = true)
        {
            if (!File.Exists(param.FilePath))
                File.Copy(param.TemplatePath, param.FilePath);

            var excel = param.GetExcelPackage(out var sheet);

            var columns = mdgv.Columns.Cast<DataGridViewColumn>().Where(w => w.Visible).ToList();

            if (createHeader)
            {
                var lastSum = param.ColumnIndex;

                var ps = typeof(TTitle).GetProperties();

                // Merges first title and sets first title value.
                foreach (var p in ps)
                {
                    var spanNum = p.GetSpan();

                    var columnDcrp = p.GetDcrp();

                    var range = sheet.Cells[param.RowIndex, lastSum, param.RowIndex, lastSum + spanNum - 1];

                    range.Value = columnDcrp;

                    if (string.IsNullOrEmpty(sheet.Cells[param.RowIndex, param.ColumnIndex].Value?.ToString()))
                        sheet.Column(lastSum).Width = GetSheetWidth(columnDcrp);

                    // If the span num equal 1, don't set merge.
                    if (spanNum != 1 && !range.Merge)
                        range.Merge = true;

                    lastSum += spanNum;
                }

                // Merges Second title.
                for (var i = 0; i < columns.Count; i++)
                    sheet.Cells[param.RowIndex + 1, i + param.ColumnIndex].Value = columns[i].HeaderText;

                // Merges title .
                for (var i = 0; i < columns.Count; i++)
                {
                    var cell = sheet.Cells[param.RowIndex, i + param.ColumnIndex];

                    // If merged, continue.
                    if (cell.Merge)
                        continue;

                    // Value not equal, continue.
                    if (cell.Value?.ToString() != sheet.Cells[param.RowIndex + 1, i + param.ColumnIndex].Value?.ToString())
                        continue;

                    // Sets merge.
                    sheet.Cells[param.RowIndex, i + param.ColumnIndex, param.RowIndex + 1, i + param.ColumnIndex].Merge = true;
                }
            }

            // Sets content cell value.
            for (var i = 0; i < mdgv.RowCount; i++)
            {
                for (var j = 0; j < columns.Count; j++)
                    sheet.Cells[i + param.RowIndex + 2, j + param.ColumnIndex].Value = mdgv.Rows[i].Cells[columns[j].Name].Value;
            }

            if (createHeader)
            {
                // Merges content cell.
                for (var i = 0; i < mdgv.ColumnCount; i++)
                {
                    for (var j = 0; j < mdgv.RowCount; j++)
                    {
                        var upRowNum = mdgv.GetUpRowNum(j, i) - 1;

                        var downRowNum = mdgv.GetDownRowNum(j, i) - 1;

                        var cell = sheet.Cells[j + param.RowIndex, i + param.ColumnIndex];

                        var tag = mdgv.Columns[i].Tag?.ToString();

                        if (!string.IsNullOrEmpty(tag))
                        {
                            var tempIndex = mdgv.Columns[tag]?.Index;

                            upRowNum = mdgv.GetUpRowNum(j, tempIndex ?? 0) - 1;

                            downRowNum = mdgv.GetDownRowNum(j, tempIndex ?? 0) - 1;
                        }

                        if (cell.Merge)
                            continue;

                        var range = sheet.Cells[j + param.RowIndex - upRowNum, i + param.ColumnIndex, j + param.RowIndex + downRowNum, i + param.ColumnIndex];

                        if (!range.Merge)
                            range.Merge = true;
                    }
                }
            }

            sheet.SetExcelStyle();

            excel.Save();

            return excel;
        }

        public static void SetDgvStyle(this DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;

            dgv.BorderStyle = BorderStyle.None;

            dgv.AllowUserToAddRows = false;

            dgv.AllowUserToDeleteRows = false;

            dgv.AllowUserToResizeRows = false;

            dgv.AllowUserToResizeColumns = false;

            dgv.RowHeadersVisible = false;

            // Sets two title height
            dgv.ColumnHeadersHeight = 50;

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Sets column middle center.
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Sets cell middle center.
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var totalWidth = dgv.Columns.Cast<DataGridViewColumn>()
                .Where(w => w.Visible).Select(s => s.Width).Sum();

            if (dgv.Width - totalWidth > 5)
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Sets select full row.
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void SetMdgvStyle(this MergeDataGridView mdgv)
        {
            mdgv.SetDgvStyle();

            mdgv.DefaultCellStyle.SelectionBackColor = mdgv.DefaultCellStyle.BackColor;

            mdgv.DefaultCellStyle.SelectionForeColor = mdgv.DefaultCellStyle.ForeColor;
        }

        public static void MergeHeaders<T>(this MergeDataGridView mdgv)
        {
            var lastSum = 0;

            for (var i = 0; i < typeof(T).GetProperties().Length; i++)
            {
                var p = typeof(T).GetProperties()[i];

                var spanNum = p.GetSpan();

                mdgv.AddSpanHeader(p.GetDcrp(), lastSum, spanNum);

                lastSum += spanNum;
            }
        }

        private static int GetColumnWeight(string description)
        {
            var f1 = string.IsNullOrEmpty(description) || description.Length > 10;

            var f2 = description.Length > 6;

            var f3 = description.Length < 4;

            return f1 ? 7 : f2 ? 4 : f3 ? 3 : description.Length;
        }

        private static int GetSheetWidth(string description)
        {
            var f1 = string.IsNullOrEmpty(description) || description.Length > 10;

            var f2 = description.Length > 6;

            var f3 = description.Length < 4;

            return f1 ? 15 : f2 ? 20 : f3 ? 8 : 10;
        }
    }
}