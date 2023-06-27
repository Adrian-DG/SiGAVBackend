using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class TramoViewModel
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string PerteneceA { get; set; }
		public string RegionAsistencia { get; set; }
	}
}
