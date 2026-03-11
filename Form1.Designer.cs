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
            btnUploadXML = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(222, 30);
            label1.TabIndex = 0;
            label1.Text = "Course Data Warehouse";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(0, 61);
            label2.Name = "label2";
            label2.Size = new Size(1106, 3);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(14, 367);
            label3.Name = "label3";
            label3.Size = new Size(145, 23);
            label3.TabIndex = 2;
            label3.Text = "Filters - Instructor";
            // 
            // cboInstructorUniversity
            // 
            cboInstructorUniversity.FormattingEnabled = true;
            cboInstructorUniversity.Location = new Point(145, 396);
            cboInstructorUniversity.Margin = new Padding(3, 4, 3, 4);
            cboInstructorUniversity.Name = "cboInstructorUniversity";
            cboInstructorUniversity.Size = new Size(218, 28);
            cboInstructorUniversity.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 400);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 5;
            label5.Text = "University\n";
            // 
            // cboRank
            // 
            cboRank.FormattingEnabled = true;
            cboRank.Location = new Point(145, 473);
            cboRank.Margin = new Padding(3, 4, 3, 4);
            cboRank.Name = "cboRank";
            cboRank.Size = new Size(218, 28);
            cboRank.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 477);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 7;
            label6.Text = "Rank";
            // 
            // cboInstructorName
            // 
            cboInstructorName.FormattingEnabled = true;
            cboInstructorName.Location = new Point(145, 512);
            cboInstructorName.Margin = new Padding(3, 4, 3, 4);
            cboInstructorName.Name = "cboInstructorName";
            cboInstructorName.Size = new Size(218, 28);
            cboInstructorName.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 516);
            label7.Name = "label7";
            label7.Size = new Size(115, 20);
            label7.TabIndex = 9;
            label7.Text = "Instructor Name";
            // 
            // cboGender
            // 
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(145, 295);
            cboGender.Margin = new Padding(3, 4, 3, 4);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(218, 28);
            cboGender.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 299);
            label10.Name = "label10";
            label10.Size = new Size(57, 20);
            label10.TabIndex = 14;
            label10.Text = "Gender";
            // 
            // cboMajor
            // 
            cboMajor.FormattingEnabled = true;
            cboMajor.Location = new Point(145, 256);
            cboMajor.Margin = new Padding(3, 4, 3, 4);
            cboMajor.Name = "cboMajor";
            cboMajor.Size = new Size(218, 28);
            cboMajor.TabIndex = 13;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 260);
            label11.Name = "label11";
            label11.Size = new Size(48, 20);
            label11.TabIndex = 12;
            label11.Text = "Major";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.Location = new Point(14, 217);
            label12.Name = "label12";
            label12.Size = new Size(130, 23);
            label12.TabIndex = 11;
            label12.Text = "Filters - Student";
            // 
            // cboDepartment
            // 
            cboDepartment.FormattingEnabled = true;
            cboDepartment.Location = new Point(145, 180);
            cboDepartment.Margin = new Padding(3, 4, 3, 4);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(218, 28);
            cboDepartment.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 184);
            label8.Name = "label8";
            label8.Size = new Size(89, 20);
            label8.TabIndex = 21;
            label8.Text = "Department";
            // 
            // cboCouseFaculty
            // 
            cboCouseFaculty.FormattingEnabled = true;
            cboCouseFaculty.Location = new Point(145, 141);
            cboCouseFaculty.Margin = new Padding(3, 4, 3, 4);
            cboCouseFaculty.Name = "cboCouseFaculty";
            cboCouseFaculty.Size = new Size(218, 28);
            cboCouseFaculty.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 145);
            label9.Name = "label9";
            label9.Size = new Size(54, 20);
            label9.TabIndex = 19;
            label9.Text = "Faculty";
            // 
            // cboCourseUniversity
            // 
            cboCourseUniversity.FormattingEnabled = true;
            cboCourseUniversity.Location = new Point(145, 103);
            cboCourseUniversity.Margin = new Padding(3, 4, 3, 4);
            cboCourseUniversity.Name = "cboCourseUniversity";
            cboCourseUniversity.Size = new Size(218, 28);
            cboCourseUniversity.TabIndex = 18;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(14, 107);
            label13.Name = "label13";
            label13.Size = new Size(73, 20);
            label13.TabIndex = 17;
            label13.Text = "University";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F);
            label14.Location = new Point(14, 64);
            label14.Name = "label14";
            label14.Size = new Size(124, 23);
            label14.TabIndex = 16;
            label14.Text = "Filters - Course";
            // 
            // cboSemester
            // 
            cboSemester.FormattingEnabled = true;
            cboSemester.Location = new Point(145, 625);
            cboSemester.Margin = new Padding(3, 4, 3, 4);
            cboSemester.Name = "cboSemester";
            cboSemester.Size = new Size(218, 28);
            cboSemester.TabIndex = 27;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(14, 629);
            label15.Name = "label15";
            label15.Size = new Size(70, 20);
            label15.TabIndex = 26;
            label15.Text = "Semester";
            // 
            // cboYear
            // 
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(145, 587);
            cboYear.Margin = new Padding(3, 4, 3, 4);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(218, 28);
            cboYear.TabIndex = 25;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(14, 591);
            label16.Name = "label16";
            label16.Size = new Size(37, 20);
            label16.TabIndex = 24;
            label16.Text = "Year";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10F);
            label17.Location = new Point(14, 548);
            label17.Name = "label17";
            label17.Size = new Size(107, 23);
            label17.TabIndex = 23;
            label17.Text = "Filters - Date";
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.Location = new Point(278, 669);
            btnApplyFilters.Margin = new Padding(3, 4, 3, 4);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(86, 31);
            btnApplyFilters.TabIndex = 28;
            btnApplyFilters.Text = "Apply";
            btnApplyFilters.UseVisualStyleBackColor = true;
            btnApplyFilters.Click += btnApplyFilters_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(145, 669);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(86, 31);
            btnClear.TabIndex = 29;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10F);
            label18.Location = new Point(370, 64);
            label18.Name = "label18";
            label18.Size = new Size(63, 23);
            label18.TabIndex = 30;
            label18.Text = "Results";
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(370, 93);
            dgvResults.Margin = new Padding(3, 4, 3, 4);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(629, 607);
            dgvResults.TabIndex = 31;
            // 
            // cboStudentName
            // 
            cboStudentName.FormattingEnabled = true;
            cboStudentName.Location = new Point(145, 333);
            cboStudentName.Margin = new Padding(3, 4, 3, 4);
            cboStudentName.Name = "cboStudentName";
            cboStudentName.Size = new Size(218, 28);
            cboStudentName.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 337);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 32;
            label4.Text = "Student Name";
            // 
            // cboInstructorFaculty
            // 
            cboInstructorFaculty.FormattingEnabled = true;
            cboInstructorFaculty.Location = new Point(145, 435);
            cboInstructorFaculty.Margin = new Padding(3, 4, 3, 4);
            cboInstructorFaculty.Name = "cboInstructorFaculty";
            cboInstructorFaculty.Size = new Size(218, 28);
            cboInstructorFaculty.TabIndex = 35;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(14, 439);
            label19.Name = "label19";
            label19.Size = new Size(54, 20);
            label19.TabIndex = 34;
            label19.Text = "Faculty\n";
            // 
            // lblStatus
            // 
            lblStatus.ImageScalingSize = new Size(20, 20);
            lblStatus.Location = new Point(0, 767);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(1, 0, 16, 0);
            lblStatus.Size = new Size(1013, 22);
            lblStatus.TabIndex = 36;
            lblStatus.Text = "statusStrip1";
            // 
            // btnUploadXML
            // 
            btnUploadXML.Location = new Point(145, 720);
            btnUploadXML.Name = "btnUploadXML";
            btnUploadXML.Size = new Size(218, 31);
            btnUploadXML.TabIndex = 37;
            btnUploadXML.Text = "Upload File";
            btnUploadXML.UseVisualStyleBackColor = true;
            btnUploadXML.Click += btnUploadXML_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 789);
            Controls.Add(btnUploadXML);
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
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btnUploadXML;
    }
}
