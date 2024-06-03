﻿using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
	public class clsVisita
	{
		private TallerCarrosEntities dbTallerCarros = new TallerCarrosEntities();

		public Visita visita {  get; set; }

		public string Insertar()
		{
			try
			{
				dbTallerCarros.Visitas.Add(visita);
				dbTallerCarros.SaveChanges();
				return "Se agendó cita para el: " + visita.fecha + " a las " + visita.hora + "correctamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public IQueryable ConsultarVisitas()
		{
			return from Vi in dbTallerCarros.Set<Visita>()
				   join Cl in dbTallerCarros.Set<Cliente>()
				   on Vi.id_cliente equals Cl.id_cliente
				   join Ve in dbTallerCarros.Set<Vehiculo>()
				   on Vi.id_vehiculo equals Ve.id_vehiculo
				   join Mv in dbTallerCarros.Set<MarcasVehiculo>()
				   on Ve.id_marca equals Mv.id_marca
				   join Em in dbTallerCarros.Set<Empleado>()
				   on Vi.id_empleado equals Em.id_empleado
				   join Vr in dbTallerCarros.Set<Visitas_Reparaciones>()
				   on Vi.id_visita equals Vr.id_visita
				   join Re in dbTallerCarros.Set<Reparacione>()
				   on Vr.id_reparacion equals Re.id_reparacion
				   orderby Vi.fecha ascending
				   select new
				   {
					   Cliente = Cl.nombre,
					   Vehiculo = Mv.nombre,
					   Servicio = Re.descripcion,
					   Empleado = Em.nombre + " " + Em.apellido,
					   Fecha = Vi.fecha,
					   Hora = Vi.hora
				   };
		}
	}
}