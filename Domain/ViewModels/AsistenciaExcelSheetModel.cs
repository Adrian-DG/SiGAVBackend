using Domain.ProcedureResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class AsistenciaExcelSheetModel : SP_ReporteAsistenciasDetalles
	{
		//public string Tipo { get; set; }
		//public string Categoria { get; set; }
		//public string Unidad { get; set; }
		//public string Region { get; set; }
		//public string Provincia { get; set; }
		//public string Municipio { get; set; }
		//public string Tramo { get; set; }

		public string Identificacion { get; set; }

		public string Fecha { get; set; }
	}
}
