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
    public partial class manager2 : Form
    {
        string[] client_name = new string[10];
        string[] client_id = new string[10];
        string[] client_number = new string[10];

        public manager2()
        {
            InitializeComponent();


            // 사용자 이름 찾기
            string query = "select client_name from totaluser_table where client_mode = 1";
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
                    client_name[count] = temp;
                    count++;
                }
            }

            myReader.Dispose();
            cmd.Dispose();


            // 사용자 아이디 찾기
            query = "select client_id from totaluser_table where client_mode = 1";
            cmd = new MySqlCommand(query, connection);
            myReader = cmd.ExecuteReader();

            count = 0;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temp = myReader.GetString(0);
                    client_id[count] = temp;
                    count++;
                }
            }

            myReader.Dispose();
            cmd.Dispose();

            // 사용자 주민등록번호 찾기
            query = "select client_id from totaluser_table where client_mode = 1";
            cmd = new MySqlCommand(query, connection);
            myReader = cmd.ExecuteReader();

            count = 0;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temp = myReader.GetString(0);
                    client_number[count] = temp;
                    count++;
                }
            }

            else
            {
                label18.Text = "일반 사용자가 존재하지 않습니다.";
            }

            myReader.Dispose();
            cmd.Dispose();

            // 사용자가 존재하면 - 일반 사용자 3명으로 지정
            string temp1, temp2, temp3;

            for (int j = 0; j < count; j++)
            {
                temp1 = client_name[j];
                temp2 = client_id[j];
                temp3 = client_number[j];

                if (j == 0)
                {
                    label6.Text = temp1;
                    label7.Text = temp3;
                    label8.Text = temp2;
                }

                else if (j == 1)
                {
                    label11.Text = temp1;
                    label10.Text = temp3;
                    label9.Text = temp2;
                }

                else
                {
                    label17.Text = temp1;
                    label16.Text = temp3;
                    label15.Text = temp2;
                }

            }

            connection.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tempId = client_id[2];

            string query = "DELETE FROM user_table WHERE user_id = ";
            query += tempId;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            MySqlCommand cmd = new MySqlCommand(query, connection);
            connection.Open();


            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("사용자 정보 삭제를 완료했습니다.");
            }

            cmd.Dispose();
            connection.Dispose();
        }

        private void manager2_Load(object sender, EventArgs e)
        {

        }
    }
}
