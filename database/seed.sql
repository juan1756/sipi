INSERT INTO Provincia (Id, Nombre) VALUES (1, 'Buenos Aires')
GO

INSERT INTO Localidad (Id, Nombre, Provincia_Id) VALUES (1, 'Buenos Aires', 1)
GO
INSERT INTO Localidad (Id, Nombre, Provincia_Id) VALUES (2, 'La Plata', 1)
GO

SET IDENTITY_INSERT Usuario ON 
GO
INSERT INTO Usuario (Id, Email, Nombre, Apellido, Contrasena, ContrasenaNueva, Hash, Altura, Calle, Direccion, Telefono, Piso, Discriminator, Localidad_Id, Provincia_Id) VALUES (1, 'miembro@mail.com', 'Don', 'Miembro', '1234', NULL, NULL, 4792, 'Charcas', 'Direccion', '47760626', '1', 'Miembro', 1, 1)
GO
INSERT INTO Usuario (Id, Email, Nombre, Apellido, Contrasena, ContrasenaNueva, Hash, Altura, Calle, Direccion, Telefono, Piso, Discriminator, Localidad_Id, Provincia_Id) VALUES (2, 'operador_contenido@mail.com', 'Don', 'Operador Contenido', '1234', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Operador', NULL, NULL)
GO
INSERT INTO Usuario (Id, Email, Nombre, Apellido, Contrasena, ContrasenaNueva, Hash, Altura, Calle, Direccion, Telefono, Piso, Discriminator, Localidad_Id, Provincia_Id) VALUES (3, 'operador_packaging@mail.com', 'Don', 'Operador Packaging', '1234', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Operador', NULL, NULL)
GO
INSERT INTO Usuario (Id, Email, Nombre, Apellido, Contrasena, ContrasenaNueva, Hash, Altura, Calle, Direccion, Telefono, Piso, Discriminator, Localidad_Id, Provincia_Id) VALUES (4, 'operador_vendedor@mail.com', 'Don', 'Operador Vendedor', '1234', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Operador', NULL, NULL)
GO
SET IDENTITY_INSERT Usuario OFF
GO

INSERT INTO Rol (Id, Nombre, Descripcion) VALUES (1, 'Contenido', 'Lorem ipsum dolo e amet')
GO
INSERT INTO Rol (Id, Nombre, Descripcion) VALUES (2, 'Packaging', 'Lorem ipsum dolo e amet')
GO
INSERT INTO Rol (Id, Nombre, Descripcion) VALUES (3, 'Vendedor', 'Lorem ipsum dolo e amet')
GO

INSERT INTO OperadorRol (Operador_Id, Rol_Id) VALUES (2, 1)
GO
INSERT INTO OperadorRol (Operador_Id, Rol_Id) VALUES (3, 2)
GO
INSERT INTO OperadorRol (Operador_Id, Rol_Id) VALUES (4, 3)
GO

SET IDENTITY_INSERT Pedido ON
GO
INSERT INTO Pedido (Numero, CantidadPedido, Estado, Fecha, PrecioTotal, FechaEntregado, Miembro_Id) VALUES (1, 3, 1, '2017-07-07', 10.5, null, 1)
GO
INSERT INTO Pedido (Numero, CantidadPedido, Estado, Fecha, PrecioTotal, FechaEntregado, Miembro_Id) VALUES (2, 3, 1, '2017-07-07', 150.5, null, 1)
GO
INSERT INTO Pedido (Numero, CantidadPedido, Estado, Fecha, PrecioTotal, FechaEntregado, Miembro_Id) VALUES (3, 1, 1, '2017-07-08', 210.5, null, 1)
GO
SET IDENTITY_INSERT Pedido OFF
GO

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

INSERT INTO Tipo (Nombre) VALUES ('Audio')
GO
INSERT INTO Tipo (Nombre) VALUES ('Video')
GO

INSERT INTO Categoria (Id, Nombre, FechaCreacion, Operador_Id) VALUES (1, 'Matrimonio', '2017-05-01', 2);
GO
INSERT INTO Categoria (Id, Nombre, FechaCreacion, Operador_Id) VALUES (2, 'Juventud', '2017-05-01', 2);
GO
INSERT INTO Categoria (Id, Nombre, FechaCreacion, Operador_Id) VALUES (3, 'Actualidad', '2017-05-01', 2);
GO

INSERT INTO MedioAudiovisual (FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES ('2016-05-06', 'Consejos de familia', 'https://www.youtube.com/watch?v=ar17oemc-kI', 100, 1, 2)
GO
INSERT INTO MedioAudiovisual (FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES ('2015-01-19', 'Adolescencia', 'https://www.youtube.com/watch?v=0f2XXh8XiTk', 70, 2, 2)
GO
INSERT INTO MedioAudiovisual (FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES ('2014-07-22', 'Caminos inciertos', 'https://www.youtube.com/watch?v=2GBpF9R79H4', 80, 3, 2)
GO
INSERT INTO MedioAudiovisual (FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES ('2017-03-22', 'Dinero y felicidad', 'https://www.youtube.com/watch?v=SOo7pBkWFEw', 800, 3, 2)
GO
INSERT INTO MedioAudiovisual (FechaGrabacion, Tema, Url, Tamano, Categoria_Id, Tipo_Id) VALUES ('2014-07-22', 'Fidelidad', 'https://www.youtube.com/watch?v=WrKsS4KbGRE', 20, 1, 2)
GO

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

INSERT INTO Orador (Nombre, Apellido, FechaCreacion, Operador_Id, MedioAudiovisual_Id) VALUES ('Hernán', 'Rodriguez', '2014-01-05', 2, 1)
GO
INSERT INTO Orador (Nombre, Apellido, FechaCreacion, Operador_Id, MedioAudiovisual_Id) VALUES ('Mariela', 'Lentini', '2014-01-05', 2, 2)
GO
INSERT INTO Orador (Nombre, Apellido, FechaCreacion, Operador_Id, MedioAudiovisual_Id) VALUES ('Paola', 'Casas', '2014-01-05', 2, 3)
GO
INSERT INTO Orador (Nombre, Apellido, FechaCreacion, Operador_Id, MedioAudiovisual_Id) VALUES ('José',  'King', '2014-01-05', 2, 4)
GO
INSERT INTO Orador (Nombre, Apellido, FechaCreacion, Operador_Id, MedioAudiovisual_Id) VALUES ('Carla', 'Mayada', '2014-01-05', 2, 5)
GO