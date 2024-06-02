using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
	public class clsCargo
	{
		private TallerCarrosEntities dbTallerCarros = new TallerCarrosEntities();

		public Cargo cargo { get; set; }

		public List<Cargo> ConsultarCargos()
		{
			return dbTallerCarros.Cargos
				.Where(c => c.id_cargo != 0)
				.OrderBy(c => c.nombre) 
				.ToList();
		}
	}
}