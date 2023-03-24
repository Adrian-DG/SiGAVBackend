using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UnidadMiembro : ModelMetadata
    {
        [ForeignKey("Unidad")]
        public int UnidadId { get; set; }
        public virtual Unidad Unidad { get; set; }

        [ForeignKey("Miembro")]
        public int MiembroId { get; set; }
        public virtual Miembro Miembro { get; set; }
    }
}