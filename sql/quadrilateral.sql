USE projekt
GO

DECLARE @ABCD [dbo].[Quadrilateral]
--trzeba u�ywa� przecink�w a nie kropek? dziwne

SET @ABCD = '5,5 0|1,5 3|0,5 -5|-1,5 1'
SELECT @ABCD.ToString()

SELECT @ABCD.getA()
SELECT @ABCD.getB()
SELECT @ABCD.getC()
SELECT @ABCD.getD()

--SELECT @A.distance(@B)