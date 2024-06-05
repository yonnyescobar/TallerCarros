using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
	public class clsServicio
	{
		private TallerCarrosEntities dbTallerCarros = new TallerCarrosEntities();

		public Servicio servicio { get; set; }

		public string Insertar()
		{
			try
			{
				dbTallerCarros.Servicios.Add(servicio);
				dbTallerCarros.SaveChanges();
				return "Se registró el servicio: " + servicio.nombre + " correctamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string Actualizar()
		{
			try
			{
				dbTallerCarros.Servicios.AddOrUpdate(servicio);
				dbTallerCarros.SaveChanges();
				return "Se actualizó el servicio: " + servicio.nombre + " correctamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public Servicio Consultar(int id_servicio)
		{
			return dbTallerCarros.Servicios.FirstOrDefault(s => s.id_servicio == id_servicio);
		}

		public List<Servicio> ConsultarServicios()
		{
			return dbTallerCarros.Servicios
				.Where(s => s.id_servicio != 0)
				.OrderBy(s => s.nombre) 
				.ToList();
		}

		public string Eliminar()
		{
			try
			{
				Servicio _servicio = Consultar(servicio.id_servicio);
				dbTallerCarros.Servicios.Remove(_servicio);
				dbTallerCarros.SaveChanges();
				return "Se eliminó el Servicio: " + servicio.nombre + " correctamente";

			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}