SELECT FirstName, LastName, JobTitle,
Towns.Name AS 'Town Name', AddressText AS 'Address'
FROM TelerikAcademy.dbo.Employees
	JOIN TelerikAcademy.dbo.Addresses 
		ON Employees.AddressID = Addresses.AddressID
	JOIN TelerikAcademy.dbo.Towns 
		ON Addresses.TownID = Towns.TownID