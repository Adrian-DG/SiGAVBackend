using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
	public class LoginUnitResponse
	{
		public string Denominacion { get; set; }
		public int UnidadMiembroId { get; set; }
		public string Ficha { get; set; }
		public string Placa { get; set; }
		public string Tramo { get; set; }
		public string MiembroInfo { get; set; }
		public string Token { get; set; }
		public bool Estatus { get; set; }
		public bool EsEncargado { get; set; }
		public bool AccesoTotal { get; set; }
        public int PertenceA { get; set; }
    }
}
