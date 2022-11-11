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
@Contrase�a varchar(20)
AS
insert into Usuarios (Nombre, Apellido, Email, Contrase�a) output inserted.Id
values (@Nombre, @Apellido, @Email, @Contrase�a)
go;
