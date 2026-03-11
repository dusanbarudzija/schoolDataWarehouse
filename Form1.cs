namespace SchoolDataWarehouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //  FORM LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllComboBoxes();
        }

        private void LoadAllComboBoxes()
        {
            // -- Course Dimension --
            DatabaseHelper.LoadCourseUniversities(cboCourseUniversity);
            DatabaseHelper.LoadCourseFaculties(cboCouseFaculty);
            DatabaseHelper.LoadDepartments(cboDepartment);

            // -- Instructor Dimension --
            DatabaseHelper.LoadInstructorUniversities(cboInstructorUniversity);
            DatabaseHelper.LoadInstructorFaculties(cboInstructorFaculty);
            DatabaseHelper.LoadInstructorRanks(cboRank);
            DatabaseHelper.LoadInstructorNames(cboInstructorName);

            // -- Student Dimension --
            DatabaseHelper.LoadMajors(cboMajor);
            DatabaseHelper.LoadGenders(cboGender);
            DatabaseHelper.LoadStudentNames(cboStudentName);

            // -- Date Dimension --
            DatabaseHelper.LoadYears(cboYear);
            DatabaseHelper.LoadSemesters(cboSemester);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset every ComboBox back to "All" (index 0)
            ComboBox[] allFilters =
                {
                cboCourseUniversity, cboCouseFaculty, cboDepartment,
                cboInstructorUniversity, cboInstructorFaculty, cboRank, cboInstructorName,
                cboMajor, cboGender, cboStudentName,
                cboYear, cboSemester
                };

            foreach (ComboBox cbo in allFilters)
                cbo.SelectedIndex = 0;

            // Re-run the query so the grid updates immediately
            btnApplyFilters_Click(sender, e);
        }


        //  APPLY FILTERS BUTTON
        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            string Get(ComboBox cbo) =>
                cbo.SelectedItem?.ToString() == "All" ? null : cbo.SelectedItem?.ToString();

            string courseUniversity = Get(cboCourseUniversity);
            string courseFaculty = Get(cboCouseFaculty);
            string department = Get(cboDepartment);
            string instructorUniversity = Get(cboInstructorUniversity);
            string instructorFaculty = Get(cboInstructorFaculty);
            string rank = Get(cboRank);
            string instructorName = Get(cboInstructorName);
            string major = Get(cboMajor);
            string gender = Get(cboGender);
            string studentName = Get(cboStudentName);
            string year = Get(cboYear);
            string semester = Get(cboSemester);

            bool needsInstructor = instructorUniversity != null || instructorFaculty != null
                                   || rank != null || instructorName != null;
            bool needsStudent = major != null || gender != null || studentName != null;
            bool needsDate = year != null || semester != null;

            var selectCols = new System.Collections.Generic.List<string>();
            var groupByCols = new System.Collections.Generic.List<string>();
            var whereClauses = new System.Collections.Generic.List<string>();
            var paramList = new System.Collections.Generic.List<Microsoft.Data.SqlClient.SqlParameter>();


            // SELECT + GROUP BY

            // Course dimension
            if (courseUniversity != null)
            {
                selectCols.Add("C.University AS [Course University]");
                groupByCols.Add("C.University");
            }
            if (courseFaculty != null)
            {
                selectCols.Add("C.Faculty AS [Course Faculty]");
                groupByCols.Add("C.Faculty");
            }
            if (department != null)
            {
                selectCols.Add("C.Department");
                groupByCols.Add("C.Department");
            }

            // Instructor dimension
            if (instructorUniversity != null)
            {
                selectCols.Add("I.University AS [Instructor University]");
                groupByCols.Add("I.University");
            }
            if (instructorFaculty != null)
            {
                selectCols.Add("I.Faculty AS [Instructor Faculty]");
                groupByCols.Add("I.Faculty");
            }
            if (rank != null)
            {
                selectCols.Add("I.Rank");
                groupByCols.Add("I.Rank");
            }
            if (instructorName != null)
            {
                selectCols.Add("I.InstructorName AS [Instructor]");
                groupByCols.Add("I.InstructorName");
            }

            // Student dimension
            if (major != null)
            {
                selectCols.Add("S.Major");
                groupByCols.Add("S.Major");
            }
            if (gender != null)
            {
                selectCols.Add("S.Gender");
                groupByCols.Add("S.Gender");
            }
            if (studentName != null)
            {
                selectCols.Add("S.StudentName AS [Student]");
                groupByCols.Add("S.StudentName");
            }

            // Date dimension
            if (year != null)
            {
                selectCols.Add("D.Year");
                groupByCols.Add("D.Year");
            }
            if (semester != null)
            {
                selectCols.Add("D.Semester");
                groupByCols.Add("D.Semester");
            }

            // Measures — always shown
            selectCols.Add("COUNT(DISTINCT C.CourseID) AS [Total Courses]");
            selectCols.Add("COUNT(DISTINCT CO.StudentID) AS [Total Students Enrolled]");


            // WHERE clauses
            if (courseUniversity != null) { whereClauses.Add("C.University = @CUni"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@CUni", courseUniversity)); }
            if (courseFaculty != null) { whereClauses.Add("C.Faculty = @CFac"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@CFac", courseFaculty)); }
            if (department != null) { whereClauses.Add("C.Department = @Dept"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@Dept", department)); }
            if (instructorUniversity != null) { whereClauses.Add("I.University = @IUni"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@IUni", instructorUniversity)); }
            if (instructorFaculty != null) { whereClauses.Add("I.Faculty = @IFac"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@IFac", instructorFaculty)); }
            if (rank != null) { whereClauses.Add("I.Rank = @Rank"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@Rank", rank)); }
            if (instructorName != null) { whereClauses.Add("I.InstructorName = @IName"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@IName", instructorName)); }
            if (major != null) { whereClauses.Add("S.Major = @Major"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@Major", major)); }
            if (gender != null) { whereClauses.Add("S.Gender = @Gender"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@Gender", gender)); }
            if (studentName != null) { whereClauses.Add("S.StudentName = @SName"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@SName", studentName)); }
            if (year != null) { whereClauses.Add("D.Year = @Year"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@Year", int.Parse(year))); }
            if (semester != null) { whereClauses.Add("D.Semester = @Semester"); paramList.Add(new Microsoft.Data.SqlClient.SqlParameter("@Semester", semester)); }

            // JOINS
            string joins = "JOIN Course C ON CO.CourseID = C.CourseID";

            if (needsInstructor)
                joins += "\n            JOIN Instructor I ON CO.InstructorID = I.InstructorID";

            if (needsStudent)
                joins += "\n            JOIN Student S ON CO.StudentID = S.StudentID";
            else
                joins += "\n            LEFT JOIN Student S ON CO.StudentID = S.StudentID";

            if (needsDate)
                joins += "\n            JOIN [Date] D ON CO.DateID = D.DateID";


            // ASSEMBLE AND RUN
            string where = whereClauses.Count > 0 ? "WHERE " + string.Join(" AND ", whereClauses) : "";
            string groupBy = groupByCols.Count > 0 ? "GROUP BY " + string.Join(", ", groupByCols) : "";
            string orderBy = groupByCols.Count > 0 ? "ORDER BY " + groupByCols[0] : "";

            string query = $@"
                SELECT  {string.Join(",\n                ", selectCols)}
                FROM    CourseOfferings CO
                {joins}
                {where}
                {groupBy}
                {orderBy}";

            System.Data.DataTable results = DatabaseHelper.ExecuteQuery(query, paramList.ToArray());
            dgvResults.DataSource = results;
        }

        private void btnUploadXML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "XML files (*.xml)|*.xml";
                dialog.Title = "Select XML File";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Process the XML file - identifies and adds only new entries
                        string result = XMLDataUploader.ProcessXML(dialog.FileName);

                        // Show success message with NEW entries identified
                        MessageBox.Show(
                            $"Upload complete!\n\n{result}",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Refresh
                        LoadAllComboBoxes();
                        btnClear_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Upload Failed:\n\n{ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
