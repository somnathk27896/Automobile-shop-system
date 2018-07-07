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
    public partial class PayRpt : Form
    {
        public PayRpt()
        {
            InitializeComponent();
        }

        private void PayRpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet5.payment' table. You can move, or remove it, as needed.
            this.paymentTableAdapter.Fill(this.DataSet5.payment);

            this.reportViewer1.RefreshReport();
        }
    }
}
