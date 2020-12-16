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
    public partial class doctorPluscs : Form
    {
        string plus;
        int plusIdx;

        public doctorPluscs(string day)
        {
            plus = day;
            InitializeComponent();

            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();

            string sql = "SELECT dateIndex FROM date_table WHERE day = '";
            sql += plus;
            sql += "'";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            // 추가할 index
            plusIdx = Convert.ToInt32(cmd.ExecuteScalar());

            connection.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();
            string dt_id = logincs.inputId, dt_pw = logincs.inputPw;

            // doctor table에 추가하기 위해서 doctor 정보 가져오기
            // 의사 이름
            string findDt = "SELECT client_name FROM totaluser_table WHERE client_id = '";
            findDt += dt_id;
            findDt += "'";

            MySqlCommand cmd = new MySqlCommand(findDt, connection);
            string dt_name = Convert.ToString(cmd.ExecuteScalar());

            cmd.Dispose();

            // 의사 주민번호
            findDt = "SELECT client_number FROM totaluser_table WHERE client_id = '";
            findDt += dt_id;
            findDt += "'";

            cmd = new MySqlCommand(findDt, connection);
            int dt_number = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.Dispose();

            // 의사 index
            MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM doctor_table", connection);
            int dtIndex = Convert.ToInt32(cmd2.ExecuteScalar()) + 1;

            // Dt_index 중복을 피하기 위해 index 정보 가져오기
            int[] doctorIndex = new int[100];
            for (int x = 0; x < 100; x++)
            {
                doctorIndex[x] = 0;
            }

            string sqlQuery = "SELECT Dt_index FROM doctor_table";
            cmd = new MySqlCommand(sqlQuery, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();

            int count = 0;
            string temp;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temp = myReader.GetString(0);
                    doctorIndex[count] = Convert.ToInt32(temp);
                    count++;
                }
            }

            cmd.Dispose();
            cmd2.Dispose();

            // doctor table에 추가하기
            string sql = "INSERT INTO doctor_table(Dt_id, Dt_pw, Dt_name, Dt_number, Dt_date, Dt_index) VALUES(";
            sql += "'";
            sql += dt_id;
            sql += "' , '";
            sql += dt_pw;
            sql += "', '";
            sql += dt_name;
            sql += "' , ";
            sql += dt_number;
            sql += " , ";
            sql += plusIdx;
            sql += " , ";
            sql += dtIndex;
            sql += ")";

            cmd = new MySqlCommand(sql, connection);

            cmd.Dispose();
            connection.Dispose();

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("진료일 추가를 완료했습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
