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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.BackColor = System.Drawing.Color.Black;
                label2.ForeColor = System.Drawing.Color.White;
                label3.ForeColor = System.Drawing.Color.White;
                radioButton1.ForeColor = System.Drawing.Color.White;
                radioButton2.ForeColor = System.Drawing.Color.White;
            }
            else if (radioButton2.Checked == true)
            {
                this.BackColor = System.Drawing.Color.White;
                label2.ForeColor = System.Drawing.Color.Black;
                label3.ForeColor = System.Drawing.Color.Black;
                radioButton1.ForeColor = System.Drawing.Color.Black;
                radioButton2.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
