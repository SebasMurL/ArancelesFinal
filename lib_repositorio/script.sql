CREATE DATABASE db_aranceles;
GO
USE db_aranceles;

---QUITE LA LOS APELLIDOS REDUNDANTES (PREGUNTAR AL PROFE SI ME DEJA)

CREATE TABLE [Paises] --Tabla 2
(
	---3 Atributos

	[Id] INT NOT NULL PRIMARY KEY, --IDENTITY (1,1) Para despues
    [Nombre] NVARCHAR (50) NOT NULL, 
    [Moneda] NVARCHAR (60) NOT NULL, 

    --envia 3

    --public List <Empresas>? Empresas {get; set;}
    --public List <Ordenes>? OrdenesDestinos {get; set;} 
    --public List <Ordenes>? OrdenesOrigenes {get; set;} 
)
CREATE TABLE [Empresas] --Tabla 1
(
	--3 Atributos

	 [Id] INT NOT NULL PRIMARY KEY, --IDENTITY (1,1) Para despues
     [Id_Pais] INT FOREIGN KEY ([Id_Pais]) REFERENCES [Paises] (Id),
     [Nombre] NVARCHAR (90),

    --Recibe 1

	--public Paises? _Pais {get; set;}
    
)
CREATE TABLE [TiposDeProductos] --Tabla 4
(
	--3 Atributos

	[Id] INT NOT NULL PRIMARY KEY, --IDENTITY (1,1) Para despues
	[Nombre] NVARCHAR (90) NOT NULL,
    [EntidadRegulatoria] NVARCHAR (90) NOT NULL
    
	--Envio 1
    
	--public List <Productos>? Productos {get; set;}

)
CREATE TABLE [Productos] --Tabla 3
(
	--5 Atributos

	[Id] INT NOT NULL PRIMARY KEY, --IDENTITY (1,1) Para despues
	[Id_Empresa]  INT FOREIGN KEY ([Id_Empresa] ) REFERENCES [Empresas] (Id),
    [Id_TipoProducto] INT FOREIGN KEY ([Id_TipoProducto] ) REFERENCES [TiposDeProductos] (Id),
    [Nombre] NVARCHAR (100) NOT NULL,
    [PrecioUnitario] DECIMAL (15,2) NOT NULL
    
	--Recibe 2
    
	--public Empresas? _Empresa {get; set;}
    --public TiposDeProductos? _TipoProducto {get; set;}
    
	--Envia 1
    
	--public List <Ordenes>? Ordenes {get; set;}
)
CREATE TABLE [Ordenes] --Tabla 5
(
	--7 Atributos

	[Id] INT NOT NULL PRIMARY KEY, --IDENTITY (1,1) Para despues
	[Id_PaisOrigen]  INT FOREIGN KEY ([Id_PaisOrigen] ) REFERENCES [Paises] (Id),
	[Id_PaisDestino]  INT FOREIGN KEY ([Id_PaisDestino] ) REFERENCES [Paises] (Id),
	[Id_Producto]  INT FOREIGN KEY ([Id_Producto] ) REFERENCES [Productos] (Id),
	[Cod] NVARCHAR (90) NOT NULL,
    [CantidadUnidades] INT NOT NULL,
    [Fecha] SMALLDATETIME NOT NULL
    
	--Recibe 3
    
	--public Paises? _PaisDestino {get; set;} 
    --public Paises? _PaisOrigen {get; set;} 
    --public Productos? _Producto {get; set;}
    
	--Envia 1
    
	--public Aranceles? Aranceles {get; set;} 
)
CREATE TABLE [TiposDeAranceles] --Tabla 6
(
	
	--3 Atributos

	[Id] INT NOT NULL PRIMARY KEY, --IDENTITY (1,1) Para despues
    [Nombre] NVARCHAR (90) NOT NULL,
    [FechaVigencia] SMALLDATETIME NOT NULL,
    
	--Envia 1
    
	--public List <Aranceles>? Aranceles {get; set;}
)
CREATE TABLE [Aranceles] --Tabla 7
(
	--4 Atributos

	[Id] INT NOT NULL PRIMARY KEY, --IDENTITY (1,1) Para despues
	[Id_Orden]  INT FOREIGN KEY ([Id_Orden] ) REFERENCES [Ordenes] (Id),
	[Id_TipoDeArancel]  INT FOREIGN KEY ([Id_TipoDeArancel] ) REFERENCES [TiposDeAranceles] (Id),
    [PorcentajeDelArancel] DECIMAL (15,2) NOT NULL
    
	--Recibe 2
    
	--public Ordenes? _Orden {get; set;}
    --public TiposDeAranceles? _TipoArancel {get; set;}
    
	--Envia 1
    
	--public Facturas? Factura {get; set;}
)
CREATE TABLE [Facturas] --Tabla 8
(
	--4 Atributos

	[Id] INT NOT NULL PRIMARY KEY, --IDENTITY (1,1) Para despues
	[Id_Arancel]  INT FOREIGN KEY ([Id_Arancel] ) REFERENCES [Aranceles] (Id),
    [Fecha] SMALLDATETIME NOT NULL,
    [PagoTotalCop] DECIMAL (15,2) NOT NULL

    --Recibe 1
    
	--public Aranceles? _Arancel {get; set;}
)
-----------------------------------------------------------------------------------------------------------------------------------------------
SELECT * FROM Paises; --1
SELECT * FROM TiposDeProductos;--2
SELECT * FROM TiposDeAranceles;--3
SELECT * FROM Aranceles;--4
SELECT * FROM Ordenes;--5
SELECT* FROM Empresas;--6
SELECT * FROM Productos;--7
SELECT * FROM Facturas;--8

DELETE FROM Aranceles;--4
GO
DELETE FROM Ordenes;--5
GO
DELETE FROM Productos;--7
GO
DELETE FROM Empresas;--6
GO
DELETE FROM Paises; --1
GO
DELETE FROM TiposDeProductos;--2
GO
DELETE FROM TiposDeAranceles;--3
GO
DELETE FROM Facturas;--8
GO










