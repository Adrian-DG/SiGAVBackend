﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProcedureResults
{
	public class SP_ObtenerListadoAsistencias
	{
		public int Id { get; set; }
		// Ciudadano 
		public string Identificacion { get; set; } // Cedula o Pasaporte
		public string NombreCiudadano { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string Telefono { get; set; }
		public string Genero { get; set; }
		public bool EsExtranjero { get; set; }

		// Vehiculo 
		public string VehiculoTipo { get; set; }
		public string VehiculoColor { get; set; }
		public string VehiculoModelo { get; set; }
		public string VehiculoMarca { get; set; }
		public string Placa { get; set; }

		// Ubicacion 
		public string Coordenadas { get; set; }
		public string Municipio { get; set; }
		public string Provincia { get; set; }
		public string Tramo { get; set; }

		// Unidad
		public string FichaUnidad { get; set; }
		public string DenominacionUnidad { get; set; }
		public string TipoUnidad { get; set; }

		// Agente
		public string CedulaAgente { get; set; }
		public string NombreAgente { get; set; }
		public string RangoAgente { get; set; }
		public string Institucion { get; set; }
		public string PerteneceA { get; set; }

		// Tipificacion Asistencia
		public IList<TipoAsistencia> TipoAsistencias { get; set; }
		public string Comentario { get; set; }

		// Metadata Asistencia
		public string ReportadaPor { get; set; }
		public DateTime FechaCreacion { get; set; }
		public string EstatusAsistencia { get; set; }
		public bool Estatus { get; set; }
	}
}
