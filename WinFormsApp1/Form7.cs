using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(OnRowHeaderMouseClick);
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * from Members", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rdsev\\source\\repos\\GitHub\\WinFormsDatabase\\database_members.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rdsev\\source\\repos\\GitHub\\WinFormsDatabase\\database_members.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                int temp;
                if (!int.TryParse(textBox3.Text.ToString(), out temp) || !int.TryParse(textBox6.Text.ToString(), out temp))
                {
                    if (!int.TryParse(textBox3.Text.ToString(), out temp))
                    {
                        MessageBox.Show("Age is wrong value!");
                    }
                    if (!int.TryParse(textBox6.Text.ToString(), out temp))
                    {
                        MessageBox.Show("Salary is wrong value!");
                    }
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Members(last_name,first_name,age,city,occupation,salary) VALUES(@last_name,@first_name,@age,@city,@occupation,@salary)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@last_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@first_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@age", textBox3.Text);
                    cmd.Parameters.AddWithValue("@city", textBox4.Text);
                    cmd.Parameters.AddWithValue("@occupation", textBox5.Text);
                    cmd.Parameters.AddWithValue("@salary", textBox6.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Successfully");
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int temp;
                if (!int.TryParse(textBox3.Text.ToString(), out temp) || !int.TryParse(textBox6.Text.ToString(), out temp))
                {
                    if (!int.TryParse(textBox3.Text.ToString(), out temp))
                    {
                        MessageBox.Show("Age is wrong value!");
                    }
                    if (!int.TryParse(textBox6.Text.ToString(), out temp))
                    {
                        MessageBox.Show("Salary is wrong value!");
                    }
                }
                else
                {
                    cmd = new SqlCommand($"UPDATE Members set last_name=@last_name,first_name=@first_name,age=@age,city=@city,occupation=@occupation,salary=@salary WHERE member_id=@member_id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@member_id", dataGridView1.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@last_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@first_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@age", textBox3.Text);
                    cmd.Parameters.AddWithValue("@city", textBox4.Text);
                    cmd.Parameters.AddWithValue("@occupation", textBox5.Text);
                    cmd.Parameters.AddWithValue("@salary", textBox6.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    con.Close();
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                cmd = new SqlCommand($"DELETE Members WHERE member_id=@member_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@member_id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM Members", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void OnRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}


