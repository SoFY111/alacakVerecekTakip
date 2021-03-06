USE [master]
GO
/****** Object:  Database [creditAndDebitProgram]    Script Date: 13.01.2020 10:35:18 ******/
CREATE DATABASE [creditAndDebitProgram]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'creditAndDebitProgram', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\creditAndDebitProgram.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'creditAndDebitProgram_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\creditAndDebitProgram_log.ldf' , SIZE = 5184KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [creditAndDebitProgram] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [creditAndDebitProgram].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [creditAndDebitProgram] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET ARITHABORT OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [creditAndDebitProgram] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [creditAndDebitProgram] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET  DISABLE_BROKER 
GO
ALTER DATABASE [creditAndDebitProgram] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [creditAndDebitProgram] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET RECOVERY FULL 
GO
ALTER DATABASE [creditAndDebitProgram] SET  MULTI_USER 
GO
ALTER DATABASE [creditAndDebitProgram] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [creditAndDebitProgram] SET DB_CHAINING OFF 
GO
ALTER DATABASE [creditAndDebitProgram] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [creditAndDebitProgram] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [creditAndDebitProgram] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'creditAndDebitProgram', N'ON'
GO
ALTER DATABASE [creditAndDebitProgram] SET QUERY_STORE = OFF
GO
USE [creditAndDebitProgram]
GO
/****** Object:  Table [dbo].[bankTypes]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bankTypes](
	[bankTypeId] [int] IDENTITY(1,1) NOT NULL,
	[bankTypeName] [nvarchar](99) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bankTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chequeInfo]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chequeInfo](
	[chequeId] [int] IDENTITY(1,1) NOT NULL,
	[chequeBankId] [int] NOT NULL,
	[chequeMoneyTypeId] [int] NOT NULL,
	[chequeBankCode] [int] NOT NULL,
	[chequeVal] [float] NOT NULL,
	[chequeDate] [datetime] NOT NULL,
	[chequeDrawingName] [nvarchar](255) NOT NULL,
	[chequeRecipientName] [nvarchar](255) NOT NULL,
	[chequeTransactionType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[chequeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[companyName]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companyName](
	[companyNameId] [int] IDENTITY(1,1) NOT NULL,
	[companyName] [nvarchar](55) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[companyNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customers]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[customerId] [int] IDENTITY(1,1) NOT NULL,
	[customerName] [nvarchar](155) NOT NULL,
	[customerSurname] [nvarchar](155) NOT NULL,
	[customerPhone] [nvarchar](20) NOT NULL,
	[customerMail] [nvarchar](155) NOT NULL,
	[customerAdress] [nvarchar](max) NOT NULL,
	[customerReliabilityVal] [int] NOT NULL,
	[customerPrivateSide] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customersDebtor]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customersDebtor](
	[debtorId] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[transactionTypeId] [int] NOT NULL,
	[debtType] [int] NOT NULL,
	[debtVal] [float] NOT NULL,
	[debtPaymentVal] [float] NOT NULL,
	[debtMoneyTypeId] [int] NOT NULL,
	[debtBankTypeId] [int] NOT NULL,
	[debtDate] [datetime] NOT NULL,
	[debtMinPaymentDate] [datetime] NOT NULL,
	[isPaid] [int] NOT NULL,
	[debtPaymentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[debtorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customersInstallment]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customersInstallment](
	[installmentId] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[transactionTypeId] [int] NOT NULL,
	[installmentCount] [int] NOT NULL,
	[installmentPaymentCounter] [int] NOT NULL,
	[installmentMinPaymentVal] [float] NOT NULL,
	[installmentPaymentVal] [float] NOT NULL,
	[installmentMinPaymentDate] [datetime] NOT NULL,
	[installmentPaymentDate] [datetime] NULL,
	[isPaid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[installmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customersMyDebt]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customersMyDebt](
	[myDebtId] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[transactionTypeId] [int] NOT NULL,
	[debtType] [int] NOT NULL,
	[debtVal] [float] NOT NULL,
	[debtPaymentVal] [float] NOT NULL,
	[debtMoneyTypeId] [int] NOT NULL,
	[debtBankTypeId] [int] NOT NULL,
	[debtDate] [datetime] NOT NULL,
	[debtMinPaymentDate] [datetime] NOT NULL,
	[isPaid] [int] NOT NULL,
	[debtPaymentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[myDebtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customersTransactionType]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customersTransactionType](
	[customerTransactionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[transactionType] [int] NOT NULL,
	[transactionDate] [datetime] NOT NULL,
	[isPaid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[customerTransactionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[degreeOfReliabilty]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[degreeOfReliabilty](
	[degreeOfRealiabiltyId] [int] IDENTITY(1,1) NOT NULL,
	[degreeOfReliabiltyDiscription] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[degreeOfRealiabiltyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[exchangeRateTable]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exchangeRateTable](
	[exchangeId] [int] IDENTITY(1,1) NOT NULL,
	[exchangedMoneyType] [int] NOT NULL,
	[exchangeMoneyType] [int] NOT NULL,
	[exchangeRate] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[exchangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[history]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[history](
	[historyId] [int] IDENTITY(1,1) NOT NULL,
	[historyType] [int] NOT NULL,
	[historyDiscription] [nvarchar](255) NOT NULL,
	[historyDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[historyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historyType]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historyType](
	[historyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[historyTypeDiscription] [nvarchar](55) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[historyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[installmentCount]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[installmentCount](
	[installmentId] [int] IDENTITY(1,1) NOT NULL,
	[installmentCount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[installmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[isAutoBackUp]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[isAutoBackUp](
	[isAutoBackUpId] [int] IDENTITY(1,1) NOT NULL,
	[isAutoBackup] [int] NOT NULL,
	[isAutoBackupFrequency] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[isAutoBackUpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[isFirstOpening]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[isFirstOpening](
	[firstOpeningId] [int] IDENTITY(1,1) NOT NULL,
	[isFirst] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[firstOpeningId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[moneyFunds]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[moneyFunds](
	[moneyFundsId] [int] IDENTITY(1,1) NOT NULL,
	[bankId] [int] NOT NULL,
	[moneyTypeId] [int] NOT NULL,
	[moneyVal] [float] NOT NULL,
	[transactionType] [int] NOT NULL,
	[transactionDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[moneyFundsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[moneyTypesTable]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[moneyTypesTable](
	[moneyId] [int] IDENTITY(1,1) NOT NULL,
	[moneyName] [nvarchar](20) NULL,
	[isBaseMoney] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[moneyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notes]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notes](
	[noteId] [int] IDENTITY(1,1) NOT NULL,
	[notePriority] [int] NOT NULL,
	[noteTitle] [nvarchar](55) NOT NULL,
	[noteDiscription] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[noteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sumAllMoney]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sumAllMoney](
	[sumAllMoneyId] [int] IDENTITY(1,1) NOT NULL,
	[moneyTypeId] [int] NOT NULL,
	[sumMoneyVal] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sumAllMoneyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[theme]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[theme](
	[themeId] [int] IDENTITY(1,1) NOT NULL,
	[theme] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[themeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 13.01.2020 10:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](55) NOT NULL,
	[userPass] [nvarchar](55) NOT NULL,
	[userLastPass] [nvarchar](55) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bankTypes] ON 

INSERT [dbo].[bankTypes] ([bankTypeId], [bankTypeName]) VALUES (2009, N'Ziraat Bankası')
SET IDENTITY_INSERT [dbo].[bankTypes] OFF
SET IDENTITY_INSERT [dbo].[companyName] ON 

INSERT [dbo].[companyName] ([companyNameId], [companyName]) VALUES (1, N'DNT Yazılım')
SET IDENTITY_INSERT [dbo].[companyName] OFF
SET IDENTITY_INSERT [dbo].[degreeOfReliabilty] ON 

INSERT [dbo].[degreeOfReliabilty] ([degreeOfRealiabiltyId], [degreeOfReliabiltyDiscription]) VALUES (7, N'Çok İyi')
INSERT [dbo].[degreeOfReliabilty] ([degreeOfRealiabiltyId], [degreeOfReliabiltyDiscription]) VALUES (8, N'İyi')
INSERT [dbo].[degreeOfReliabilty] ([degreeOfRealiabiltyId], [degreeOfReliabiltyDiscription]) VALUES (9, N'Orta')
INSERT [dbo].[degreeOfReliabilty] ([degreeOfRealiabiltyId], [degreeOfReliabiltyDiscription]) VALUES (10, N'Kötü')
INSERT [dbo].[degreeOfReliabilty] ([degreeOfRealiabiltyId], [degreeOfReliabiltyDiscription]) VALUES (11, N'Çok Kötü')
SET IDENTITY_INSERT [dbo].[degreeOfReliabilty] OFF
SET IDENTITY_INSERT [dbo].[historyType] ON 

INSERT [dbo].[historyType] ([historyTypeId], [historyTypeDiscription]) VALUES (1, N'Hızlı İşlemler')
INSERT [dbo].[historyType] ([historyTypeId], [historyTypeDiscription]) VALUES (2, N'Cari İşlemler')
INSERT [dbo].[historyType] ([historyTypeId], [historyTypeDiscription]) VALUES (3, N'Kasa İşlemleri')
INSERT [dbo].[historyType] ([historyTypeId], [historyTypeDiscription]) VALUES (4, N'Diğer İşlemler')
SET IDENTITY_INSERT [dbo].[historyType] OFF
SET IDENTITY_INSERT [dbo].[installmentCount] ON 

INSERT [dbo].[installmentCount] ([installmentId], [installmentCount]) VALUES (1, 0)
INSERT [dbo].[installmentCount] ([installmentId], [installmentCount]) VALUES (3, 3)
INSERT [dbo].[installmentCount] ([installmentId], [installmentCount]) VALUES (4, 5)
INSERT [dbo].[installmentCount] ([installmentId], [installmentCount]) VALUES (5, 6)
INSERT [dbo].[installmentCount] ([installmentId], [installmentCount]) VALUES (6, 9)
INSERT [dbo].[installmentCount] ([installmentId], [installmentCount]) VALUES (7, 12)
INSERT [dbo].[installmentCount] ([installmentId], [installmentCount]) VALUES (8, 24)
SET IDENTITY_INSERT [dbo].[installmentCount] OFF
SET IDENTITY_INSERT [dbo].[isAutoBackUp] ON 

INSERT [dbo].[isAutoBackUp] ([isAutoBackUpId], [isAutoBackup], [isAutoBackupFrequency]) VALUES (1, 0, 99)
SET IDENTITY_INSERT [dbo].[isAutoBackUp] OFF
SET IDENTITY_INSERT [dbo].[isFirstOpening] ON 

INSERT [dbo].[isFirstOpening] ([firstOpeningId], [isFirst]) VALUES (1, 1)
SET IDENTITY_INSERT [dbo].[isFirstOpening] OFF
SET IDENTITY_INSERT [dbo].[moneyTypesTable] ON 

INSERT [dbo].[moneyTypesTable] ([moneyId], [moneyName], [isBaseMoney]) VALUES (1028, N'Türk Lirası', 1)
SET IDENTITY_INSERT [dbo].[moneyTypesTable] OFF
SET IDENTITY_INSERT [dbo].[sumAllMoney] ON 

INSERT [dbo].[sumAllMoney] ([sumAllMoneyId], [moneyTypeId], [sumMoneyVal]) VALUES (1015, 1028, 0)
SET IDENTITY_INSERT [dbo].[sumAllMoney] OFF
SET IDENTITY_INSERT [dbo].[theme] ON 

INSERT [dbo].[theme] ([themeId], [theme]) VALUES (1, 0)
SET IDENTITY_INSERT [dbo].[theme] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([userId], [userName], [userPass], [userLastPass]) VALUES (1, N'admin', N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[users] OFF
ALTER TABLE [dbo].[exchangeRateTable]  WITH CHECK ADD FOREIGN KEY([exchangedMoneyType])
REFERENCES [dbo].[moneyTypesTable] ([moneyId])
GO
ALTER TABLE [dbo].[exchangeRateTable]  WITH CHECK ADD FOREIGN KEY([exchangeMoneyType])
REFERENCES [dbo].[moneyTypesTable] ([moneyId])
GO
ALTER TABLE [dbo].[exchangeRateTable]  WITH CHECK ADD FOREIGN KEY([exchangedMoneyType])
REFERENCES [dbo].[moneyTypesTable] ([moneyId])
GO
ALTER TABLE [dbo].[exchangeRateTable]  WITH CHECK ADD FOREIGN KEY([exchangeMoneyType])
REFERENCES [dbo].[moneyTypesTable] ([moneyId])
GO
USE [master]
GO
ALTER DATABASE [creditAndDebitProgram] SET  READ_WRITE 
GO
