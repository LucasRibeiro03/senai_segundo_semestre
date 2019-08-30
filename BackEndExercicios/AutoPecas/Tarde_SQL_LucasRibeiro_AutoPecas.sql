Create Database T_AutoPecas;

Use T_AutoPecas;



Create table Usuarios(
IdUsuario int primary key identity,
Email varchar(300) not null unique,
Senha varchar(300) not null 
);

create Table Fornecedores(
	IdFornecedor int primary key identity,
	NomeFornecedor varchar(300) not null,
	CNPJ VARCHAR(300) UNIQUE NOT NULL,
	RazaoSocial VARCHAR(300) UNIQUE NOT NULL,
	Endereco VARCHAR(300) NOT NULL,
	IdUsuario int Foreign key references Usuarios(idUsuario) unique
);

create table Pecas(
	IdPecas int primary key identity,
	CodigoPeca varchar(300) not null unique ,
	Descricao varchar(300) not null,
	Peso varchar(100) not null,
	PrecoCusto varchar(100) not null,
	PrecoVenda varchar(100) not null,
	FornecedorVinculado int foreign key  references Fornecedores(IdFornecedor) 
);

Select * from Usuarios order by IdUsuario;

select * from Fornecedores order by IdFornecedor;

select * from Pecas order by IdPecas;

insert into Usuarios values('Lucas','123456'),('Felipe','654321'),('Matheus','m123456')

insert into Fornecedores  values  ('LucasRibeiro','5234671-2','Programador','Rua1',1),
							      ('FelipeRibeiro','123456-1','Engenheiro','Rua2',2),
							      ('MatheusRibeiro','5124217-5','FazNadaDeBom','Rua3',3);


insert into Pecas values	('123456-321','Motor Eletrico','15 kilos','R$ 100,00','R$ 150,00',1),
							('123451-312','Motor a combustão','20 kilos','R$ 150,00','R$ 300,00',1),
							('561234-154','Placa Fotovoltaica','30 kilos','R$ 400,00','R$ 10.000,00',2),
							('561243-122','Bateria de ions de Litio','40 kilos','R$ 500,00','R$ 750,00',2);