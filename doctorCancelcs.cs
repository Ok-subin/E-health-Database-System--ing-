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
    public partial class doctorCancelcs : Form
    {
        string cancel;
        int cancelIdx;

        public doctorCancelcs(string cancelDay)
        {
            InitializeComponent();
            cancel = cancelDay;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();

            string sql = "SELECT dateIndex FROM date_table WHERE day = '";
            sql += cancel;
            sql += "'";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cancelIdx = Convert.ToInt32(cmd.ExecuteScalar());

            connection.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();
            string dt_id = logincs.inputId;

            // 해당 의사 데이터에 대한 index 찾기
            string findQuery = "SELECT Dt_index FROM doctor_table WHERE Dt_date = ";
            findQuery += cancelIdx;
            findQuery += " and Dt_id = '";
            findQuery += dt_id;
            findQuery += "'";
            MySqlCommand cmd2 = new MySqlCommand(findQuery, connection);
            int deleteIdx = Convert.ToInt32(cmd2.ExecuteScalar());

            cmd2.Dispose();
            // 총 의사 데이터 개수 찾기 -> total에 저장
            string totalQuery = "SELECT COUNT(*) FROM doctor_table WHERE Dt_id = '";
            totalQuery += dt_id;
            totalQuery += "'";
            cmd2 = new MySqlCommand(totalQuery, connection);
            int total = Convert.ToInt32(cmd2.ExecuteScalar());            

            cmd2.Dispose();

            // 데이터 삭제
            // 만약 해당 의사에 대한 데이터가 1개라면 --> 아예 삭제가 아닌 index를 0으로 초기화
            // doctorIndex에서 삭제할 필요 X
            if (total == 1)
            {
                string sql = "UPDATE doctor_table SET Dt_date = 0 WHERE Dt_id = '";
                sql += dt_id;
                sql += "'";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("진료일 삭제를 완료했습니다.");
                }
                cmd.Dispose();
            }            

            // 해당 의사에 대한 데이터가 2개 이상이라면 --> 데이터 삭제
            // doctorIndex에서 해당 index 삭제해야 함.
            else
            {
                string sql = "DELETE FROM doctor_table WHERE Dt_date = ";
                sql += cancelIdx;
                sql += " and Dt_id = '";
                sql += dt_id;
                sql += "'";

                MySqlCommand cmd = new MySqlCommand(sql, connection);                

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("진료일 삭제를 완료했습니다.");
                }
                
                cmd.Dispose();
            }
            connection.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
