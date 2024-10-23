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

namespace database_connect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionstring = "Data Source=DESKTOP-M561BCP\\;Initial Catalog=mydb;Integrated Security=True";

            string fname = textBox1.Text;
            string fathername = textBox2.Text;


            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();


                    string query = "INSERT INTO Name (name, fathername) VALUES (@Name, @Fname)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", fname);
                        cmd.Parameters.AddWithValue("@Fname", fathername);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Saved");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message);
                }


            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=DESKTOP-M561BCP\\;Initial Catalog=mydb;Integrated Security=True";

            string Nametodelete = textBox3.Text;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();


                    string query = "Delete From Name Where name = @Name";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", Nametodelete);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Delete");
                        }
                        else
                        {

                            MessageBox.Show("No record found with that name.");
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}