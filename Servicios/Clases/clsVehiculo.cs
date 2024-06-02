using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
	public class clsVehiculo
	{
		private TallerCarrosEntities dbTallerCarros = new TallerCarrosEntities();

		public Vehiculo vehiculo { get; set; }

		public string Insertar()
		{
			try
			{
				dbTallerCarros.Vehiculos.Add(vehiculo);
				dbTallerCarros.SaveChanges();
				return "Se registró el vehículo de placa: " + vehiculo.placa + " correctamente";
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
				dbTallerCarros.Vehiculos.AddOrUpdate(vehiculo);
				dbTallerCarros.SaveChanges();
				return "Se actualizó el vehículo de placa: " + vehiculo.placa + " correctamente";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public Vehiculo Consultar(string placa)
		{
			return dbTallerCarros.Vehiculos.FirstOrDefault(e => e.placa == placa);
		}

		public IQueryable ConsultarVehiculos()
		{
			return from V in dbTallerCarros.Set<Vehiculo>()
				   join Cl in dbTallerCarros.Set<Cliente>()
				   on V.id_cliente equals Cl.id_cliente
				   join MV in dbTallerCarros.Set<MarcasVehiculo>()
				   on V.id_marca equals MV.id_marca
				   orderby MV.nombre ascending
				   select new
				   {
					   Marca = MV.nombre,
					   Modelo = V.modelo,
					   Año = V.ano,
					   Placa = V.placa,
					   Cliente = Cl.nombre + " " + Cl.apellido
				   };
				   
		}

		public string Eliminar()
		{
			try
			{
				Vehiculo _vehiculo = Consultar(vehiculo.placa);
				dbTallerCarros.Vehiculos.Remove(_vehiculo);
				dbTallerCarros.SaveChanges();
				return "Se eliminó el vehículo de placa: " + vehiculo.placa + " correctamente";

			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}