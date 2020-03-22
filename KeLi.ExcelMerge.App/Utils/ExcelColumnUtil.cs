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
using System.Data;
using System.IO;
using System.Linq;

using KeLi.Common.Converter.Serialization;
using KeLi.Common.Drive.Excel;
using KeLi.ExcelMerge.App.Entities;
using KeLi.ExcelMerge.App.Properties;

namespace KeLi.ExcelMerge.App.Utils
{
    public static class ExcelColumnUtil
    {
        public static void ToExcel(string typeName)
        {
            var baseColumnsFile = new FileInfo(Resources.Json_BaseColumns);

            var baseColumns = JsonUtil.Deserialize<string[]>(baseColumnsFile);

            var baseItemsFile = new FileInfo(Resources.Json_BaseItems);

            var baseItems = JsonUtil.Deserialize<string[]>(baseItemsFile);

            var customColumnFile = new FileInfo(Resources.Json_CustomColumns);

            var customColumns = JsonUtil.Deserialize<string[]>(customColumnFile);

            var customItemsFile = new FileInfo(Resources.Json_CustomItems);

            var customItems = JsonUtil.Deserialize<string[][]>(customItemsFile);

            var templatePath = new FileInfo(Resources.Excel_DefaultTemplate);

            var columnInfo = new ColumnInfo(baseColumns, baseItems, customColumns, customItems);

            var typeTemplate = new FileInfo(typeName + "_" + templatePath.Name);

            var param1 = new ExcelParam(typeTemplate, templatePath);

            param1.BuildTemplate(columnInfo);

            var fileName = Path.GetFileNameWithoutExtension(typeTemplate.FullName);

            var a1File = new FileInfo(fileName + DateTime.Now.ToString("_yyMMddHHmm") + typeTemplate.Extension);

            var param2 = new ExcelParam(a1File, typeTemplate);

            param2.BuildData(columnInfo);
        }

        private static void BuildTemplate(this ExcelParam param, ColumnInfo columnInfo)
        {
            var table = new DataTable();

            foreach (var baseColumn in columnInfo.BaseClumns)
                table.Columns.Add(baseColumn);

            foreach (var dataItem in columnInfo.CustomItems)
            {
                foreach (var customColumn in columnInfo.CustomColumns)
                    table.Columns.Add(dataItem[columnInfo.SkipIndex] + " " + customColumn);
            }

            param.ToExcel(table);
        }

        public static void BuildData(this ExcelParam param, ColumnInfo columnInfo)
        {
            var items = new object[1][];

            var offsetNum = 0;

            var sumLength = 0;

            foreach (var customItem in columnInfo.CustomItems)
                sumLength += customItem.Length;

            var tempItems = new string[sumLength - columnInfo.CustomItems.Length];

            for (var i = 0; i < columnInfo.CustomItems[0].Length; i++)
            {
                for (var j = 0; j < columnInfo.CustomItems[i].Length; j++)
                {
                    var tempIndex = i * columnInfo.CustomItems[i].Length + j - offsetNum;

                    if (j == columnInfo.SkipIndex)
                    {
                        offsetNum += 1;

                        continue;
                    }

                    tempItems[tempIndex] = columnInfo.CustomItems[i][j];
                }
            }

            items[0] = columnInfo.BaseItems.Concat(tempItems).ToArray<object>();

            param.ToExcel(items);
        }
    }
}