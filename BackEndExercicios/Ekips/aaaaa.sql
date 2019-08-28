CREATE DATABASE T_Ekips;

--DDL
USE T_Ekips;

CREATE TABLE Departamentos (
	IdDepartamento int primary key identity
	, Nome varchar(300) not null unique
	
);
CREATE TABLE Cargos(
	IdCargo int primary key identity
	,NomeCargo varchar(300) not null unique
);

CREATE TABLE Funcionarios(
	IdFuncionario int primary key identity
	,NomeFuncionario varchar(300) not null
	,IdCargo int foreign key references Cargos(IdCargo)
	,IdDepartamento int foreign key references Departamentos(IdDepartamento) 
	,CPF varchar(300)not null unique
	,DataNascimento date not null
	,Salario varchar(300) not null
);

CREATE TABLE Usuario(
	IdUsuario int foreign key references Funcionarios(IdFuncionario)
	,Email varchar(300) not null unique
	,Senha varchar(300) not null
	,Permissao varchar (300) not null 
);

--DML
	SELECT *FROM Cargos

	insert into Cargos values ('FrontEnd'),('BackEnd'),('ServidorManeger'),('Administrador'),('WebDesign'),('MobileDesign');

	insert into Departamentos values('Administrativo'),('Executivo'),('Legislativo');

	SELECT *FROM Departamentos order by IdDepartamento;

	insert into Funcionarios values ('Felipe',1,1,'1234567-8'   ,'2001-11-01','R$1300,00'),
									('João'  ,3,2,'4123567-1'   ,'2002-02-01','R$1500,00'),
									('Lucas' ,4,1,'458488738-10','2003-05-02','R$100.000,00');
	
	select *from Funcionarios order by IdFuncionario;

	insert into Usuario values  (1,'Felipe@gmail.com','123456','COMUM'),
								(2,'Joao@gmail.com  ','123456','COMUM'),
								(3,'Lucas@gmail.com','123456' ,'ADMINISTRADOR');

								
		
	select *from Usuario order by IdUsuario;

--DQL
	select *from Usuario order by IdUsuario;
	select *from Funcionarios order by IdFuncionario;
	SELECT *FROM Departamentos order by IdDepartamento;
	SELECT *FROM Cargos order by IdCargo;
