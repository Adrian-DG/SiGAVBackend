using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class HistoricoAsistencia : ModelMetadata
	{
		public int IdAsistencia { get; set; }
		public int IdUnidadMiembro { get; set; }
	}
}
