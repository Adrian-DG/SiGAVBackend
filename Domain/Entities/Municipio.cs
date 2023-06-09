using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Municipio : NombreModelMetadata
    {
        [ForeignKey("Provincia")]
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}