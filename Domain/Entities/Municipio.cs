using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Municipio : NombreModelMetadata
    {
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}