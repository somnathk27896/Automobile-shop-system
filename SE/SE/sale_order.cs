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
    public partial class sale_order : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\soms\Documents\Visual Studio 2010\SE\SE\SE\SE\SE.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        
        public sale_order()
        {
            InitializeComponent();
            
        }



        public int validation()
        {
            int flag = 0;
            if (textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider1.SetError(textBox2, MessageBox.Show("Opss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }
            else if (textBox3.Text == "")
            {
                textBox3.Focus();
                errorProvider1.SetError(textBox3, MessageBox.Show("Opss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }
            else
                if (textBox5.Text == "")
                {
                    textBox5.Focus();
                    errorProvider1.SetError(textBox5, MessageBox.Show("Opss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    flag = 1;
                }
                else
                    if (textBox6.Text == "")
                    {
                        textBox6.Focus();
                        errorProvider1.SetError(textBox6, MessageBox.Show("Opss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        flag = 1;
                    }
                    else
                        if (textBox7.Text == "")
                        {
                            textBox7.Focus();
                            errorProvider1.SetError(textBox8, MessageBox.Show("Opss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                            flag = 1;
                        }
                        else
                            if (textBox10.Text == "")
                            {
                                textBox10.Focus();
                                errorProvider1.SetError(textBox10, MessageBox.Show("Opss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                                flag = 1;
                            }
                          /*  else
                                if (textBox9.Text == "")
                                {
                                    textBox9.Focus();
                                    errorProvider1.SetError(textBox9, MessageBox.Show("Opss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                                    flag = 1;
                                }
                                else
                                    if (textBox1.Text == "")
                                    {
                                        textBox1.Focus();
                                        errorProvider1.SetError(textBox1, MessageBox.Show("Opss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                                        flag = 1;
                                    }*/
            return flag;

        }



        




        public void diplay_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from sale_order where s_id ='"+textBox11.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }





        private void sale_order_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select isnull (max (cast(i_id as int)),0)+1 from sale_order", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            textBox8.Text = dt.Rows[0][0].ToString();





            SqlDataAdapter sda2 = new SqlDataAdapter("Select isnull (max (cast(s_id as int)),0)+1 from sales", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            textBox11.Text = dt2.Rows[0][0].ToString();

            diplay_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (validation() == 0)
            {
                errorProvider1.Clear();


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into sale_order values ('" + textBox8.Text + "','" + textBox11.Text + "','" + textBox2.Text + "','" + this.dateTimePicker1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox10.Text + "')";
                //cmd.CommandText = "update vehicle set v_quantity = v_quantity - '" + textBox6.Text + "' where v_id = '" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                //cmd.CommandText = "insert into sale_order values ('" + textBox8.Text + "','" + textBox11.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox10.Text + "')";
                cmd1.CommandText = "update vehicle set v_quantity = v_quantity - '" + textBox6.Text + "' where v_id = '" + textBox2.Text + "'";
                cmd1.ExecuteNonQuery();
                con.Close();
              



                MessageBox.Show("Added to cart !");
                diplay_data();
                this.Close();
                sale_order so = new sale_order();
                so.Show();


            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda3 = new SqlDataAdapter("Select sum(total) from sale_order where s_id = '" + textBox11.Text + "'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            textBox1.Text = dt3.Rows[0][0].ToString();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from vehicle where v_id ='" + textBox2.Text + "'";
            cmd.Parameters.AddWithValue("@v_id", textBox2.Text);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["v_id"].ToString();
                textBox3.Text = dr["v_company"].ToString();
                textBox4.Text = dr["v_model"].ToString();
               // textBox5.Text = dr["v_hp"].ToString();
                textBox5.Text = dr["v_color"].ToString();

                textBox7.Text = dr["v_price"].ToString();
                //textBox6.Text = dr["v_quantity"].ToString();
            }
            else
            {
                MessageBox.Show("No Data Found");
            }


            con.Close();
        }



        public void diplay()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from sale_order where s_id = '"+textBox13.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }







        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into sales values ('" + textBox11.Text + "','" + this.dateTimePicker1.Text + "','" + textBox9.Text + "','" + textBox1.Text + "')";
            //cmd.CommandText = "update vehicle set v_quantity = v_quantity - (select quentity from sale_order where s_id = '"+textBox11.Text+"' )";
            
            cmd.ExecuteNonQuery();
            con.Close();

            


           // MessageBox.Show("Order Placed !");
           // this.Close();
            payment p = new payment(textBox11.Text,textBox9.Text,textBox1.Text);
            p.Show();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text))

            textBox10.Text = (Convert.ToDouble(textBox6.Text) * Convert.ToDouble(textBox7.Text)).ToString();


            



        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "update vehicle set v_quantity = v_quantity + (select quentity from sale_order) where i_id = '" + textBox12.Text + "'";
            
            cmd.CommandText = "delete from sale_order where i_id = '" + textBox12.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
              



            
            MessageBox.Show("Item Removed From Cart !");
            diplay_data();
            // this.Close();
            //payment p = new payment(textBox11.Text, textBox9.Text, textBox1.Text);
            //p.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            diplay();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
