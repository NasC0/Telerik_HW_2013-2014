USE BankSystemDB
GO

CREATE FUNCTION ufn_CalculateInterest(
	@sum money, @yearlyInterest real, @months int)
	RETURNS money
AS
BEGIN
	DECLARE @resultSum money;
	SET @resultSum = (@sum * @months) * @yearlyInterest
	RETURN @resultSum + @sum
END
GO