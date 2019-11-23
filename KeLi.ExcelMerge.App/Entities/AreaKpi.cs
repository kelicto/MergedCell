using System.ComponentModel;

namespace KeLi.ExcelMerge.App.Entities
{
    public class AreaKpi
    {
        [Description("楼栋号")]
        public string BuildingNo { get; set; }

        [Description("楼层")]
        public string Floor { get; set; }

        [Description("铺")]
        public string ShopName { get; set; }

        [Description("房间名称")]
        public string RoomName { get; set; }

        [Description("龙湖建筑面积(㎡)")]
        public string LongforBuildingArea { get; set; }

        [Description("计容建筑面积")]
        public string JiRongBuildingArea { get; set; }

        [Description("计容系数")]
        public string JiRongFactor { get; set; }

        [Description("地上/地下属性")]
        public string EarthOrUnder { get; set; }

        [Description("是否装修")]
        public string IsDecorate { get; set; }

        [Description("标准主业态")]
        public string MainBusinessType { get; set; }

        [Description("服务对象")]
        public string ServerObject { get; set; }

        [Description("店铺上下水条件")]
        public string ShopSewerage { get; set; }

        [Description("店铺餐饮条件(含排油烟)")]
        public string ShopDining { get; set; }

        [Description("经营属性")]
        public string ManageProperty { get; set; }

        [Description("经营类型")]
        public string ManageType { get; set; }
    }
}