using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class CreateAsistenciaR5
	{
		public string Identificacion { get; set; } // Cedula o Pasaporte
		public string Nombre { get; set; }
		public string Apellido { get; set; }

		public string Telefono { get; set; }
		public Genero Genero { get; set; }
		public bool EsExtranjero { get; set; }


		public int VehiculoTipoId { get; set; }
		public int VehiculoColorId { get; set; }
		public int VehiculoModeloId { get; set; }
		public int VehiculoMarcaId { get; set; }
		public string Placa { get; set; }


		public int MunicipioId { get; set; }
		public int ProvinciaId { get; set; }
		public string Direccion { get; set; }
		public int UnidadId { get; set; }

		public IList<int> TipoAsistencias { get; set; }


		public string Comentario { get; set; }
		public int UsuarioId { get; set; }

	}
}
