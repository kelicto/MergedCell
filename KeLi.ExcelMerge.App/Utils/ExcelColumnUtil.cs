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
                foreach (var customColumn in columnInfo.CustomColumns)
                    table.Columns.Add(dataItem[columnInfo.SkipIndex] + " " + customColumn);

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