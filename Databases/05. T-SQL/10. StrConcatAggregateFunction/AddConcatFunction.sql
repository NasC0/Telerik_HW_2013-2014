CREATE ASSEMBLY StrConcatAssembly FROM 'C:\StrConcatSolution.dll';
GO
CREATE AGGREGATE StrConcat (@input nvarchar(200)) RETURNS nvarchar(max)
EXTERNAL NAME StrConcatAssembly.StrConcat;