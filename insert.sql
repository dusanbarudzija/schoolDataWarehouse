USE UniWarehouse;
GO

INSERT INTO Date (Semester, Year) VALUES
('Fall', 2022),
('Winter', 2023),
('Spring/Summer', 2023),
('Fall', 2023),
('Winter', 2024),
('Spring/Summer', 2024),
('Fall', 2024),
('Winter', 2025);
GO

INSERT INTO Instructor (InstructorName, Faculty, Rank, University) VALUES
('Dr. Sarah Mitchell',    'Science',               'Professor',            'University of Alberta'),
('Dr. James Okafor',      'Science',               'Associate Professor',  'University of Alberta'),
('Dr. Linda Nguyen',      'Engineering',           'Professor',            'University of Alberta'),
('Dr. Tom Breslin',       'Engineering',           'Lecturer',             'University of Alberta'),
('Dr. Priya Sharma',      'Arts',                  'Associate Professor',  'University of Alberta'),
('Dr. Carlos Rivera',     'Business',              'Professor',            'MacEwan University'),
('Dr. Amy Tran',          'Business',              'Lecturer',             'MacEwan University'),
('Dr. Kevin Park',        'Health Sciences',       'Associate Professor',  'MacEwan University'),
('Dr. Rachel Osei',       'Arts',                  'Lecturer',             'MacEwan University'),
('Dr. Wei Zhang',         'Science',               'Professor',            'MacEwan University'),
('Dr. Fatima Al-Hassan',  'Engineering',           'Professor',            'Mount Royal University'),
('Dr. David Lemoine',     'Arts',                  'Associate Professor',  'Mount Royal University'),
('Dr. Nina Kowalski',     'Business',              'Lecturer',             'Mount Royal University'),
('Dr. Omar Siddiqui',     'Health Sciences',       'Professor',            'Mount Royal University'),
('Dr. Grace Okonkwo',     'Science',               'Lecturer',             'Mount Royal University');
GO

INSERT INTO Student (StudentName, Major, Gender) VALUES
('Alice Johnson',     'Computer Science',     'Female'),
('Bob Chen',          'Mechanical Engineering','Male'),
('Carmen Lopez',      'Business Admin',       'Female'),
('Daniel Kim',        'Biology',              'Male'),
('Emma Wilson',       'Psychology',           'Female'),
('Frank Obi',         'Computer Science',     'Male'),
('Grace Lee',         'Nursing',              'Female'),
('Henry Patel',       'Electrical Engineering','Male'),
('Isla Brown',        'Business Admin',       'Female'),
('James Tremblay',    'Chemistry',            'Male'),
('Kira Santos',       'Psychology',           'Female'),
('Liam Murphy',       'Biology',              'Male'),
('Maya Johansson',    'Computer Science',     'Female'),
('Noah Fernandez',    'Mechanical Engineering','Male'),
('Olivia Grant',      'Nursing',              'Female'),
('Patrick Yuen',      'Business Admin',       'Male'),
('Quinn Dube',        'Chemistry',            'Non-binary'),
('Rosa Martini',      'Electrical Engineering','Female'),
('Samuel Adeyemi',    'Psychology',           'Male'),
('Tara MacLeod',      'Computer Science',     'Female');
GO

INSERT INTO Course (CourseName, CourseCode, Department, Faculty, University) VALUES
('Introduction to Databases',       'CMPT391',  'Computing Science',      'Science',         'University of Alberta'),
('Data Structures',                 'CMPT201',  'Computing Science',      'Science',         'University of Alberta'),
('Algorithms',                      'CMPT307',  'Computing Science',      'Science',         'University of Alberta'),
('Thermodynamics',                  'MECE301',  'Mechanical Engineering', 'Engineering',     'University of Alberta'),
('Circuit Analysis',                'ELEE201',  'Electrical Engineering', 'Engineering',     'University of Alberta'),
('Organizational Behaviour',        'BUS220',   'Management',             'Business',        'MacEwan University'),
('Financial Accounting',            'ACCT101',  'Accounting',             'Business',        'MacEwan University'),
('Marketing Fundamentals',          'MRKT101',  'Marketing',              'Business',        'MacEwan University'),
('Human Anatomy',                   'HLTH210',  'Health Sciences',        'Health Sciences', 'MacEwan University'),
('Introduction to Psychology',      'PSYC101',  'Psychology',             'Arts',            'MacEwan University'),
('Structural Analysis',             'ENGI301',  'Engineering',            'Engineering',     'Mount Royal University'),
('Environmental Science',           'ENSC201',  'Science',                'Science',         'Mount Royal University'),
('Introductory Calculus',           'MATH101',  'Mathematics',            'Science',         'Mount Royal University'),
('Business Communications',         'COMM210',  'Business',               'Business',        'Mount Royal University'),
('Nursing Fundamentals',            'NURS201',  'Nursing',                'Health Sciences', 'Mount Royal University'),
('Organic Chemistry',               'CHEM301',  'Chemistry',              'Science',         'University of Alberta'),
('Abnormal Psychology',             'PSYC310',  'Psychology',             'Arts',            'University of Alberta'),
('Operations Management',           'BUS310',   'Management',             'Business',        'MacEwan University'),
('Pathophysiology',                 'HLTH320',  'Health Sciences',        'Health Sciences', 'Mount Royal University'),
('Linear Algebra',                  'MATH201',  'Mathematics',            'Science',         'Mount Royal University');
GO

