USE master;
GO;

IF EXISTS(select * from sys.databases where name='resturanttinder')
DROP DATABASE resturanttinder;
GO;

CREATE DATABASE resturanttinder
GO;

USE resturanttinder;
GO;

CREATE TABLE [users] (
	[id]			int				IDENTITY (1, 1) NOT NULL,
	[username]		nvarchar(50)	NOT NULL,
	[password]		varchar(50)		NOT NULL,
	[salt]			varchar(50)		NOT NULL,
	[firstname]		nvarchar(50)	NOT NULL,
	[lastname]		nvarchar(50)	NOT NULL,
	[addressid]		int				NOT NULL,
	CONSTRAINT fk_address FOREIGN KEY (addressid),
	CONSTRAINT pk_user PRIMARY KEY (id),
);

CREATE TABLE [address] (
	[id]			int				IDENTITY (1, 1) NOT NULL,
	[address1]		nvarchar(100)	NOT NULL,
	[address2]		nvarchar(100),
	[city]			nvarchar(50)	NOT NULL,
	[state]			nvarchar(50)	NOT NULL,
	[postalcode]	char(5)			NOT NULL,
	CONSTRAINT pk_address PRIMARY KEY (id),
);


