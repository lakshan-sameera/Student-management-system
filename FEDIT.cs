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
    public partial class FEDIT : Form
    {
        public static System.Data.SqlClient.SqlConnection Connection = new System.Data.SqlClient.SqlConnection();
        public static System.Data.SqlClient.SqlDataAdapter Adapter = new System.Data.SqlClient.SqlDataAdapter();
        public static System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
        public static DataSet DataSet = new DataSet();
        
        public FEDIT()
        {
            InitializeComponent();
        }

        private void FEDIT_Load(object sender, EventArgs e)
        {
            Connection.ConnectionString = @"Data Source=LAKSHAN-S-PC\SQLEXPRESS;Initial Catalog=newm;Integrated Security=True";
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox3.Checked == true)
                {
                    textBox9.Enabled = true;
                }
                else
                {
                    textBox9.Enabled = false;
                    textBox9.Clear();
                }
            }
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
            if (textBox3.Text == null || textBox5.Text == null || richTextBox1.Text == null || textBox4.Text == null || textBox6.Text == null || comboBox1.Text == "ID Type"
                   || textBox8.Text == null || dateTimePicker1.Value == DateTime.Now ||
                  textBox9.Text == null || textBox10.Text == null || textBox11.Text == null)
            {
                MessageBox.Show("Please fill the all  fields");
                return;
            }
            else if (radioButton2.Checked == false && radioButton1.Checked == false)
            {
                MessageBox.Show("Please Select Your gender");
                return;
            }
            else if (textBox6.Text != textBox7.Text)
            {
                MessageBox.Show("Your 1st Password does not match with the second password");
                return;
            }
            else
            {
                string gender = "";
                if (radioButton1.Checked)
                {
                    gender = "Female";

                }
                else
                {
                    gender = "Male";
                }
                Connection.ConnectionString = @"Data Source=LAKSHAN-S-PC\SQLEXPRESS;Initial Catalog=newm;Integrated Security=True";
                Command.Connection = Connection ;
                Command.CommandText = "UPDATE  tab SET fname= '" + textBox3.Text + "', lname='" + textBox5.Text + "', fullname='" + textBox1.Text + " ',address='"
                      + richTextBox1.Text + "',username= '" + textBox4.Text + "',password='" + textBox6.Text + "',idtype='" + comboBox1.Text + "',idno='" + textBox8.Text + "',dob='" +
                      dateTimePicker1.Value.ToShortDateString() + "',gender='" + gender + "',mob='" +
                     textBox9.Text + "',home='" + textBox10.Text + "',office='" + textBox11.Text + "'WHERE idno='"+ textBox8.Text + "'";
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                MessageBox.Show(" Data has been Update successfully");

                listBox1.Items.Clear();
                listBox1.Refresh();
                
                if(DataSet.Tables["tab"] != null)
                {
                    DataSet.Tables["tab"].Clear();
                }
                Connection.ConnectionString = @"Data Source=LAKSHAN-S-PC\SQLEXPRESS;Initial Catalog=newm;Integrated Security=True";
                Connection.Open ();
                Adapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM tab", Connection);
                Adapter.Fill(DataSet, "tab");
                Connection.Close ();

                int currentrow = 0;
                int rowcount = DataSet.Tables["tab"].Rows.Count;

                while(currentrow < rowcount)
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

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox10.Enabled = true;
            }
            else
            {
                textBox10.Enabled = false;
                textBox10.Clear();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox11.Enabled = true;
            }
            else
            {
                textBox11.Enabled = false;
                textBox11.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if(DataSet.Tables["tab"] != null)
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
            while(currentrow < rowcount)
            {
                listBox1.Items.Add(DataSet.Tables["tab"].Rows[currentrow].ItemArray[3].ToString());
                currentrow++;
            }




        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }
    }
}
