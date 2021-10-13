CREATE DATABASE PRG282_Project_Database
GO

USE PRG282_Project_Database
CREATE TABLE tblStudents
(
	StudentNumber INT IDENTITY(1,1) PRIMARY KEY,
	StudentName VARCHAR(30) NOT NULL,
	StudentSurname VARCHAR(30) NOT NULL,
	StudentImage VARBINARY(MAX),
	DOB DATETIME NOT NULL,
	Gender VARCHAR NOT NULL,
	Phone VARCHAR(10) NOT NULL,
	StudentAddress VARCHAR(50),
)
GO

CREATE TABLE tblModules
(
	ModuleID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	ModuleCode VARCHAR(10) NOT NULL,
	ModuleName VARCHAR(30) NOT NULL,
	ModuleDescription VARCHAR(75) NOT NULL,
	ResourceLinks VARCHAR(100) NOT NULL,
)

GO

INSERT INTO tblStudents
VALUES
('Joubert', 'Van Zyl', NULL, GETDATE(), 'M', '0120987654', 'Some address'),
('Xillon', 'Fick', NULL, GETDATE(), 'M', '0120983637', 'Some address'),
('Josh', 'Hoffman', NULL, GETDATE(), 'M', '0121234567', 'Some address'),
('Francois', 'Birkholtz', NULL, GETDATE(), 'M', '0120987654', 'Some address'),
('Joubert', 'Van Zyl', NULL, GETDATE(), 'M', '0120987654', 'Some address')

GO

INSERT INTO tblModules
VALUES
('PRG282', 'Programming 282', 'Some programming description', 'https://www.youtube.com/watch?v=dQw4w9WgXcQ'),
('LPR281', 'Linear Programming 282', 'Some LPR description', 'https://www.youtube.com/watch?v=dQw4w9WgXcQ'),
('WPR282', 'Web Programming 282', 'Some Web description', 'https://www.youtube.com/watch?v=dQw4w9WgXcQ'),
('MAT281', 'Mathematics 281', 'Some maths description', 'https://www.youtube.com/watch?v=dQw4w9WgXcQ')

GO

ALTER TABLE tblModules
ADD StudentNumber INT REFERENCES tblStudents(StudentNumber)

GO

CREATE PROCEDURE spGetStudents
AS
BEGIN
	SELECT * FROM tblStudents
END

GO

CREATE PROCEDURE spAddStudent
(
	@Name VARCHAR(30),
	@Surname VARCHAR(30),
	@DOB DATETIME,
	@Gender VARCHAR,
	@Phone VARCHAR(10),
	@Address VARCHAR(50)
)
AS
BEGIN
	INSERT INTO tblStudents
	VALUES (@Name, @Surname, NULL, @DOB, @Gender, @Phone, @Address)
END

GO

CREATE PROCEDURE spUpdateStudent
(
	@ID INT,
	@Name VARCHAR(30),
	@Surname VARCHAR(30),
	@DOB DATETIME,
	@Gender VARCHAR,
	@Phone VARCHAR(10),
	@Address VARCHAR(50)
)
AS
BEGIN
	UPDATE tblStudents
	SET StudentName = @Name, StudentSurname = @Surname, DOB = @DOB, Gender = @Gender, Phone = @Phone, StudentAddress = @Address
	WHERE StudentNumber = @ID
END

GO

CREATE PROCEDURE spSearchStudent
(
	@ID INT
)
AS
BEGIN
	SELECT * FROM tblStudents
	WHERE StudentNumber = @ID
END

GO

CREATE PROCEDURE spDeleteStudent
(
	@ID INT
)
AS
BEGIN
	DELETE FROM tblStudents
	WHERE StudentNumber = @ID
END

GO

CREATE PROCEDURE spGetStudentModules
(
	@ID INT
)
AS
BEGIN
	SELECT * FROM tblModules
	WHERE tblModules.StudentNumber = @ID
END


GO

USE PRG282_Project_Database
GO

CREATE PROCEDURE spRemoveStudentModules
(
	@ID INT
)
AS
BEGIN
	DELETE FROM tblModules
	WHERE StudentNumber = @ID
END

GO

CREATE PROCEDURE spAddModuleToStudent
(
	@ID INT,
	@ModuleCode VARCHAR(10),
	@ModuleName VARCHAR(30),
	@ModuleDescription VARCHAR(75),
	@ResourceLinks VARCHAR(100)
)
AS
BEGIN
	INSERT INTO tblModules
	VALUES
	(@ModuleCode, @ModuleName, @ModuleDescription, @ResourceLinks, @ID);
END

USE PRG282_Project_Database
GO

CREATE PROCEDURE spGetNewlyAddedStudent
AS
BEGIN
	SELECT TOP 1 StudentNumber FROM tblStudents ORDER BY StudentNumber DESC 
END