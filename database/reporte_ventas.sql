-- Reporte
select c.Nombre, count(p.Numero) from Pedido as p
inner join Insumo as i on i.PedidoNumero = p.Numero
inner join InsumoMedioAudiovisual as ima on ima.Insumo_PedidoNumero = i.PedidoNumero
inner join MedioAudiovisual as m on m.Id = ima.MedioAudiovisual_Id
inner join Categoria as c on c.Id = m.Categoria_Id
group by c.Nombre


-- Pruebas
select distinct c.Nombre, p.*, i.*, m.* from Pedido as p
inner join Insumo as i on i.PedidoNumero = p.Numero
inner join InsumoMedioAudiovisual as ima on ima.Insumo_PedidoNumero = i.PedidoNumero
inner join MedioAudiovisual as m on m.Id = ima.MedioAudiovisual_Id
inner join Categoria as c on c.Id = m.Categoria_Id