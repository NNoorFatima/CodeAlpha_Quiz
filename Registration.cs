using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CodeALpha_Quiz
{
    public partial class Registration : Form
    {
        public static string source="Data Source=FATIMA\\SQLEXPRESS;Initial Catalog=quiz;Integrated Security=True";
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(source);
            conn.Open();
            MessageBox.Show("Connection Open");
            SqlCommand cm;
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string dob = textBox3.Text;
            string email = textBox4.Text;
           
            string query1 = "Insert into Members(Username, Password,DOB,Email) values ('" + un + "','" + pass + "','" + dob + "','" + email + "')";
            cm = new SqlCommand(query1, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
            Hide();
            using (Login form2 = new Login())
                form2.ShowDialog();
            Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (Login form2 = new Login())
                form2.ShowDialog();
            Show();
        }
    }
}
