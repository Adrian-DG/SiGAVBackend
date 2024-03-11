using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class DatosPreHospitalaria : ModelMetadata
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

        public bool  EsTraslado { get; set; } // Si el paciente fue trasladado o no
        public TipoCausaTrasladoEnum TipoTraslado { get; set; }

        public DepachoAsistenciaEnum DespachadaPor { get; set; }
        public ApoyoBrindadoEnum ApoyoBrindado { get; set; }

        // Lugar 
        public bool FueEventoCampo { get; set; }
        public string DetalleEvento { get; set; }
        public RegionMacro Zona { get; set; }

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

        public DateTime TiempoLlamadaRecibida { get; set; }
        public DateTime TiempoLlegada { get; set; }
        public DateTime TiempoAbordajePaciente { get; set; }
        public DateTime TiempoSalidaHospital  { get; set; }
        public DateTime TiempoEntregaPaciente  { get; set; }
        public TipoAsistenciaPreHospitalariaEnum TipoAsistencia { get; set; }
        public string DetalleAsistencia { get; set; } // Detalle de la asistencia 

        // Signos Vitales 
		public int FrecuenciaCardiaca { get; set; }
		public int FrecuenciaRespiratoria { get; set; }
		public int TensionArterialSistolica { get; set; }
		public int TensionArterialDiastolica { get; set; }
		public int SaturacionParcialOxigeno { get; set; }
		public int Temperatura { get; set; }
		public LlenadoCapilarEnum LlenadoCapilar { get; set; }
		public int AperturaOcular { get; set; } // del 1 al 4
		public int RespuestaVerbal { get; set; } // del 1 al 5
		public int RespuestaMotora { get; set; } // del 1 al 5

        //
		public string HallazgoPositivo { get; set; }
		public string DiagnosticoPresuntivo { get; set; }
		public string ProcedimientosRealizados { get; set; }
        public string InsumosUtilizados { get; set; } // Insumos / Medicamentos

        // Datos personal brindo asistencia 

        [ForeignKey("Miembro")]
        public int  MiembroId { get; set; }
        public virtual Miembro Miembro { get; set; }

		[ForeignKey("Componente1")]
		public int Componente1Id { get; set; }
		public virtual Miembro Componente1 { get; set; }

		[ForeignKey("Componente2")]
		public int Componente2Id { get; set; }
		public virtual Miembro Componente2 { get; set; }


		[ForeignKey("RegularEmergencia")]
		public int ReguladorEmergeciaId { get; set; }
		public virtual Miembro ReguladorEmergencia { get; set; }


	}
}
