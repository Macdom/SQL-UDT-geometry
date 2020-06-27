USE projekt
GO

DECLARE @ABCD [dbo].[Quadrilateral]

SET @ABCD = '0 0|0 2|2 2|2 0'
SELECT @ABCD.ToString() AS ABCD

SELECT @ABCD.getA() AS A
SELECT @ABCD.getB() AS B
SELECT @ABCD.getC() AS C
SELECT @ABCD.getD() AS D

SELECT @ABCD.Area() AS Area

DECLARE @A [dbo].[Point]
DECLARE @B [dbo].[Point]
SET @A = '1,2 1'
SET @B = '-10,53 9,22'

SELECT @A.ToString() AS A
SELECT @B.ToString() AS B

SELECT @ABCD.IsInside(@A) AS 'Is A in ABCD?'
SELECT @ABCD.IsInside(@B) AS 'Is B in ABCD?'