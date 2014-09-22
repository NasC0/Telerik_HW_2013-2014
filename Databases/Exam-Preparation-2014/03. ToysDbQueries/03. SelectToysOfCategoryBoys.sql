SELECT t.Name, t.Price, t.Color
FROM Toys t
	JOIN Categories c
		ON t.CategoryID = c.CategoryID
WHERE c.Name = 'boys'
OR t.CategoryID IS NULL