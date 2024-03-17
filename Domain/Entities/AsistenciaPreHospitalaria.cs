using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class AsistenciaPreHospitalaria : ModelMetadata
	{
        // Ciudadano
        public string Identificacion { get; set; } // Cedula o Pasaporte 
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public Genero Sexo { get; set; }
        public string Telefono { get; set; }
        public bool PersonaDesconocida { get; set; }

        [ForeignKey("Nacionalidad")]
        public int NacionalidadId { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public TipoCausaPreHospitalariaEnum TipoCausa { get; set; }

		public bool EsEventoCampo { get; set; }

        // Traslado 
		public bool EsTraslado { get; set; } // Si el paciente fue trasladado o no
		public TipoCausaTrasladoEnum CausaTraslado { get; set; }

		// Evento Especial 
		public bool EsEventoEspecial { get; set; } // Algun evento festivo 
		public string NombreEventoEspecial { get; set; }
		
       
        public DepachoAsistenciaEnum DespachadaPor { get; set; }
        public ApoyoBrindadoEnum ApoyoBrindado { get; set; }
		public TipoAsistenciaPreHospitalariaEnum TipoAsistencia { get; set; }

		// Lugar 
		
        
        public RegionMacro Zona { get; set; }

        [ForeignKey("provincia")]
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }

		[ForeignKey("municipio")]
		public int MunicipioId { get; set; }
		public virtual Municipio Municipio { get; set; }

		[ForeignKey("Unidad")]
        public int UnidadId { get; set; }
        public virtual Unidad Unidad { get; set; }

        [ForeignKey("Denominacion")]
        public int DenominacionId { get; set; }
        public virtual Denominacion Denominacion { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
        public string PersonaRecibioEnHospital { get; set; }
        public string AntecedentesMorbidos { get; set; } // Detalle enfermedades del paciente
        public string DetalleAsistencia { get; set; } // Detalle de la asistencia 

        // Signos Vitales 
        public IList<SignosVitales> SignosVitales { get; set; }

        // Imagenes
        public IList<string> Imagenes { get; set; }

        //
        public string HallazgoPositivo { get; set; }
		public string DiagnosticoPresuntivo { get; set; }
		public string ProcedimientosRealizados { get; set; }
        public string InsumosUtilizados { get; set; } // Insumos / Medicamentos

        // Datos personal brindo asistencia 

        [ForeignKey("Miembro")]
        public int  MedicoId { get; set; }
        public virtual Miembro Medico { get; set; }

		[ForeignKey("Componente1")]
		public int Componente1Id { get; set; }
		public virtual Miembro Componente1 { get; set; }

		[ForeignKey("Componente2")]
		public int Componente2Id { get; set; }
		public virtual Miembro Componente2 { get; set; }


		[ForeignKey("ReguladorEmergencia")]
		public int ReguladorEmergeciaId { get; set; }
		public virtual Miembro ReguladorEmergencia { get; set; }

        public EstatusAsistencia EstatusAsistencia { get; set; }


	}
}
