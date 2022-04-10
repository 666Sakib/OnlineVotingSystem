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
    
    public partial class LetsVote : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public LetsVote()
        {
            InitializeComponent();
            BindGridView();
        }

        private void LetsVote_Load(object sender, EventArgs e)
        {

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select Name,Info,Team from candidate_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection cs = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString))
                {
                    if (cs.State == ConnectionState.Closed)
                        cs.Open();
                    using(DataTable dt = new DataTable("candidate_info"))
                    {
                        using (SqlCommand cmd = new SqlCommand("select *from candidate_info where Name =@name", cs))
                        {
                            cmd.Parameters.AddWithValue("Name", string.Format("%{0}%", textBox3.Text));
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            label3.Text = $"Candidate is: {dataGridView1.RowCount}";
                        }
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            MessageBox.Show("Vote Success!!");          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
