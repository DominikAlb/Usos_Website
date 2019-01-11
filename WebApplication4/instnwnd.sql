CREATE TABLE Exam(ID Integer IDENTITY(1, 1), NameOfSub NVARCHAR(64), Professor NVARCHAR(64), Date NVARCHAR(20), PRIMARY KEY(ID));
CREATE TABLE SubjectGroup(ID INTEGER NOT NULL IDENTITY(1, 1), ID_USER INTEGER NOT NULL FOREIGN KEY REFERENCES [User](ID), ID_EXAM INTEGER NOT NULL FOREIGN KEY REFERENCES Exam(Id), PRIMARY KEY(ID))
Create TABLE [Subject](ID Integer IDENTITY(1, 1), NameOfSub NVARCHAR(64), Professor NVARCHAR(64), ECTS INTEGER NOT NULL, Department NVARCHAR(32), PRIMARY KEY(ID)) 
CREATE TABLE [User](ID Integer IDENTITY(1, 1), Login NVARCHAR(64), Hash NVARCHAR(64), Data NVARCHAR(20), Flag Integer, ECTS Integer, Department NVARCHAR(32), PRIMARY KEY(ID))

Drop Table Exam
Drop Table SubjectGroup
Delete from SubjectGroup
INSERT INTO Exam(NameOfSub, Professor, Date) Values('Matematyka Dyskretna', 'Pani Bakłażan', '30-1-2019'), ('ASD', 'Pan Gniadek', '10-1-2019')

DELETE FROM [User]
DROP TABLE [User]
INSERT INTO [User] VALUES('ADMIN', '12345', '13-5-1997', 0, 50, 'WMII')
Insert into SubjectGroup(ID_USER, ID_EXAM) VALUES(1, 1)

Select * from SubjectGroup
SELECT * FROM [Subject]
select * from [User]
insert into [Subject](NameOfSub, Professor, ECTS, Department) Values('Matematyka Dyskretna', 'Pani Bakłażan', 4, 'FAIS'),('Analiza Matematyczna', 'Edward Szczypka', 6, 'WMII')
Drop Table [Subject]
Select * From [Subject]
DELETE FROM SubjectGroup

