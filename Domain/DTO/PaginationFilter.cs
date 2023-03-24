using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class PaginationFilter
	{
		public int Page { get; set; } = 1;
		public int Size { get; set; } = 10;
		public string SearchTerm { get; set; }
		public bool Status { get; set; }

		public PaginationFilter()
		{
			this.Page = 1;
			this.Size = 10;
		}
		public PaginationFilter(int pageNumber, int pageSize)
		{
			this.Page = pageNumber < 1 ? 1 : pageNumber;
			this.Size = pageSize > 10 ? 10 : pageSize;
		}
	}
}
