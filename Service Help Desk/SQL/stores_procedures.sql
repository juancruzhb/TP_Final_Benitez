
CREATE PROCEDURE sp_obtenerCategorias
AS
SELECT ID, NOMBRE FROM Categorias
GO

CREATE PROCEDURE sp_obtenerPrioridades
AS
BEGIN
SELECT ID, NOMBRE FROM Prioridades
END
GO

CREATE PROCEDURE sp_InsertarUsuario
@Apellido varchar(50),
@Nombre varchar(50),
@Email varchar(100),
@Contraseña varchar(20)
AS
BEGIN
insert into Usuarios (Nombre, Apellido, Email, Contraseña) output inserted.Id
values (@Nombre, @Apellido, @Email, @Contraseña)
END

go

CREATE PROCEDURE sp_InsertarTicket
@Asunto varchar(200),
@Mensaje varchar(2000),
@IdCategoria int,
@IdPrioridad int,
@FechaCreacion datetime,
@IdEstado int,
@IdUsuario int,
@Celular varchar(20),
@IdAgente int
AS
BEGIN
INSERT INTO Tickets(Asunto, Mensaje, IdCategoria, IdPrioridad, FechaCreacion, IdEstado, IdUsuario, Celular, IdAgente) 
OUTPUT inserted.Id
VALUES(@Asunto, @Mensaje, @IdCategoria, @IdPrioridad, @FechaCreacion, @IdEstado, @IdUsuario, @Celular, @IdAgente)
END

go

Create Procedure Sp_InsertarAgente(
@Apellido varchar(20), 
@Nombre varchar(30), 
@Email varchar(30), 
@Contraseña varchar(30), 
@Tipo int
)
AS
Begin
	Insert into Agentes (Apellido, Nombre, Email, Contraseña, Tipo)
	Output inserted.Id
	values(@Apellido, @Nombre, @Email, @Contraseña, @Tipo)
End
