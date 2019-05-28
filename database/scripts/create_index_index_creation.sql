USE GTL
CREATE NONCLUSTERED INDEX Borrow_Card_IsReturned ON Borrow (CardNo DESC, IsReturned ASC);
CREATE NONCLUSTERED INDEX Item_Title ON Item (Title DESC);
CREATE NONCLUSTERED INDEX Borrow_Barcode_IsReturned ON Borrow (Barcode DESC, IsReturned ASC);
CREATE NONCLUSTERED INDEX Book_Booktype ON Book (BookType DESC);