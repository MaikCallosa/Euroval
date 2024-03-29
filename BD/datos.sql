USE [Euroval]
GO
SET IDENTITY_INSERT [dbo].[Deporte] ON 

INSERT [dbo].[Deporte] ([Id], [Nombre]) VALUES (1, N'Futbol')
INSERT [dbo].[Deporte] ([Id], [Nombre]) VALUES (2, N'Baloncesto')
INSERT [dbo].[Deporte] ([Id], [Nombre]) VALUES (3, N'Balonmano')
INSERT [dbo].[Deporte] ([Id], [Nombre]) VALUES (4, N'Tenis')
INSERT [dbo].[Deporte] ([Id], [Nombre]) VALUES (5, N'Padel')
SET IDENTITY_INSERT [dbo].[Deporte] OFF
SET IDENTITY_INSERT [dbo].[Pista] ON 

INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (1, N'Campo Futbol 1', 1)
INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (2, N'Campo Futbol 2', 1)
INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (3, N'Pista Baloncesto 1', 2)
INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (4, N'Pista Tenis 1', 4)
INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (5, N'Pista Tenis 2', 4)
INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (6, N'Pista Padel 1', 5)
INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (7, N'Pista Balonmano 1 ', 3)
INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (8, N'Pista Padel 2', 5)
INSERT [dbo].[Pista] ([Id], [Nombre], [DeporteId]) VALUES (10, N'Pista Tenis 3', 4)
SET IDENTITY_INSERT [dbo].[Pista] OFF
SET IDENTITY_INSERT [dbo].[Socio] ON 

INSERT [dbo].[Socio] ([Id], [Nombre], [DNI], [Email], [Telefono]) VALUES (1, N'Miguel', N'48335577E', N'miguel.garcia@gmail.com', N'666999666')
INSERT [dbo].[Socio] ([Id], [Nombre], [DNI], [Email], [Telefono]) VALUES (2, N'Jose', N'44455324R', N'jose.perez@gmail.com', N'676765434')
INSERT [dbo].[Socio] ([Id], [Nombre], [DNI], [Email], [Telefono]) VALUES (3, N'Pepe', N'48556688W', N'pepe.lopez@gmail.com', N'666999555')
INSERT [dbo].[Socio] ([Id], [Nombre], [DNI], [Email], [Telefono]) VALUES (4, N'Maria', N'45656785R', N'maria.segui@gmail.com', N'666999555')
INSERT [dbo].[Socio] ([Id], [Nombre], [DNI], [Email], [Telefono]) VALUES (6, N'Sara', N'48990099S', N'sara.godoy@gmail.com', N'656559656')
SET IDENTITY_INSERT [dbo].[Socio] OFF
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT [dbo].[Reserva] ([Id], [SocioId], [PistaId], [FechaInicio], [FechaFin]) VALUES (1, 1, 1, CAST(N'2019-10-24T09:00:00.0000000' AS DateTime2), CAST(N'2019-10-24T10:00:00.0000000' AS DateTime2))
INSERT [dbo].[Reserva] ([Id], [SocioId], [PistaId], [FechaInicio], [FechaFin]) VALUES (2, 2, 3, CAST(N'2019-10-24T10:00:00.0000000' AS DateTime2), CAST(N'2019-10-24T11:00:00.0000000' AS DateTime2))
INSERT [dbo].[Reserva] ([Id], [SocioId], [PistaId], [FechaInicio], [FechaFin]) VALUES (3, 2, 3, CAST(N'2019-10-25T10:00:00.0000000' AS DateTime2), CAST(N'2019-10-25T11:00:00.0000000' AS DateTime2))
INSERT [dbo].[Reserva] ([Id], [SocioId], [PistaId], [FechaInicio], [FechaFin]) VALUES (4, 2, 3, CAST(N'2019-10-25T11:00:00.0000000' AS DateTime2), CAST(N'2019-10-25T12:00:00.0000000' AS DateTime2))
INSERT [dbo].[Reserva] ([Id], [SocioId], [PistaId], [FechaInicio], [FechaFin]) VALUES (5, 2, 3, CAST(N'2019-10-25T12:00:00.0000000' AS DateTime2), CAST(N'2019-10-25T13:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Reserva] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Usuario], [Contrasenya], [Token]) VALUES (1, N'Miguel', N'holahola', NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
