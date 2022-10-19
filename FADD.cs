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
    public partial class FADD : Form
    {
        public static System.Data.SqlClient.SqlConnection Connection = new System.Data.SqlClient.SqlConnection();  
        public static System.Data.SqlClient.SqlDataAdapter Adapter = new System.Data.SqlClient.SqlDataAdapter();
        public static System.Data.SqlClient.SqlCommand Command  = new System.Data.SqlClient.SqlCommand();
        public static DataSet DataSet = new DataSet();
        
        public FADD()
        {
            InitializeComponent();
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text + " " + textBox5.Text;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox9.Enabled = true;
            }
            else
            {
                textBox9.Enabled = false;
            }
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
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                MessageBox.Show("Your 1st Password does not match with the Second password");
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
                Command.Connection = Connection;
                Command.CommandText = "INSERT INTO  tab VALUES(' " + textBox3.Text + "', '" + textBox5.Text + "', '" + textBox1.Text + " ','"
                       + richTextBox1.Text + "', '" + textBox4.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox8.Text + "','" +
                       dateTimePicker1.Value.ToShortDateString() + "','" + gender + "','" +
                      textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + " ')";
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                MessageBox.Show(" Data has been Saved successfully");

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



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FADD_Load(object sender, EventArgs e)
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
