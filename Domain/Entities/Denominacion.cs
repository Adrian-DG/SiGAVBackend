using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Denominacion : NombreModelMetadata
	{
		[ForeignKey("Tramo")]
        public int TramoId { get; set; }
        public virtual Tramo Tramo { get; set; }
    }
}
