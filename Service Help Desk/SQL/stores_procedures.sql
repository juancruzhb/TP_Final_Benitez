USE [HelpDesk_DB]
go

CREATE PROCEDURE sp_obtenerCategorias
AS
SELECT ID, NOMBRE FROM Categorias
GO;

CREATE PROCEDURE sp_obtenerPrioridades
AS
SELECT ID, NOMBRE FROM Prioridades
GO;

CREATE PROCEDURE sp_InsertarUsuario
@Apellido varchar(50),
@Nombre varchar(50),
@Email varchar(100),
@Contraseña varchar(20)
AS
insert into Usuarios (Nombre, Apellido, Email, Contraseña) output inserted.Id
values (@Nombre, @Apellido, @Email, @Contraseña)
go;

CREATE PROCEDURE sp_InsertarTicket
@Asunto varchar(200),
@Mensaje varchar(2000),
@IdCategoria int,
@IdPrioridad int,
@FechaCreacion datetime,
@IdEstado int,
@IdUsuario int,
@Celular varchar(20)
AS
INSERT INTO Tickets(Asunto, Mensaje, IdCategoria, IdPrioridad, FechaCreacion, IdEstado, IdUsuario, Celular) 
OUTPUT inserted.Id
VALUES(@Asunto, @Mensaje, @IdCategoria, @IdPrioridad, @FechaCreacion, @IdEstado, @IdUsuario, @Celular)

