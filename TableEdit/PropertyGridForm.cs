using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableEdit
{
    public partial class PropertyGridForm : Form
    {
        public PropertyGridForm()
        {
            InitializeComponent();
            ConfigClass.Init();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave.Enabled = false;
                ConfigClass.Save();
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                btnsave.Enabled = true;
            }
        }

        private void PropertyGridForm_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = ConfigClass.GetInstance();
        }

        private void btnfresh_Click(object sender, EventArgs e)
        {
            ConfigClass.Init();
            propertyGrid.SelectedObject = ConfigClass.GetInstance();
        }
    }
}
