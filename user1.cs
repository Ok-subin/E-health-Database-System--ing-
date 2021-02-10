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
    public partial class user1 : Form
    {
        public static int[] nextDept = new int[5];
        public static int[] nextDate = new int[5];
        public user1()
        {
            InitializeComponent();

            // 초기화
            for (int i = 0; i < 5; i++)
            {
                nextDept[i] = 0;
                nextDate[i] = 0;
            }

            // 진료 현황에 대한 정보를 보여주기 위해 미리 데이터 찾아서 public으로 저장
            // 진료과별           
            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();
            MySqlCommand cmd;

            // 현황 데이터 가져와서 배열에 저장
            string query;
            int temp;
            for (int i = 0; i < 5; i++)
            {                
                query = "SELECT COUNT(*) FROM history_table WHERE department = ";
                query += (i + 1);
                query += ";";

                cmd = new MySqlCommand(query, connection);

                temp = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Dispose();

                nextDept[i] = temp;
            }

            // 기간별
            string temps;

            // 월요일
            query = "SELECT department FROM history_table WHERE date LIKE '%월요일%';";
            cmd = new MySqlCommand(query, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();

            int count = 0;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temps = myReader.GetString(0);
                    count++;
                }
            }
            nextDate[0] = count;
            cmd.Dispose();
            myReader.Dispose();

            // 화요일
            query = "SELECT department FROM history_table WHERE date LIKE '%화요일%';";
            cmd = new MySqlCommand(query, connection);
            myReader = cmd.ExecuteReader();

            count = 0;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temps = myReader.GetString(0);
                    count++;
                }
            }
            nextDate[1] = count;
            cmd.Dispose();
            myReader.Dispose();

            // 수요일
            query = "SELECT department FROM history_table WHERE date LIKE '%수요일%';";
            cmd = new MySqlCommand(query, connection);
            myReader = cmd.ExecuteReader();

            count = 0;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temps = myReader.GetString(0);
                    count++;
                }
            }
            nextDate[2] = count;
            cmd.Dispose();
            myReader.Dispose();

            // 목요일
            query = "SELECT department FROM history_table WHERE date LIKE '%목요일%';";
            cmd = new MySqlCommand(query, connection);
            myReader = cmd.ExecuteReader();

            count = 0;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temps = myReader.GetString(0);
                    count++;
                }
            }
            nextDate[3] = count;
            cmd.Dispose();
            myReader.Dispose();

            // 금요일
            query = "SELECT department FROM history_table WHERE date LIKE '%금요일%';";
            cmd = new MySqlCommand(query, connection);
            myReader = cmd.ExecuteReader();

            count = 0;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temps = myReader.GetString(0);
                    count++;
                }
            }
            nextDate[4] = count;
            cmd.Dispose();
            myReader.Dispose();

            connection.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user2 dp = new user2();
            dp.Tag = this;
            dp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user3 period = new user3();
            period.Tag = this;
            period.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
