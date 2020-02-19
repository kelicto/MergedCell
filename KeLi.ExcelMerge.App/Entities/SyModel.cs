using System.ComponentModel;

namespace KeLi.ExcelMerge.App.Entities
{
    public class SyModel
    {
        [Description("数据唯一编号")]
        public string UniqueCode { get; set; }

        [Description("商业类型")]
        public string BusinessType { get; set; }

        [Description("资产编号")]
        public string PropertyCode { get; set; }

        [Description("项目名称")]
        public string ProjectName { get; set; }
    }
}