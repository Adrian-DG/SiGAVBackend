﻿using Domain.ViewModels;
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
	public class UnidadRepository : GenericRepository<Unidad>
	{
		public UnidadRepository(MainContext mainContext) : base(mainContext)
		{
		}

		public async Task<PagedData<UnidadViewModel>> GetAllUnidadesAsync(PaginationFilter filters, Expression<Func<Unidad, bool>> predicate)
		{
			var results = await _repository
							.Include(u => u.Tramo)
							.Include(u => u.TipoUnidad)
							.Where(predicate)							
							.Skip((filters.Page - 1) * filters.Size)
							.Take(filters.Size)
							.OrderBy(u => u.FechaCreacion)
							.Select(u => new UnidadViewModel
							{
								Id = u.Id,
								Denominacion = u.Denominacion,
								Ficha = u.Ficha,
								Placa = u.Placa,
								Tramo = u.Tramo.Nombre,
								Cobertura = u.Cobertura,
								TipoUnidad = u.TipoUnidad.Nombre,
								PuntosAsignados = u.PuntosAsignados
							})
							.ToListAsync();

			return new PagedData<UnidadViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = results,
				TotalCount = await GetTotalRecords(filters.Status)
			};
		}

		public async Task<List<UnidadAutoCompleteViewModel>> GetUnidadesAutoComplete(string param)
		{
			var result = await _repository
						.Include(x => x.Tramo)
						.Where(x => x.Denominacion.Contains(param))
						.Select(x => new UnidadAutoCompleteViewModel
						{
							UnidadId = x.Id,
							Denominacion = x.Denominacion,
							Placa = x.Placa,
							Ficha = x.Ficha,
							Tramo = x.Tramo.Nombre,
							EstaDisponible = false
						})
						.Take(5)
						.ToListAsync();

			return result;
		}

		public async Task<bool> ConfirmUnidadExists(string ficha)
		{
			return await _repository.AnyAsync(x => x.Ficha == ficha);
		}
	}

}
