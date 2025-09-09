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
    CONSTRAINT PK_Productos PRIMARY KEY (Codigo, Id_Color ,Id_Marca, Id_Talle, Id_Tipo),
    CONSTRAINT FK_Productos_Colores FOREIGN KEY (Id_Color) REFERENCES Colores(ID_Color),
    CONSTRAINT FK_Productos_Talles FOREIGN KEY (Id_Talle) REFERENCES Talles(ID_Talle),
    CONSTRAINT FK_Productos_Marcas FOREIGN KEY (Id_Marca) REFERENCES Marcas(ID_Marca),
    CONSTRAINT FK_Productos_Tipo FOREIGN KEY (Id_Tipo) REFERENCES Tipo_Producto(ID_Tipo)
)

SELECT  pr.Codigo, pr.Nombre as Nombre, SUM(pr.Cantidad), Precio, col.Nombre as Color, t.Nombre as Talle, m.Nombre as Marca, tp.Nombre as  Categoria FROM Productos pr INNER JOIN Colores col on pr.Id_Color=col.ID_Color INNER JOIN Talles t on pr.Id_Talle=t.ID_Talle INNER JOIN Marcas m on pr.Id_Marca= m.ID_Marca INNER JOIN Tipo_Producto tp on pr.Id_Tipo=tp.ID_Tipo
where pr.Codigo = '10001'

SELECT DISTINCT col.Nombre as Color FROM Productos pr INNER JOIN Colores col on pr.Id_Color=col.ID_Color where pr.Codigo=10001

SELECT DISTINCT t.Nombre as Talle FROM Productos pr INNER JOIN Talles t on pr.Id_Talle=t.ID_Talle where pr.Codigo=10001 

INSERT INTO Productos (Codigo, IMG, Nombre, Id_Color, Id_Talle, Id_Marca, Id_Tipo, Cantidad, Precio) 
VALUES 
('10001','https://images.puma.net/images/525899/01/mod01/fnd/ARG/w/600/h/600/fmt/png/bg/%23FAFAFA','Calzas Essentials',1,1,1,1,1,69999),
('10001','https://images.puma.net/images/525899/01/mod01/fnd/ARG/w/600/h/600/fmt/png/bg/%23FAFAFA','Calzas Essentials',1,2,1,1,1,69999),
('10001','https://images.puma.net/images/525899/01/mod01/fnd/ARG/w/600/h/600/fmt/png/bg/%23FAFAFA','Calzas Essentials',1,3,1,1,6,69999),
('10001','https://images.puma.net/images/525899/01/mod01/fnd/ARG/w/600/h/600/fmt/png/bg/%23FAFAFA','Calzas Essentials',1,4,1,1,2,69999),
('10001','https://images.puma.net/images/525899/01/mod01/fnd/ARG/w/600/h/600/fmt/png/bg/%23FAFAFA','Calzas Essentials',1,5,1,1,3,69999),
('10003','https://assets.adidas.com/images/h_2000,f_auto,q_auto,fl_lossy,c_fill,g_auto/0adc2346acba46a3856aa43d6fdbfb14_9366/Calzas_Algodon_Essentials_Linear_Gris_JD3151_21_model.jpg','Calzas Linear',2,1,3,1,5,72000),
('10003','https://assets.adidas.com/images/h_2000,f_auto,q_auto,fl_lossy,c_fill,g_auto/0adc2346acba46a3856aa43d6fdbfb14_9366/Calzas_Algodon_Essentials_Linear_Gris_JD3151_21_model.jpg','Calzas Linear',2,2,3,1,5,72000),
('10003','https://assets.adidas.com/images/h_2000,f_auto,q_auto,fl_lossy,c_fill,g_auto/0adc2346acba46a3856aa43d6fdbfb14_9366/Calzas_Algodon_Essentials_Linear_Gris_JD3151_21_model.jpg','Calzas Linear',2,3,3,1,5,72000),
('10003','https://assets.adidas.com/images/h_2000,f_auto,q_auto,fl_lossy,c_fill,g_auto/0adc2346acba46a3856aa43d6fdbfb14_9366/Calzas_Algodon_Essentials_Linear_Gris_JD3151_21_model.jpg','Calzas Linear',2,4,3,1,5,72000)

SELECT Id_Color, Nombre from Colores
SELECT Id_talle, Nombre from Talles 
SELECT Id_Marca, Nombre from Marcas 
SELECT Id_Tipo, Nombre from Tipo_Producto

CREATE TABLE Ventas(
    ID_Venta SMALLINT PRIMARY KEY IDENTITY (1,2),
    Fecha DATE NOT NULL,
    Total_Productos SMALLINT NOT NULL,
    Total DECIMAL(10,2) NOT NULL
);

CREATE TABLE DetalleVenta (
    ID_Detalle INT PRIMARY KEY IDENTITY(1,1),
    ID_Venta SMALLINT NOT NULL,
    Codigo_Producto VARCHAR(15) NOT NULL,
    Cantidad SMALLINT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_DetalleVenta_Ventas FOREIGN KEY (ID_Venta) REFERENCES Ventas(ID_Venta),
);



SELECT pr.Codigo from DetalleVenta dv inner join Productos pr on dv.Codigo_Producto=pr.Codigo