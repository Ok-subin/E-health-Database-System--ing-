using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace e_health
{
    public partial class patient2_1 : Form
    {
        string[] dtName = new string[10];
        int selectIdx;
        public static string nextDtName;

        public patient2_1()
        {
            InitializeComponent();

            try
            {
                string query = "select DISTINCT Dt_name from doctor_table where Dt_department = 1";
                MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();

                int count = 0;
                string temp;
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        temp = myReader.GetString(0);
                        comboBox1.Items.Add(temp);
                        dtName[count] = temp;
                        count++;
                    }
                    comboBox1.Items.Add("의료진 상관없음");
                }

                else
                {
                    comboBox1.Items.Add("의료진이 존재하지 않습니다.");
                }
                myReader.Dispose();
                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*private void button5_Click(object sender, EventArgs e)
        {

        }*/

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            selectIdx = cb.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = dtName[selectIdx];

            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();

            nextDtName = name;

            MessageBox.Show(name + " 의료진을 선택하였습니다.");

            string cmdSql = "SELECT Dt_id FROM doctor_table WHERE Dt_name = '";
            cmdSql += name;
            cmdSql += "'";

            MySqlCommand cmd = new MySqlCommand(cmdSql, connection);
            string dtId = Convert.ToString(cmd.ExecuteScalar());

            patient2_1_1 CF = new patient2_1_1(dtId);

            //CF.Owner = this;
            //CF.ShowDialog();

            CF.Tag = this;
            CF.Show();
            this.Hide();

            cmd.Dispose();
            connection.Close();
        }
    }
}
