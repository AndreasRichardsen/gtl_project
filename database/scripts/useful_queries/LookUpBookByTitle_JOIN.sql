USE GTL
SELECT I.ISBN, I.Title, I.Author, I.ItemDescription, I.Publisher, I.YearPublishing, B.BookType, S.BookSubject
FROM (Item AS I JOIN Book AS B ON B.ISBN = I.ISBN JOIN BookSubject AS S ON S.ISBN = B.ISBN)
WHERE I.Title = 'LemonChiffon Nepal Isaac';