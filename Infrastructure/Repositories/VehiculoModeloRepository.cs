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
	public class VehiculoModeloRepository : GenericRepository<VehiculoModelo>
	{
		public VehiculoModeloRepository(MainContext mainContext) : base(mainContext)
		{
		}

		public async Task<PagedData<VehiculoModeloViewModel>> GetAllModelos(PaginationFilter filters, Expression<Func<VehiculoModelo, bool>> predicate)
		{
			var result = await _repository
						.Include(x => x.VehiculoMarca)
						.Include(x => x.VehiculoTipo)
						.Where(predicate)
						.Skip((filters.Page - 1) * filters.Size)
						.Take(filters.Size)
						.OrderBy(x => x.VehiculoMarca.Nombre).ThenBy(x => x.Nombre).ThenBy(x => x.VehiculoTipo.Nombre)
						.Select(x => new VehiculoModeloViewModel { Id = x.Id, Modelo = x.Nombre, Marca = x.VehiculoMarca.Nombre, Tipo = x.VehiculoTipo.Nombre })
						.ToListAsync();

			return new PagedData<VehiculoModeloViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = result,
				TotalCount = await GetTotalRecords(true)
			};
		}
	}
}
