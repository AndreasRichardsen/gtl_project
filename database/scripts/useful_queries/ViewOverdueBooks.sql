USE GTL
SELECT Bo.DateBorrowed, I.Title, P.Fname + ' ' + P.LName AS 'Full Name', DATEDIFF(DAY, Bo.DateBorrowed, GETDATE()) AS 'Days Overdue'
FROM (Borrow AS Bo JOIN Item AS I ON Bo.ISBN = I.ISBN JOIN Person AS P ON Bo.CardNo = P.CardNo)
WHERE Bo.CardNo IN ( SELECT P.CardNo
						FROM Person as P 
						WHERE (P.SSN IN (SELECT M.SSN
										FROM Member AS M
										WHERE (M.Personification = 'Student' AND Bo.IsReturned = 'false' AND (DATEDIFF(DAY, Bo.DateBorrowed, GETDATE()) >= 21)
										OR 
										(M.Personification = 'Professor' AND Bo.IsReturned = 'false' AND (DATEDIFF(MONTH, Bo.DateBorrowed, GETDATE()) >= 3))))));