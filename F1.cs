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
    public partial class F1 : Form
    {
        public F1()
        {
            InitializeComponent();
        }

        private void baToolStripMenuItem_Click(object sender, EventArgs e)
        { 

            F2 login = new F2();
            if (login.ShowDialog() == DialogResult.OK) 
            {
                baToolStripMenuItem.Enabled = false;
                toolStripMenuItem2.Enabled = true;
                ffToolStripMenuItem.Enabled=true;
                ddToolStripMenuItem.Enabled = true;
                etStudentToolStripMenuItem.Enabled = true;

            }
            else
            {
                baToolStripMenuItem.Enabled = true;
                toolStripMenuItem2.Enabled = false;
                ffToolStripMenuItem.Enabled = false;
                ddToolStripMenuItem.Enabled = false;
                etStudentToolStripMenuItem.Enabled = false;

            }




        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            baToolStripMenuItem.Enabled = true;
            toolStripMenuItem2.Enabled = false;
            ffToolStripMenuItem.Enabled = false;
            ddToolStripMenuItem.Enabled = false;
            etStudentToolStripMenuItem.Enabled = false;
            F2 login = new F2();
            login.Show();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FADD fADD = new FADD();
            fADD.ShowDialog();
        }

        private void ddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FREMO fREMO = new FREMO();
            fREMO.ShowDialog();
        }

        private void etStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEDIT fEDIT = new FEDIT();  
            fEDIT.ShowDialog();
        }

        private void F1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
