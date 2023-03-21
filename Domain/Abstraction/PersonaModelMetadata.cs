using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public class PersonaModelMetadata : ModelMetadata
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }        
        
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public Genero Genero { get; set; }
    }
}