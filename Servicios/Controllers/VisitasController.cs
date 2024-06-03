using Servicios.Clases;
using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios.Controllers
{
	[EnableCors(origins: "http://localhost:50167", headers: "*", methods: "*")]
	public class VisitasController : ApiController
	{
		// GET Visitas
		public IQueryable Get()
		{
			clsVisita _visita = new clsVisita();
			return _visita.ConsultarVisitas();
		}

		// POST
		public string Post([FromBody] Visita visita)
		{
			clsVisita _visita = new clsVisita();
			_visita.visita = visita;
			return _visita.Insertar();
		}

	}
}