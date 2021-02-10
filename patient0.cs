using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_health
{
    public partial class patient0 : Form
    {
        public patient0()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patient1 next = new patient1();
            next.Tag = this;
            next.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            patient3 next = new patient3();
            next.Tag = this;
            next.Show();
            this.Hide();
        }
    }
}
