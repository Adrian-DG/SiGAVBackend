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
	public class MiembroRepository : GenericRepository<Miembro>
	{
		public MiembroRepository(MainContext mainContext) : base(mainContext)
		{
		}

		public async Task<PagedData<MiembroViewModel>> GetAllMiembrosAsync(PaginationFilter filters, Expression<Func<Miembro, bool>> predicate)
		{
			var results = await _repository
							.Include(u => u.Rango)
							.Where(predicate)
							.Skip((filters.Page - 1) * filters.Size)
							.Take(filters.Size)
							.OrderBy(u => u.FechaCreacion)
							.Select(u => new MiembroViewModel
							{
								Id = u.Id,
								Cedula = u.Cedula,
								NombreCompleto = u.NombreCompleto(),
								Rango = u.Rango.Nombre,
								Institucion = u.Institucion.ToString()
							})
							.ToListAsync();

			return new PagedData<MiembroViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = results,
				TotalCount = await GetTotalRecords()
			};
		}
	}
}
