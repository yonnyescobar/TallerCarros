using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
	public class clsMarcaVehiculo
	{
		private TallerCarrosEntities dbTallerCarros = new TallerCarrosEntities();

		public MarcasVehiculo marcasVehiculo { get; set; }

		public List<MarcasVehiculo> ConsultarMarcasVehiculo()
		{
			return dbTallerCarros.MarcasVehiculos
				.Where(mv => mv.id_marca != 0)
				.OrderBy(mv => mv.nombre)
				.ToList();
		}
	}
}