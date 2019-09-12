
--DDL
CREATE DATABASE T_Opflix2sprint;

USE T_Opflix2sprint;

Create Table Usuarios
(
 IdUsuario int primary key identity,
 Email varchar(200) not null unique
 ,Senha varchar(200) not null unique 
 ,Permissao varchar(50) not null 
);

Create Table Plataformas(
IdPlataforma int primary key identity,
NomePlataforma varchar(200) not null unique
)
Create Table Categorias(
IdCategoria int primary key identity,
NomeCategoria varchar(200) not null unique
)
Create Table Lancamentos(
IdLancamento int primary key identity,
NomeLancamento varchar(200) not null unique ,

IdCategoria int foreign key references Categorias(IdCategoria),
IdPlataforma int foreign key references Plataformas(IdPlataforma)
);


alter table Lancamentos add Sinopse varchar(300);

--DML
insert into Usuarios values ('Admin@admin.com','admin','ADMINISTRADOR')
,('Lucas@admin.com','lucas','ADMINISTRADOR')
,('Felipe@comum.com','felipe','COMUM')

insert into Plataformas values ('Netflix'),('Amazon'),('Cinema')

insert into Categorias values ('Ação'),
('Animação'),('Aventura'),('Comédia'),('Documentário'),('Drama'),('Fantasia'),('Ficção Científica'),
('Guerra'),('Musicais'),('Romance'),('Suspense'),('Terror')

insert into Lancamentos values ('Pantera Negra',1,3,'Os Maluko tem tecnologia e resolve quem vai ser rei na porrada!'),
('Os Incriveis 2',4,3,'Muito Bom ,Recomendo para quem curte uma animaçãozinha com comedia'),
('Deadpool 2',4,1,'Incrivel!!'),
('Agua Homem(Aquaman)',1,3,'O cara é um peixe'),
('Miranha no Miranha versu',2,2,'o Miranha pretende fazer varias peripecias junto com sua turma durante a sua tarde de domingo')


select * from Usuarios;

select * from Categorias;

select * from Plataformas;

select * from Lancamentos;