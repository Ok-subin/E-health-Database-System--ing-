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
    public partial class plusUser : Form
    {
        public int state; // 사용자 모드 (1.일반 사용자, 2.환자, 3.의료진, 4.관리자)
        public static string name, id, pw;
        public int userNum1, userNum2;

        public plusUser()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                state = 1;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                state = 2;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                state = 3;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            userNum1 = Convert.ToInt32(textBox2.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            userNum2 = Convert.ToInt32(textBox5.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            id = textBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            pw = textBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputData, inputMgdata;
            //Application.Exit();           

            switch (state)
            {
                case 1:  // 일반 사용자
                    MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
                    connection.Open();

                    // user table에 정보 입력
                    inputData = "'" + name + "' , " + userNum1.ToString() + userNum2.ToString() + " , '" + id + "' , '" + pw + "')";
                    string insert = "INSERT INTO user_table(user_name,user_number, user_id, user_pw) VALUES(";
                    insert += inputData;
                    MySqlCommand command = new MySqlCommand(insert, connection);

                    // totaluser table에 정보 입력 (pw 제외)
                    string mgInsert = "INSERT INTO totaluser_table(client_mode, client_name, client_number, client_id) VALUES(";
                    inputMgdata = "1, '" + name + "' , " + userNum1.ToString() + userNum2.ToString() + " , '" + id + "')";
                    mgInsert += inputMgdata;
                    MySqlCommand command2 = new MySqlCommand(mgInsert, connection);                        


                    if (command.ExecuteNonQuery() == 1 && command2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("가입 완료!\n회원가입을 축하드립니다.");
                    }
                    connection.Close();
                 
                    break;

                case 2:  // 환자
                    connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
                    connection.Open();

                    // patient table에 정보 입력
                    inputData = "'" + name + "' , " + userNum1.ToString() + userNum2.ToString() + " , '" + id + "' , '" + pw + "')";
                    insert = "INSERT INTO patient_table(Pt_name, Pt_number, Pt_id, Pt_pw) VALUES(";
                    insert += inputData;
                    command = new MySqlCommand(insert, connection);

                    // totaluser table에 정보 입력 (pw 제외)
                    mgInsert = "INSERT INTO totaluser_table(client_mode, client_name, client_number, client_id) VALUES(";
                    inputMgdata = "2 , '" + name + "' , " + userNum1.ToString() + userNum2.ToString() + " , '" + id + "')";
                    mgInsert += inputMgdata;
                    command2 = new MySqlCommand(mgInsert, connection);

                    if (command.ExecuteNonQuery() == 1 && command2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("가입 완료!\n회원가입을 축하드립니다.");
                    }
                    connection.Close();

                    break;

                case 3:  // 의료진                
                    connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
                    connection.Open();

                    // index를 추가하기 위해 총 ROW 개수 확인
                    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM doctor_table", connection);
                    int totalNum = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    cmd.Dispose();

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

                    myReader.Dispose();


                    // 비어있는 index가 존재하면 그 index로 설정 + 겹치는지 확인
                    int dtIndex = totalNum;
                    for (int x = 1; x < totalNum; x++)
                    {
                        if (doctorIndex.Contains(x))
                        {
                            continue;
                        }

                        else
                        {
                            dtIndex = x;
                            break;
                        }
                    }

                    // doctor table에 추가
                    inputData = "'" + name + "' , " + userNum1.ToString() + userNum2.ToString() + " , '" + id + "' , '" + pw + "', " + dtIndex.ToString() + ")";
                    insert = "INSERT INTO doctor_table(Dt_name, Dt_number, Dt_id, Dt_pw, Dt_index) VALUES(";
                    insert += inputData;
                    command = new MySqlCommand(insert, connection);

                    // totaluser table에 추가
                    mgInsert = "INSERT INTO totaluser_table(client_mode, client_name, client_number, client_id) VALUES(";
                    inputMgdata = "3 , '" + name + "' , " + userNum1.ToString() + userNum2.ToString() + " , '" + id + "')";
                    mgInsert += inputMgdata;
                    command2 = new MySqlCommand(mgInsert, connection);                   

                    if (command.ExecuteNonQuery() == 1 && command2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("가입 완료!\n회원가입을 축하드립니다.");
                    }
                    connection.Close();

                    break;

                case 4:  // 관리자
                    connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
                    connection.Open();

                    // manager table에 정보 입력
                    insert = "INSERT INTO manager_table(Mg_name, Mg_number, Mg_id, Mg_pw) VALUES(";
                    inputData = "'" + name + "' , " + userNum1.ToString() + userNum2.ToString() + " , '" + id + "' , '" + pw + "')";
                    insert += inputData;
                    command = new MySqlCommand(insert, connection);

                    // totaluser table에 추가
                    mgInsert = "INSERT INTO totaluser_table(client_mode, client_name, client_number, client_id) VALUES(";
                    inputMgdata = "4 , '" + name + "' , " + userNum1.ToString() + userNum2.ToString() + " , '" + id + "')";
                    mgInsert += inputMgdata;
                    command2 = new MySqlCommand(mgInsert, connection);

                    if (command.ExecuteNonQuery() == 1 && command2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("가입 완료!\n회원가입을 축하드립니다.");
                    }
                    connection.Close();

                    break;
                default:
                    break;
            }

            if (state == 3)
            {
                doctorPlusDept main = new doctorPlusDept();
                main.Tag = this;
                main.Show();
                this.Hide();
            }

            else
            {
                Form1 main = new Form1();
                main.Tag = this;
                main.Show();
                this.Hide();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                state = 4;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }
    }

}
