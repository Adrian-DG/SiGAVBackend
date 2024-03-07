using Domain.ViewModels;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class StatsRepository : IStatsRepository
	{
		private readonly MainContext _context;
		private readonly DbSet<Asistencia> _asistencias;

		public StatsRepository(MainContext context)
		{
			_context = context;
			_asistencias = _context.Set<Asistencia>();
		}

		public async Task<List<GraphViewModel>> GetAsistenciasByRegion(Expression<Func<Asistencia, bool>> predicate)
		{
			return await _asistencias
				.Where(predicate)
				.Include(x => x.UnidadMiembro.Unidad.Tramo.RegionAsistencia)
				.GroupBy(x => x.UnidadMiembro.Unidad.Tramo.RegionAsistencia.Nombre)
				.Select(x => new GraphViewModel { Nombre = x.Key, Value = x.Count() })
				.ToListAsync();				
		}

		public async Task<List<GraphViewModel>> GetAsistenciasByTramo(Expression<Func<Asistencia, bool>> predicate)
		{
			return await _asistencias
				.Where(predicate)
				.Include(x => x.UnidadMiembro.Unidad.Tramo)
				.GroupBy(x => x.UnidadMiembro.Unidad.Tramo.Nombre)
				.Select(x => new GraphViewModel { Nombre = x.Key, Value = x.Count() })
				.ToListAsync();
		}

		public async Task<List<GraphViewModel>> GetAsistenciasByProvincia(Expression<Func<Asistencia, bool>> predicate)
		{
			return await _asistencias
				.Where(predicate)
				.Include(x => x.Provincia)
				.GroupBy(x => x.Provincia.Nombre)
				.Select(x => new GraphViewModel { Nombre = x.Key, Value = x.Count() })
				.ToListAsync();
		}

		public async Task<List<GraphViewModel>> GetAsistenciasByTipoVehiculo(Expression<Func<Asistencia, bool>> predicate)
		{
			return await _asistencias
				.Where(predicate)
				.Include(x => x.VehiculoTipo)
				.GroupBy(x => x.VehiculoTipo.Nombre)
				.Select(x => new GraphViewModel { Nombre = x.Key, Value = x.Count() })
				.ToListAsync();
		}

		public async Task<List<GraphViewModel>> GetStatsByEstatus(Expression<Func<Asistencia, bool>> predicate)
		{
			var result = await _asistencias
				.Where(predicate)
				.GroupBy(x => x.EstatusAsistencia)
				.Select(x => new GraphViewModel { Nombre = x.Key.ToString(), Value = x.Count() })
				.ToListAsync();

			return result;				
		}

	}
}
