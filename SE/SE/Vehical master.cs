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
    public partial class Vehical_master : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\soms\Documents\Visual Studio 2010\SE\SE\SE\SE\SE.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        
        public Vehical_master()
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
                    if (textBox6.Text == "")
                    {
                        textBox6.Focus();
                        errorProvider1.SetError(textBox6, MessageBox.Show("PLEASE ENTER DESIGNATION", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        flag = 1;
                    }
                    else
                        if (textBox8.Text == "")
                        {
                            textBox8.Focus();
                            errorProvider1.SetError(textBox8, MessageBox.Show("PLEASE ENTER SALARY", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                            flag = 1;
                        }
                        else
                            if (textBox9.Text == "")
                            {
                                textBox9.Focus();
                                errorProvider1.SetError(textBox9, MessageBox.Show("PLEASE ENTER GENDER", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                                flag = 1;
                            }
            return flag;

        }




        private void Vehical_master_Load(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select isnull (max (cast(v_id as int)),0)+1 from vehicle", con);
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
            cmd.CommandText = "select * from vehicle";
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
                cmd.CommandText = "insert into vehicle values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','"+comboBox1.Text+"''" + textBox6.Text + "','" + textBox8.Text + "','" +textBox9.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                diplay_data();

                MessageBox.Show("Record Inserted Suuccesfully !");
                this.Close();
                Vehical_master vm = new Vehical_master();
                vm.Show();
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
            cmd.CommandText = "delete from vehicle where v_id ='" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            diplay_data();
            //textBox2.Text = "";
           // textBox3.Text = "";

           // textBox5.Text = "";
           // textBox6.Text = "";
       
           // textBox8.Text = "";
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

        private void textBox8_TextChanged(object sender, EventArgs e)
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

        private void textBox9_TextChanged(object sender, EventArgs e)
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
            cmd.CommandText = "select * from vehicle where v_id ='" + textBox7.Text + "'";
            cmd.Parameters.AddWithValue("@v_id", textBox7.Text);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["v_id"].ToString();
                textBox2.Text = dr["v_company"].ToString();
                textBox3.Text = dr["v_model"].ToString();
                textBox5.Text = dr["v_hp"].ToString();
                comboBox1.Text = dr["v_fuel"].ToString();
                textBox6.Text = dr["v_color"].ToString();
              
                textBox8.Text = dr["v_price"].ToString();
                textBox9.Text = dr["v_quantity"].ToString();
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update vehicle set v_id ='" + textBox1.Text + "',v_company = '" + textBox2.Text + "',v_model ='" + textBox3.Text + "',v_hp ='" + textBox5.Text + "',v_fuel = '"+comboBox1.Text+"',v_color='" + textBox6.Text + "',v_price ='" + textBox8.Text + "',v_quantity ='" + textBox9.Text + "' where v_id = '" + textBox7.Text + "'";
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
