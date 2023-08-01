using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class AsistenciaPaginationFilter : PaginationFilter
	{
		public int EstatusAsistencia { get; set; }
	}
}
