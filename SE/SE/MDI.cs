using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SE
{
    public partial class MDI : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\soms\Documents\Visual Studio 2010\Projects\SE\SE\SE\SE.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public MDI()
        {
            InitializeComponent();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ChangePassword cp = new ChangePassword();
            cp.Show();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.Show();
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehical_master vm = new Vehical_master();
            vm.Show();
        }

        private void saleOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sale_order sm = new sale_order();
            sm.Show();
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpRpt er = new EmpRpt();
            er.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustRpt cr = new CustRpt();
            cr.Show();
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SORpt sr = new SORpt();
            sr.Show();
        }

        private void paymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayRpt pr = new PayRpt();
            pr.Show();
        }

       
      

    }
}
