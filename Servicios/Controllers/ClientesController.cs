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
	public class ClientesController : ApiController
	{
		//GET
		public Cliente Get(string documento)
		{
			clsCliente _cliente = new clsCliente();
			return _cliente.Consultar(documento);
		}

		//GET
		public List<Cliente> Get()
		{
			clsCliente _cliente = new clsCliente();
			return _cliente.ConsultarClientes();
		}

		//POST
		public string Post([FromBody] Cliente cliente)
		{
			clsCliente _cliente = new clsCliente();
			_cliente.cliente = cliente;
			return _cliente.Insertar();
		}

		//PUT
		public string Put([FromBody] Cliente cliente)
		{
			clsCliente _cliente = new clsCliente();
			_cliente.cliente = cliente;
			return _cliente.Actualizar();
		}

		//DELETE
		public string Delete([FromBody] Cliente cliente)
		{
			clsCliente _cliente = new clsCliente();
			_cliente.cliente = cliente;
			return _cliente.Eliminar();
		}

	}
}