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
	public class EmpleadosController : ApiController
	{
		//GET
		public Empleado Get(string documento)
		{
			clsEmpleado _empleado = new clsEmpleado();
			return _empleado.Consultar(documento);
		}

		//GET
		public IQueryable Get()
		{
			clsEmpleado _empleado = new clsEmpleado();
			return _empleado.ConsultarEmpleados();
		}

		//POST
		public string Post([FromBody] Empleado empleado)
		{
			clsEmpleado _empleado = new clsEmpleado();
			_empleado.empleado = empleado;
			return _empleado.Insertar();
		}

		//PUT
		public string Put([FromBody] Empleado empleado)
		{
			clsEmpleado _empleado = new clsEmpleado();
			_empleado.empleado = empleado;
			return _empleado.Actualizar();
		}

		//DELETE
		public string Delete([FromBody] Empleado empleado)
		{
			clsEmpleado _empleado = new clsEmpleado();
			_empleado.empleado = empleado;
			return _empleado.Eliminar();
		}

	}
}