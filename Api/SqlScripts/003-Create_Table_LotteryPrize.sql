CREATE TABLE LotteryPrize(
	Id INT IDENTITY(1,1),
	LotteryId INT NOT NULL,
	[Name] nvarchar(200) NOT NULL,
	Price INT NOT NULL,
	CONSTRAINT PK_LotteryPrize PRIMARY KEY (Id),
	CONSTRAINT FK_Lottery__LotteryPrize FOREIGN KEY (LotteryId) REFERENCES Lottery(Id)
)