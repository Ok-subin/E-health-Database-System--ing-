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
    public partial class patient3 : Form
    {
        public patient3()
        {
            InitializeComponent();

            // 예약 상태를 보여줄 테이블 생성
            DataTable table = new DataTable();

            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();

            // 예약정보 (환자 이름, 의사 이름, 날짜, 진료과 번호) 가져와서 저장
            // history table에서 환자를 찾기 위해 환자 이름 찾기
            string findPt = "SELECT Pt_name FROM patient_table WHERE Pt_id = '";
            findPt += logincs.inputId;
            findPt += "'";
            MySqlCommand findPtName = new MySqlCommand(findPt, connection);
            string ptName = Convert.ToString(findPtName.ExecuteScalar());
            findPtName.Dispose();

            // 의사 이름 검색
            string sql = "SELECT Dt_name FROM history_table WHERE Pt_name = '";
            sql += ptName;
            sql += "'";
            MySqlCommand findInform = new MySqlCommand(sql, connection);
            string dtName = Convert.ToString(findInform.ExecuteScalar());
            findInform.Dispose();

            // 날짜 검색
            sql = "SELECT date FROM history_table WHERE Pt_name = '";
            sql += ptName;
            sql += "'";
            findInform = new MySqlCommand(sql, connection);
            string date = Convert.ToString(findInform.ExecuteScalar());
            findInform.Dispose();

            // 진료과 이름 검색
            sql = "SELECT department FROM history_table WHERE Pt_name = '";
            sql += ptName;
            sql += "'";
            findInform = new MySqlCommand(sql, connection);
            int deptNum = Convert.ToInt32(findInform.ExecuteScalar());
            findInform.Dispose();

            sql = "SELECT dept_name FROM department_table WHERE dept_num = ";
            sql += deptNum;
            findInform = new MySqlCommand(sql, connection);
            string deptName = Convert.ToString(findInform.ExecuteScalar());
            findInform.Dispose();

            table.Columns.Add("이름", typeof(string));
            table.Columns.Add("진료과", typeof(string));
            table.Columns.Add("의료진명", typeof(string));
            table.Columns.Add("날짜", typeof(string));

            table.Rows.Add(ptName, deptName, dtName, date);

            dataGridView1.DataSource = table;

            connection.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
