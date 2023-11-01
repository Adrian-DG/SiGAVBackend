using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class UpdateAsistencia
	{
		public int Id { get; set; }
		public int EstatusAsistencia { get; set; }
		public Nullable<int> CodUsuario { get; set; }
		public Nullable<int> UnidadMiembroId { get; set; } 
	}
}
