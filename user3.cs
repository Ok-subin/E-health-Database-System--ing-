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
    public partial class user3 : Form
    {
       int[] nextDate = new int[5];

        public user3()
        {
            InitializeComponent();

            // user1에서 구해놨던 진료과별 / 요일별 진료 현황
            for (int i = 0; i < 5; i++)
            {
                nextDate[i] = user1.nextDate[i];
            }

            try
            {
                label3.Text = nextDate[0].ToString();
                label4.Text = nextDate[1].ToString();
                label6.Text = nextDate[2].ToString();
                label5.Text = nextDate[3].ToString();
                label7.Text = nextDate[4].ToString();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
