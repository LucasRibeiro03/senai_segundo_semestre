create database T_Peoples;

use T_Peoples;

create table Funcionarios
(
IdFuncionario int primary key identity,
NomeFuncionario Varchar(255) not null,
SobrenomeFuncionario varchar(255) not null,
);

insert into Funcionarios values ('Catarina','Strada'),('Tadeu','Vitelli'),('Lucas','Ribeiro');

select* from Funcionarios;
