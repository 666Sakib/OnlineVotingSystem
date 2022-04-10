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
    public partial class MemberDetails_Employees_ : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public MemberDetails_Employees_()
        {
            InitializeComponent();           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into assistant_data values (@id , @username, @pass)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox3.Text);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a>0)
            {
                MessageBox.Show("Data Inserted Successfully");
            }
            else
            {
                MessageBox.Show("Data not Inserted!");
            }
        }

        private void GetdataFromdatabase()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            try
            {
                string query = "select * from assistant_data";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }
            catch(Exception ex)
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
            if(dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                DialogResult confirm = MessageBox.Show("Are you sure? You want to delete!", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(confirm == DialogResult.Yes)
                {
                    int id;
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    try
                    {
                        string query = "delete from assistant_data where id=@code";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@code", id);
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
                int id, pass; string username;

                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                username = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["username"].Value);
                pass = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["pass"].Value);

                Update_ManageEmployees_ formtwo = new Update_ManageEmployees_(id, username, pass);
                formtwo.ShowDialog();
            }
        }

        private void MemberDetails_Employees__Activated(object sender, EventArgs e)
        {
            GetdataFromdatabase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form6().Show();
        }

        private void MemberDetails_Employees__Load(object sender, EventArgs e)
        {

        }
    }
}
