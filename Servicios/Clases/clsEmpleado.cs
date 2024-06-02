using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
	public class clsEmpleado
	{
		private TallerCarrosEntities dbTallerCarros = new TallerCarrosEntities();

		public Empleado empleado { get; set; }

		public string Insertar()
		{
			try
			{
				dbTallerCarros.Empleados.Add(empleado);
				dbTallerCarros.SaveChanges();
				return "Se registró el empleado: " + empleado.nombre + " " + empleado.apellido + " correctamente";
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
				dbTallerCarros.Empleados.AddOrUpdate(empleado);
				dbTallerCarros.SaveChanges();
				return "Se actualizó el empleado: " + empleado.nombre + " " + empleado.apellido + " correctamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public Empleado Consultar(string documento)
		{
			return dbTallerCarros.Empleados.FirstOrDefault(e => e.documento == documento);
		}

		public IQueryable ConsultarEmpleados()
		{
			return from E in dbTallerCarros.Set<Empleado>()
				   join CA in dbTallerCarros.Set<Cargo>()
				   on E.id_cargo equals CA.id_cargo
				   orderby E.nombre ascending
				   select new
				   {
					   Documento = E.documento,
					   Nombre = E.nombre + " " + E.apellido,
					   Telefono = E.telefono,
					   Correo = E.email,
					   Cargo = CA.nombre
				   };
		}

		public string Eliminar()
		{
			try
			{
				Empleado _empleado = Consultar(empleado.documento);
				dbTallerCarros.Empleados.Remove(_empleado);
				dbTallerCarros.SaveChanges();
				return "Se eliminó el empleado con documento: " + empleado.documento + " correctamente";

			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}