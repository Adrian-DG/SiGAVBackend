using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class SupervisorEncargadoTramo : ModelMetadata
	{
		[ForeignKey("IOT")]
		public int SupervisorEncargadoId { get; set; }
		public virtual SupervisorEncargado SupervisorEncargado { get; set; }

		[ForeignKey("Tramo")]
		public int TramoId { get; set; }
		public virtual Tramo Tramo { get; set; }
	}
}
