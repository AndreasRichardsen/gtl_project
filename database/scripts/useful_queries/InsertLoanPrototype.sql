USE GTL

DECLARE @isAllowed BIT,
	@ISBN NUMERIC(13) = '25841210000',
	@BARCODE NUMERIC(20) = '913719133000000',
	@CARDNO INT = '2',
	@ret_value_BookLimit BIT,
	@ret_val_IsLoanable BIT,
	@ret_val_BookCopy BIT,
	@ret_val_ValidCard BIT,
	@ret_val_CopyAvailable BIT;

EXEC	[dbo].[VerifyBookLimit]
		@cardno = @CARDNO,
		@loanable = @ret_value_BookLimit OUTPUT
	
IF (@ret_value_BookLimit = '1')
BEGIN 
	PRINT 'Book Limit OK'
END 
ELSE 
BEGIN 
	PRINT 'Book Limit NOT OK'
END 

EXEC	[dbo].[VerifyIsLoanable]
		@isbn = @ISBN,
		@loanable = @ret_val_IsLoanable OUTPUT

IF (@ret_val_IsLoanable = '1')
BEGIN 
	PRINT 'Book Type Is Loanable OK'
END 
ELSE 
BEGIN 
	PRINT 'Book Type Is NOT Loanable NOT OK'
END 

EXEC	[dbo].[VerifyBookCopy]
		@isbn = @ISBN,
		@barcode = @BARCODE,
		@exists = @ret_val_BookCopy OUTPUT

IF (@ret_val_BookCopy = '1')
BEGIN 
	PRINT 'Book ISBN and Copy Is OK'
END 
ELSE 
BEGIN 
	PRINT 'Book ISBN and Copy Is NOT OK'
END 

EXEC	[dbo].[VerifyCard]
		@cardno = @CARDNO,
		@exists = @ret_val_ValidCard OUTPUT

IF (@ret_val_ValidCard = '1')
BEGIN 
	PRINT 'Card Is OK'
END 
ELSE 
BEGIN 
	PRINT 'Card Is NOT OK'
END 

EXEC [dbo].[VerifyCopyAvailable]
	@barcode = @BARCODE,
	@available = @ret_val_CopyAvailable OUTPUT

IF (@ret_val_CopyAvailable = '1')
BEGIN 
	PRINT 'Copy is available to loan OK'
END 
ELSE 
BEGIN 
	PRINT 'Copy is NOT available to loan NOT OK'
END 


/*INSERT INTO Borrow (ISBN, Barcode, CardNo, IsReturned, DateBorrowed) 
VALUES ('78020000', '286238471000000', '1', 'false', GETDATE())*/