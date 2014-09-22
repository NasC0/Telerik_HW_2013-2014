SELECT FirstName, LastName, MiddleName, Departments.Name AS DepartmentName, JobTitle, Employees.ManagerID, 
HireDate, Salary, AddressID
FROM TelerikAcademy.dbo.Employees
	JOIN TelerikAcademy.dbo.Departments 
		ON Employees.DepartmentID = Departments.DepartmentID
WHERE Departments.Name = 'Sales'
OR Departments.Name = 'Finance'
AND YEAR(Employees.HireDate) BETWEEN 1995 AND 2005