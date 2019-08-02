CREATE DATABASE T_Livros;

use T_Livros

CREATE TABLE Generos 
(
	IdGeneros int primary key Identity,
	NomeGenero VARCHAR(200) NOT NULL UNIQUE
)
CREATE TABLE Autores
(
	IdAutores int primary key identity,
	NomeAutor VARCHAR(200) NOT NULL 
)

CREATE TABLE Livros
(
	IdLivros int primary key identity,
	NomeLivro VARCHAR(200) NOT NULL,
	IdAutores int FOREIGN KEY REFERENCES Autores(IdAutores),
	IdGeneros int FOREIGN KEY REFERENCES Generos(IdGeneros)
) 
INSERT INTO Autores(NomeAutor) VALUES ('AUTOR 1'),('AUTOR 2'),('AUTOR 3'),('AUTOR 4'),('AUTOR 5');

SELECT* FROM Autores

INSERT INTO Generos(NomeGenero) VALUES ('Romance'),('Drama'),('Biografia')

SELECT* FROM Generos

INSERT INTO Livros(NomeLivro,IdGeneros,IdAutores) VALUES ('CRIANDO CODIGOS EM UMA BATATA',1,2),('O REPITILIANO DAS REDES SOCIAIS',2,1),('MUITO MAIS QUE PROGRAMAS',3,4),('DEV MELHOR QUE REDES',3,3),(' O HOMEM QUE ROUBAVA CODIGOS',1,5)

SELECT* FROM Livros

INSERT INTO Livros(NomeLivro,IdGeneros,IdAutores) VALUES ('COMER DORMIR ',1,2) 


SELECT Livros.IdLivros,Livros.NomeLivro,Autores.*,Generos.*
FROM Livros
full JOIN Autores on Autores.IdAutores = livros.IdAutores
full join Generos on Generos.IdGeneros = Generos.IdGeneros

SELECT Generos.NomeGenero, Autores.NomeAutor, Livros.NomeLivro,Livros.sinopse FROM Livros FULL JOIN Generos ON Generos.IdGeneros = Livros.IdGeneros
																		   FULL JOIN Autores ON Autores.IdAutores = Livros.IdAutores;



alter table Livros
ADD	sinopse VARCHAR(200)


UPDATE Livros 
set sinopse = 'aaa'
where IdLivros = 1;

UPDATE Livros 
set sinopse = 'bbb'
where IdLivros = 2;

UPDATE Livros 
set sinopse = 'ccc'
where IdLivros = 3;

UPDATE Livros 
set sinopse = 'ddd'
where IdLivros = 4;


UPDATE Livros 
set sinopse = 'eee'
where IdLivros = 5;

SELECT Generos.NomeGenero, Autores.NomeAutor, Livros.NomeLivro,Livros.sinopse ,Livros.DataLançamento 
FROM Livros 
FULL JOIN Generos ON Generos.IdGeneros = Livros.IdGeneros
FULL JOIN Autores ON Autores.IdAutores = Livros.IdAutores;



alter table Livros 
ADD DataLançamento Date null

UPDATE Livros 
set DataLançamento = '2017-01-13'
where IdLivros = 2;

UPDATE Livros 
set DataLançamento = '2019-05-13'
where IdLivros = 1;

UPDATE Livros 
set DataLançamento = '2018-09-02'
where IdLivros = 3;

UPDATE Livros 
set DataLançamento = '2016-11-12'
where IdLivros = 4;

UPDATE Livros 
set DataLançamento = '2003-05-02'
where IdLivros = 5;

alter table Livros 
ADD Validador varchar(30) 

SELECT Generos.NomeGenero, Autores.NomeAutor, Livros.NomeLivro,Livros.sinopse ,Livros.DataLançamento, Livros.Validador 
FROM Livros 
FULL JOIN Generos ON Generos.IdGeneros = Livros.IdGeneros
FULL JOIN Autores ON Autores.IdAutores = Livros.IdAutores;

