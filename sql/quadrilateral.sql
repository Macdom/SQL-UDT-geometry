USE projekt
GO

DECLARE @ABCD [dbo].[Quadrilateral]
--trzeba u¿ywaæ przecinków a nie kropek? dziwne

SET @ABCD = '0 0|2 0|2 2|2 0'
SELECT @ABCD.ToString() AS ABCD

SELECT @ABCD.getA() AS A
SELECT @ABCD.getB() AS B
SELECT @ABCD.getC() AS C
SELECT @ABCD.getD() AS D

SELECT @ABCD.Area() AS Area
