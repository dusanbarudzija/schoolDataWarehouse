namespace SchoolDataWarehouse
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboInstructorUniversity = new ComboBox();
            label5 = new Label();
            cboRank = new ComboBox();
            label6 = new Label();
            cboInstructorName = new ComboBox();
            label7 = new Label();
            cboGender = new ComboBox();
            label10 = new Label();
            cboMajor = new ComboBox();
            label11 = new Label();
            label12 = new Label();
            cboDepartment = new ComboBox();
            label8 = new Label();
            cboCouseFaculty = new ComboBox();
            label9 = new Label();
            cboCourseUniversity = new ComboBox();
            label13 = new Label();
            label14 = new Label();
            cboSemester = new ComboBox();
            label15 = new Label();
            cboYear = new ComboBox();
            label16 = new Label();
            label17 = new Label();
            btnApplyFilters = new Button();
            btnClear = new Button();
            label18 = new Label();
            dgvResults = new DataGridView();
            cboStudentName = new ComboBox();
            label4 = new Label();
            cboInstructorFaculty = new ComboBox();
            label19 = new Label();
            lblStatus = new StatusStrip();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(179, 23);
            label1.TabIndex = 0;
            label1.Text = "Course Data Warehouse";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(0, 46);
            label2.Name = "label2";
            label2.Size = new Size(968, 2);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(12, 275);
            label3.Name = "label3";
            label3.Size = new Size(119, 19);
            label3.TabIndex = 2;
            label3.Text = "Filters - Instructor";
            // 
            // cboInstructorUniversity
            // 
            cboInstructorUniversity.FormattingEnabled = true;
            cboInstructorUniversity.Location = new Point(127, 297);
            cboInstructorUniversity.Name = "cboInstructorUniversity";
            cboInstructorUniversity.Size = new Size(191, 23);
            cboInstructorUniversity.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 300);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 5;
            label5.Text = "University\n";
            // 
            // cboRank
            // 
            cboRank.FormattingEnabled = true;
            cboRank.Location = new Point(127, 355);
            cboRank.Name = "cboRank";
            cboRank.Size = new Size(191, 23);
            cboRank.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 358);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 7;
            label6.Text = "Rank";
            // 
            // cboInstructorName
            // 
            cboInstructorName.FormattingEnabled = true;
            cboInstructorName.Location = new Point(127, 384);
            cboInstructorName.Name = "cboInstructorName";
            cboInstructorName.Size = new Size(191, 23);
            cboInstructorName.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 387);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 9;
            label7.Text = "Instructor Name";
            // 
            // cboGender
            // 
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(127, 221);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(191, 23);
            cboGender.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 224);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 14;
            label10.Text = "Gender";
            // 
            // cboMajor
            // 
            cboMajor.FormattingEnabled = true;
            cboMajor.Location = new Point(127, 192);
            cboMajor.Name = "cboMajor";
            cboMajor.Size = new Size(191, 23);
            cboMajor.TabIndex = 13;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 195);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 12;
            label11.Text = "Major";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.Location = new Point(12, 163);
            label12.Name = "label12";
            label12.Size = new Size(107, 19);
            label12.TabIndex = 11;
            label12.Text = "Filters - Student";
            // 
            // cboDepartment
            // 
            cboDepartment.FormattingEnabled = true;
            cboDepartment.Location = new Point(127, 135);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(191, 23);
            cboDepartment.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 138);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 21;
            label8.Text = "Department";
            // 
            // cboCouseFaculty
            // 
            cboCouseFaculty.FormattingEnabled = true;
            cboCouseFaculty.Location = new Point(127, 106);
            cboCouseFaculty.Name = "cboCouseFaculty";
            cboCouseFaculty.Size = new Size(191, 23);
            cboCouseFaculty.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 109);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 19;
            label9.Text = "Faculty";
            // 
            // cboCourseUniversity
            // 
            cboCourseUniversity.FormattingEnabled = true;
            cboCourseUniversity.Location = new Point(127, 77);
            cboCourseUniversity.Name = "cboCourseUniversity";
            cboCourseUniversity.Size = new Size(191, 23);
            cboCourseUniversity.TabIndex = 18;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 80);
            label13.Name = "label13";
            label13.Size = new Size(59, 15);
            label13.TabIndex = 17;
            label13.Text = "University";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F);
            label14.Location = new Point(12, 48);
            label14.Name = "label14";
            label14.Size = new Size(102, 19);
            label14.TabIndex = 16;
            label14.Text = "Filters - Course";
            // 
            // cboSemester
            // 
            cboSemester.FormattingEnabled = true;
            cboSemester.Location = new Point(127, 469);
            cboSemester.Name = "cboSemester";
            cboSemester.Size = new Size(191, 23);
            cboSemester.TabIndex = 27;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(12, 472);
            label15.Name = "label15";
            label15.Size = new Size(55, 15);
            label15.TabIndex = 26;
            label15.Text = "Semester";
            // 
            // cboYear
            // 
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(127, 440);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(191, 23);
            cboYear.TabIndex = 25;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(12, 443);
            label16.Name = "label16";
            label16.Size = new Size(29, 15);
            label16.TabIndex = 24;
            label16.Text = "Year";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10F);
            label17.Location = new Point(12, 411);
            label17.Name = "label17";
            label17.Size = new Size(88, 19);
            label17.TabIndex = 23;
            label17.Text = "Filters - Date";
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.Location = new Point(243, 502);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(75, 23);
            btnApplyFilters.TabIndex = 28;
            btnApplyFilters.Text = "Apply";
            btnApplyFilters.UseVisualStyleBackColor = true;
            btnApplyFilters.Click += btnApplyFilters_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(127, 502);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 29;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10F);
            label18.Location = new Point(324, 48);
            label18.Name = "label18";
            label18.Size = new Size(52, 19);
            label18.TabIndex = 30;
            label18.Text = "Results";
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(324, 70);
            dgvResults.Name = "dgvResults";
            dgvResults.Size = new Size(550, 455);
            dgvResults.TabIndex = 31;
            // 
            // cboStudentName
            // 
            cboStudentName.FormattingEnabled = true;
            cboStudentName.Location = new Point(127, 250);
            cboStudentName.Name = "cboStudentName";
            cboStudentName.Size = new Size(191, 23);
            cboStudentName.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 253);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 32;
            label4.Text = "Student Name";
            // 
            // cboInstructorFaculty
            // 
            cboInstructorFaculty.FormattingEnabled = true;
            cboInstructorFaculty.Location = new Point(127, 326);
            cboInstructorFaculty.Name = "cboInstructorFaculty";
            cboInstructorFaculty.Size = new Size(191, 23);
            cboInstructorFaculty.TabIndex = 35;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(12, 329);
            label19.Name = "label19";
            label19.Size = new Size(45, 15);
            label19.TabIndex = 34;
            label19.Text = "Faculty\n";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(0, 531);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(886, 22);
            lblStatus.TabIndex = 36;
            lblStatus.Text = "statusStrip1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 553);
            Controls.Add(lblStatus);
            Controls.Add(cboInstructorFaculty);
            Controls.Add(label19);
            Controls.Add(cboStudentName);
            Controls.Add(label4);
            Controls.Add(dgvResults);
            Controls.Add(label18);
            Controls.Add(btnClear);
            Controls.Add(btnApplyFilters);
            Controls.Add(cboSemester);
            Controls.Add(label15);
            Controls.Add(cboYear);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(cboDepartment);
            Controls.Add(label8);
            Controls.Add(cboCouseFaculty);
            Controls.Add(label9);
            Controls.Add(cboCourseUniversity);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(cboGender);
            Controls.Add(label10);
            Controls.Add(cboMajor);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(cboInstructorName);
            Controls.Add(label7);
            Controls.Add(cboRank);
            Controls.Add(label6);
            Controls.Add(cboInstructorUniversity);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cboInstructorUniversity;
        private Label label5;
        private ComboBox cboRank;
        private Label label6;
        private ComboBox cboInstructorName;
        private Label label7;
        private ComboBox cboGender;
        private Label label10;
        private ComboBox cboMajor;
        private Label label11;
        private Label label12;
        private ComboBox cboDepartment;
        private Label label8;
        private ComboBox cboCouseFaculty;
        private Label label9;
        private ComboBox cboCourseUniversity;
        private Label label13;
        private Label label14;
        private ComboBox cboSemester;
        private Label label15;
        private ComboBox cboYear;
        private Label label16;
        private Label label17;
        private Button btnApplyFilters;
        private Button btnClear;
        private Label label18;
        private DataGridView dgvResults;
        private ComboBox cboStudentName;
        private Label label4;
        private ComboBox cboInstructorFaculty;
        private Label label19;
        private StatusStrip statusStrip1;
        private StatusStrip lblStatus;
    }
}
