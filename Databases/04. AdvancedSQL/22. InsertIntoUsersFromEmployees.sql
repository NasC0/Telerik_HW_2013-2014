INSERT INTO Users
	(Username, Password, FullName, LastLogin)
SELECT LOWER(LEFT(e.FirstName, 1) + e.LastName), LOWER(LEFT(e.FirstName, 1) + e.LastName), 
	MIN(e.FirstName + ' ' + e.LastName), NULL
FROM Employees e
WHERE LEN(LOWER(LEFT(e.FirstName, 1) + e.LastName)) >= 5
GROUP BY LOWER(LEFT(e.FirstName, 1) + e.LastName)