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
		//GET
		public Servicio Get(int id_servicio)
		{
			clsServicio _servicio = new clsServicio();
			return _servicio.Consultar(id_servicio);
		}

		// GET Servicios
		public List<Servicio> Get()
		{
			clsServicio _servicio = new clsServicio();
			return _servicio.ConsultarServicios();
		}

		//POST
		public string Post([FromBody] Servicio servicio)
		{
			clsServicio _servicio = new clsServicio();
			_servicio.servicio = servicio;
			return _servicio.Insertar();
		}

		//PUT
		public string Put([FromBody] Servicio servicio)
		{
			clsServicio _servicio = new clsServicio();
			_servicio.servicio = servicio;
			return _servicio.Actualizar();
		}

		//DELETE
		public string Delete([FromBody] Servicio servicio)
		{
			clsServicio _servicio = new clsServicio();
			_servicio.servicio = servicio;
			return _servicio.Eliminar();
		}
	}
}