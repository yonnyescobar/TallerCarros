using Servicios.Models;
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
				return "Se agendó cita para el: " + visita.fecha + "correctamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public IQueryable ConsultarVisitas()
		{
			return from Vi in dbTallerCarros.Set<Visita>()
				   join Se in dbTallerCarros.Set<Servicio>()
				   on Vi.id_servicio equals Se.id_servicio
				   orderby Vi.fecha ascending
				   select new
				   {
					   Documento = Vi.documento,
					   Nombre = Vi.nombre,
					   Apellido = Vi.apellido,
					   Telefono = Vi.telefono,
					   Correo = Vi.email,
					   Fecha = Vi.fecha
				   };
		}
	}
}