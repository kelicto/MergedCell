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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using KeLi.ExcelMerge.App.Entities;

namespace KeLi.ExcelMerge.App
{
    public partial class MergeDataGridView : DataGridView
    {
        public MergeDataGridView()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public List<string> MergeColumnNames { get; set; } = new List<string>();

        private Dictionary<int, SpanInfo> SpanRows { get; } = new Dictionary<int, SpanInfo>();

        private List<CellInfo> CellInfos { get; } = new List<CellInfo>();

        private bool IsLoaded { get; set; }

        private int SumWidth { get; set; }

        private void OnSizeChange(object sender, EventArgs e)
        {
            var sumWidth = Columns.Cast<DataGridViewColumn>().Where(w => w.Visible).Select(s => s.Width).Sum();

            if (SumWidth == 0)
                SumWidth = sumWidth;

            if (Width - sumWidth > 5 && IsLoaded)
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            else if (sumWidth < SumWidth && IsLoaded)
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        public void AddSpanHeader(string headerText, int colIndex, int colCount)
        {
            var rightIndex = colIndex + colCount - 1;

            SpanRows[colIndex] = new SpanInfo(headerText, colIndex, rightIndex);

            SpanRows[rightIndex] = new SpanInfo(headerText, colIndex, rightIndex);

            for (var i = colIndex + 1; i < rightIndex; i++)
                SpanRows[i] = new SpanInfo(headerText, colIndex, rightIndex);
        }

        public void SetCellInfos()
        {
            for (var i = 0; i < ColumnCount; i++)
            {
                for (var j = 0; j < RowCount; j++)
                {
                    var cellInfo = new CellInfo
                    {
                        RowIndex = j,

                        ColumnIndex = i
                    };

                    var cellVal = Rows[j].Cells[i].Value?.ToString();

                    // Compares value from bottom to top.
                    for (var k = j; k >= 0; k--)
                    {
                        var tempVal = Rows[k].Cells[i].Value?.ToString();

                        if (tempVal != cellVal)
                            break;

                        cellInfo.UpRowNum++;
                    }

                    // Compares value from top to bottom.
                    for (var k = j; k < RowCount; k++)
                    {
                        var tempVal = Rows[k].Cells[i].Value?.ToString();

                        if (tempVal != cellVal)
                            break;

                        cellInfo.DownRowNum++;
                    }

                    CellInfos.Add(cellInfo);
                }
            }
        }

        public int GetUpRowNum(int rowIndex, int columnIndex)
        {
            return CellInfos.Where(w => w.RowIndex == rowIndex && w.ColumnIndex <= columnIndex).Select(s => s.UpRowNum).Min();
        }

        public int GetDownRowNum(int rowIndex, int columnIndex)
        {
            return CellInfos.Where(w => w.RowIndex == rowIndex && w.ColumnIndex <= columnIndex).Select(s => s.DownRowNum).Min();
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (!IsLoaded)
                IsLoaded = true;

            // Row title don't override.
            if (e.ColumnIndex < 0)
            {
                base.OnCellPainting(e);

                return;
            }

            // Draws title.
            if (e.RowIndex == -1)
                DrawTitle(e);

            // Draws content.
            else if (e.RowIndex >= 0)
                DrawCell(e);

            e.Handled = true;
        }

        private void DrawTitle(DataGridViewCellPaintingEventArgs e)
        {
            var span = SpanRows[e.ColumnIndex];

            // Declares a grid pen.
            var gridPen = new Pen(GridColor);

            var virtualWidth = GetVirtualWidth(span);

            var image = new Bitmap(virtualWidth, e.CellBounds.Bottom - e.CellBounds.Top);

            var gs = Graphics.FromImage(image);

            gs.Clear(ColumnHeadersDefaultCellStyle.BackColor);

            // Draws right line.
            if (e.ColumnIndex < ColumnCount - 1)
                gs.DrawLine(gridPen, image.Width - 1, 0, image.Width - 1, image.Height);

            // Draws top line.
            gs.DrawLine(gridPen, 0, 0, image.Width, 0);

            // Draws bottom line.
            gs.DrawLine(gridPen, 0, image.Height - 1, image.Width, image.Height - 1);

            // If has not merge item.
            if (span.LeftIndex == span.RightIndex)
            {
                var rect = new Rectangle(0, 0, image.Width, image.Height);

                TextRenderer.DrawText(gs, span.HeaderText, Font, rect, ColumnHeadersDefaultCellStyle.ForeColor);
            }
            else
            {
                var topRect = new Rectangle(-1, 0, image.Width, image.Height / 2);

                TextRenderer.DrawText(gs, span.HeaderText, Font, topRect, ColumnHeadersDefaultCellStyle.ForeColor);

                gs.DrawRectangle(gridPen, topRect);

                var imageDx = -1;

                for (var i = span.LeftIndex; i <= span.RightIndex; i++)
                {
                    var bottomWidth = Columns[i].Width;

                    var bottomRect = new Rectangle(imageDx, image.Height / 2, bottomWidth, image.Height / 2);

                    gs.DrawRectangle(gridPen, bottomRect);

                    TextRenderer.DrawText(gs, Columns[i].HeaderText, Font, bottomRect, ColumnHeadersDefaultCellStyle.ForeColor);

                    imageDx += bottomWidth;
                }
            }

            var offset = GetVirtualOffset(span) - HorizontalScrollingOffset;

            e.Graphics.DrawImage(image, new PointF(offset + 1, e.CellBounds.Top));
        }

        private void DrawCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (!MergeColumnNames.Contains(Columns[e.ColumnIndex].Name))
                return;

            var rect = e.CellBounds;

            var g = e.Graphics;

            var upRowNum = GetUpRowNum(e.RowIndex, e.ColumnIndex);

            var downRowNum = GetDownRowNum(e.RowIndex, e.ColumnIndex);

            var tag = Columns[e.ColumnIndex].Tag.ToString();

            if (!string.IsNullOrEmpty(tag))
            {
                var index = Columns[tag]?.Index;

                upRowNum = GetUpRowNum(e.RowIndex, index ?? 0);

                downRowNum = GetDownRowNum(e.RowIndex, index ?? 0);
            }

            var backBrush = new SolidBrush(e.CellStyle.BackColor);

            // Fills by background color.
            g.FillRectangle(backBrush, rect);

            // Draws string.
            DrawString(e, upRowNum, downRowNum);

            // Declares a grid pen.
            var gridPen = new Pen(GridColor);

            // Draws bottom line.
            if (downRowNum == 1)
                g.DrawLine(gridPen, rect.Left, rect.Bottom - 1, rect.Right, rect.Bottom - 1);

            // Draws right line.
            if (e.ColumnIndex < ColumnCount - 1)
                g.DrawLine(gridPen, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom);
        }

