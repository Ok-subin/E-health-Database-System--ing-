namespace e_health
{
    partial class doctor2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.input2 = new System.Windows.Forms.Label();
            this.input3 = new System.Windows.Forms.Label();
            this.input4 = new System.Windows.Forms.Label();
            this.input5 = new System.Windows.Forms.Label();
            this.input6 = new System.Windows.Forms.Label();
            this.input1 = new System.Windows.Forms.Label();
            this.input7 = new System.Windows.Forms.Label();
            this.input8 = new System.Windows.Forms.Label();
            this.input9 = new System.Windows.Forms.Label();
            this.input10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("빙그레체", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(55, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 37);
            this.label3.TabIndex = 67;
            this.label3.Text = "현재 진료 시간표";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("가비아 솔미체", 25F, System.Drawing.FontStyle.Underline);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 47);
            this.label1.TabIndex = 63;
            this.label1.Text = "진료일 변경";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(767, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 68;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 317F));
            this.tableLayoutPanel1.Controls.Add(this.input10, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.input9, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.input8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.input2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.input3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.input4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.input5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.input6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.input1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.input7, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(90, 157);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 263);
            this.tableLayoutPanel1.TabIndex = 70;
            // 
            // input2
            // 
            this.input2.AutoSize = true;
            this.input2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input2.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input2.Location = new System.Drawing.Point(3, 52);
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(310, 52);
            this.input2.TabIndex = 0;
            this.input2.Text = "화요일 오전";
            this.input2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input2.Click += new System.EventHandler(this.input2_Click);
            // 
            // input3
            // 
            this.input3.AutoSize = true;
            this.input3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input3.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input3.Location = new System.Drawing.Point(3, 104);
            this.input3.Name = "input3";
            this.input3.Size = new System.Drawing.Size(310, 52);
            this.input3.TabIndex = 0;
            this.input3.Text = "수요일 오전";
            this.input3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input3.Click += new System.EventHandler(this.input3_Click);
            // 
            // input4
            // 
            this.input4.AutoSize = true;
            this.input4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input4.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input4.Location = new System.Drawing.Point(3, 156);
            this.input4.Name = "input4";
            this.input4.Size = new System.Drawing.Size(310, 52);
            this.input4.TabIndex = 0;
            this.input4.Text = "목요일 오전";
            this.input4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input4.Click += new System.EventHandler(this.input4_Click);
            // 
            // input5
            // 
            this.input5.AutoSize = true;
            this.input5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input5.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input5.Location = new System.Drawing.Point(3, 208);
            this.input5.Name = "input5";
            this.input5.Size = new System.Drawing.Size(310, 55);
            this.input5.TabIndex = 0;
            this.input5.Text = "금요일 오전";
            this.input5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input5.Click += new System.EventHandler(this.input5_Click);
            // 
            // input6
            // 
            this.input6.AutoSize = true;
            this.input6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input6.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input6.Location = new System.Drawing.Point(319, 0);
            this.input6.Name = "input6";
            this.input6.Size = new System.Drawing.Size(311, 52);
            this.input6.TabIndex = 0;
            this.input6.Text = "월요일 오후";
            this.input6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input6.Click += new System.EventHandler(this.input1_Click);
            // 
            // input1
            // 
            this.input1.AutoSize = true;
            this.input1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input1.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input1.Location = new System.Drawing.Point(3, 0);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(310, 52);
            this.input1.TabIndex = 0;
            this.input1.Text = "월요일 오전";
            this.input1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input1.Click += new System.EventHandler(this.input1_Click);
            // 
            // input7
            // 
            this.input7.AutoSize = true;
            this.input7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input7.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input7.Location = new System.Drawing.Point(319, 52);
            this.input7.Name = "input7";
            this.input7.Size = new System.Drawing.Size(311, 52);
            this.input7.TabIndex = 1;
            this.input7.Text = "화요일 오후";
            this.input7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input7.Click += new System.EventHandler(this.label2_Click);
            // 
            // input8
            // 
            this.input8.AutoSize = true;
            this.input8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input8.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input8.Location = new System.Drawing.Point(319, 104);
            this.input8.Name = "input8";
            this.input8.Size = new System.Drawing.Size(311, 52);
            this.input8.TabIndex = 2;
            this.input8.Text = "수요일 오후";
            this.input8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input8.Click += new System.EventHandler(this.input8_Click);
            // 
            // input9
            // 
            this.input9.AutoSize = true;
            this.input9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input9.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input9.Location = new System.Drawing.Point(319, 156);
            this.input9.Name = "input9";
            this.input9.Size = new System.Drawing.Size(311, 52);
            this.input9.TabIndex = 3;
            this.input9.Text = "목요일 오후";
            this.input9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input9.Click += new System.EventHandler(this.input9_Click);
            // 
            // input10
            // 
            this.input10.AutoSize = true;
            this.input10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input10.Font = new System.Drawing.Font("나눔스퀘어_ac", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input10.Location = new System.Drawing.Point(319, 208);
            this.input10.Name = "input10";
            this.input10.Size = new System.Drawing.Size(311, 55);
            this.input10.TabIndex = 4;
            this.input10.Text = "금요일 오후";
            this.input10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.input10.Click += new System.EventHandler(this.input10_Click);
            // 
            // doctor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "doctor2";
            this.Text = "doctor2";
            this.Load += new System.EventHandler(this.doctor2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label input1;
        private System.Windows.Forms.Label input2;
        private System.Windows.Forms.Label input3;
        private System.Windows.Forms.Label input4;
        private System.Windows.Forms.Label input5;
        private System.Windows.Forms.Label input6;
        private System.Windows.Forms.Label input7;
        private System.Windows.Forms.Label input8;
        private System.Windows.Forms.Label input10;
        private System.Windows.Forms.Label input9;
    }
}