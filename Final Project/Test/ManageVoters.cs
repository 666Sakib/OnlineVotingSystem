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
    public partial class ManageVoters : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ManageVoters()
        {
            InitializeComponent();
        }

        private void ManageVoters_Load(object sender, EventArgs e)
        {

        }
        private void GetdataFromdatabase()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            try
            {
                string query = "SELECT VoterID, PhoneNumber, EMail FROM Voter_info";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                DialogResult confirm = MessageBox.Show("Are you sure? You want to delete!", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    int VoterID;
                    VoterID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VoterID"].Value);

                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    try
                    {
                        string query = "delete from Voter_info where VoterID=@code";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@code", VoterID);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Data Deleted Successful");
                        }
                        else
                        {
                            MessageBox.Show("Data not Deleted");
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

            }

            //code for update
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Update")
            {
                int VoterID; string Email;
                VoterID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VoterID"].Value);
                Email = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Email"].Value);


                VotersUpdate formtwo = new VotersUpdate(VoterID,Email);
                formtwo.ShowDialog();
            }
        }

        private void ManageVoters_Activated(object sender, EventArgs e)
        {
            GetdataFromdatabase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
