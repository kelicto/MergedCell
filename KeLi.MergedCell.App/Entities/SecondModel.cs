using System;
using System.ComponentModel;
using KeLi.Common.Drive.Excel;

namespace KeLi.ExcelMerge.App.Entities
{
    [Description("测试工作表")]
    public class SecondModel
    {
        public SecondModel(params object[] strs)
        {
            if (strs.Length < 14)
                return;

            MainBusinessType = strs[0].ToString();
            ToltalAreaTotal = Convert.ToDouble(strs[1]);
            ToltalAreaEarth = Convert.ToDouble(strs[2]);
            ToltalAreaUnder = Convert.ToDouble(strs[3]);
            LeaseAreaTotal = Convert.ToDouble(strs[4]);
            LeaseAreaEarth = Convert.ToDouble(strs[5]);
            LeaseAreaUnder = Convert.ToDouble(strs[6]);
            ElevatorNumPassenger = Convert.ToInt32(strs[7]);
            ElevatorNumFreight = Convert.ToInt32(strs[8]);
            RoomName = strs[9].ToString();
            JrArea = Convert.ToDouble(strs[10]);
            JrFactor = Convert.ToDouble(strs[11]);
            IsDecorate = Convert.ToBoolean(strs[12]);
            WaterCondition = strs[13].ToString();
        }

        [Description("主数据建筑业态")]
        public object MainBusinessType { get; set; }

        [Description("总面积")]
        public object ToltalAreaTotal { get; set; }

        [Description("地上")]
        public object ToltalAreaEarth { get; set; }

        [Description("地下")]
        public object ToltalAreaUnder { get; set; }

        [Description("总面积")]
        public object LeaseAreaTotal { get; set; }

        [Description("地上")]
        public object LeaseAreaEarth { get; set; }

        [Description("地下")]
        public object LeaseAreaUnder { get; set; }

        [Description("客梯")]
        [Reference("MainBusinessType")]
        public object ElevatorNumPassenger { get; set; }

        [Description("货梯")]
        public object ElevatorNumFreight { get; set; }

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