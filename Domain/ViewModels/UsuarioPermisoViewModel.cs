using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class UsuarioPermisoViewModel : UsuarioViewModel
	{
		public List<PermisoViewModel> Permisos { get; set; }
	}
}
