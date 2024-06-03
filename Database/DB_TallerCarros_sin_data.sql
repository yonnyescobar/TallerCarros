-- Crear la base de datos
CREATE DATABASE TallerCarros;
GO

-- Usar la base de datos
USE TallerCarros;
GO

-- Tabla Clientes
CREATE TABLE Clientes (
    id_cliente INT PRIMARY KEY IDENTITY(1,1),
    documento NVARCHAR(20) NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    apellido NVARCHAR(50) NOT NULL,
    telefono NVARCHAR(15) NOT NULL,
    email NVARCHAR(100) NOT NULL
);
GO

-- Tabla MarcasVehiculos
CREATE TABLE MarcasVehiculos (
    id_marca INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL
);
GO

-- Tabla Vehiculos
CREATE TABLE Vehiculos (
    id_vehiculo INT PRIMARY KEY IDENTITY(1,1),
    id_marca INT FOREIGN KEY REFERENCES MarcasVehiculos(id_marca),
    modelo NVARCHAR(50) NOT NULL,
    ano INT NOT NULL,
    placa NVARCHAR(10) NOT NULL,
    id_cliente INT FOREIGN KEY REFERENCES Clientes(id_cliente)
);
GO

-- Tabla Cargos
CREATE TABLE Cargos (
    id_cargo INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL
);
GO

-- Tabla Empleados
CREATE TABLE Empleados (
    id_empleado INT PRIMARY KEY IDENTITY(1,1),
    documento NVARCHAR(20) NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    apellido NVARCHAR(50) NOT NULL,
    telefono NVARCHAR(15) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    id_cargo INT FOREIGN KEY REFERENCES Cargos(id_cargo)
);
GO

-- Tabla Repuestos
CREATE TABLE Repuestos (
    id_repuesto INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255),
    precio_unitario DECIMAL(10, 2) NOT NULL
);
GO

-- Tabla Inventario
CREATE TABLE Inventario (
    id_inventario INT PRIMARY KEY IDENTITY(1,1),
    id_repuesto INT FOREIGN KEY REFERENCES Repuestos(id_repuesto),
    cantidad INT NOT NULL
);
GO

-- Tabla Proveedores
CREATE TABLE Proveedores (
    id_proveedor INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    telefono NVARCHAR(15) NOT NULL,
    email NVARCHAR(100) NOT NULL
);
GO

-- Tabla Compras
CREATE TABLE Compras (
    id_compra INT PRIMARY KEY IDENTITY(1,1),
    id_proveedor INT FOREIGN KEY REFERENCES Proveedores(id_proveedor),
    fecha DATE NOT NULL,
    total DECIMAL(10, 2) NOT NULL
);
GO

-- Tabla DetalleCompra
CREATE TABLE DetalleCompras (
    id_detalle INT PRIMARY KEY IDENTITY(1,1),
    id_compra INT FOREIGN KEY REFERENCES Compras(id_compra),
    id_repuesto INT FOREIGN KEY REFERENCES Repuestos(id_repuesto),
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL
);
GO

-- Tabla Ventas
CREATE TABLE Ventas (
    id_venta INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT FOREIGN KEY REFERENCES Clientes(id_cliente),
    fecha DATE NOT NULL,
    total DECIMAL(10, 2) NOT NULL
);
GO

-- Tabla DetalleVenta
CREATE TABLE DetalleVentas (
    id_detalle_venta INT PRIMARY KEY IDENTITY(1,1),
    id_venta INT FOREIGN KEY REFERENCES Ventas(id_venta),
    id_repuesto INT FOREIGN KEY REFERENCES Repuestos(id_repuesto),
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL
);
GO

-- Tabla CategoriasRepuestos
CREATE TABLE CategoriasRepuestos (
    id_categoria INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL
);
GO

-- Tabla Repuestos_Categorias
CREATE TABLE Repuestos_Categorias (
    id_repuesto_categoria INT PRIMARY KEY IDENTITY(1,1),
    id_repuesto INT FOREIGN KEY REFERENCES Repuestos(id_repuesto),
    id_categoria INT FOREIGN KEY REFERENCES CategoriasRepuestos(id_categoria)
);
GO

-- Tabla MarcasRepuestos
CREATE TABLE MarcasRepuestos (
    id_marca INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL
);
GO

-- Tabla Servicios
CREATE TABLE Servicios (
    id_servicio INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    costo DECIMAL(10, 2) NOT NULL
);
GO

-- Tabla Visitas
CREATE TABLE Visitas (
    id_visita INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT FOREIGN KEY REFERENCES Servicios(id_servicio),
    documento NVARCHAR(20) NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    apellido NVARCHAR(50) NOT NULL,
    telefono NVARCHAR(15) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    fecha DATETIME NOT NULL
);
GO