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
    public partial class ChangePassword : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\soms\Documents\Visual Studio 2010\SE\SE\SE\SE\SE.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
           


            string query = "select * from login where username = '" + textBox3.Text + "' and password = '" + textBox1.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            if (dt1.Rows.Count == 1)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update login set password ='" + textBox2.Text + "' where password ='" + textBox1.Text + "' and username = '" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password Changed.");
            }
            else
            {
                MessageBox.Show("Something Went Wrong");
            }


            con.Close();
            
           

           // MDI m = new MDI();
            //LOGIN lg = new LOGIN();
            this.Hide();
            //m.Hide();
            //lg.Show();
        }
    }
}
