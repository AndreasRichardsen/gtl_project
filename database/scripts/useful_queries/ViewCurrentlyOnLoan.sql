USE GTL
SELECT I.ISBN, I.Title, Bo.Barcode, Bo.DateBorrowed, P.FName, P.LName
FROM (Borrow AS Bo JOIN Item AS I ON Bo.ISBN = I.ISBN JOIN Person AS P ON Bo.CardNo = P.CardNo)
WHERE Bo.IsReturned = 'false';