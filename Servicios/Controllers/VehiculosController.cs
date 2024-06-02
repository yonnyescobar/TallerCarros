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
	public class VehiculosController : ApiController
	{
		//GET
		public Vehiculo Get(string placa)
		{
			clsVehiculo _vehiculo = new clsVehiculo();
			return _vehiculo.Consultar(placa);
		}

		//GET
		public IQueryable Get()
		{
			clsVehiculo _vehiculo = new clsVehiculo();
			return _vehiculo.ConsultarVehiculos();
		}

		//POST
		public string Post([FromBody] Vehiculo vehiculo)
		{
			clsVehiculo _vehiculo = new clsVehiculo();
			_vehiculo.vehiculo = vehiculo;
			return _vehiculo.Insertar();
		}

		//PUT
		public string Put([FromBody] Vehiculo vehiculo)
		{
			clsVehiculo _vehiculo = new clsVehiculo();
			_vehiculo.vehiculo = vehiculo;
			return _vehiculo.Actualizar();
		}

		//DELETE
		public string Delete([FromBody] Vehiculo vehiculo)
		{
			clsVehiculo _vehiculo = new clsVehiculo();
			_vehiculo.vehiculo = vehiculo;
			return _vehiculo.Eliminar();
		}
	}
}