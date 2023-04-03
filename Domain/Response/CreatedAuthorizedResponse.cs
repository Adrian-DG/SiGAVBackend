using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
	public class CreatedAuthorizedResponse
	{
		public bool Created { get; set; }
		public bool IsAuthorized { get; set; }
	}
}
