USE TimeTrackerDatabase

CREATE TABLE [dbo].[Customer]
(
	[CustomerID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[Project]
(
	[ProjectID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [CustomerID] INT NULL, 
    [CostPerHour] DECIMAL(10, 2) NULL
)

CREATE TABLE [dbo].[TimeRecord]
(
	[TimeRecordID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL,
	[ProjectID] INT NULL, 
    [Start] DATETIME NOT NULL, 
    [End] DATETIME NULL, 
    [Comments] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[User]
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL
)
