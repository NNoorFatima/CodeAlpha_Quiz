using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeALpha_Quiz
{
    public partial class options : Form
    {
        public options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (quiz1 form2 = new quiz1())
                form2.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Hide();
            using (quiz2 form2 = new quiz2())
                form2.ShowDialog();
            Show();
        }
    }
}
