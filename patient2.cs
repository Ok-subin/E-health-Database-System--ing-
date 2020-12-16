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
    public partial class patient2 : Form
    {
        int pt_dept = patient1.Pt_Dept;     // 환자가 선택한 진료과
        public static string[] dtNameList = new string[100];

        public patient2()
        {
            InitializeComponent();

            MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=ehealth;Uid=root;Pwd=Suyuyebin0623");
            connection.Open();

            // 해당 진료과의 의사이름 모두 불러오기 (중복없이)
            string sqlQuery;
            sqlQuery = "SELECT DISTINCT Dt_name FROM doctor_table WHERE Dt_department = ";
            sqlQuery += pt_dept;

            // 해당 진료과의 의사의 수 count하기 (중복없이)
            string countQuery;
            countQuery = "SELECT COUNT(*) FROM doctor_table WHERE Dt_department = ";
            countQuery += pt_dept;


            connection.Close();
        }
    }
}
