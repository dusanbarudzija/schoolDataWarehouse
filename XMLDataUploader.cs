using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;


public static class XMLDataUploader
{
    public static string ProcessXML(string xmlFilePath)
    {
        // Validate filename
        if (!ValidateFileName(xmlFilePath))
            throw new Exception("File must be named: description_YYYY-MM-DD.xml");

        // Parse XML
        XDocument doc = XDocument.Load(xmlFilePath);

        // Insert data (returns count of NEW entries only)
        int newStudents = InsertStudents(doc);
        int newCourses = InsertCourses(doc);
        int newInstructors = InsertInstructors(doc);
        int newDates = InsertDates(doc);
        int newOfferings = InsertCourseOfferings(doc);

        // Return summary of NEW entries identified and added
        return $"NEW Entries Added:\n" +
               $"Students: {newStudents}\n" +
               $"Courses: {newCourses}\n" +
               $"Instructors: {newInstructors}\n" +
               $"Date Periods: {newDates}\n" +
               $"Course Offerings: {newOfferings}";
    }


    private static bool ValidateFileName(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);

        // Expected format: filename_YYYY-MM-DD
        return Regex.IsMatch(fileName, @".*_\d{4}-\d{2}-\d{2}$");
    }

    /* --------------------------------------------------------
    // Insert Students (skips duplicates)
    // Returns count of NEW students actually inserted
    -------------------------------------------------------- */
    private static int InsertStudents(XDocument doc)
    {
        int newCount = 0;

        foreach (var student in doc.Descendants("Student"))
        {
            string name = student.Element("StudentName")?.Value;
            string major = student.Element("Major")?.Value;
            string gender = student.Element("Gender")?.Value;

            string query = @"
                IF NOT EXISTS (SELECT 1 FROM Student 
                               WHERE StudentName = @Name AND Major = @Major AND Gender = @Gender)
                BEGIN
                    INSERT INTO Student (StudentName, Major, Gender)
                    VALUES (@Name, @Major, @Gender)
                    SELECT 1 -- Returns 1 if inserted
                END
                ELSE
                BEGIN
                    SELECT 0 -- Returns 0 if already exists
                END";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name ?? ""),
                new SqlParameter("@Major", major ?? ""),
                new SqlParameter("@Gender", gender ?? "")
            };

            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) == 1)
            {
                newCount++;
            }
        }

        return newCount;
    }

    // --------------------------------------------------------
    // Insert Courses (skips duplicates)
    // Returns count of NEW courses actually inserted
    // --------------------------------------------------------
    private static int InsertCourses(XDocument doc)
    {
        int newCount = 0;

        foreach (var course in doc.Descendants("Course"))
        {
            string query = @"
                IF NOT EXISTS (SELECT 1 FROM Course WHERE CourseCode = @Code)
                BEGIN
                    INSERT INTO Course (CourseName, CourseCode, Department, Faculty, University)
                    VALUES (@Name, @Code, @Dept, @Faculty, @University)
                    SELECT 1
                END
                ELSE
                BEGIN
                    SELECT 0
                END";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", course.Element("CourseName")?.Value ?? ""),
                new SqlParameter("@Code", course.Element("CourseCode")?.Value ?? ""),
                new SqlParameter("@Dept", course.Element("Department")?.Value ?? ""),
                new SqlParameter("@Faculty", course.Element("Faculty")?.Value ?? ""),
                new SqlParameter("@University", course.Element("University")?.Value ?? "")
            };

            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) == 1)
            {
                newCount++;
            }
        }

        return newCount;
    }

    // --------------------------------------------------------
    // Insert Instructors (skips duplicates)
    // Returns count of NEW instructors actually inserted
    // --------------------------------------------------------
    private static int InsertInstructors(XDocument doc)
    {
        int newCount = 0;

        foreach (var instructor in doc.Descendants("Instructor"))
        {
            string query = @"
                IF NOT EXISTS (SELECT 1 FROM Instructor 
                               WHERE InstructorName = @Name AND University = @University)
                BEGIN
                    INSERT INTO Instructor (InstructorName, Faculty, Rank, University)
                    VALUES (@Name, @Faculty, @Rank, @University)
                    SELECT 1
                END
                ELSE
                BEGIN
                    SELECT 0
                END";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", instructor.Element("InstructorName")?.Value ?? ""),
                new SqlParameter("@Faculty", instructor.Element("Faculty")?.Value ?? ""),
                new SqlParameter("@Rank", instructor.Element("Rank")?.Value ?? ""),
                new SqlParameter("@University", instructor.Element("University")?.Value ?? "")
            };

            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) == 1)
            {
                newCount++;
            }
        }

        return newCount;
    }

    // --------------------------------------------------------
    // Insert Dates (skips duplicates)
    // Returns count of NEW dates actually inserted
    // --------------------------------------------------------
    private static int InsertDates(XDocument doc)
    {
        int newCount = 0;
        var uniqueDates = doc.Descendants("CourseOffering")
            .Select(o => new
            {
                Semester = o.Element("Semester")?.Value,
                Year = o.Element("Year")?.Value
            })
            .Distinct();

        foreach (var date in uniqueDates)
        {
            string query = @"
                IF NOT EXISTS (SELECT 1 FROM [Date] 
                               WHERE Semester = @Semester AND Year = @Year)
                BEGIN
                    INSERT INTO [Date] (Semester, Year)
                    VALUES (@Semester, @Year)
                    SELECT 1
                END
                ELSE
                BEGIN
                    SELECT 0
                END";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Semester", date.Semester ?? ""),
                new SqlParameter("@Year", int.Parse(date.Year ?? "0"))
            };

            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) == 1)
            {
                newCount++;
            }
        }

        return newCount;
    }

    // --------------------------------------------------------
    // Insert Course Offerings (skips duplicates)
    // Returns count of NEW course offerings actually inserted
    // --------------------------------------------------------
    private static int InsertCourseOfferings(XDocument doc)
    {
        int newCount = 0;

        foreach (var offering in doc.Descendants("CourseOffering"))
        {
            string query = @"
                DECLARE @StudentID INT, @CourseID INT, @InstructorID INT, @DateID INT
                DECLARE @Inserted INT = 0

                SELECT @StudentID = StudentID FROM Student 
                WHERE StudentName = @StudentName

                SELECT @CourseID = CourseID FROM Course 
                WHERE CourseCode = @CourseCode

                SELECT @InstructorID = InstructorID FROM Instructor 
                WHERE InstructorName = @InstructorName

                SELECT @DateID = DateID FROM [Date] 
                WHERE Semester = @Semester AND Year = @Year

                IF @StudentID IS NOT NULL AND @CourseID IS NOT NULL 
                   AND @InstructorID IS NOT NULL AND @DateID IS NOT NULL
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM CourseOfferings 
                                   WHERE StudentID = @StudentID 
                                   AND CourseID = @CourseID 
                                   AND InstructorID = @InstructorID 
                                   AND DateID = @DateID)
                    BEGIN
                        INSERT INTO CourseOfferings 
                        (CourseID, InstructorID, StudentID, DateID, EnrollmentCount, CoursesOffered)
                        VALUES (@CourseID, @InstructorID, @StudentID, @DateID, 1, 1)
                        SET @Inserted = 1
                    END
                END
                
                SELECT @Inserted";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentName", offering.Element("StudentName")?.Value ?? ""),
                new SqlParameter("@CourseCode", offering.Element("CourseCode")?.Value ?? ""),
                new SqlParameter("@InstructorName", offering.Element("InstructorName")?.Value ?? ""),
                new SqlParameter("@Semester", offering.Element("Semester")?.Value ?? ""),
                new SqlParameter("@Year", int.Parse(offering.Element("Year")?.Value ?? "0"))
            };

            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) == 1)
            {
                newCount++;
            }
        }

        return newCount;
    }
}