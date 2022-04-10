using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Test
{
    public partial class Update_ManageEmployees_ : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string firstname; int code , old;
        public Update_ManageEmployees_(int id, string username, int pass)
        {
            InitializeComponent();

            code = id;
            firstname = username;
            old = pass;
            
        }

        private void Update_ManageEmployees__Load(object sender, EventArgs e)
        {   
            textBox3.Text = code.ToString();
            textBox1.Text = firstname;
            textBox2.Text = old.ToString();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            code = Convert.ToInt32(textBox3.Text);
            firstname = textBox1.Text;
            old = Convert.ToInt32(textBox2.Text);
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            try
            {
                string query = "update assistant_data set username = @name, pass = @pass where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", code);
                cmd.Parameters.AddWithValue("@name", firstname);
                cmd.Parameters.AddWithValue("@pass", old);
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
    }
}
