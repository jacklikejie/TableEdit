using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableEdit
{
    public class ConfigClass
    {
        private const string FileName = "Param.xml";
        private static ConfigClass s_self;
        private static readonly string FilePath = Environment.CurrentDirectory + "//Configure//";

        [DisplayName("工站名称"), Description("显示在主界面的工站名称"), DataMember]
        public string StationName { get; set; } = "CCS安装工站";

        [DisplayName("设备编号"), Description("显示在主界面的设备编号"), DataMember]
        public int MachineNo { get; set; } = 1;

        [DisplayName("箱体码长度"), Description("箱体二维码的长度"), DataMember]
        public int BoxCodeLength { get; set; }

        [DisplayName("箱盖码长度"), Description("箱盖二维码的长度"), DataMember]
        public int BoxLidCodeLength { get; set; }

        public static void Init()
        {
            try
            {
                s_self = FileHelper.Load<ConfigClass>(FilePath, FileName);
            }
            catch (Exception e)
            {
                s_self = new ConfigClass();
                MessageBox.Show(e.Message);
            }
        }

        public static void Save()
        {
            try
            {
                FileHelper.Save(s_self, FilePath, FileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void Init(string filename)
        {
            try
            {
                s_self = FileHelper.Load<ConfigClass>(FilePath, filename);
            }
            catch (Exception e)
            {
                s_self = new ConfigClass();
                MessageBox.Show(e.Message);
            }
        }

        public static void Save(string filename)
        {
            try
            {
                FileHelper.Save(s_self, FilePath, filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static ConfigClass GetInstance()
        {
            return s_self ?? (s_self = new ConfigClass());
        }
    }

  
}
