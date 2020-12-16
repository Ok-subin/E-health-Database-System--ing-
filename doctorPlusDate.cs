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
    public partial class doctorPlusDate : Form
    {
        string dt_id = plusUser.id, dt_pw = plusUser.pw;
        string dt_name;
        int dt_Dept = doctorPlusDept.dt_Dept;

        public static int[] dtDateList = new int[10];

        public doctorPlusDate()
        {
            InitializeComponent();

            // 진료일 list를 0으로 초기화해놓기
            for (int i = 0; i < 10; i++)
            {
                dtDateList[i] = 0;
            }
        }

        /*
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 체크된 요일 list에서 1로 변경
            if (checkBox1.Checked == true)
                dtDateList[0] = 1;
            if (checkBox2.Checked == true)
                dtDateList[2] = 1;
            if (checkBox3.Checked == true)
                dtDateList[6] = 1;
            if (checkBox4.Checked == true)
                dtDateList[4] = 1;
            if (checkBox5.Checked == true)
                dtDateList[8] = 1;
            if (checkBox6.Checked == true)
                dtDateList[9] = 1;
            if (checkBox7.Checked == true)
                dtDateList[7] = 1;
            if (checkBox8.Checked == true)
                dtDateList[5] = 1;
            if (checkBox9.Checked == true)
                dtDateList[3] = 1;
            if (checkBox10.Checked == true)
                dtDateList[1] = 1;

            // 체크된 요일을 date에 추가해주기
            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();

            // doctor table에 추가하기 위해서 doctor 정보 가져오기
            // 의사 이름
            string findDt = "SELECT client_name FROM totaluser_table WHERE client_id = '";
            findDt += dt_id;
            findDt += "'";

            MySqlCommand cmd = new MySqlCommand(findDt, connection);
            dt_name = Convert.ToString(cmd.ExecuteScalar());

            MessageBox.Show("이름 : " + dt_name);
            cmd.Dispose();

            // 의사 주민번호
            findDt = "SELECT client_number FROM totaluser_table WHERE client_id = '";
            findDt += dt_id;
            findDt += "'";

            cmd = new MySqlCommand(findDt, connection);
            string dt_number = Convert.ToString(cmd.ExecuteScalar());
            cmd.Dispose();

            //MessageBox.Show(dtDateList.ToString());

            // doctor table에 추가하기
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                if (dtDateList[i] == 1)
                {
                    // 첫 번째 진료일 추가니까 : plusUser에서 추가한 의사 정보 데이터에 update
                    if (count == 0)
                    {
                        int plusIdx = (i + 1);
                        string sql = "UPDATE doctor_table SET Dt_date = ";
                        sql += plusIdx;
                        sql += " , Dt_department = ";
                        sql += dt_Dept;
                        sql += " WHERE Dt_id = '";
                        sql += dt_id;
                        sql += "'";

                        cmd = new MySqlCommand(sql, connection);

                        //MessageBox.Show(plusIdx.ToString());

                        if (cmd.ExecuteNonQuery() == 1)
                           count++;

                        cmd.Dispose();
                    }

                    // 더 추가할 진료일은 새롭게 테이블에 insert
                    else
                    {
                        MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM doctor_table", connection);
                        int dtIndex = Convert.ToInt32(cmd2.ExecuteScalar()) + 1;

                        int[] doctorIndex = new int[100];
                        for (int x = 0; x < 100; x++)
                        {
                            doctorIndex[x] = 0;
                        }

                        string sqlQuery = "SELECT Dt_index FROM doctor_table";
                        cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader myReader = cmd.ExecuteReader();

                        int count2 = 0;
                        string temp;
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                temp = myReader.GetString(0);
                                doctorIndex[count2] = Convert.ToInt32(temp);
                                count2++;
                            }
                        }

                        myReader.Dispose();
                        cmd.Dispose();
                        cmd2.Dispose();

                        int plusIdx = (i + 1);
                        string sql = "INSERT INTO doctor_table(Dt_id, Dt_pw, Dt_name, Dt_number, Dt_date, Dt_department, Dt_index) VALUES(";
                        sql += "'";
                        sql += dt_id;
                        sql += "' , '";
                        sql += dt_pw;
                        sql += "', '";
                        sql += dt_name;
                        sql += "' , '";
                        sql += dt_number;
                        sql += "' , ";
                        sql += plusIdx;
                        sql += " , ";
                        sql += dt_Dept;
                        sql += " , ";
                        sql += dtIndex;
                        sql += ")";

                        cmd = new MySqlCommand(sql, connection);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            count++;
                        }
                        cmd.Dispose();
                    }                    
                }                   
            }
            MessageBox.Show("총 " + count.ToString() + "개의 진료일이 추가되었습니다.");

            Form1 main = new Form1();
            main.Tag = this;
            main.Show();
            this.Hide();

            connection.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
