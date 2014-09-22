USE Northwind
GO

CREATE PROCEDURE usp_GetTotalIncome(
	@supplier varchar(50), @startDate datetime, @endDate datetime)
AS
BEGIN
	SELECT SUM(od.UnitPrice * od.Quantity)
	FROM Suppliers s
		JOIN Products p
			ON p.SupplierID = s.SupplierID
		JOIN [Order Details] od
			ON p.ProductID = od.ProductID
		JOIN Orders o
			ON od.OrderID = o.OrderID
	WHERE s.CompanyName = @supplier
	AND o.OrderDate BETWEEN @startDate AND @endDate
END
GO