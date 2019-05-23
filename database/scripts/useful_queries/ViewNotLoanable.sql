USE GTL
SELECT I.ISBN, I.Title, I.Author, I.ItemDescription, I.Publisher, I.YearPublishing
FROM Item AS I 
WHERE I.ISBN NOT IN ( SELECT B.ISBN 
					FROM Book AS B
					WHERE B.BookType = 'Normal');