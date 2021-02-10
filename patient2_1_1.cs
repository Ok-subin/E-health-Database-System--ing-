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
    public partial class patient2_1_1 : Form
    {
        string selectDate;
        int selectIdx;
        int[] dateList = new int[10];
        string[] dateValue = new string[10];

        public patient2_1_1(string DtId)
        {
            InitializeComponent();

            try
            {                
                MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
                connection.Open();

                // 진료가 가능한 일시의 index를 dateList에 저장
                string query = "SELECT Dt_date FROM doctor_table WHERE Dt_department = 1 AND Dt_id = '";
                query += DtId;
                query += "'";

                MySqlCommand cmd = new MySqlCommand(query, connection); 
                MySqlDataReader myReader = cmd.ExecuteReader();

                int count = 0, temp, total = 0;
                if (myReader.HasRows)   // 진료 가능한 일시가 존재하는 경우
                {
                    while (myReader.Read())
                    {
                        temp = Convert.ToInt32(myReader.GetString(0));
                        dateList[count] = temp;
                        count++;
                    }
                    total = count;
                }

                else // 진료 가능한 일시가 없는 경우
                {
                    comboBox1.Items.Add("예약이 불가능한 의료진입니다.");
                }

                cmd.Dispose();
                myReader.Dispose();

                // date_table에서 해당 index (+1 해줘야함)에 맞는 요일, 시간대를 추출하여 listBox에 추가
                count = 0;
                string temp2;
                for (int x = 0; x < total; x++)
                {
                    query = "SELECT day FROM date_table WHERE dateIndex = ";
                    query += Convert.ToString(dateList[x]);
                    cmd = new MySqlCommand(query, connection);
                    temp2 = Convert.ToString(cmd.ExecuteScalar());

                    dateValue[count] = temp2;
                    comboBox1.Items.Add(temp2);
                    count++;

                    cmd.Dispose();
                }                   
                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            selectIdx = cb.SelectedIndex;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            selectDate = dateValue[selectIdx];

            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();

            // 환자 이름 찾기
            string findPt = "SELECT Pt_name FROM patient_table WHERE Pt_id = '";
            findPt += logincs.inputId;
            findPt += "'";

            MySqlCommand findPtName = new MySqlCommand(findPt, connection);

            string ptName = Convert.ToString(findPtName.ExecuteScalar());
            findPtName.Dispose();

            string query = "INSERT INTO history_table(Pt_name, Dt_name, date, department) VALUES('";
            query += ptName;
            query += "' , '";
            query += patient2_1.nextDtName;
            query += "' , '";
            query += selectDate;
            query += "' , 1)";


            MySqlCommand cmd = new MySqlCommand(query, connection);

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(selectDate + " 시간대를 선택하였습니다.");
                MessageBox.Show("예약이 완료되었습니다.");
            }      

            patient0 Pmain = new patient0();
            Pmain.Tag = this;
            Pmain.Show();
            this.Hide();

            cmd.Dispose();
            connection.Close();
        }

        /*
        private void patient2_1_1_Load(object sender, EventArgs e)
        {

        }*/
    }
}
