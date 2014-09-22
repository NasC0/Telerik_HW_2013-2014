SELECT Employees.EmployeeID AS 'EmployeeID',
Employees.FirstName AS 'Employee First Name', Employees.LastName AS 'Employee Last Name',
Managers.EmployeeID, Managers.FirstName, Managers.LastName
FROM TelerikAcademy.dbo.Employees
	JOIN TelerikAcademy.dbo.Employees AS Managers 
		ON Employees.ManagerID = Managers.EmployeeID
ORDER BY Employees.EmployeeID