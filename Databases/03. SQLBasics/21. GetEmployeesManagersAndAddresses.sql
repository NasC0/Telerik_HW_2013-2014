SELECT Employees.FirstName, Employees.LastName, Employees.JobTitle,
Employees.Salary, Employees.HireDate,
Managers.FirstName as [Manager First Name], Managers.LastName as [Manager Last Name],
Addresses.AddressText
FROM TelerikAcademy.dbo.Employees
	JOIN TelerikAcademy.dbo.Employees AS Managers 
		ON Employees.ManagerID = Managers.EmployeeID
	JOIN TelerikAcademy.dbo.Addresses 
		ON Employees.AddressID = Addresses.AddressID
ORDER BY Managers.EmployeeID ASC