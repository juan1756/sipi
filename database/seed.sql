/* Borrado */

PRINT 'BORRANDO CONTENIDO DE LAS TABLAS'

PRINT ''
PRINT 'Tabla: MedioAudiovisualOrador'
DELETE FROM MedioAudiovisualOrador
GO

PRINT ''
PRINT 'Tabla: Orador'
DELETE FROM Orador
DBCC CHECKIDENT ('[Orador]', RESEED, 1);
GO

PRINT ''
PRINT 'Tabla: InsumoMedioAudiovisual'
DELETE FROM InsumoMedioAudiovisual
-- no tiene identity

PRINT ''
PRINT 'Tabla: MedioAudiovisual'
DELETE FROM MedioAudiovisual
DBCC CHECKIDENT ('[MedioAudiovisual]', RESEED, 1);
GO

PRINT ''
PRINT 'Tabla: Categoria'
DELETE FROM Categoria
-- no tiene identity

PRINT ''
PRINT 'Tabla: Tipo'
DELETE FROM Tipo
DBCC CHECKIDENT ('[Tipo]', RESEED, 1);
GO

PRINT ''
PRINT 'Tabla: Insumo'
DELETE FROM Insumo
-- no tiene identity

PRINT ''
PRINT 'Tabla: Pedido'
DELETE FROM Pedido
DBCC CHECKIDENT ('[Pedido]', RESEED, 1);
GO

PRINT ''
PRINT 'Tabla: OperadorRol'
DELETE FROM OperadorRol
-- no tiene identity

PRINT ''
PRINT 'Tabla: Rol'
DELETE FROM Rol
-- no tiene identity

PRINT ''
PRINT 'Tabla: Usuario'
DELETE FROM Usuario
DBCC CHECKIDENT ('[Usuario]', RESEED, 1);
GO

PRINT ''
PRINT 'Tabla: Localidad'
DELETE FROM Localidad
-- no tiene identity

PRINT ''
PRINT 'Tabla: Provincia'
DELETE FROM Provincia
-- no tiene identity

PRINT ''
PRINT '------------------------------------------------------------------------'
PRINT ''

/* Inserciones */

PRINT 'INSERTANDO CONTENIDO EN LAS TABLAS'

PRINT ''
PRINT 'Tabla: Provincia'
INSERT INTO Provincia (Id, Nombre) VALUES (1, 'Buenos Aires')
GO

PRINT ''
PRINT 'Tabla: Localidad'
INSERT INTO Localidad (Id, Nombre, Provincia_Id) VALUES (1, 'Buenos Aires', 1)
GO
INSERT INTO Localidad (Id, Nombre, Provincia_Id) VALUES (2, 'La Plata', 1)
GO

PRINT ''
PRINT 'Tabla: Usuario'
SET IDENTITY_INSERT Usuario ON 
GO
INSERT INTO Usuario (Id, Email, Nombre, Apellido, Contrasena, ContrasenaNueva, Hash, Altura, Calle, Telefono, Piso, Discriminator, Localidad_Id, Provincia_Id) VALUES (1, 'miembro@mail.com', 'Don', 'Miembro', '1234', NULL, NULL, 4792, 'Charcas', '47760626', '1', 'Miembro', 1, 1)
GO
INSERT INTO Usuario (Id, Email, Nombre, Apellido, Contrasena, ContrasenaNueva, Hash, Altura, Calle, Telefono, Piso, Discriminator, Localidad_Id, Provincia_Id) VALUES (2, 'operador_contenido@mail.com', 'Don', 'Operador Contenido', '1234', NULL, NULL, NULL, NULL, NULL, NULL, 'Operador', NULL, NULL)
GO
INSERT INTO Usuario (Id, Email, Nombre, Apellido, Contrasena, ContrasenaNueva, Hash, Altura, Calle, Telefono, Piso, Discriminator, Localidad_Id, Provincia_Id) VALUES (3, 'operador_packaging@mail.com', 'Don', 'Operador Packaging', '1234', NULL, NULL, NULL, NULL, NULL, NULL, 'Operador', NULL, NULL)
GO
INSERT INTO Usuario (Id, Email, Nombre, Apellido, Contrasena, ContrasenaNueva, Hash, Altura, Calle, Telefono, Piso, Discriminator, Localidad_Id, Provincia_Id) VALUES (4, 'operador_vendedor@mail.com', 'Don', 'Operador Vendedor', '1234', NULL, NULL, NULL, NULL, NULL, NULL, 'Operador', NULL, NULL)
GO
SET IDENTITY_INSERT Usuario OFF
GO

