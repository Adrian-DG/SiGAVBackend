using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class HistoricoUnidad : ModelMetadata
	{
		public string Denominacion { get; set; }
		public string Ficha { get; set; }
		public string Placa { get; set; }
		public int UnidadId { get; set; }
		public int TipoUnidad { get; set; }
		public int TramoId { get; set; }

	}
}
