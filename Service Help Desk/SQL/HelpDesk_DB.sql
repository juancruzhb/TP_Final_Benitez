CREATE DATABASE HelpDesk_DB

go

USE HelpDesk_DB

CREATE TABLE Categorias(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Activo BIT NOT NULL
)
GO

CREATE TABLE Prioridades(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombre Varchar(50) NOT NULL,
	Activo bit not null
)
GO

CREATE TABLE Estados(
	Id int not null primary key IDENTITY(1,1),
	Nombre varchar(50) not null
)

GO

CREATE TABLE Usuarios(
	Id int not null primary key identity(1,1),
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Email varchar(100) not null unique,
	Contraseņa varchar(20) not null
	)
GO

CREATE TABLE Tickets(
	Id int not null primary key IDENTITY(1,1),
	Asunto varchar(200) not null,
	Mensaje varchar(2000) not null,
	IdCategoria int not null FOREIGN KEY REFERENCES Categorias(Id),
	IdPrioridad int not null FOREIGN KEY REFERENCES Prioridades(Id),
	FechaCreacion datetime,
	IdEstado int not null,
	IdUsuario int not null foreign key references usuarios(Id),
	Celular varchar(20) not null
)



