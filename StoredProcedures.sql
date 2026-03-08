CREATE PROCEDURE UploadCourseXML
    @CourseXML XML
AS
BEGIN
    SET NOCOUNT ON;

    /* Insert Instructor */
    INSERT INTO Instructor (InstructorName, Faculty, Rank, University)
    SELECT
        x.value('(InstructorName)[1]', 'VARCHAR(100)'),
        x.value('(Faculty)[1]', 'VARCHAR(100)'),
        x.value('(Rank)[1]', 'VARCHAR(50)'),
        x.value('(University)[1]', 'VARCHAR(100)')
    FROM @CourseXML.nodes('/CourseWarehouse/Offering/Instructor') AS T(x);


    /* Insert Student */
    INSERT INTO Student (StudentName, Major, Gender)
    SELECT
        x.value('(StudentName)[1]', 'VARCHAR(100)'),
        x.value('(Major)[1]', 'VARCHAR(100)'),
        x.value('(Gender)[1]', 'VARCHAR(20)')
    FROM @CourseXML.nodes('/CourseWarehouse/Offering/Student') AS T(x);


    /* Insert Course */
    INSERT INTO Course (CourseName, CourseCode, Department, Faculty, University)
    SELECT
        x.value('(CourseName)[1]', 'VARCHAR(150)'),
        x.value('(CourseCode)[1]', 'VARCHAR(20)'),
        x.value('(Department)[1]', 'VARCHAR(100)'),
        x.value('(Faculty)[1]', 'VARCHAR(100)'),
        x.value('(University)[1]', 'VARCHAR(100)')
    FROM @CourseXML.nodes('/CourseWarehouse/Offering/Course') AS T(x);


    /* Insert Date */
    INSERT INTO Date (Semester, Year)
    SELECT
        x.value('(Semester)[1]', 'VARCHAR(20)'),
        x.value('(Year)[1]', 'INT')
    FROM @CourseXML.nodes('/CourseWarehouse/Offering/Date') AS T(x);

END