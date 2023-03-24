using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class AsistenciaRepository : GenericRepository<Asistencia>
	{
		public AsistenciaRepository(MainContext mainContext) : base(mainContext)
		{
		}
	}
}
