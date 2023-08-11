using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class CreateAsistenciaAgente
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
		public string Coordenadas { get; set; }

		public int UnidadMiembroId { get; set; }

		public IList<int> TipoAsistencias { get; set; }
		public IList<string> Imagenes { get; set; }

		public  ReportadoPor reportadoPor { get; set; }
		public string Comentario { get; set; }
		public int UsuarioId { get; set; }
		public DateTime FechaCreacion { get; set; }
	}
}
