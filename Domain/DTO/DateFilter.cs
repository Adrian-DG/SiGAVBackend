using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class DateFilter
	{
		public DateTime InitialDate { get; set; }
		public DateTime FinalDate { get; set; }

		public DateFilter(DateTime initialDate, DateTime finalDate)
		{
			InitialDate = initialDate;
			FinalDate = finalDate;
		}
	}
}
