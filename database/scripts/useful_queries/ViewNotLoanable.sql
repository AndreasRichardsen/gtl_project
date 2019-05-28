USE GTL
DECLARE @StartTime datetime, @EndTime datetime
SELECT @StartTime = GETDATE()
SELECT I.ISBN, I.Title, I.Author, I.ItemDescription, I.Publisher, I.YearPublishing
FROM Item AS I 
WHERE I.ISBN NOT IN ( SELECT B.ISBN 
					FROM Book AS B
					WHERE B.BookType = 'Normal');
SELECT @EndTime = GETDATE()
SELECT DATEDIFF(ms, @StartTime, @EndTime) AS [Duration in microseconds]