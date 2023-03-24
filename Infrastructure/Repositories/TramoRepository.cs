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
	}
}
