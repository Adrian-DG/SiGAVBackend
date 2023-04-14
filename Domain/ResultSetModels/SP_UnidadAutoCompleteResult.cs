using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResultSetModels
{
    public class SP_UnidadAutoCompleteResult
    {
        public int UnidadId { get; set; }
        public string Denominacion { get; set; }
        public string Ficha { get; set; }
        public string Placa { get; set; }
        public string Tramo { get; set; }
        public bool EstaDisponible { get; set; }
    }
}
