using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Tramo : NombreModelMetadata
    {
        public bool PerteneceAGestion { get; set; } = false;

        [ForeignKey("RegionAsistencia")]
        public int RegionAsistenciaId { get; set; }
        public virtual RegionesAsistencia RegionAsistencia { get; set; }
    }
}