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
    public partial class CustRpt : Form
    {
        public CustRpt()
        {
            InitializeComponent();
        }

        private void CustRpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet3.vehicle' table. You can move, or remove it, as needed.
            this.vehicleTableAdapter.Fill(this.DataSet3.vehicle);
            // TODO: This line of code loads data into the 'DataSet2.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.DataSet2.customer);

            this.reportViewer1.RefreshReport();
        }
    }
}
