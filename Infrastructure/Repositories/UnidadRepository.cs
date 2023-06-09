﻿using Domain.ResultSetModels;
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
								PuntosAsignados = u.PuntosAsignados,
								EstaDisponible = u.EstaDisponible,
								Estatus = u.Estatus
							})
							.ToListAsync();

			return new PagedData<UnidadViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = results,
				TotalCount = await GetTotalRecords()
			};
		}

		public async Task<List<SP_UnidadAutoCompleteResult>> GetUnidadesAutoComplete(string param)
		{
			return await _repository
				.Include(x => x.Tramo)
				.Where(x => x.Denominacion.Contains(param) && x.Estatus)
				.Select(x => new SP_UnidadAutoCompleteResult
				{
					UnidadId = x.Id,
					Ficha = x.Ficha,
					Denominacion = x.Denominacion,
					Placa = x.Placa,
					Tramo = x.Tramo.Nombre,
					EstaDisponible = x.EstaDisponible,
				}).ToListAsync();

			//return _context.SP_UnidadAutoComplete_Result.FromSqlInterpolated($"[dbo].[UnidadesAutocompleteAsignar] {param}").ToList();
		}

		public async Task<bool> ConfirmUnidadExists(string ficha)
		{
			return await _repository.AnyAsync(x => x.Ficha == ficha && x.Estatus);
		}

		public async Task<bool> ConfirmUnidadEstatus(string ficha)
		{
			return (await _repository.SingleAsync(x => x.Ficha == ficha)).EstaDisponible;
		}

		public async Task CambiarEstatusUnidad(string ficha)
		{
			var exists = await _repository.AnyAsync(x => x.Ficha == ficha);
			var foundUnit = await _context.Unidades.FirstAsync(x => x.Ficha == ficha);
			foundUnit.EstaDisponible = !foundUnit.EstaDisponible;
			_context.Attach<Unidad>(foundUnit);
			_context.Entry<Unidad>(foundUnit).State = EntityState.Modified;
		}

 	}

}
