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
    public partial class VotersUpdate : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int code;
        string code1;
        public VotersUpdate(int VoterID, string Email)
        {
            InitializeComponent();
            code = VoterID;
            code1 = Email;
        }

        private void VotersUpdate_Load(object sender, EventArgs e)
        {
            textBox3.Text = code.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            code = Convert.ToInt32(textBox3.Text);
            
            
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            try
            {
                string query = "update voter_info set VoterID= @voterid where Email = @email";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@VoterID", code);
                cmd.Parameters.AddWithValue("@Email", code1);


                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data Updated Successful");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data not Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageVoters().Show();
        }
    }
}
