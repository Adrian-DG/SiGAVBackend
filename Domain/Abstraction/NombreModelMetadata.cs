using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public abstract class NombreModelMetadata : ModelMetadata
    {
        public string Nombre { get; set; }
    }
}