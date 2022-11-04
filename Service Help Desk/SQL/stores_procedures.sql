USE [HelpDesk_DB]
go

CREATE PROCEDURE sp_obtenerCategorias
AS
SELECT ID, NOMBRE FROM Categorias
GO;