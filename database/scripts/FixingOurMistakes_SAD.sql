USE GTL 
DELETE 
FROM Borrow
WHERE ISBN IN ( SELECT B.ISBN 
					FROM Book AS B
					WHERE B.BookType != 'Normal');