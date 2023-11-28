--CREATE DATABASE CONSULTASIVR
use CONSULTASIVR
go

/* Creando tabla Estado */


Create table Estado(
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre varchar(20) not null,
);


/*Creando tabla CambioEstado*/




/*Creando tabla Cliente*/

CREATE TABLE Cliente(
Dni CHAR(20) PRIMARY KEY,
NroCelular VARCHAR (20),
NombreCompleto TEXT
);



/*Creando tabla Encuesta*/

/*
CREATE TABLE Encuesta(
Id INT IDENTITY(1,1) PRIMARY KEY,
Descripcion TEXT,
);
*/

/*
CREATE TABLE Pregunta(
Id INT IDENTITY(1,1) PRIMARY KEY,
Pregun TEXT,
IdEncuesta INT,
CONSTRAINT fk_Encuesta FOREIGN KEY (IdEncuesta) REFERENCES Encuesta (Id)
);
*/

/*
CREATE TABLE RespuestaPosible(
Id INT IDENTITY(1,1) PRIMARY KEY,
Valor VARCHAR (20),
Descripcion TEXT,
IdPregunta INT,
CONSTRAINT fk_Pregunta FOREIGN KEY (IdPregunta) REFERENCES Pregunta (Id)
);
*/

--CREATE DATABASE CONSULTASIVR
use CONSULTASIVR
go

/* Creando tabla Estado */


Create table Estado(
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre varchar(20) not null,
);


/*Creando tabla CambioEstado*/




/*Creando tabla Cliente*/

CREATE TABLE Cliente(
Dni CHAR(20) PRIMARY KEY,
NroCelular VARCHAR (20),
NombreCompleto TEXT
);



/*Creando tabla Encuesta*/


CREATE TABLE Encuesta(
Id INT IDENTITY(1,1) PRIMARY KEY,
Descripcion TEXT,
);



CREATE TABLE Pregunta(
Id INT IDENTITY(1,1) PRIMARY KEY,
Pregun TEXT,
IdEncuesta INT,
CONSTRAINT fk_Encuesta FOREIGN KEY (IdEncuesta) REFERENCES Encuesta (Id)
);



CREATE TABLE RespuestaPosible(
Id INT IDENTITY(1,1) PRIMARY KEY,
Valor VARCHAR (20),
Descripcion TEXT,
IdPregunta INT,
CONSTRAINT fk_Pregunta FOREIGN KEY (IdPregunta) REFERENCES Pregunta (Id)
);



CREATE TABLE Llamada(
Id INT IDENTITY(1,1) PRIMARY KEY,
DescripcionOperador TEXT,
DetalleEncuesta TEXT,
Duracion CHAR(20),
EncuestaEnviada BIT NOT NULL,
DniCliente CHAR(20) NOT NULL,
CONSTRAINT fk_DniCliente FOREIGN KEY (DniCliente) REFERENCES Cliente (Dni)
);

CREATE TABLE CambioEstado(
Id INT IDENTITY(1,1) PRIMARY KEY,
IdEstado INT,
IdLlamada INT,
FechaHoraInicio DATETIME,
CONSTRAINT fk_Estado FOREIGN KEY (IdEstado) REFERENCES Estado (Id),
CONSTRAINT fk_Llamada_CE FOREIGN KEY (IdLlamada) REFERENCES Llamada (Id),
);


CREATE TABLE RespuestaCliente(
Id INT IDENTITY(1,1) PRIMARY KEY,
FechaEncuesta DATETIME,
IdRespuestaPosible INT,
IdLlamada INT,
CONSTRAINT fk_RespuestaPosible FOREIGN KEY (IdRespuestaPosible) REFERENCES RespuestaPosible (Id),
CONSTRAINT fk_Llamada_RC FOREIGN KEY (IdLlamada) REFERENCES Llamada (Id),
);

