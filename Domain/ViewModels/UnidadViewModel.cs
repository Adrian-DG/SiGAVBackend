using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class UnidadViewModel
	{
		public int Id { get; set; }
		public string Denominacion { get; set; }
		public string Ficha { get; set; }
		public string Placa { get; set; }
		public Tramo Tramo { get; set; }
		public string PuntosAsignados { get; set; }
		public string Cobertura { get; set; }
		public string TipoUnidad { get; set; }
	}
}
