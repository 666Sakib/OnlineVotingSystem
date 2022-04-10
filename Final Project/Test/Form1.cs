using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Test
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch(status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;

                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex == 0)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from login_tbl where username=@user and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true )
                {
                    MessageBox.Show("Login Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Form6().Show();
                }
                else
                {
                    MessageBox.Show("Login failed", "failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex == 1)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from assistant_data where username=@user and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Form5().Show();
                }
                else
                {
                    MessageBox.Show("Login failed", "failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex == 2)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from candidate_info where VoterID=@user and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Form4().Show();
                }
                else
                {
                    MessageBox.Show("Login failed", "failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex == 3)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from Voter_info where VoterID=@user and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Form7().Show();
                }
                else
                {
                    MessageBox.Show("Login failed", "failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Please fill all fields first", "failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text)==true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill this field first!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please fill this field first!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
                Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
