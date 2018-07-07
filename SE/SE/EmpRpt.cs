using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE
{
    public partial class EmpRpt : Form
    {
        public EmpRpt()
        {
            InitializeComponent();
        }

        private void EmpRpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.sale_order' table. You can move, or remove it, as needed.
            this.sale_orderTableAdapter.Fill(this.DataSet1.sale_order);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            this.reportViewer1.RefreshReport();
        }
    }
}
