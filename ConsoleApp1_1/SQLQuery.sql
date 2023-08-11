
use B1;

GO
CREATE PROCEDURE SumMedian AS
BEGIN
    SELECT TOP (1) Percentile_Disc (0.5)
           WITHIN GROUP (ORDER BY RandReal)
           OVER() as median FROM Table3
	select sum(RandInteger) as sum from Table3
END;

exec SumMedian;