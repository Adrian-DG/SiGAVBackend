using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class StatsFilterDTO
	{
		public int Estatus { get; set; }
		public DateTime Initial { get; set; }
		public DateTime Final { get; set; }
	}
}
