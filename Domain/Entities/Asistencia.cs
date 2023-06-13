using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Asistencia : ModelMetadata
    {
        // Ciudadano
		public string Identificacion { get; set; } // Cedula o Pasaporte
        public string Nombre { get; set; }
        public string Apellido { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string Telefono { get; set; }
        public Genero Genero { get; set; }
        public bool EsExtranjero { get; set; }

		// Vehiculo asistido

		[ForeignKey("VehiculoTipo")]
		public int VehiculoTipoId { get; set; }
		public virtual VehiculoTipo VehiculoTipo { get; set; }

		[ForeignKey("VehiculoColor")]
		public int VehiculoColorId { get; set; }
		public virtual VehiculoColor VehiculoColor { get; set; }

		[ForeignKey("VehiculoModelo")]
		public int VehiculoModeloId { get; set; }
		public virtual VehiculoModelo VehiculoModelo { get; set; }

		[ForeignKey("VehiculoMarca")]
		public int VehiculoMarcaId { get; set; }
		public virtual VehiculoMarca VehiculoMarca { get; set; }
		public string Placa { get; set; }

		// Informacion Ubicacion Asistencia		
		public string Coordenadas { get; set; }

		public string Direccion { get; set; }

		[ForeignKey("Municipio")]
		public int MunicipioId { get; set; }
		public virtual Municipio Municipio { get; set; }

		[ForeignKey("Provincia")]
		public int ProvinciaId { get; set; }
		public virtual Provincia Provincia { get; set; }

		// Unidad-Miembro

		[ForeignKey("UnidadMiembro")]
		public int UnidadMiembroId { get; set; }
		public virtual UnidadMiembro UnidadMiembro { get; set; }

		// Imagenes de Asistencia
		public IList<string> Imagenes { get; set; }

		// Tipos de Asistencia
		public IList<TipoAsistencia> TipoAsistencias { get; set; }

		public ReportadoPor ReportadoPor { get; set; }

		[DataType(DataType.MultilineText)]
		public string Comentario { get; set; }

		// Tiempos
		[DataType(DataType.Time)]
		public DateTime TiempoLlegada { get; set; }

		[DataType(DataType.Time)]
		public DateTime TiempoCompletada { get; set; }

		// Estatus 
		public EstatusAsistencia EstatusAsistencia { get; set; }
	}
}