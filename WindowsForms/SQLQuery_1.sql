CREATE DATABASE ControlStock
GO
USE ControlStock;
GO

CREATE TABLE Colores(
    ID_Color SMALLINT PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(15) NOT NULL UNIQUE
);
INSERT INTO Colores (Nombre) VALUES ('Negro'),('Gris')

CREATE TABLE Talles(
    ID_Talle SMALLINT PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(15) NOT NULL UNIQUE
);
INSERT INTO Talles (Nombre) VALUES ('XS'),('S'),('M'),('L'),('XL'),('XLL')

CREATE TABLE Marcas(
    ID_Marca SMALLINT PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(15) NOT NULL UNIQUE
);
INSERT INTO Marcas (Nombre) VALUES ('Puma'),('Nike'),('Adidas'),('Reebok')

CREATE TABLE Tipo_Producto(
    ID_Tipo SMALLINT PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(15) NOT NULL UNIQUE
);
INSERT INTO Tipo_Producto (Nombre) VALUES ('Calza'),('Pantalon'),('Remera'),('Buzo')

CREATE table Productos(
    Codigo VARCHAR(15),
    IMG VARCHAR(1000) NULL,
    Nombre VARCHAR(40) NOT NULL,
    Id_Color SMALLINT NOT NULL,
    Id_Talle SMALLINT NOT NULL,
    Id_Marca SMALLINT NOT NULL,
    Id_Tipo SMALLINT NOT NULL,
    Cantidad SMALLINT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Estado BIT,
    CONSTRAINT PK_Productos PRIMARY KEY (Codigo, Id_Color ,Id_Marca, Id_Talle, Id_Tipo),
    CONSTRAINT FK_Productos_Colores FOREIGN KEY (Id_Color) REFERENCES Colores(ID_Color),
    CONSTRAINT FK_Productos_Talles FOREIGN KEY (Id_Talle) REFERENCES Talles(ID_Talle),
    CONSTRAINT FK_Productos_Marcas FOREIGN KEY (Id_Marca) REFERENCES Marcas(ID_Marca),
    CONSTRAINT FK_Productos_Tipo FOREIGN KEY (Id_Tipo) REFERENCES Tipo_Producto(ID_Tipo)
)

SELECT * FROM Productos

CREATE TABLE Ventas(
    ID_Venta SMALLINT PRIMARY KEY IDENTITY (1,2),
    Fecha DATE NOT NULL,
    Total_Productos SMALLINT NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    Estado BIT NOT NULL
);

CREATE TABLE DetalleVenta (
    ID_Detalle INT PRIMARY KEY IDENTITY(1,1),
    ID_Venta SMALLINT NOT NULL,
    Codigo_Producto VARCHAR(15) NOT NULL,
    Cantidad SMALLINT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_DetalleVenta_Ventas FOREIGN KEY (ID_Venta) REFERENCES Ventas(ID_Venta),
);
/*
CREATE TRIGGER TR_Nuevo_Producto
ON Productos
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Productos(Codigo, IMG, Nombre, Id_Color, Id_Talle, Id_Marca, Id_Tipo, Cantidad, Precio)
    SELECT CAST(Codigo AS VARCHAR) 
        + CAST(Id_Color AS VARCHAR) 
        + CAST(Id_Talle AS VARCHAR) 
        + CAST(Id_Marca AS VARCHAR) 
        + CAST(Id_Tipo AS VARCHAR),
        IMG, Nombre, Id_Color, Id_Talle, Id_Marca, Id_Tipo, Cantidad, Precio 
    FROM inserted;

END;

CREATE VIEW Todos_Los_Articulos AS
SELECT pr.Codigo, IMG, pr.Nombre as Nombre, Cantidad, Precio, col.Nombre as Color, col.Id_Color as Id_Color, t.Nombre as Talle, t.Id_Talle, m.Nombre as Marca, m.Id_Marca, tp.Nombre as Categoria, tp.Id_Tipo FROM Productos pr INNER JOIN Colores col on pr.Id_Color=col.ID_Color INNER JOIN Talles t on pr.Id_Talle=t.ID_Talle INNER JOIN Marcas m on pr.Id_Marca= m.ID_Marca INNER JOIN Tipo_Producto tp on pr.Id_Tipo=tp.ID_Tipo WHERE pr.Estado=0*/


SELECT * FROM Todos_Los_Articulos

/*
CREATE PROCEDURE SP_Busqueda_Filtrada(
    @idmarca SMALLINT = NULL,
    @Idtipo SMALLINT = NULL,
    @nombre VARCHAR(15) = NULL
)
AS
BEGIN
    SELECT pr.Codigo, IMG, pr.Nombre as Nombre, Cantidad, Precio, col.Nombre as Color, col.Id_Color as Id_Color, t.Nombre as Talle, t.Id_Talle, m.Nombre as Marca, m.Id_Marca, tp.Nombre as Categoria, tp.Id_Tipo FROM Productos pr INNER JOIN Colores col on pr.Id_Color=col.ID_Color INNER JOIN Talles t on pr.Id_Talle=t.ID_Talle INNER JOIN Marcas m on pr.Id_Marca= m.ID_Marca INNER JOIN Tipo_Producto tp on pr.Id_Tipo=tp.ID_Tipo WHERE 
    pr.Estado=0 AND m.Id_Marca=@idmarca AND tp.Id_Tipo=@idtipo AND pr.Nombre LIKE '%'+ @nombre +'%'
END
*/


SELECT * FROM MARCAS ORDER BY ID_Marca ASC
EXEC SP_Busqueda_Filtrada 1,'',''

