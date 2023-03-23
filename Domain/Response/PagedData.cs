using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
	public class PagedData<T> where T : class
	{
		public int Page { get; set; }
		public int Size { get; set; }
		public List<T> Items { get; set; }
		public int TotalCount { get; set; }
	}
}
