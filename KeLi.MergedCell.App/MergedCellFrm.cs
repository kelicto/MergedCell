using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using KeLi.MergedCell.App.Entities;
using KeLi.Power.Tool.Serializations;

namespace KeLi.MergedCell.App
{
    public partial class MergedCellFrm : Form
    {
        public MergedCellFrm()
        {
            InitializeComponent();

            var businessfile = new FileInfo(@"Resources\BusinessData.xml");
            var data = XmlUtil.Deserialize<List<BusinessEntity>>(businessfile);

            mdgvTest.ToMergeDgv<BusinessCategory, BusinessEntity>(data);
        }
    }
}
