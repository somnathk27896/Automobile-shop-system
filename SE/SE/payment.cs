using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SE
{
    public partial class payment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\soms\Documents\Visual Studio 2010\SE\SE\SE\SE\SE.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        String Type;
        public payment(string sid, string cid, string pamt)
        {
            InitializeComponent();
            textBox2.Text= sid;
            textBox3.Text= cid;
            textBox4.Text= pamt;
        }


        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Type = "Cash";
            if (radioButton1.Checked)
            {
                groupBox1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Type = "cheque";
            if (radioButton2.Checked)
            {
                groupBox1.Visible = true;
            }

        }

        private void payment_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select isnull (max (cast(pay_id as int)),0)+1 from payment", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            textBox1.Text = dt.Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into payment values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Type + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
           

            MessageBox.Show("Payment Saved Suuccesfully !");
            //this.Close();


            recipte rcpt = new recipte();
            this.Hide();
            rcpt.label1.Text = textBox1.Text.ToString();
            rcpt.label2.Text = textBox2.Text.ToString();
            rcpt.label3.Text = textBox3.Text.ToString();
            rcpt.label4.Text = textBox4.Text.ToString();
            rcpt.Show();  
        }


            

    }
}