PRINT ''
PRINT 'Tabla: Rol'
INSERT INTO Rol (Id, Nombre, Descripcion) VALUES (1, 'Contenido', 'Lorem ipsum dolo e amet')
GO
INSERT INTO Rol (Id, Nombre, Descripcion) VALUES (2, 'Packaging', 'Lorem ipsum dolo e amet')
GO
INSERT INTO Rol (Id, Nombre, Descripcion) VALUES (3, 'Vendedor', 'Lorem ipsum dolo e amet')
GO

PRINT ''
PRINT 'Tabla: OperadorRol'
INSERT INTO OperadorRol (Operador_Id, Rol_Id) VALUES (2, 1)
GO
INSERT INTO OperadorRol (Operador_Id, Rol_Id) VALUES (3, 2)
GO
INSERT INTO OperadorRol (Operador_Id, Rol_Id) VALUES (4, 3)
GO

PRINT ''
PRINT 'Tabla: Pedido'
SET IDENTITY_INSERT Pedido ON
GO
INSERT INTO Pedido (Numero, CantidadPedido, Estado, Fecha, PrecioTotal, FechaEntregado, Miembro_Id) VALUES (1, 3, 1, '20170707', 10.5, null, 1)
GO
INSERT INTO Pedido (Numero, CantidadPedido, Estado, Fecha, PrecioTotal, FechaEntregado, Miembro_Id) VALUES (2, 3, 1, '20170707', 150.5, null, 1)
GO
INSERT INTO Pedido (Numero, CantidadPedido, Estado, Fecha, PrecioTotal, FechaEntregado, Miembro_Id) VALUES (3, 1, 1, '20170708', 210.5, null, 1)
GO
SET IDENTITY_INSERT Pedido OFF
GO

PRINT ''
PRINT 'Tabla: Insumo'
INSERT INTO Insumo (PedidoNumero, Numero, Precio, Tamano) VALUES (1, 1, 10.5, 80)
GO
INSERT INTO Insumo (PedidoNumero, Numero, Precio, Tamano) VALUES (2, 2, 100.5, 870)
GO
INSERT INTO Insumo (PedidoNumero, Numero, Precio, Tamano) VALUES (2, 3, 50, 120)
GO
INSERT INTO Insumo (PedidoNumero, Numero, Precio, Tamano) VALUES (3, 4, 10.5, 80)
GO
INSERT INTO Insumo (PedidoNumero, Numero, Precio, Tamano) VALUES (3, 5, 50, 120)
GO
INSERT INTO Insumo (PedidoNumero, Numero, Precio, Tamano) VALUES (3, 6, 150, 970)
GO

PRINT ''
PRINT 'Tabla: Tipo'
SET IDENTITY_INSERT Tipo ON 
INSERT INTO Tipo (Id, Nombre) VALUES (1,'Audio')
GO
INSERT INTO Tipo (Id, Nombre) VALUES (2,'Video')
GO
SET IDENTITY_INSERT Tipo OFF 

PRINT ''
PRINT 'Tabla: Categoria'
INSERT INTO Categoria (Id, Nombre, FechaCreacion, Operador_Id) VALUES (1, 'Matrimonio', '20170501', 2);
GO
INSERT INTO Categoria (Id, Nombre, FechaCreacion, Operador_Id) VALUES (2, 'Juventud', '20170501', 2);
GO
INSERT INTO Categoria (Id, Nombre, FechaCreacion, Operador_Id) VALUES (3, 'Actualidad', '20170501', 2);
GO

