using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
	public class clsServicio
	{
		private TallerCarrosEntities dbTallerCarros = new TallerCarrosEntities();

		public Servicio servicio { get; set; }

		public List<Servicio> ConsultarServicios()
		{
			return dbTallerCarros.Servicios
				.Where(s => s.id_servicio != 0)
				.OrderBy(s => s.nombre) 
				.ToList();
		}
	}
}