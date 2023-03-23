using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TipoAsistencia : NombreModelMetadata
    {
        public CategoriaAsistencia CategoriaAsistencia { get; set; }
    }
}