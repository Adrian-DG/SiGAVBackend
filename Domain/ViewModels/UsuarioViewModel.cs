using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class UsuarioViewModel
	{
		public int Id { get; set; }
		public string Cedula { get; set; }
		public string NombreCompleto { get; set; }
		public string NombreUsuario { get; set; }
		public string TipoUsuario { get; set; }
		public bool Estatus { get; set; }
	}
}
