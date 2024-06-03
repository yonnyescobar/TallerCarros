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
	public class ServiciosController : ApiController
	{
		// GET Servicios
		public List<Servicio> Get()
		{
			clsServicio _servicio = new clsServicio();
			return _servicio.ConsultarServicios();
		}
	}
}