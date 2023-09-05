using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProcedureResults
{
	public class SP_ReporteEstadisticoAsistencias
	{
		public string Nombre { get; set; }
		
		// Accidentes
		public int Choque { get; set; }
		public int ChoqueMultiple { get; set; }
		public int ChoqueConAnimal { get; set; }
		public int Deslizamiento  { get; set; }
		public int Volcadura { get; set; }
		public int Atropellamiento { get; set; }

		// Asistencias 
		public int Seguridad { get; set; }
		public int Neumatico { get; set; }
		public int Combustible { get; set; }
		public int Mecanica { get; set; }
		public int Electrica { get; set; }
		public int Calentamiento { get; set; }
		public int Gruas { get; set; }
		public int Ambulancia { get; set; }
		public int Talleres { get; set; }
		public int CamionRescate { get; set; }

	}
}