INSERT INTO CourseOfferings (CourseID, InstructorID, StudentID, DateID, EnrollmentCount, CoursesOffered) VALUES
-- University of Alberta - Computing Science courses
(1,  1,  1,  1, 1, 1),
(1,  1,  6,  1, 1, 1),
(1,  1,  13, 1, 1, 1),
(1,  1,  20, 1, 1, 1),
(2,  2,  1,  2, 1, 1),
(2,  2,  6,  2, 1, 1),
(2,  2,  13, 2, 1, 1),
(3,  1,  20, 4, 1, 1),
(3,  1,  6,  4, 1, 1),
-- University of Alberta - Engineering courses
(4,  3,  2,  1, 1, 1),
(4,  3,  8,  1, 1, 1),
(4,  3,  14, 1, 1, 1),
(5,  4,  2,  2, 1, 1),
(5,  4,  8,  2, 1, 1),
(5,  4,  18, 2, 1, 1),
-- University of Alberta - Science & Arts
(16, 1,  10, 3, 1, 1),
(16, 1,  17, 3, 1, 1),
(17, 5,  11, 4, 1, 1),
(17, 5,  19, 4, 1, 1),
(17, 5,  5,  4, 1, 1),
-- MacEwan University - Business courses
(6,  6,  3,  1, 1, 1),
(6,  6,  9,  1, 1, 1),
(6,  6,  16, 1, 1, 1),
(7,  7,  3,  2, 1, 1),
(7,  7,  9,  2, 1, 1),
(7,  7,  16, 2, 1, 1),
(8,  6,  3,  4, 1, 1),
(8,  6,  9,  4, 1, 1),
(18, 7,  16, 5, 1, 1),
(18, 7,  3,  5, 1, 1),
-- MacEwan University - Health Sciences & Arts
(9,  8,  4,  1, 1, 1),
(9,  8,  7,  1, 1, 1),
(9,  8,  15, 1, 1, 1),
(10, 9,  5,  2, 1, 1),
(10, 9,  11, 2, 1, 1),
(10, 9,  19, 2, 1, 1),
-- MacEwan University - Science
(2,  10, 4,  3, 1, 1),
(2,  10, 12, 3, 1, 1),
(2,  10, 17, 3, 1, 1),
-- Mount Royal University - Engineering & Science
(11, 11, 2,  4, 1, 1),
(11, 11, 14, 4, 1, 1),
(11, 11, 18, 4, 1, 1),
(12, 15, 4,  5, 1, 1),
(12, 15, 12, 5, 1, 1),
(13, 15, 1,  6, 1, 1),
(13, 15, 13, 6, 1, 1),
(20, 15, 20, 7, 1, 1),
(20, 15, 17, 7, 1, 1),
-- Mount Royal University - Business
(14, 13, 3,  4, 1, 1),
(14, 13, 9,  4, 1, 1),
(14, 13, 16, 4, 1, 1),
-- Mount Royal University - Health Sciences
(15, 14, 7,  5, 1, 1),
(15, 14, 15, 5, 1, 1),
(19, 14, 7,  7, 1, 1),
(19, 14, 15, 7, 1, 1),
-- Mount Royal University - Arts
(17, 12, 5,  6, 1, 1),
(17, 12, 11, 6, 1, 1),
(17, 12, 19, 6, 1, 1),
-- Cross-university enrollments (later semesters)
(1,  1,  4,  7, 1, 1),
(3,  2,  20, 8, 1, 1),
(7,  7,  9,  8, 1, 1);
GO

SELECT 'Instructor'    AS TableName, COUNT(*) AS RercordCount FROM Instructor    UNION ALL
SELECT 'Student',                    COUNT(*)             FROM Student        UNION ALL
SELECT 'Course',                     COUNT(*)             FROM Course         UNION ALL
SELECT 'Date',                       COUNT(*)             FROM [Date]           UNION ALL
SELECT 'CourseOfferings',           COUNT(*)             FROM CourseOfferings;
GO