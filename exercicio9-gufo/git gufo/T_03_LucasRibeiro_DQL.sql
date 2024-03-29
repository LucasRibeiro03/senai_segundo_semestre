use T_Gufos;

select * from Categorias order by IdCategoria asc;
select * from Eventos ;
select * from Usuarios;
select * from Presenšas;


select Eventos.*,Categorias.Nome from 
Eventos inner join Categorias 
on Eventos.IdCategoria = Categorias.IdCategoria;

select P.*, U.*, E.*
FROM Presenšas as p 
join Usuarios as u
on p.IdUsuario =u.IdUsuario
join Eventos E
on p.IdEventos = E.IdEventos;



SELECT P.*, U.*,E.*,C.*
FROM Presenšas P
INNER JOIN Usuarios U
ON P.IdUsuario = U.IdUsuario
INNER JOIN Eventos E
ON P.IdEventos = E.IdEventos
INNER JOIN Categorias C
ON E.IdCategoria = C.IdCategoria;

