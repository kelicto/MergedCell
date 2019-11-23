using System.ComponentModel;
using KeLi.Common.Drive.Excel;

namespace KeLi.ExcelMerge.App.Entities
{
    public class BusinessCategory
    {
        public BusinessCategory(params object[] objs)
        {
            if (objs.Length < 9)
                return;

            MainBusinessType = objs[0];
            ToltalArea = objs[1];
            LeaseArea = objs[2];
            ElevatorNum = objs[3];
            RoomName = objs[4];
            JrArea = objs[5];
            JrFactor = objs[6];
            IsDecorate = objs[7];
            WaterCondition = objs[8];
        }

        [Description("主数据建筑业态")]
        public object MainBusinessType { get; set; }

        [Span(3)]
        [Description("总建筑面积")]
        public object ToltalArea { get; set; }

        [Span(3)]
        [Description("可租赁面积")]
        public object LeaseArea { get; set; }

        [Span(2)]
        [Description("电梯数")]
        public object ElevatorNum { get; set; }

        [Description("房间名称")]
        public object RoomName { get; set; }

        [Description("计容建筑面积")]
        public object JrArea { get; set; }

        [Description("计容系数")]
        public object JrFactor { get; set; }

        [Description("是否装修")]
        public object IsDecorate { get; set; }

        [Description("上下水条件")]
        public object WaterCondition { get; set; }
    }
}