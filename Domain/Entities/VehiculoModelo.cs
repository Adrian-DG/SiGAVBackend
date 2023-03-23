using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehiculoModelo : NombreModelMetadata
    {
        [ForeignKey("VehiculoMarca")]
        public int VehiculoMarcaId { get; set; }
        public virtual VehiculoMarca VehiculoMarca { get; set; }
        
        [ForeignKey("VehiculoTipo")]
        public int VehiculoTipoId { get; set; }
        public virtual VehiculoTipo VehiculoTipo { get; set; }
    }
}