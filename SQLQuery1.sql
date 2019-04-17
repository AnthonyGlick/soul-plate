USE master;
GO

IF EXISTS(select * from sys.databases where name='soulplate')
DROP DATABASE soulplate;
GO

CREATE DATABASE soulplate
GO

USE soulplate;
GO
CREATE TABLE [users] (
	[username]		nvarchar(50)	NOT NULL UNIQUE,
	[password]		varchar(50)		NOT NULL,
	[salt]			varchar(50)		NOT NULL,
	[role]			varchar(50)		NULL,	
	[firstname]		nvarchar(50)	NULL,
	[lastname]		nvarchar(50)	NULL,
	[address1]		nvarchar(100)	NULL,
	[address2]		nvarchar(100),
	[city]			nvarchar(50)	NULL,
	[state]			nvarchar(50)	NULL,
	[postalcode]	char(5)			NULL,

	CONSTRAINT pk_user PRIMARY KEY (username),
);

CREATE TABLE [favorites] (
    [user_username]		nvarchar(50)	NOT NULL,
    [restaurant_id]		INT				NOT NULL,

	CONSTRAINT fk_favorites FOREIGN KEY ([user_username]) references users ([username])
);

INSERT INTO favorites(user_username, restaurant_id) VALUES('test',16962117)
SELECT TOP (1000) [user_username]
      ,[restaurant_id]
  FROM [soulplate].[dbo].[favorites]
