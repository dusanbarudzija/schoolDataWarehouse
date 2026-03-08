using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

// ============================================================
//  DatabaseHelper.cs
// ============================================================
public class DatabaseHelper
{
    private static string connectionString =
        "Server=localhost;Database=UniWarehouse;Trusted_Connection=True;TrustServerCertificate=True;";

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
}