using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class SignosVitales
	{
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
	}
}
