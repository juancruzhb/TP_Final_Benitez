USE [HelpDesk_DB]

GO

INSERT INTO Categorias (Nombre, Activo) VALUES
('Impresoras',1),
('Actualizaciones', 1),
('Instalaciones', 1),
('Antivirus',1),
('Sistema X',1)

INSERT INTO Prioridades(Nombre, Activo) VALUES
('Bajo',1),
('Medio',1),
('Alto',1),
('Urgente',1)