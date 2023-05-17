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
		public EstatusAsistencia EstatusAsistencia { get; set; }
		public Nullable<int> CodUsuario { get; set; }
	}
}
