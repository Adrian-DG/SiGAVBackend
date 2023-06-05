using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class AsistenciaEditViewModel
	{
		public int Id { get; set; }
		public string Identificacion { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Telefono { get; set; }
		public Genero Genero { get; set; }

		public string Placa { get; set; }

		public int VehiculoTipoId { get; set; }
		public int VehiculoColorId { get; set; }
		public int VehiculoModeloId { get; set; }
		public int VehiculoMarcaId { get; set; }

		public IList<int> TipoAsistencias { get; set; }
		public string Comentario { get; set; }
	}
}
