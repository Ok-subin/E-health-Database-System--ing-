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
    public partial class user2 : Form
    {
        int[] nextDept = new int[5];

        public user2()
        {
            InitializeComponent();

            // user1에서 구해놨던 진료과별 / 요일별 진료 현황
            for (int i = 0; i < 5; i++)
            {
                nextDept[i] = user1.nextDept[i];
            }

            try
            {
                label3.Text = nextDept[0].ToString();
                label4.Text = nextDept[1].ToString();
                label6.Text = nextDept[2].ToString();
                label5.Text = nextDept[3].ToString();
                label7.Text = nextDept[4].ToString();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void user2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
