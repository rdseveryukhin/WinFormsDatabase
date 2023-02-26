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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SqlText = "SELECT " + textBox1.Text.ToString() + " FROM Members WHERE " + textBox2.Text.ToString() + " ORDER BY " + textBox3.Text.ToString();

            SqlDataAdapter da = new SqlDataAdapter(SqlText, conString);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Members]");

            dataGridView1.DataSource = ds.Tables["[Members]"].DefaultView;
        }

        public string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rdsev\\source\\repos\\GitHub\\WinFormsDatabase\\database_members.mdf;Integrated Security=True;Connect Timeout=30";

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
