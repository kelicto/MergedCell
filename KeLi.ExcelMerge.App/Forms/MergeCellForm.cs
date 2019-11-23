using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using KeLi.Common.Converter.Serialization;
using KeLi.ExcelMerge.App.Entities;
using KeLi.ExcelMerge.App.Properties;
using KeLi.ExcelMerge.App.Utils;

namespace KeLi.ExcelMerge.App.Forms
{
    public partial class MergeCellForm : Form
    {
        public MergeCellForm()
        {
            InitializeComponent();
            LoadDgv();

            ExcelColumnUtil.ToExcel("A1");
        }

        public void LoadDgv()
        {
            var businessfile = new FileInfo(Resources.Xml_BusinessEntities);
            var data = XmlUtil.Deserialize<List<BusinessEntity>>(businessfile);

            mdgvTest.ToMergeDgv<BusinessCategory, BusinessEntity>(data);
        }
    }
}