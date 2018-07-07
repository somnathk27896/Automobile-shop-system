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
    public partial class SORpt : Form
    {
        public SORpt()
        {
            InitializeComponent();
        }

        private void SORpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet4.sale_order' table. You can move, or remove it, as needed.
            this.sale_orderTableAdapter.Fill(this.DataSet4.sale_order);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.Parse(dateTimePicker1.Value.Date.ToShortDateString());
            DateTime toDate = DateTime.Parse(dateTimePicker2.Value.Date.ToShortDateString());
            this.sale_orderTableAdapter.FillBy(this.DataSet4.sale_order, fromDate, toDate);
           

            this.reportViewer1.RefreshReport();
        }
    }
}
