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
using System.ComponentModel;

using KeLi.Power.Drive.Excel;

namespace KeLi.MergedCell.App.Entities
{
    [Serializable]
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            MainBusinessType = default;
            ToltalAreaTotal = default;
            ToltalAreaEarth = default;
            ToltalAreaUnder = default;
            LeaseAreaTotal = default;
            LeaseAreaEarth = default;
            LeaseAreaUnder = default;
            ElevatorNumPassenger = default;
            ElevatorNumFreight = default;
            RoomName = default;
            JrArea = default;
            JrFactor = default;
            IsDecorate = default;
            WaterCondition = default;
        }

        public BusinessEntity(params object[] strs)
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