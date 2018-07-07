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
    public partial class Customer : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\soms\Documents\Visual Studio 2010\SE\SE\SE\SE\SE.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        
        public Customer()
        {
            InitializeComponent();
        }



        public int validation()
        {
            int flag = 0;
            if (textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider1.SetError(textBox2, MessageBox.Show("PLEASE ENTER YOUR NAME", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }
            else if (textBox3.Text == "")
            {
                textBox3.Focus();
                errorProvider1.SetError(textBox3, MessageBox.Show("PLEASE ENTER YOUR Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }
            else
                if (textBox5.Text == "")
                {
                    textBox5.Focus();
                    errorProvider1.SetError(textBox5, MessageBox.Show("PLEASE ENTER CONTACT NUMBER", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    flag = 1;
                }
                else
                    
                        if (textBox8.Text == "")
                        {
                            textBox8.Focus();
                            errorProvider1.SetError(textBox8, MessageBox.Show("PLEASE ENTER SALARY", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                            flag = 1;
                        }
                        
                            
            return flag;

        }

        
       



       

        private void Customer_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select isnull (max (cast(c_id as int)),0)+1 from customer", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            textBox1.Text = dt.Rows[0][0].ToString();

            diplay_data();

        }



        public void diplay_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customer";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (validation() == 0)
            {
                errorProvider1.Clear();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into customer values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox8.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                diplay_data();

                MessageBox.Show("Record Inserted Suuccesfully !");
                this.Close();
                Customer cust = new Customer();
                cust.Show();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from customer where c_id ='" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            diplay_data();
            //textBox2.Text = "";
            //textBox3.Text = "";

            //textBox5.Text = "";
            
            //textBox8.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string pattern = "[0-9]";
            if (Regex.IsMatch(textBox5.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {

                errorProvider1.SetError(this.textBox5, "ONLY NUMBERS ARE ALLOWD..!");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customer where c_id ='" + textBox7.Text + "'";
            cmd.Parameters.AddWithValue("@c_id", textBox7.Text);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["c_id"].ToString();
                textBox2.Text = dr["c_name"].ToString();
                textBox3.Text = dr["c_addr"].ToString();

                textBox5.Text = dr["c_no"].ToString();
                textBox8.Text = dr["c_email"].ToString();
            }
            else
            {
                MessageBox.Show("No Data Found");
            }


            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update customer set c_id ='" + textBox1.Text + "',c_name = '" + textBox2.Text + "',c_addr='" + textBox3.Text + "',c_no ='" + textBox5.Text + "',c_email ='" + textBox8.Text + "' where c_id = '" + textBox7.Text + "'";
            //cmd.Parameters.AddWithValue("@emp_id", textBox7.Text);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlDataReader dr = cmd.ExecuteReader();
            MessageBox.Show("UPDATE SUCCESS");

            con.Close();
            diplay_data();
        }



    }
}
