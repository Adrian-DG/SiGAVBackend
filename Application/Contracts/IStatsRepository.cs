using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
	public interface IStatsRepository
	{
		Task<List<GraphViewModel>> GetAsistenciasByRegion(Expression<Func<Asistencia, bool>> predicate);
		Task<List<GraphViewModel>> GetAsistenciasByTramo(Expression<Func<Asistencia, bool>> predicate);
		Task<List<GraphViewModel>> GetAsistenciasByProvincia(Expression<Func<Asistencia, bool>> predicate);
		Task<List<GraphViewModel>> GetAsistenciasByTipoVehiculo(Expression<Func<Asistencia, bool>> predicate);
	}
}
