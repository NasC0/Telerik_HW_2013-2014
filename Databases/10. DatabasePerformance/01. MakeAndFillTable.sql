CREATE TABLE LogTable(
	LogID int NOT NULL IDENTITY PRIMARY KEY,
	Text nvarchar(MAX) NOT NULL,
	Date datetime NOT NULL
)
GO

SET NOCOUNT ON
DECLARE @Rows int = 10000000;
WHILE (@Rows > 0)
BEGIN
	DECLARE @Text nvarchar(100) = 'Text' + CONVERT(nvarchar(100), @Rows) + ': ' + 
		CONVERT(nvarchar(100), NEWID())
	DECLARE @Date datetime = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 4650), '2000-01-01')
	INSERT INTO LogTable
	(Text, Date)
	VALUES (@Text, @Date)
	SET @Rows = @Rows - 1
END
SET NOCOUNT OFF