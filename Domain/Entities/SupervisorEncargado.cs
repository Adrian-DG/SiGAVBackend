using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class SupervisorEncargado : ModelMetadata
	{
		public string IOT { get; set; } // Codigo de encargado/supervisor ej: OP-8

		public CategoriaSupervisor CategoriaSupervisor { get; set; }

		[ForeignKey("Miembro")]
		public int MiembroId { get; set; }
		public virtual Miembro Miembro { get; set; }

	}
}
