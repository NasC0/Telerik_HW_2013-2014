/*
Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). Don't forget to define  identity, primary key and appropriate foreign key. 
Issue few SQL statements to insert, update and delete of some data in the table.
Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record data, the new record data and the command (insert / update / delete).
*/

CREATE TABLE WorkHours(
	EntryID int IDENTITY PRIMARY KEY,
	EmployeeID int NOT NULL,
	Task varchar(100) NOT NULL,
	Hours float NOT NULL,
	Comments nvarchar(MAX),
	CONSTRAINT FK_WorkHours_Employee FOREIGN KEY (EmployeeID)
	REFERENCES Employees(EmployeeID)
)
GO

CREATE TABLE WorkHours_Log(
	EntryID int IDENTITY PRIMARY KEY,
	OldEmployeeID int,
	OldTask varchar(100),
	OldHours float,
	OldComments nvarchar(MAX),
	NewEmployeeID int,
	NewTask varchar(100),
	NewHours float,
	NewComments nvarchar(MAX),
	Operation varchar(50) NOT NULL
)
GO

CREATE TRIGGER trgAfterInsert ON WorkHours
FOR INSERT
AS
	declare @employeeID int;
	declare @task varchar(100);
	declare @hours float;
	declare @comments nvarchar(MAX);

	select @employeeID = i.EmployeeID from inserted i;
	select @task = i.Task from inserted i;
	select @hours = i.Hours from inserted i;
	select @comments = i.Comments from inserted i;

	INSERT INTO WorkHours_Log
		(OldEmployeeID, OldTask, OldHours, OldComments, 
			NewEmployeeID, NewTask, NewHours, NewComments, Operation)
		VALUES(NULL, NULL, NULL, NULL, @employeeID, @task, @hours, @comments, 'INSERT')
GO

CREATE TRIGGER trgAfterDelete ON WorkHours
FOR DELETE
AS
	declare @employeeID int;
	declare @task varchar(100);
	declare @hours float;
	declare @comments nvarchar(MAX);

	select @employeeID = i.EmployeeID from deleted i;
	select @task = i.Task from deleted i;
	select @hours = i.Hours from deleted i;
	select @comments = i.Comments from deleted i;

	INSERT INTO WorkHours_Log
		(OldEmployeeID, OldTask, OldHours, OldComments, 
			NewEmployeeID, NewTask, NewHours, NewComments, Operation)
		VALUES(@employeeID, @task, @hours, @comments, NULL, NULL, NULL, NULL, 'DELETE')
GO

CREATE TRIGGER trgAfterUpdate ON WorkHours
FOR UPDATE
AS
	declare @employeeID int;
	declare @task varchar(100);
	declare @hours float;
	declare @comments nvarchar(MAX);
	declare @newEmployeeID int;
	declare @newTask varchar(100);
	declare @newHours float;
	declare @newComments nvarchar(MAX);

	select @employeeID = i.EmployeeID from deleted i;
	select @task = i.Task from deleted i;
	select @hours = i.Hours from deleted i;
	select @comments = i.Comments from deleted i;
	select @newEmployeeID = i.EmployeeID from inserted i;
	select @newTask = i.Task from inserted i;
	select @newHours = i.Hours from inserted i;
	select @newComments = i.Comments from inserted i;

	INSERT INTO WorkHours_Log
		(OldEmployeeID, OldTask, OldHours, OldComments, 
			NewEmployeeID, NewTask, NewHours, NewComments, Operation)
		VALUES(@employeeID, @task, @hours, @comments, 
			@newEmployeeID, @newTask, @newHours, @newComments, 'UPDATE')
GO

INSERT INTO WorkHours
(EmployeeID, Task, Hours, Comments)
VALUES
(1, 'Be Batman', 1, 'Much Batman, very wow')

INSERT INTO WorkHours
(EmployeeID, Task, Hours, Comments)
VALUES
(1, 'Be boring and ordinary', 10000, 'Back to being bored out of my skull')

INSERT INTO WorkHours
(EmployeeID, Task, Hours, Comments)
VALUES
(2, 'Sleep on the job', 9, 'ZZZZZZZZZ')
GO

UPDATE WorkHours
SET Task = 'Go home'
WHERE Task = 'Sleep on the job'

UPDATE WorkHours
SET Task = 'Go home'
WHERE Task = 'Be boring and ordinary'

DELETE FROM WorkHours
WHERE Task = 'Go home'