using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProcedureResults
{
    public class SP_ReporteAsistenciasDetalles
    {
        // Ubicacion
        public string Region { get; set; }
        public string Tramo { get; set; }
		public string Provincia { get; set; }
		public string Municipio { get; set; }
		
        // Unidad
        public string Unidad { get; set; }
        public string Ficha { get; set; }
        
        // Asistencia
        public string CategoriaAsistencia { get; set; }
        public string TipoAsistencia { get; set; }

        // Ciudadano
        public string Cedula { get; set; }
        public string Pasaporte { get; set; }
        public string NombreCiudadano { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string EsExtranjero { get; set; }

        // Vehiculo Asistido
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }

        // Soldado
        public string Institucion { get; set; }
        public string RangoAgente { get; set;}
        public string CedulaSoldado { get; set; }
        public string NombreSoldado { get; set; }

        // Creacion
        public string FechaCreacion { get; set; }
        public string TiempoCreacion { get; set; }
        public string TiempoLlegada { get; set; }
        public string TiempoCompletada { get; set; }
        public string QuienReporta { get; set; }
        public string Usuario { get; set; }
        public string Comentario { get; set; }
    }
}




