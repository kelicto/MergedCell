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

using System.ComponentModel;

namespace KeLi.MergedCell.App.Entities
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