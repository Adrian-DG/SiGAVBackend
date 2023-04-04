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
	public class TramoRepository : GenericRepository<Tramo>
	{
		public TramoRepository(MainContext mainContext) : base(mainContext)
		{
		}

		public async Task<PagedData<TramoViewModel>> GetAllTramosAsync(PaginationFilter filters, Expression<Func<Tramo, bool>> predicate)
		{
			var results = await _repository
							.Where(predicate)
							.Include(t => t.RegionAsistencia)
							.Skip((filters.Page - 1) * filters.Size)
							.Take(filters.Size)
							.OrderBy(t => t.FechaCreacion)
							.Select(t => new TramoViewModel { Id = t.Id, Nombre = t.Nombre, RegionAsistencia = t.RegionAsistencia.Nombre })
							.ToListAsync();

			return new PagedData<TramoViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = results,
				TotalCount = await GetTotalRecords()
			};
		}


		public async Task<ICollection<TramoViewModel>> GetTramosByNombre()
		{
			return await _repository
				.Where(x => x.Estatus)
				.Select(x => new TramoViewModel { Id = x.Id, Nombre = x.Nombre, RegionAsistencia = x.Nombre })
				.ToListAsync<TramoViewModel>();
		}

		public async Task<List<GenericData>> GetTramosEncargadoSupervisor(string ficha)
		{
			var unidad = await _context.Unidades
					    .Include(x => x.Tramo)
						.SingleAsync(x => x.Ficha == ficha);

			if(unidad.TipoUnidadId == 1) // Encargado regional (todos los tramos correspondientes a su region)
			{
				return await _repository
					.Where(x => x.RegionAsistenciaId == unidad.Tramo.RegionAsistenciaId)
					.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
					.ToListAsync();
			}
			else // Supervisor tramo (solo el tramo al que esta asignado)
			{
				return await _repository
					.Where(x => x.Id == unidad.TramoId)
					.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
					.ToListAsync();
			}

		}

	}
}
