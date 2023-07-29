select * from USUARIO
select IdUsuario,Documento,NombreCompleto,Correo,Clave,Estado from usuario

select * from rol


select * from permiso

select p.IdRol,p.NombreMenu from PERMISO p
inner join ROL r on r.IdRol = p.IdRol
inner join USUARIO u on u.IdRol =r.IdRol
where u.IdUsuario = 1

/*
insert into PERMISO (IdRol,NombreMenu) values
(1,'menuusuarios'),
(1,'menumantenedor'),
(1,'menuventas'),
(1,'menucompras'),
(1,'menuclientes'),
(1,'menuproveedores'),
(1,'menureportes'),
(1,'menuacercade')

insert into rol (Descripcion) values
('Empleado')

UPDATE rol
SET Descripcion = 'EMPLEADO'
WHERE Descripcion = 'Empleado';

insert into PERMISO (IdRol,NombreMenu) values
(2,'menuventas'),
(2,'menucompras'),
(2,'menuclientes'),
(2,'menuproveedores'),
(2,'menuacercade')

insert into USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
values('20','EMPLEADO','@gmail.com','456',2,1)

*/