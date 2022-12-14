
CREATE PROCEDURE sp_obtenerCategorias
AS
SELECT ID, NOMBRE, Activo FROM Categorias
GO

CREATE PROCEDURE sp_obtenerPrioridades
AS
BEGIN
SELECT ID, NOMBRE, Activo FROM Prioridades
END
GO

CREATE PROCEDURE sp_obtenerEstados
AS
BEGIN
SELECT ID, NOMBRE, Activo FROM Estados
END
GO

CREATE PROCEDURE sp_InsertarUsuario
@Apellido varchar(50),
@Nombre varchar(50),
@Email varchar(100),
@Contraseņa varchar(20)
AS
BEGIN
insert into Usuarios (Nombre, Apellido, Email, Contraseņa) output inserted.Id
values (@Nombre, @Apellido, @Email, @Contraseņa)
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
@Contraseņa varchar(30), 
@Tipo int
)
AS
Begin
	Insert into Agentes (Apellido, Nombre, Email, Contraseņa, Tipo)
	Output inserted.Id
	values(@Apellido, @Nombre, @Email, @Contraseņa, @Tipo)
End

go

Create procedure SP_LeerRespuesta(
@IdTicket int,
@EsAgente int
)
As
Begin
	Update Tickets_Respuestas set Leido = 1 where IdTicket = @IdTicket and EsAgente = @EsAgente
end

go