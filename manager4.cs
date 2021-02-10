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
    public partial class manager4 : Form
    {
        string[] client_name = new string[10];
        string[] client_id = new string[10];
        string[] client_number = new string[10];

        public manager4()
        {
            InitializeComponent();

            // 등록된 의료진 이름 찾기
            string query = "select client_name from totaluser_table where client_mode = 2";
            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            MySqlCommand cmd = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataReader myReader = cmd.ExecuteReader();

            int count = 0;
            string temp;
            // 1명 이상 존재하면 --> client_name 배열에 이름 추가
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


            // 사용자 아이디 찾아서 client_id 배열에 추가
            query = "select client_id from totaluser_table where client_mode = 2";
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

            // 사용자 주민등록번호 찾아서 client_number 배열에 추가
            query = "select client_number from totaluser_table where client_mode = 2";
            cmd = new MySqlCommand(query, connection);
            myReader = cmd.ExecuteReader();

            count = 0;
            string temp2_, temp3_, resultNum;
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    temp = myReader.GetString(0);
                    temp2_ = temp.Substring(0, 6);
                    temp3_ = temp.Substring(6);
                    resultNum = temp2_ + "-" + temp3_;

                    client_number[count] = resultNum;
                    count++;
                }
            }

            myReader.Dispose();
            cmd.Dispose();
            connection.Dispose();


            // 사용자가 존재하면
            string temp1, temp2, temp3;

            System.Windows.Forms.Label label;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;

            TabControl tabcontrol1 = new TabControl();

            // 6명 이하 : 한 페이지 내에 모두 
            for (int j = 0; j < count; j++)
            {
                temp1 = client_name[j];
                temp2 = client_id[j];
                temp3 = client_number[j];

                // 이름 - label
                label = new System.Windows.Forms.Label();
                label.Location = new System.Drawing.Point(55, 135 + j * 38);
                label.Name = "name" + j.ToString();
                label.Size = new System.Drawing.Size(80, 40);
                label.Font = new Font(this.label1.Font.Name, 18);
                label.TabIndex = j;
                label.Text = temp1;

                this.Controls.Add(label);


                // 주민등록번호 - label2
                label2 = new System.Windows.Forms.Label();
                label2.Location = new System.Drawing.Point(180, 135 + j * 38);
                label2.Name = "number" + j.ToString();
                label2.Size = new System.Drawing.Size(180, 40);
                label2.Font = new Font(this.label1.Font.Name, 18);
                label2.TabIndex = j;
                label2.Text = temp3;

                this.Controls.Add(label2);


                // 아이디 - label3
                label3 = new System.Windows.Forms.Label();
                label3.Location = new System.Drawing.Point(410, 135 + j * 38);
                label3.Name = "id" + j.ToString();
                label3.Size = new System.Drawing.Size(70, 40);
                label3.Font = new Font(this.label1.Font.Name, 18);
                label3.TabIndex = j;
                label3.Text = temp2;

                this.Controls.Add(label3);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
