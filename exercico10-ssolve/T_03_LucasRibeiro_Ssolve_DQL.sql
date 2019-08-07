USe T_Ssolve;

SELECT * FROM Cliente ORDER BY IdCliente asc;

SELECT * FROM Comodo ORDER BY IdLocal asc;

SELECT * FROM Funcionario order by IdFuncionario asc;

SELECT * FROM Servico order by IdServico asc;

SELECT * FROM ServicoFuncionario order by IdFuncionario asc;

SELECT * FROM Manutencao ORDER BY IdManutencao asc;


SELECT Servico.IdServico,Cliente.NomeCliente,Funcionario.NomeFuncionario,Servico.DataEntrada,Servico.DataSaida,Manutencao.NomeManutencao,Manutencao.Preco
FROM Servico
inner join Cliente on Cliente.IdCliente = Servico.IdCliente
inner join Manutencao on Manutencao.IdManutencao = Servico.IdManutencao
INNER JOIN ServicoFuncionario on ServicoFuncionario.IdServico = Servico.IdCliente
INNER JOIN Funcionario ON Funcionario.IdFuncionario = ServicoFuncionario.IdFuncionario
