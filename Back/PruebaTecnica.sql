Create Database PruebaTecnica;
go
	use PruebaTecnica;
go

CREATE TABLE Municipio
(
	Id int identity(1,1) PRIMARY KEY NOT NULL ,
	[Name] VARCHAR(100) UNIQUE NOT NULL	
) 
go
CREATE TABLE IdentificationType
(
	Id int identity(1,1) PRIMARY KEY NOT NULL ,
	[Type] VARCHAR(100) UNIQUE NOT NULL
) 
go
Create table [User](
	Id int identity(1,1)  PRIMARY KEY NOT NULL,	
	IdentificationTypeId int not null REFERENCES  IdentificationType(Id) ON UPDATE CASCADE,
	IdentificationNumber VARCHAR(15) UNIQUE NOT NULL,
	CompanyName VARCHAR(100),
	FirstName VARCHAR(50),
	SecondName VARCHAR(50),
	FirstLastName VARCHAR(50),
	SecondLastName VARCHAR(50),
	MunicipioId int REFERENCES  Municipio(Id) ON UPDATE CASCADE,
	Email VARCHAR(80) NULL,
	[CellPhone] VARCHAR(15) NOT NULL,
)
go
-- INSERT  --

INSERT INTO Municipio 
VALUES('COLOMBIA - ANTIOQUIA - MEDELLIN'),
('COLOMBIA - BOGOTA - FUNZA'),
('COLOMBIA - BOGOTA - FACATATIVA'),
('COLOMBIA - MAGDALENA - FUNDACION');

go
 
INSERT INTO IdentificationType 
VALUES('Persona juridica'),
('Persona Natural'),
('Persona Extranjera');
GO
INSERT INTO [dbo].[User]
           ([IdentificationTypeId]
           ,[IdentificationNumber]
           ,[CompanyName]
           ,[MunicipioId]
           ,[Address] 
		   ,[CellPhone])
     VALUES
           (1
           ,'900674335'
           ,'CONSULTORES WEB S.A.S' 
           ,1
           ,'CARRERA-43-A-1--85INT 613' 
           ,'2684917')