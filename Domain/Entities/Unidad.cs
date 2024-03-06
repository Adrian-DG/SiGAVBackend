using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Unidad : ModelMetadata
    {
        [NotMapped]
        public string Denominacion { get; set; }
        public string Ficha { get; set; }
        public string Placa { get; set; }
        public string PuntosAsignados { get; set; }
		public string Cobertura { get; set; }
        public bool EstaDisponible { get; set; } = true;

        [ForeignKey("TipoUnidad")]
        public int TipoUnidadId { get; set; }
        public virtual TipoUnidad TipoUnidad { get; set; }

        [ForeignKey("Tramo")]
        public int TramoId { get; set; }
        public virtual Tramo Tramo { get; set; }

        [ForeignKey("Denominacion")]
        public int DenominacionId { get; set; }
        public virtual Denominacion DenominacionT { get; set; }

        public string GetUnidadInfo() => $"{DenominacionT.Nombre} - {Ficha}";
    }
}