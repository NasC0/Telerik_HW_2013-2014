SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.JobTitle,
Employees.Salary, Employees.HireDate, Managers.FirstName, Managers.LastName
FROM TelerikAcademy.dbo.Employees
	LEFT OUTER JOIN TelerikAcademy.dbo.Employees AS Managers
		ON Employees.ManagerID = Managers.EmployeeID