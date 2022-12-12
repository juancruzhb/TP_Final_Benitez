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
	Contraseña varchar(20) not null
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
go

CREATE TABLE Tipo_Agentes(
	Id int not null primary key identity(1,1),
	Tipo varchar(20) not null
)
go

Create TABLE Agentes(
	Id int not null primary key IDENTITY(100,10),
	Apellido varchar(20) not null,
	Nombre varchar(30) not null, 
	Email varchar(30) not null,
	Contraseña varchar(30) not null,
	Tipo int not null foreign key references Tipo_Agentes(Id),
	Estado bit not null
)
go

Create Table Tickets_Respuestas(
	Id int not null primary key Identity(1,1),
	Fecha datetime not null,
	IdTicket int not null foreign key references Tickets(Id),
	Respuesta varchar(2000) not null,
	Emisor int not null foreign key references Agentes(Id)
)
go
alter table Tickets
Add IdAgente int null foreign key references Agentes(Id)

go
alter table tickets_respuestas
add Tipo int not null 