using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResultSetsModels
{
    public class SP_ReporteAsistenciasResult
    {
        public string Region { get; set; }
        public string CategoriaAsistencia { get; set; }
        public string TipoAsistencia { get; set; }
        public int Total { get; set; }
    }
}
