SELECT m.Name, COUNT(t.ToyID)
FROM Toys t
	JOIN AgeRanges ar
		ON t.AgeRangeID = ar.AgeRangeID
	JOIN Manufacturers m
		ON t.ManufacturerID = m.ManufacturerID
WHERE ar.FromAge >= 5
AND ar.ToAge <= 10
GROUP BY m.Name