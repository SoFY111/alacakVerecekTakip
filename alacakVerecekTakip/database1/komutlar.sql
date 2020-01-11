--moneyTypesTable tablosunu olu�turma
CREATE TABLE moneyTypesTable(
   -- IDENTITY (ba�lang�� de�eri, art�� miktar�)
   moneyId   INT  IDENTITY(1,1) NOT NULL,
   moneyName NVARCHAR (20),     
   PRIMARY KEY (moneyId)
);

--exchangeRateTable tablosu olu�turma
CREATE TABLE exchangeRateTable(
   exchangeId   INT  IDENTITY(1,1) NOT NULL,
   exchangedMoneyType INT,     
   exchangeMoneyType INT, 
   exahngeRate FLOAT,
   PRIMARY KEY (exchangeId)
);

--exchangeRateTable tablosundaki exchangedMoneyType kolonunu tabloyu olu�tururken yapmad��m�z i�in burada FK yap�yoruz
ALTER TABLE exchangeRateTable
ADD FOREIGN KEY (exchangedMoneyType) REFERENCES moneyTypesTable(moneyId)  

--exchangeRateTable tablosundaki exchangeMoneyType kolonunu tabloyu olu�tururken yapmad��m�z i�in burada FK yap�yoruz
ALTER TABLE exchangeRateTable
ADD FOREIGN KEY (exchangeMoneyType) REFERENCES moneyTypesTable(moneyId)  

--companyName ad�nda bir tablo olu�turduk
CREATE TABLE companyName(
   companyNameId INT IDENTITY(1,1) NOT NULL,
   companyName nvarchar(55) NOT NULL,
   PRIMARY KEY (companyNameId)
);

--theme ad�nda bir tablo olu�turduk
CREATE TABLE theme(
   themeId INT IDENTITY(1,1) NOT NULL,
   theme int NOT NULL,
   PRIMARY KEY (themeId)
);

-- users ad�nda bir tablo olu�turduk
CREATE TABLE users(
   userId INT IDENTITY(1,1) NOT NULL,
   userName nvarchar(55) NOT NULL,
   userPass nvarchar(55) NOT NULL,
   userLastPass nvarchar(55) NOT NULL,
   PRIMARY KEY (userId)
);

-- history ad�nda bir tablo olu�turduk
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


-- notes ad�nda bir tablo olu�turduk
CREATE TABLE notes(
   noteId INT IDENTITY(1,1) NOT NULL,
   notePriority int NOT NULL,
   noteTitle nvarchar(55) NOT NULL,
   noteDiscription nvarchar(255) NOT NULL,
   PRIMARY KEY (noteId),
);

-- reliabilty ad�nda bir tablo olu�turduk
CREATE TABLE degreeOfReliabilty(
   degreeOfRealiabiltyId INT IDENTITY(1,1) NOT NULL,
   degreeOfRealiabiltyDiscription nvarchar(50) NOT NULL,
   PRIMARY KEY (degreeOfRealiabiltyId)
);

-- isAutoBackup ad�nda bir tablo olu�turduk
CREATE TABLE isAutoBackUp(
   isAutoBackUpId INT IDENTITY(1,1) NOT NULL,
   isAutoBackup int NOT NULL,
   isAutoBackupFrequency int NOT NULL,
   PRIMARY KEY (isAutoBackUpId)
);

EXEC sp_addumpdevice 'disk', 'bckp2', 'C:\\Users\\metinDnt\\Desktop\\backup'

EXEC sys.sp_dropdevice 'sqlBackUP1';  --dump device'� siler
SELECT * FROM sys.backup_devices --dumpListesini g�sterir


DROP DATABASE creditAndDebitProgram
--.bak uzant�l� dosyay� geri y�klenme
RESTORE DATABASE creditAndDebitProgram
    FROM DISK = 'C:\CreditAndDebitDBBackup\creditAndDebitBackup20191126T1828.bak'

--.bak uzant�l� dosyay� farkl� isimle geri y�klenme
RESTORE DATABASE HRTest FROM DISK='C:\CreditAndDebitDBBackup\creditAndDebitBackup20191126T1828.bak'
	WITH
		MOVE 'creditAndDebitProgram' TO 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\creditAndDebitProgramAgain.mdf',
		MOVE 'creditAndDebitProgram_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\creditAndDebitProgramAgain_log.ldf'

--Veri Taban�n� Kullananlar� g�sterir
select * from sys.sysprocesses where dbid=DB_ID('creditAndDebitProgram')

--Veri Taban�n� Kullananlar� �ld�r�r
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


--moneyTypesTable s�tun ekleme
ALTER TABLE moneyTypesTable ADD isBaseMoney int;

