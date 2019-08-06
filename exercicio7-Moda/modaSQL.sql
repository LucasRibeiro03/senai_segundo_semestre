CREATE DATABASE T_Modaa 

USE T_Modaa

CREATE TABLE Cores (
	IdCores int primary key identity ,
	Cores VARCHAR (200) NOT NULL UNIQUE 

)

CREATE TABLE Tamanhos(
	IdTamanhos INT PRIMARY KEY IDENTITY ,
	Tamanhos VARCHAR (10) NOT NULL UNIQUE 

) 

CREATE TABLE Marcas(
	IdMarcas INT PRIMARY KEY IDENTITY ,
	Marcas VARCHAR (100) NOT NULL UNIQUE 
)
CREATE TABLE Tipo(
	IdTipo INT PRIMARY KEY IDENTITY,
	Tipo VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE Camisetas(
	IdCamiseta INT PRIMARY KEY IDENTITY,
	IdCores INT FOREIGN KEY REFERENCES Cores(IdCores),
	IdTamanhos INT FOREIGN KEY REFERENCES Tamanhos(IdTamanhos),
	IdMarcas INT FOREIGN KEY REFERENCES Marcas(IdMarcas),
	IdTipo INT FOREIGN KEY REFERENCES Tipo(IdTipo)
)

INSERT INTO Tipo(Tipo) values ('manga longa'),('manga curta'),('sem manga');


INSERT INTO Cores(cores) values('azul'),('vermelho'),('amarelo'),('preto'),('branco'),('verde'),('marron'),('roxo'),('rosa'),('lilas');

INSERT INTO Tamanhos(Tamanhos) VALUES('P'),('M'),('G'),('GG'),('GGG'),('XG'),('XXG'),('XXX'),('XXXX'),('vish');

INSERT INTO Marcas(Marcas) VALUES ('INDIFERENTE'),('DESCONHECIDA'),('TANTO FAZ'),('TANTO FEZ'),('GORDO'),('MAGRO'),('VAI ESTUDAR'),('P=NP');

SELECT* FROM Tamanhos
SELECT* FROM Cores
SELECT* FROM Tipo
SELECT* FROM Marcas
SELECT* FROM Camisetas

INSERT INTO Camisetas(IdCores,IdMarcas,IdTamanhos,IdTipo) VALUES (7,3,5,2),(3,3,2,2),(3,3,3,3),(2,2,2,2),(1,1,1,1)


SELECT Tipo.Tipo,Tamanhos.Tamanhos,Cores.Cores,Marcas.Marcas,Camisetas.IdCamiseta 
FROM Camisetas
JOIN Tipo ON Tipo.IdTipo = Camisetas.IdTipo
JOIN Tamanhos ON Tamanhos.IdTamanhos = Camisetas.IdTamanhos
JOIN Marcas ON Marcas.IdMarcas = Camisetas.IdMarcas
JOIN cores on cores.IdCores = Camisetas.IdCores

--EXTRA

