create database T_DPS
USE T_DPS

CREATE TABLE Habilidade
(
  IdHabilidade int primary key identity,
  habilidade VARCHAR(100) NOT NULL UNIQUE,
  Descrição VARCHAR(200) 

)

CREATE TABLE Departamento 
(
idDepartamento int primary key identity,
departamento varchar(100) not null unique,
)

create table função(
IdFunção int primary key identity,
NomeFunção varchar (200) not null unique,
Salario int not null

)


create table Funcionario
(
IdFuncionario INT PRIMARY KEY IDENTITY,
NomeFuncionario varchar(200) not null ,
função int foreign key references função(Idfunção)
)

create table HabilidadeFuncionario
(
IdFuncionario int foreign key references Funcionario(IdFuncionario),
IdHabilidade int foreign key references Habilidade(idHabilidade)
)

alter table Funcionario add IdDepartamento int foreign key references Departamento(idDepartamento);

INSERT INTO Departamento(departamento) VALUES ('Financa'),('Desenvolvimento'),('Redes'),('direção'),('Comunicação');

INSERT INTO Habilidade(habilidade) VALUES ('Criatividade'),('escrita'),('Codificação'),('Digitação'),('Dialetica'),('Design'),('Didatica');

INSERT INTO função(NomeFunção,Salario) VALUES ('Estagiario',1000),('Junior',2000),('Senior',3000),('Diretor',5000),('Contador',3200),('Gerente',3400);

select *from Departamento

select* from Habilidade

select* from função;

SELECT* FROM FUNCIONARIO

SELECT* FROM HabilidadeFuncionario

insert into Funcionario(NomeFuncionario,IdDepartamento,função) values ('adc',1,4),('carlos',3,4),('joão',2,5),('felipe',5,3),('amigo',2,3);

insert into HabilidadeFuncionario(IdFuncionario,IdHabilidade) VALUES (13,2),(14,3),(15,4),(14,3),(13,2),(15,6),(16,1),(17,5),(17,1),(15,6)
