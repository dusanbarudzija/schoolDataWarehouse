using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

// ============================================================
//  DatabaseHelper.cs
// ============================================================
public class DatabaseHelper
{
    private static string connectionString =
        "Server=DESKTOP-RDD83TJ\\MSSQLSERVER01;Database=UniWarehouse;Trusted_Connection=True;TrustServerCertificate=True;";

    // --------------------------------------------------------
    // Runs a query and returns a DataTable
    // --------------------------------------------------------
    public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        return dt;
    }

    // --------------------------------------------------------
    // Runs an INSERT / UPDATE / DELETE
    // --------------------------------------------------------
    public static void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // --------------------------------------------------------
    // Helper: fills a ComboBox from a single-column DataTable.
    // Always adds "All" as the first item (roll-up state).
    // --------------------------------------------------------
    private static void FillComboBox(ComboBox comboBox, DataTable dt, string columnName)
    {
        comboBox.Items.Clear();
        comboBox.Items.Add("All");

        foreach (DataRow row in dt.Rows)
        {
            string value = row[columnName]?.ToString();
            if (!string.IsNullOrWhiteSpace(value) && !comboBox.Items.Contains(value))
                comboBox.Items.Add(value);
        }

        comboBox.SelectedIndex = 0;
    }

    // ============================================================
    //  COURSE DIMENSION
    // ============================================================
    public static void LoadCourseUniversities(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT University FROM Course ORDER BY University");
        FillComboBox(comboBox, dt, "University");
    }

    public static void LoadCourseFaculties(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT Faculty FROM Course ORDER BY Faculty");
        FillComboBox(comboBox, dt, "Faculty");
    }

    public static void LoadDepartments(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT Department FROM Course ORDER BY Department");
        FillComboBox(comboBox, dt, "Department");
    }

    // ============================================================
    //  INSTRUCTOR DIMENSION
    // ============================================================
    public static void LoadInstructorUniversities(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT University FROM Instructor ORDER BY University");
        FillComboBox(comboBox, dt, "University");
    }

    public static void LoadInstructorFaculties(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT Faculty FROM Instructor ORDER BY Faculty");
        FillComboBox(comboBox, dt, "Faculty");
    }

    public static void LoadInstructorRanks(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT Rank FROM Instructor ORDER BY Rank");
        FillComboBox(comboBox, dt, "Rank");
    }

    public static void LoadInstructorNames(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT InstructorName FROM Instructor ORDER BY InstructorName");
        FillComboBox(comboBox, dt, "InstructorName");
    }

    // ============================================================
    //  STUDENT DIMENSION
    // ============================================================
    public static void LoadMajors(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT Major FROM Student ORDER BY Major");
        FillComboBox(comboBox, dt, "Major");
    }

    public static void LoadGenders(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT Gender FROM Student ORDER BY Gender");
        FillComboBox(comboBox, dt, "Gender");
    }

    public static void LoadStudentNames(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT StudentName FROM Student ORDER BY StudentName");
        FillComboBox(comboBox, dt, "StudentName");
    }

    // ============================================================
    //  DATE DIMENSION
    // ============================================================
    public static void LoadYears(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT Year FROM [Date] ORDER BY Year DESC");
        FillComboBox(comboBox, dt, "Year");
    }

    public static void LoadSemesters(ComboBox comboBox)
    {
        DataTable dt = ExecuteQuery("SELECT DISTINCT Semester FROM [Date] ORDER BY Semester");
        FillComboBox(comboBox, dt, "Semester");
    }

    // ============================================================
    //  ETL — Load XML file into the data warehouse
    // ============================================================
    public static (int inserted, int skipped) RunETL(string xmlFilePath)
    {
        int inserted = 0, skipped = 0;

        XDocument doc = XDocument.Load(xmlFilePath);

        // ---- INSTRUCTORS ----
        foreach (XElement el in doc.Descendants("Instructor"))
        {
            string name = el.Element("InstructorName")?.Value ?? "";
            string fac = el.Element("Faculty")?.Value ?? "";
            string rank = el.Element("Rank")?.Value ?? "";
            string uni = el.Element("University")?.Value ?? "";

            var check = ExecuteQuery(
                "SELECT COUNT(*) AS Cnt FROM Instructor WHERE InstructorName=@N AND University=@U",
                new[] {
                    new SqlParameter("@N", name),
                    new SqlParameter("@U", uni)
                });

            if (Convert.ToInt32(check.Rows[0]["Cnt"]) == 0)
            {
                ExecuteNonQuery(
                    "INSERT INTO Instructor (InstructorName, Faculty, Rank, University) VALUES (@N,@F,@R,@U)",
                    new[] {
                        new SqlParameter("@N", name),
                        new SqlParameter("@F", fac),
                        new SqlParameter("@R", rank),
                        new SqlParameter("@U", uni)
                    });
                inserted++;
            }
            else skipped++;
        }

        // ---- STUDENTS ----
        foreach (XElement el in doc.Descendants("Student"))
        {
            string name = el.Element("StudentName")?.Value ?? "";
            string major = el.Element("Major")?.Value ?? "";
            string gender = el.Element("Gender")?.Value ?? "";

            var check = ExecuteQuery(
                "SELECT COUNT(*) AS Cnt FROM Student WHERE StudentName=@N AND Major=@M",
                new[] {
                    new SqlParameter("@N", name),
                    new SqlParameter("@M", major)
                });

            if (Convert.ToInt32(check.Rows[0]["Cnt"]) == 0)
            {
                ExecuteNonQuery(
                    "INSERT INTO Student (StudentName, Major, Gender) VALUES (@N,@M,@G)",
                    new[] {
                        new SqlParameter("@N", name),
                        new SqlParameter("@M", major),
                        new SqlParameter("@G", gender)
                    });
                inserted++;
            }
            else skipped++;
        }

        // ---- COURSES ----
        foreach (XElement el in doc.Descendants("Course"))
        {
            string cname = el.Element("CourseName")?.Value ?? "";
            string code = el.Element("CourseCode")?.Value ?? "";
            string dept = el.Element("Department")?.Value ?? "";
            string fac = el.Element("Faculty")?.Value ?? "";
            string uni = el.Element("University")?.Value ?? "";

            var check = ExecuteQuery(
                "SELECT COUNT(*) AS Cnt FROM Course WHERE CourseCode=@C AND University=@U",
                new[] {
                    new SqlParameter("@C", code),
                    new SqlParameter("@U", uni)
                });

            if (Convert.ToInt32(check.Rows[0]["Cnt"]) == 0)
            {
                ExecuteNonQuery(
                    "INSERT INTO Course (CourseName, CourseCode, Department, Faculty, University) VALUES (@CN,@C,@D,@F,@U)",
                    new[] {
                        new SqlParameter("@CN", cname),
                        new SqlParameter("@C",  code),
                        new SqlParameter("@D",  dept),
                        new SqlParameter("@F",  fac),
                        new SqlParameter("@U",  uni)
                    });
                inserted++;
            }
            else skipped++;
        }

        // ---- DATES ----
        foreach (XElement el in doc.Descendants("Date"))
        {
            string semester = el.Element("Semester")?.Value ?? "";
            int year = int.Parse(el.Element("Year")?.Value ?? "0");

            var check = ExecuteQuery(
                "SELECT COUNT(*) AS Cnt FROM [Date] WHERE Semester=@S AND Year=@Y",
                new[] {
                    new SqlParameter("@S", semester),
                    new SqlParameter("@Y", year)
                });

            if (Convert.ToInt32(check.Rows[0]["Cnt"]) == 0)
            {
                ExecuteNonQuery(
                    "INSERT INTO [Date] (Semester, Year) VALUES (@S,@Y)",
                    new[] {
                        new SqlParameter("@S", semester),
                        new SqlParameter("@Y", year)
                    });
                inserted++;
            }
            else skipped++;
        }

        // ---- COURSE OFFERINGS ----
        foreach (XElement el in doc.Descendants("Offering"))
        {
            string courseName = el.Element("CourseName")?.Value ?? "";
            string instructorName = el.Element("InstructorName")?.Value ?? "";
            string studentName = el.Element("StudentName")?.Value ?? "";
            string semester = el.Element("Semester")?.Value ?? "";
            int year = int.Parse(el.Element("Year")?.Value ?? "0");

            var cRow = ExecuteQuery("SELECT CourseID FROM Course WHERE CourseName=@N",
                new[] { new SqlParameter("@N", courseName) });
            var iRow = ExecuteQuery("SELECT InstructorID FROM Instructor WHERE InstructorName=@N",
                new[] { new SqlParameter("@N", instructorName) });
            var sRow = ExecuteQuery("SELECT StudentID FROM Student WHERE StudentName=@N",
                new[] { new SqlParameter("@N", studentName) });
            var dRow = ExecuteQuery("SELECT DateID FROM [Date] WHERE Semester=@S AND Year=@Y",
                new[] {
                    new SqlParameter("@S", semester),
                    new SqlParameter("@Y", year)
                });

            if (cRow.Rows.Count == 0 || iRow.Rows.Count == 0 ||
                sRow.Rows.Count == 0 || dRow.Rows.Count == 0)
            { skipped++; continue; }

            int courseID = Convert.ToInt32(cRow.Rows[0]["CourseID"]);
            int instructorID = Convert.ToInt32(iRow.Rows[0]["InstructorID"]);
            int studentID = Convert.ToInt32(sRow.Rows[0]["StudentID"]);
            int dateID = Convert.ToInt32(dRow.Rows[0]["DateID"]);

            var check = ExecuteQuery(
                @"SELECT COUNT(*) AS Cnt FROM CourseOfferings
                  WHERE CourseID=@C AND InstructorID=@I AND StudentID=@S AND DateID=@D",
                new[] {
                    new SqlParameter("@C", courseID),
                    new SqlParameter("@I", instructorID),
                    new SqlParameter("@S", studentID),
                    new SqlParameter("@D", dateID)
                });

            if (Convert.ToInt32(check.Rows[0]["Cnt"]) == 0)
            {
                ExecuteNonQuery(
                    @"INSERT INTO CourseOfferings (CourseID, InstructorID, StudentID, DateID, EnrollmentCount, CoursesOffered)
                      VALUES (@C,@I,@S,@D,1,1)",
                    new[] {
                        new SqlParameter("@C", courseID),
                        new SqlParameter("@I", instructorID),
                        new SqlParameter("@S", studentID),
                        new SqlParameter("@D", dateID)
                    });
                inserted++;
            }
            else skipped++;
        }

        return (inserted, skipped);
    }
}