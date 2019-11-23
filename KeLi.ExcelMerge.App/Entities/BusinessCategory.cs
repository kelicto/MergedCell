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