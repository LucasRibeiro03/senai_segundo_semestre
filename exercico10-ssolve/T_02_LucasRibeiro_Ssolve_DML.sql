USE T_Ssolve;

SELECT * FROM Cliente ORDER BY IdCliente asc;

SELECT * FROM Comodo ORDER BY IdLocal asc;

SELECT * FROM Funcionario order by IdFuncionario asc;

SELECT * FROM Servico order by IdServico asc;

SELECT * FROM ServicoFuncionario order by IdFuncionario asc;

SELECT * FROM Manutencao ORDER BY IdManutencao asc;


INSERT INTO Cliente(NomeCliente,CNPJ,Razao,Endereço) VALUES ('Roberto',2331,'Comer o Almoço','Alameda Barão de Limeira'),
															('Felipe',6623,'Lavar a Louça','Alameda Barão de Limeira'),
															('João',13231,'Subir as Escadas','Alameda Barão de Limeira'),
															('Matheus',23113,'Trabalhar','Alameda Barão de Limeira'),
															('Daniel',1231,'Dormir','Alameda Barão de Limeira');

INSERT INTO Comodo (NomeLocal) values ('Quarto'),
									  ('Quintal'),
									  ('Cozinha'),
									  ('Banheiro'),
									  ('Sala'),
									  ('Garagem');
										


ALTER TABLE Manutencao ADD Preco varchar(255) not null;

INSERT INTO Manutencao (NomeManutencao,IdLocal,Preco) VALUES ('Trocar Lampada',1,'15,00'),
															 ('Lavar Quintal',2,'35,00'),
															 ('Arrumar chuveiro',4,'25,00'),
															 ('Arrumar privada',4,'45,00'),
															 ('Trocar Tomada',5,'15,00'),
															 ('Arrumar Pia',3,'45,00');

INSERT INTO Funcionario (NomeFuncionario) VALUES ('Matheus'),('Felipe'),('Daniel'),('André'),('Fernando'),('Thiago');


alter table Servico ADD DataEntrada dateTime not null

alter table Servico ADD DataSaida dateTime NOT NULL

alter table Servico drop COLUMN DataSaida 

alter table Servico ADD DataSaida dateTime;

INSERT INTO Servico(IdCliente,IdManutencao,DataEntrada,DataSaida) VALUES (6,1,'2000-02-02','2000-02-02')
INSERT INTO Servico(IdCliente,IdManutencao,DataEntrada,DataSaida) VALUES (3,2,'2000-02-02','2000-02-02'),
																		 (5,3,'2000-02-02','2000-02-02'),
																		 (7,4,'2000-02-02','2000-02-02'),
																		 (17,3,'2000-02-02','2000-02-02'),
																		 (10,6,'2000-02-02','2000-02-02'),
																		 (8,4,'2000-02-02','2000-02-02'),
																		 (12,5,'2000-02-02','2000-02-02');


INSERT INTO ServicoFuncionario(IdServico,IdFuncionario) VALUES (3,2),(6,3),(10,4),(12,5),(11,6),(8,6),(3,3);