using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class UpdateReasignarAsistenciaDTO
	{
		public int IdAsistencia { get; set; }
		public int NewUnidadId { get; set; }
		public int UsuarioId { get; set; }
	}
}
