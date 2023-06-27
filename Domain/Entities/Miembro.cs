using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Miembro : PersonaModelMetadata
    {
        [ForeignKey("Rango")]
        public int RangoId { get; set; }
        public virtual Rango Rango { get; set; }
        public Institucion Institucion { get; set; }
        public bool Autorizado { get; set; } = false;
    }
}