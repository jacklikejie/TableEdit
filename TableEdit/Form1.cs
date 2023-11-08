using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            UpdateDgvBarcode();
        }
        private void UpdateDgvBarcode()
        {
            dgvBarcode.Rows.Clear();
            if (dgvBarcode.RowCount > 0)
                dgvBarcode.Rows[dgvBarcode.RowCount - 1].Cells[2].Value = "删除";
            dgvBarcode.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvBarcode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (e.ColumnIndex == 2)
            {
                var row = dgvBarcode.Rows[e.RowIndex];
                if (row.Cells[2].Value.ToString() == "删除")
                {
                    var barcode = (row.Cells[1].Value ?? "").ToString();
                    UpdateDgvBarcode();
                }
            }
            else if (e.ColumnIndex == 3)
            {
                var barcode = (dgvBarcode.Rows[e.RowIndex].Cells[1].Value ?? "").ToString();
            }
            else if (e.ColumnIndex == 4)
            {
                var barcode = (dgvBarcode.Rows[e.RowIndex].Cells[1].Value ?? "").ToString();
            }
        }
    }
}
