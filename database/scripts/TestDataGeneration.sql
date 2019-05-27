USE GTL_TEST

INSERT INTO Person (SSN, FName, LName, HomeAddress, CampusAddress, CardNo)
VALUES ('244466666', 'Tyrion', 'Lannister', 'Casterly Rock', 'UCN', '1');

INSERT INTO Member (SSN, Personification)
VALUES ('244466666', 'Professor');

INSERT INTO Item (ISBN, Title, Author, ItemDescription, Publisher, YearPublishing)
VALUES ('1234567890', 'The Communist Manifesto', 'Karl Marx', 'The book that started it all.', 'Publisher of Doom', '1940');

INSERT INTO Book (ISBN, BookType)
VALUES ('1234567890', 'Normal');

INSERT INTO BookCopy(ISBN, Barcode)
VALUES ('1234567890', '77777777788');