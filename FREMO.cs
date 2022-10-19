using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace management_sstem
{
    public partial class FREMO : Form
    {
        public static System.Data.SqlClient.SqlConnection Connection = new System.Data.SqlClient.SqlConnection();
        public static System.Data.SqlClient.SqlDataAdapter Adapter = new System.Data.SqlClient.SqlDataAdapter();
        public static System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
        public static DataSet DataSet = new DataSet();
        public FREMO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet.Tables["tab"].Clear();
            Connection.Open();
            Adapter = new System.Data.SqlClient.SqlDataAdapter("SELECT *  FROM tab WHERE fullname = '" + listBox1.SelectedItem.ToString() + "'", Connection);
            Adapter.Fill(DataSet, "tab");
            Connection.Close();

            textBox3.Text = DataSet.Tables["tab"].Rows[0].ItemArray[1].ToString();
            textBox5.Text = DataSet.Tables["tab"].Rows[0].ItemArray[2].ToString();
            richTextBox1.Text = DataSet.Tables["tab"].Rows[0].ItemArray[4].ToString();
            textBox4.Text = DataSet.Tables["tab"].Rows[0].ItemArray[5].ToString();
            textBox6.Text = DataSet.Tables["tab"].Rows[0].ItemArray[6].ToString();
            comboBox1.Text = DataSet.Tables["tab"].Rows[0].ItemArray[7].ToString();
            textBox8.Text = DataSet.Tables["tab"].Rows[0].ItemArray[8].ToString();
            dateTimePicker1.Text = DataSet.Tables["tab"].Rows[0].ItemArray[9].ToString();

            if (DataSet.Tables["tab"].Rows[0].ItemArray[10].ToString() == "male")
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }
            textBox9.Text = DataSet.Tables["tab"].Rows[0].ItemArray[11].ToString();
            if (DataSet.Tables["tab"].Rows[0].ItemArray[11].ToString() != "")
            {
                checkBox3.Checked = true;

            }
            else
            {
                checkBox3.Checked = false;
            }
            textBox10.Text = DataSet.Tables["tab"].Rows[0].ItemArray[12].ToString();
            if (DataSet.Tables["tab"].Rows[0].ItemArray[12].ToString() != "")
            {
                checkBox4.Checked = true;

            }
            else
            {
                checkBox4.Checked = false;
            }
            textBox11.Text = DataSet.Tables["tab"].Rows[0].ItemArray[13].ToString();
            if (DataSet.Tables["tab"].Rows[0].ItemArray[13].ToString() != "")
            {
                checkBox5.Checked = true;

            }
            else
            {
                checkBox5.Checked = false;
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text + " " + textBox5.Text;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text + " " + textBox5.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text + " " + textBox5.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.ConnectionString = @"Data Source=LAKSHAN-S-PC\SQLEXPRESS;Initial Catalog=newm;Integrated Security=True";
            Connection.Open();
            Command = new System.Data.SqlClient.SqlCommand("DELETE FROM tab WHERE idno='" + textBox8.Text + "'", Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
            MessageBox.Show("Succsessfuly Deleted !");

            listBox1.Items.Clear();
            listBox1.Refresh();

            if (DataSet.Tables["tab"] != null)
            {
                DataSet.Tables["tab"].Clear();
                

            }
            Connection.ConnectionString = @"Data Source=LAKSHAN-S-PC\SQLEXPRESS;Initial Catalog=newm;Integrated Security=True";
            Connection.Open();
            Adapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tab WHERE fullname like '%" + textBox12.Text + "%'", Connection);
            Adapter.Fill(DataSet, "tab");
            Connection.Close();

            int currentrow = 0;
            int rowcount = DataSet.Tables["tab"].Rows.Count;
            while (currentrow < rowcount)
            {
                listBox1.Items.Add(DataSet.Tables["tab"].Rows[currentrow].ItemArray[3].ToString());
                currentrow++;
            }
            richTextBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox1.Clear();
            comboBox1.Text = "ID Type";
            dateTimePicker1.Value = DateTime.Now;
            radioButton2.Checked = false;
            radioButton1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (DataSet.Tables["tab"] != null)
            {
                DataSet.Tables["tab"].Clear();
                listBox1.Items.Clear();
                listBox1.Refresh();

            }
            Connection.Open();
            Adapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tab WHERE fullname like '%" + textBox12.Text + "%'", Connection);
            Adapter.Fill(DataSet, "tab");
            Connection.Close();

            int currentrow = 0;
            int rowcount = DataSet.Tables["tab"].Rows.Count;
            while (currentrow < rowcount)
            {
                listBox1.Items.Add(DataSet.Tables["tab"].Rows[currentrow].ItemArray[3].ToString());
                currentrow++;
            }
        }

        private void FREMO_Load(object sender, EventArgs e)
        {
            if (DataSet.Tables["tab"] != null)
            {
                DataSet.Tables["tab"].Clear();
            }
            Connection.ConnectionString = @"Data Source=LAKSHAN-S-PC\SQLEXPRESS;Initial Catalog=newm;Integrated Security=True";
            Connection.Open();
            Adapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tab", Connection);
            Adapter.Fill(DataSet, "tab");
            Connection.Close();

            int currentrow = 0;
            int rowcount = DataSet.Tables["tab"].Rows.Count;

            while (currentrow < rowcount)
            {
                listBox1.Items.Add(DataSet.Tables["tab"].Rows[currentrow].ItemArray[3].ToString());
                currentrow++;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
