using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
	public class clsCliente
	{
		private TallerCarrosEntities dbTallerCarros = new TallerCarrosEntities();

		public Cliente cliente { get; set; }

		public string Insertar()
		{
			try
			{
				dbTallerCarros.Clientes.Add(cliente);
				dbTallerCarros.SaveChanges();
				return "Se registró el cliente: " + cliente.nombre + " " + cliente.apellido + " correctamente";
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
				dbTallerCarros.Clientes.AddOrUpdate(cliente);
				dbTallerCarros.SaveChanges();
				return "Se actualizó el cliente: " + cliente.nombre + " " + cliente.apellido + " correctamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public Cliente Consultar(string documento)
		{
			return dbTallerCarros.Clientes.FirstOrDefault(e => e.documento == documento);
		}

		public List<Cliente> ConsultarClientes()
		{
			return dbTallerCarros.Clientes
				.Where(c => c.id_cliente != 0)
				.OrderBy(c => c.nombre)
				.ToList();
		}

		public string Eliminar()
		{
			try
			{
				Cliente _cliente = Consultar(cliente.documento);
				dbTallerCarros.Clientes.Remove(_cliente);
				dbTallerCarros.SaveChanges();
				return "Se eliminó el cliente con documento: " + cliente.documento + " correctamente";

			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}