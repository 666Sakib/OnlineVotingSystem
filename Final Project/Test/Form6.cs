using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MemberDetails_Employees_().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageVoters().Show();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Settings().Show();
        }
    }
}
