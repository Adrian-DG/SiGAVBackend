using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Tramo : NombreModelMetadata
    { 

        [ForeignKey("RegionAsistencia")]
        public int RegionAsistenciaId { get; set; }
        public virtual RegionesAsistencia RegionAsistencia { get; set; }
    }
}