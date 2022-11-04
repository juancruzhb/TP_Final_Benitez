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
