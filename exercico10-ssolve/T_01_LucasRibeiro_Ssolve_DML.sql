CREATE DATABASE T_Ssolve

use T_Ssolve

create table Cliente (
IdCliente int primary key not null identity, 
NomeCliente varchar(255) not null ,
CNPJ int , 
Razao Varchar(255),
Endereço varchar(255) not null 
);


create table Comodo(
IdLocal int primary key not null identity,
NomeLocal varchar(255)not null unique
);


create table Funcionario(
IdFuncionario int primary key not null identity,
NomeFuncionario varchar(255) not null
);

CREATE TABLE Manutencao(
IdManutencao int primary key not null identity,
NomeManutencao varchar(255)not null,
IdLocal int foreign key references Comodo(IdLocal)

);

CREATE TABLE Servico(
IdServico int primary key not null identity,
IdCliente int foreign key references Cliente(IdCliente) ,
IdManutencao int foreign key references Manutencao(IdManutencao)
);

CREATE TABLE ServicoFuncionario(

IdServico int foreign key references Servico(IdServico),
IdFuncionario int foreign key references Funcionario(IdFuncionario),
);









