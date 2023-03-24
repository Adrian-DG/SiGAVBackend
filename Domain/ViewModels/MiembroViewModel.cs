using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class MiembroViewModel
	{
		public int Id { get; set; }
		public string Cedula { get; set; }
		public string NombreCompleto { get; set; }
		public string Rango { get; set; }
		public string Institucion { get; set; }
	}
}
