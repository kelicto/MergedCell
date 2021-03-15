namespace KeLi.MergedCell.App.Entities
{
    public class ColumnInfo
    {
        public ColumnInfo(string[] baseClumns, string[] baseItems, string[] customColumns, string[][] customItems)
        {
            BaseClumns = baseClumns;
            BaseItems = baseItems;
            CustomColumns = customColumns;
            CustomItems = customItems;
        }

        public string[] BaseClumns { get; set; }

        public string[] BaseItems { get; set; }

        public string[] CustomColumns { get; set; }

        public string[][] CustomItems { get; set; }

        public int SkipIndex { get; set; }
    }
}