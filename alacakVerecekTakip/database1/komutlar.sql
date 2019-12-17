--moneyTypesTable tablosunu oluþturma
CREATE TABLE moneyTypesTable(
   -- IDENTITY (baþlangýç deðeri, artýþ miktarý)
   moneyId   INT  IDENTITY(1,1) NOT NULL,
   moneyName NVARCHAR (20),     
   PRIMARY KEY (moneyId)
);

--exchangeRateTable tablosu oluþturma
CREATE TABLE exchangeRateTable(
   exchangeId   INT  IDENTITY(1,1) NOT NULL,
   exchangedMoneyType INT,     
   exchangeMoneyType INT, 
   exahngeRate FLOAT,
   PRIMARY KEY (exchangeId)
);

--exchangeRateTable tablosundaki exchangedMoneyType kolonunu tabloyu oluþtururken yapmadýðmýz için burada FK yapýyoruz
ALTER TABLE exchangeRateTable
ADD FOREIGN KEY (exchangedMoneyType) REFERENCES moneyTypesTable(moneyId)  

--exchangeRateTable tablosundaki exchangeMoneyType kolonunu tabloyu oluþtururken yapmadýðmýz için burada FK yapýyoruz
ALTER TABLE exchangeRateTable
ADD FOREIGN KEY (exchangeMoneyType) REFERENCES moneyTypesTable(moneyId)  

--companyName adýnda bir tablo oluþturduk
CREATE TABLE companyName(
   companyNameId INT IDENTITY(1,1) NOT NULL,
   companyName nvarchar(55) NOT NULL,
   PRIMARY KEY (companyNameId)
);

--theme adýnda bir tablo oluþturduk
CREATE TABLE theme(
   themeId INT IDENTITY(1,1) NOT NULL,
   theme int NOT NULL,
   PRIMARY KEY (themeId)
);

-- users adýnda bir tablo oluþturduk
CREATE TABLE users(
   userId INT IDENTITY(1,1) NOT NULL,
   userName nvarchar(55) NOT NULL,
   userPass nvarchar(55) NOT NULL,
   userLastPass nvarchar(55) NOT NULL,
   PRIMARY KEY (userId)
);

-- history adýnda bir tablo oluþturduk
CREATE TABLE history(
   historyId INT IDENTITY(1,1) NOT NULL,
   historyType int NOT NULL,
   historyDescription nvarchar(100) NOT NULL,
   historyDate datetime NOT NULL,
   PRIMARY KEY (historyId),
);

CREATE TABLE historyType(
   historyTypeId INT IDENTITY(1,1) NOT NULL,
   historyTypeDiscription nvarchar(55) NOT NULL,
   PRIMARY KEY (historyTypeId),
);


-- notes adýnda bir tablo oluþturduk
CREATE TABLE notes(
   noteId INT IDENTITY(1,1) NOT NULL,
   notePriority int NOT NULL,
   noteTitle nvarchar(55) NOT NULL,
   noteDiscription nvarchar(255) NOT NULL,
   PRIMARY KEY (noteId),
);

-- reliabilty adýnda bir tablo oluþturduk
CREATE TABLE degreeOfReliabilty(
   degreeOfRealiabiltyId INT IDENTITY(1,1) NOT NULL,
   degreeOfRealiabiltyDiscription nvarchar(50) NOT NULL,
   PRIMARY KEY (degreeOfRealiabiltyId)
);

-- isAutoBackup adýnda bir tablo oluþturduk
CREATE TABLE isAutoBackUp(
   isAutoBackUpId INT IDENTITY(1,1) NOT NULL,
   isAutoBackup int NOT NULL,
   isAutoBackupFrequency int NOT NULL,
   PRIMARY KEY (isAutoBackUpId)
);

EXEC sys.sp_dropdevice 'sqlBackUP1';  --dump device'ý siler
SELECT * FROM sys.backup_devices --dumpListesini gösterir


DROP DATABASE creditAndDebitProgram
--.bak uzantýlý dosyayý geri yüklenme
RESTORE DATABASE creditAndDebitProgram
    FROM DISK = 'C:\CreditAndDebitDBBackup\creditAndDebitBackup20191126T1828.bak'

--.bak uzantýlý dosyayý farklý isimle geri yüklenme
RESTORE DATABASE HRTest FROM DISK='C:\CreditAndDebitDBBackup\creditAndDebitBackup20191126T1828.bak'
	WITH
		MOVE 'creditAndDebitProgram' TO 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\creditAndDebitProgramAgain.mdf',
		MOVE 'creditAndDebitProgram_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\creditAndDebitProgramAgain_log.ldf'

--Veri Tabanýný Kullananlarý gösterir
select * from sys.sysprocesses where dbid=DB_ID('creditAndDebitProgram')

--Veri Tabanýný Kullananlarý Öldürür
declare @Sql varchar(1000), @veritabaniadi varchar(100) 
set @veritabaniadi = 'creditAndDebitProgram' 
set @Sql = ''  
select  @Sql = @Sql + 'kill ' + convert(char(10), spid) + ' ' 
from    master.dbo.sysprocesses 
where   db_name(dbid) = @veritabaniadi
     and 
     dbid <> 0 
     and 
     spid <> @@spid 
exec(@Sql)
GO


--moneyTypesTable sütun ekleme
ALTER TABLE moneyTypesTable ADD isBaseMoney int;

--exchangeRateTable sütun ekleme
ALTER TABLE exchangeRateTable ADD isRated int;

-- bankTypes adýnda bir tablo oluþturduk
CREATE TABLE bankTypes(
   bankTypeId INT IDENTITY(1,1) NOT NULL,
   bankTypeName nvarchar(99) NOT NULL,
   PRIMARY KEY (bankTypeId)
);

-- moneyFunds adýnda bir tablo oluþturduk
CREATE TABLE moneyFunds(
   moneyFundsId INT IDENTITY(1,1) NOT NULL,
   bankId int NOT NULL,
   moneyTypeId int NOT NULL,
   moneyVal float NOT NULL,
   transactionType int NOT NULL,
   transactionDate datetime NOT NULL,
   PRIMARY KEY (moneyFundsId)
);

-- sumAllMoney adýnda bir tablo oluþturduk
CREATE TABLE sumAllMoney(
   sumAllMoneyId INT IDENTITY(1,1) NOT NULL,
   moneyTypeId int NOT NULL,
   sumMoneyVal float NOT NULL,
   PRIMARY KEY (sumAllMoneyId)
);


-- chequeInfo adýnda bir tablo oluþturduk
CREATE TABLE chequeInfo(
   chequeId INT IDENTITY(1,1) NOT NULL,
   chequeBankId int NOT NULL,
   chequeMoneyTypeId int NOT NULL,
   chequeBankCode int NOT NULL,
   chequeVal float NOT NULL,
   chequeDate datetime NOT NULL,
   chequeDrawingName nvarchar(255) NOT NULL,
   chequeRecipientName nvarchar(255) NOT NULL,
   chequeTransactionType int NOT NULL,
   PRIMARY KEY (chequeId)
);



INSERT INTO chequeInfo VALUES(1, 1, 6002, 1000, '2019-01-1 00:00:00.00', 'Metin DÝNÇTÜRK', 'Hakan DÝNÇTÜRK', 1)












-- DNT Yazýlým Alacak Verecek Takip Otomasyonu Veri Tabaný Oluþturma Kodlarý