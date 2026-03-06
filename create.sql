-- CREATE DATABASE UniWarehouse;

USE UniWarehouse;
GO

DROP TABLE IF EXISTS [Date];
DROP TABLE IF EXISTS Course;
DROP TABLE IF EXISTS Instructor;
DROP TABLE IF EXISTS Student;
DROP TABLE IF EXISTS Department;
DROP TABLE IF EXISTS CourseOfferings;
GO

/*--- Dimension Tables ---*/
CREATE TABLE Instructor (
    InstructorID INT PRIMARY KEY IDENTITY(1,1),
    InstructorName VARCHAR(100) NOT NULL,
    Faculty VARCHAR(100) NOT NULL,
    Rank VARCHAR(50) NOT NULL,   -- e.g. Professor, Associate Professor, Lecturer
    University VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Student (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    StudentName VARCHAR(100)  NOT NULL,
    Major VARCHAR(100)  NOT NULL,
    Gender VARCHAR(20)   NOT NULL
);
GO

CREATE TABLE Course (
    CourseID	INT PRIMARY KEY IDENTITY(1,1),
    CourseName	VARCHAR(150)  NOT NULL,
    CourseCode	VARCHAR(20)   NOT NULL,
    Department	VARCHAR(100)  NOT NULL,
    Faculty		VARCHAR(100)  NOT NULL,
    University	VARCHAR(100)  NOT NULL
);
GO

CREATE TABLE Date (
    DateID          INT PRIMARY KEY IDENTITY(1,1),
    Semester        VARCHAR(20)   NOT NULL,   -- Fall, Winter, Spring, Summer
    Year            INT           NOT NULL
);
GO

/*--- Fact Table ---*/
CREATE TABLE CourseOfferings (
    OfferingID	INT PRIMARY KEY IDENTITY(1,1),
    CourseID	INT NOT NULL REFERENCES Course(CourseID),
    InstructorID INT NOT NULL REFERENCES Instructor(InstructorID),
    StudentID	INT NOT NULL REFERENCES Student(StudentID),
    DateID INT NOT NULL REFERENCES Date(DateID),
    EnrollmentCount INT NOT NULL DEFAULT 1,   -- 1 per row; aggregate for totals
    CoursesOffered  INT NOT NULL DEFAULT 1    -- measure: count of course offerings
);
GO