PRINT ''
PRINT 'Tabla: MedioAudiovisual'
SET IDENTITY_INSERT MedioAudiovisual ON 
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (1, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (2, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (3, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (4, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (5, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (6, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (7, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (8, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (9, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (10, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (11, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (12, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (13, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (14, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (15, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (16, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (17, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (18, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (19, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (20, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (21, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (22, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (23, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (24, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (25, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (26, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (27, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (28, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (29, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (30, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (31, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (32, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (33, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (34, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (35, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (36, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (37, '20160506', 'Paz en la Familia', 'https://www.youtube.com/watch?v=ynIgAMOd-SI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (38, '20150119', 'Adolescencia y Juventud', 'https://www.youtube.com/watch?v=kjx0Y3QBOKw', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (39, '20170322', 'Paternidad y felicidad', 'https://www.youtube.com/watch?v=Ibb3ex25G6E', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (40, '20140722', 'Fidelidad', 'https://www.youtube.com/watch?v=PIVDZTyt6z0', 20, 1, 2)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (41, '20140722', 'Canción de Navidad', 'https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/334269643&amp;auto_play=false&amp;hide_related=true&amp;show_comments=false&amp;show_user=true&amp;show_reposts=false&amp;visual=true', 20, 3, 1)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (42, '20140722', 'Canción de Navidad', 'https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/334269643&amp;auto_play=false&amp;hide_related=true&amp;show_comments=false&amp;show_user=true&amp;show_reposts=false&amp;visual=true', 20, 3, 1)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (43, '20140722', 'Canción de Navidad', 'https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/334269643&amp;auto_play=false&amp;hide_related=true&amp;show_comments=false&amp;show_user=true&amp;show_reposts=false&amp;visual=true', 20, 3, 1)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (44, '20140722', 'Canción de Navidad', 'https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/334269643&amp;auto_play=false&amp;hide_related=true&amp;show_comments=false&amp;show_user=true&amp;show_reposts=false&amp;visual=true', 20, 3, 1)
GO
INSERT INTO MedioAudiovisual (Id, FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES (45, '20140722', 'Canción de Navidad', 'https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/334269643&amp;auto_play=false&amp;hide_related=true&amp;show_comments=false&amp;show_user=true&amp;show_reposts=false&amp;visual=true', 20, 3, 1)
GO
SET IDENTITY_INSERT MedioAudiovisual OFF

PRINT ''
PRINT 'Tabla: InsumoMedioAudiovisual'
INSERT INTO InsumoMedioAudiovisual VALUES (1, 1, 3)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (2, 2, 2)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (2, 2, 4)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (2, 3, 1)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (2, 3, 5)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (3, 4, 3)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (3, 5, 1)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (3, 5, 5)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (3, 6, 1)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (3, 6, 2)
GO
INSERT INTO InsumoMedioAudiovisual VALUES (3, 6, 4)
GO

PRINT ''
PRINT 'Tabla: Orador'
SET IDENTITY_INSERT Orador ON
INSERT INTO Orador (Id, Nombre, Apellido, FechaCreacion, Operador_Id) VALUES (1, 'Hernán', 'Rodriguez', '20140105', 2)
GO
INSERT INTO Orador (Id, Nombre, Apellido, FechaCreacion, Operador_Id) VALUES (2, 'Mariela', 'Lentini', '20140105', 2)
GO
INSERT INTO Orador (Id, Nombre, Apellido, FechaCreacion, Operador_Id) VALUES (3, 'Paola', 'Casas', '20140105', 2)
GO
INSERT INTO Orador (Id, Nombre, Apellido, FechaCreacion, Operador_Id) VALUES (4, 'José',  'King', '20140105', 2)
GO
INSERT INTO Orador (Id, Nombre, Apellido, FechaCreacion, Operador_Id) VALUES (5, 'Carla', 'Mayada', '20140105', 2)
GO
SET IDENTITY_INSERT Orador OFF

PRINT ''
PRINT 'Tabla: MedioAudiovisualOrador'
INSERT INTO MedioAudiovisualOrador (MedioAudiovisual_Id, Orador_Id)
VALUES 
	(1,1),(2,2),(3,3),(4,4),(5,5),
	(6,1),(7,2),(8,3),(9,4),(10,5),
	(11,1),(12,2),(13,3),(14,4),(15,5),
	(16,1),(17,2),(18,3),(19,4),(20,5),
	(21,1),(22,2),(23,3),(24,4),(25,5),
	(26,1),(27,2),(28,3),(29,4),(30,5),
	(31,1),(32,2),(33,3),(34,4),(35,5),
	(36,1),(37,2),(38,3),(39,4),(40,5),
	(41,4),(42,4),(43,4),(44,4),(45,4)

/* Verficación */

--SELECT * FROM Provincia
--SELECT * FROM Localidad
--SELECT * FROM Usuario
--SELECT * FROM Rol
--SELECT * FROM OperadorRol
--SELECT * FROM Pedido
--SELECT * FROM Insumo
--SELECT * FROM Tipo
--SELECT * FROM Categoria
--SELECT * FROM MedioAudiovisual
--SELECT * FROM InsumoMedioAudiovisual
--SELECT * FROM Orador