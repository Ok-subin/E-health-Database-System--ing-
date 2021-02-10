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

            System.Windows.Forms.Label label;

            label = new System.Windows.Forms.Label();
            label.Location = new System.Drawing.Point(30, 50 + 30);
            label.Name = "label1";
            label.Size = new System.Drawing.Size(100, 23);
            label.TabIndex = 1;
            label.Text = "label2";
        }
    }
}
