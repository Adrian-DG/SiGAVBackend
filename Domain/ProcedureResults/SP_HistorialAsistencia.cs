using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProcedureResults
{
    public class SP_HistorialAsistencia
    {
        public string Ficha { get; set; }
        public string Rango { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
