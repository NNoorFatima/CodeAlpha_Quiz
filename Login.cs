using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeALpha_Quiz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Registration.source);
            conn.Open();


            SqlCommand cm;
            string un = textBox1.Text;
        
            string pass = textBox2.Text;
            string query;
            query = "select count (*) from MEMBERS where USERNAME = @ID and PASSWORD = @password";

            cm = new SqlCommand(query, conn);

            cm.Parameters.AddWithValue("@ID", un);
            cm.Parameters.AddWithValue("@password", pass);


            int count = (int)cm.ExecuteScalar();



            if (count > 0)
            {


                Hide();
                using (options form2 = new options())
                    form2.ShowDialog();
                Show();

            }
            else
            {
                MessageBox.Show("Invalid id or password");

            }
        }
    }
}
