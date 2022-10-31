CREATE DATABASE HelpDesk_DB

USE HelpDesk_DB

CREATE TABLE Categorias(
	Id int NOT NULL PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	Activo BIT NOT NULL
)
GO

CREATE TABLE Prioridades(
	Id int NOT NULL PRIMARY KEY,
	Nombre Varchar(50) NOT NULL,
	Activo bit not null
)
GO

CREATE TABLE Estados(
	Id int not null primary key,
	Nombre varchar(50) not null
)

GO

CREATE TABLE Tickets(
	Id bigint not null primary key,
	Asunto varchar(200) not null,
	Descripcion varchar(2000) not null,
	IdCategoria int not null FOREIGN KEY REFERENCES Categorias(Id),
	IdPrioridad int not null FOREIGN KEY REFERENCES Prioridades(Id),
	FechaCreacion date,
	IdEstado int not null
)

