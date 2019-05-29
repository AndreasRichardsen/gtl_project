USE GTL
DECLARE @ISBN NUMERIC(13) = '19190630000',
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
EXEC	[dbo].[VerifyIsLoanable]
		@isbn = @ISBN,
		@loanable = @ret_val_IsLoanable OUTPUT
EXEC	[dbo].[VerifyBookCopy]
		@isbn = @ISBN,
		@barcode = @BARCODE,
		@exists = @ret_val_BookCopy OUTPUT
EXEC	[dbo].[VerifyCard]
		@cardno = @CARDNO,
		@exists = @ret_val_ValidCard OUTPUT
EXEC [dbo].[VerifyCopyAvailable]
	@barcode = @BARCODE,
	@available = @ret_val_CopyAvailable OUTPUT
IF(@ret_val_BookCopy = '1' AND @ret_val_CopyAvailable = '1' AND 
	@ret_val_IsLoanable = '1' AND @ret_val_ValidCard = '1' AND @ret_value_BookLimit = '1')
BEGIN 
	INSERT INTO Borrow (ISBN, Barcode, CardNo, IsReturned, DateBorrowed) 
	VALUES (@ISBN, @BARCODE, @CARDNO, 'false', GETDATE())
	PRINT 'LOAN INSERTED SUCCESFULLY!'
END 
ELSE 
BEGIN 
	PRINT 'CANNOT INSERT LOAN!'
END 