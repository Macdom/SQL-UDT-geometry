USE projekt
GO

DECLARE @A [dbo].[Point]
DECLARE @B [dbo].[Point]

--trzeba u¿ywaæ przecinków a nie kropek? dziwne

SET @A = '5,5 0'
SELECT @A.ToString()

SELECT @A.getX()
SELECT @A.getY()

SET @B = '-1,53 9,22'
SELECT @A.distance(@B)