        private static void DrawString(DataGridViewCellPaintingEventArgs e, int upRowNum, int downRowNum)
        {
            var font = e.CellStyle.Font;

            var gs = e.Graphics;

            var brush = new SolidBrush(e.CellStyle.ForeColor);

            var fontH = (int)gs.MeasureString(e.Value?.ToString(), font).Height;

            var fontW = (int)gs.MeasureString(e.Value?.ToString(), font).Width;

            var rectX = e.CellBounds.X;

            var rectY = e.CellBounds.Y;

            var rectH = e.CellBounds.Height;

            var rectW = e.CellBounds.Width - fontW;

            var val = e.Value?.ToString();

            var count = upRowNum + downRowNum - 1;

            switch (e.CellStyle.Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    gs.DrawString(val, font, brush, rectX + rectW / 2, rectY + rectH * downRowNum - fontH);

                    break;

                case DataGridViewContentAlignment.BottomLeft:
                    gs.DrawString(val, font, brush, rectX, rectY + rectH * downRowNum - fontH);

                    break;

                case DataGridViewContentAlignment.BottomRight:
                    gs.DrawString(val, font, brush, rectX + rectW, rectY + rectH * downRowNum - fontH);

                    break;

                case DataGridViewContentAlignment.MiddleCenter:
                    gs.DrawString(val, font, brush, rectX + rectW / 2, rectY - rectH * (upRowNum - 1) + (rectH * count - fontH) / 2);

                    break;

                case DataGridViewContentAlignment.MiddleLeft:
                    gs.DrawString(val, font, brush, rectX, rectY - rectH * (upRowNum - 1) + (rectH * count - fontH) / 2);

                    break;

                case DataGridViewContentAlignment.MiddleRight:
                    gs.DrawString(val, font, brush, rectX + rectW, rectY - rectH * (upRowNum - 1) + (rectH * count - fontH) / 2);

                    break;

                case DataGridViewContentAlignment.TopCenter:
                    gs.DrawString(val, font, brush, rectX + rectW / 2, rectY - rectH * (upRowNum - 1));

                    break;

                case DataGridViewContentAlignment.TopLeft:
                    gs.DrawString(val, font, brush, rectX, rectY - rectH * (upRowNum - 1));

                    break;

                case DataGridViewContentAlignment.TopRight:
                    gs.DrawString(val, font, brush, rectX + rectW, rectY - rectH * (upRowNum - 1));

                    break;

                default:
                    gs.DrawString(val, font, brush, rectX + rectW / 2, rectY - rectH * (upRowNum - 1) + (rectH * count - fontH) / 2);

                    break;
            }
        }

        private int GetVirtualWidth(SpanInfo span)
        {
            var width = 0;

            for (var i = span.LeftIndex; i <= span.RightIndex; i++)
                width += Columns[i].Width;

            return width;
        }

        private int GetVirtualOffset(SpanInfo span)
        {
            var width = 0;

            for (var i = 0; i < span.LeftIndex; i++)
                width += Columns[i].Width;

            return width;
        }
    }
}