--exchangeRateTable s�tun ekleme
ALTER TABLE exchangeRateTable ADD isRated int;

-- bankTypes ad�nda bir tablo olu�turduk
CREATE TABLE bankTypes(
   bankTypeId INT IDENTITY(1,1) NOT NULL,
   bankTypeName nvarchar(99) NOT NULL,
   PRIMARY KEY (bankTypeId)
);

-- moneyFunds ad�nda bir tablo olu�turduk
CREATE TABLE moneyFunds(
   moneyFundsId INT IDENTITY(1,1) NOT NULL,
   bankId int NOT NULL,
   moneyTypeId int NOT NULL,
   moneyVal float NOT NULL,
   transactionType int NOT NULL,
   transactionDate datetime NOT NULL,
   PRIMARY KEY (moneyFundsId)
);

-- sumAllMoney ad�nda bir tablo olu�turduk
CREATE TABLE sumAllMoney(
   sumAllMoneyId INT IDENTITY(1,1) NOT NULL,
   moneyTypeId int NOT NULL,
   sumMoneyVal float NOT NULL,
   PRIMARY KEY (sumAllMoneyId)
);


-- chequeInfo ad�nda bir tablo olu�turduk
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

-- customers ad�nda bir tablo olu�turduk
CREATE TABLE customers(
   customerId INT IDENTITY(1,1) NOT NULL,
   customerName nvarchar(155) NOT NULL,
   customerSurname nvarchar(155) NOT NULL,
   customerPhone nvarchar(20) NOT NULL,
   customerMail nvarchar(155) NOT NULL,
   customerAdress nvarchar(max) NOT NULL,
   customerReliabilityVal int NOT NULL,
   PRIMARY KEY (customerId)
);


-- customerTranactionType ad�nda bir tablo olu�turduk
CREATE TABLE customersTransactionType(
   customerTransactionTypeId int IDENTITY(1,1) NOT NULL,
   customerId int NOT NULL,
   transactionType int NOT NULL,
   transactionDate datetime NOT NULL,
   isPaid int,
   PRIMARY KEY (customerTransactionTypeId)
);

-- myDebt ad�nda bir tablo olu�turduk
CREATE TABLE customersMyDebt(
   myDebtId int IDENTITY(1,1) NOT NULL,
   customerId int NOT NULL,
   transactionTypeId int NOT NULL,
   debtType int NOT NULL,
   debtVal float NOT NULL,
   debtPaymentVal float NOT NULL,
   debtMoneyTypeId int NOT NULL,
   debtBankTypeId int NOT NULL,
   debtDate datetime NOT NULL,
   debtMinPaymentDate datetime NOT NULL,
   debtPaymentDate datetime NOT NULL,
   isPaid int NOT NULL,
   PRIMARY KEY (myDebtId)
);

-- debtor ad�nda bir tablo olu�turduk
CREATE TABLE customersDebtor(
   debtorId int IDENTITY(1,1) NOT NULL,
   customerId int NOT NULL,
   transactionTypeId int NOT NULL,
   debtType int NOT NULL,
   debtVal float NOT NULL,
   debtPaymentVal float NOT NULL,
   debtMoneyTypeId int NOT NULL,
   debtBankTypeId int NOT NULL,
   debtDate datetime NOT NULL,
   debtMinPaymentDate datetime NOT NULL,
   isPaid int NOT NULL,
   debtPaymentDate datetime NOT NULL,
   PRIMARY KEY (debtorId)
);

-- customersInstatllment ad�nda bir tablo olu�turduk
CREATE TABLE customersInstallment(
   installmentId INT IDENTITY(1,1) NOT NULL,
   customerId int NOT NULL,
   transactionTypeId int NOT NULL,
   installmentCount int NOT NULL,
   installmentPaymentCounter int NOT NULL,
   installmentMinPaymentVal float NOT NULL,
   installmentPaymentVal float NOT NULL,
   installmentMinPaymentDate datetime NOT NULL,
   isPaid int NOT NULL,
   installmentPaymentDate datetime,
   PRIMARY KEY (installmentId)
);

-- installmentCount ad�nda bir tablo olu�turduk
CREATE TABLE installmentCount(
   installmentId INT IDENTITY(1,1) NOT NULL,
   installmentCount int NOT NULL,
   PRIMARY KEY (installmentId)
);

CREATE TABLE isFirstOpening(
   firstOpeningId INT IDENTITY(1,1) NOT NULL,
   isFirst int NOT NULL,
   PRIMARY KEY (firstOpeningId)
);










-- DNT Yaz�l�m Alacak Verecek Takip Otomasyonu Veri Taban� Olu�turma Kodlar