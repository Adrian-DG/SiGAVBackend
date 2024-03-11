using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Hospital : NombreModelMetadata
	{
		public RegionMacro Region { get; set; }
	}
}
