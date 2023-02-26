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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM Members", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rdsev\\source\\repos\\GitHub\\WinFormsDatabase\\database_members.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int newID = 0;
            con.Open();
            cmd = new SqlCommand("SET IDENTITY_INSERT Members ON", con);
            cmd.ExecuteNonQuery();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string temp = $"INSERT INTO Members(member_id, last_name, first_name, age, city, occupation, salary) VALUES('{i + 1}', '{dataGridView1[1, i].Value}', '{dataGridView1[2, i].Value}', '{dataGridView1[3, i].Value}', '{dataGridView1[4, i].Value}', '{dataGridView1[5, i].Value}', '{dataGridView1[6, i].Value}')";
                cmd = new SqlCommand($"DELETE Members WHERE member_id='{dataGridView1[0, i].Value}'", con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(temp, con);
                cmd.ExecuteNonQuery();
                newID = i + 1;
            }
            cmd = new SqlCommand("SET IDENTITY_INSERT Members OFF", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand($"DBCC CHECKIDENT(Members, RESEED, {newID})", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("IDs Updated Successfully");
            con.Close();
            LoadAgain();
        }

        private void LoadAgain()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM Members", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
