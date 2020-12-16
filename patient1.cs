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
    public partial class patient1 : Form
    {
        public static int Pt_Dept;

        public patient1()
        {
            InitializeComponent();
        }

        private void patient1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pt_Dept = 1;
            patient2_1 MG = new patient2_1();
            MG.Tag = this;
            MG.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pt_Dept = 2;
            patient2_2 GS = new patient2_2();
            GS.Tag = this;
            GS.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Pt_Dept = 3;
            patient2_3 DT = new patient2_3();
            DT.Tag = this;
            DT.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pt_Dept = 4;
            patient2_4 EY = new patient2_4();
            EY.Tag = this;
            EY.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Pt_Dept = 5;
            patient2_5 ENT = new patient2_5();
            ENT.Tag = this;
            ENT.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
