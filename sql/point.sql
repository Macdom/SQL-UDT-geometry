USE projekt
GO

DECLARE @A [dbo].[Point]
DECLARE @B [dbo].[Point]

--trzeba u¿ywaæ przecinków a nie kropek? dziwne

SET @A = '5,5 0'
SET @B = '-1,53 9,22'
SELECT @A.ToString() AS A
SELECT @B.ToString() AS B

SELECT @A.getX() AS X_A
SELECT @A.getY() AS Y_A

SELECT @A.distance(@B) AS 'Distance (A, B)'