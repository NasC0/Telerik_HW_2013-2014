/*
	Doesn't work
*/

BEGIN TRAN
ALTER TABLE Employees
	DROP CONSTRAINT FK_Employees_Employees

ALTER TABLE Employees
	DROP CONSTRAINT FK_Employees_Addresses

ALTER TABLE Employees
	DROP CONSTRAINT FK_Employees_Departments

ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees

ALTER TABLE Employees
	ADD CONSTRAINT FK_Employees_Employees
	FOREIGN KEY (ManagerID) REFERENCES Employees
	ON DELETE NO ACTION

ALTER TABLE Employees
	ADD CONSTRAINT FK_Employees_Addresses
	FOREIGN KEY (AddressID) REFERENCES Addresses(AddressID)
	ON DELETE CASCADE

ALTER TABLE Employees
	ADD CONSTRAINT FK_Employees_Departments
	FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
	ON DELETE CASCADE

ALTER TABLE Departments
	ADD CONSTRAINT FK_Departments_Employees
	FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID)
	ON DELETE CASCADE

DELETE FROM Employees
WHERE DepartmentID = 
	(SELECT DepartmentID FROM Departments
	 WHERE Name = 'Sales')

ROLLBACK TRAN