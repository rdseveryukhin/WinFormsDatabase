using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
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
                    string q = "INSERT INTO Members(last_name, first_name, age, city, occupation, salary)" +
                    $" VALUES('{textBox1.Text.ToString()}', '{textBox2.Text.ToString()}', '{textBox3.Text.ToString()}', '{textBox4.Text.ToString()}', '{textBox5.Text.ToString()}', '{textBox6.Text.ToString()}')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Connection was succesfull!");
                }
            }
            else
            {
                MessageBox.Show("Connection declined!");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        public string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rdsev\\source\\repos\\GitHub\\WinFormsDatabase\\database_members.mdf;Integrated Security=True;Connect Timeout=30";
    }
}
