CREATE DATABASE T_SStop;

USE T_SStop;

CREATE TABLE EstilosMusicais(
IdEstiloMusical INT PRIMARY KEY IDENTITY,
Nome VARCHAR(100) NOT NULL UNIQUE 

);
CREATE TABLE Artista(
IdArtista INT PRIMARY KEY IDENTITY,
IdEstiloMusical INT FOREIGN KEY REFERENCES EstilosMusicais(IdEstiloMusical)

);

ALTER TABLE Artista
ADD Nome  VARCHAR(100);

INSERT INTO EstilosMusicais(Nome) VALUES ('Rock''n Roll'),
										('Metal'),
										('MPB'),
										('Erudita'),
										('Sertanejo');

											

SELECT* FROM EstilosMusicais;

INSERT INTO Artista (Nome,IdEstiloMusical) VALUES ('Legião Urbana',1),
												  ('Metallica',2),
												  ('Mozard',4),
												  ('Luan Santana',5),
												  ('Tchaikovisk',4),
												  ('Beatles',1),
												  ('Roling Stone',1),
												  ('Artista Imaginario',3)
SELECT* FROM Artista;

UPDATE Artista SET IdEstiloMusical = 3 WHERE IdArtista=1;

SELECT* FROM EstilosMusicais;