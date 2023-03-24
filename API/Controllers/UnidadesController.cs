using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class UnidadesController : GenericController<Unidad>
	{
		private readonly UnidadRepository _unidades;
		public UnidadesController(IUnitOfWork unitOfWork, ISpecifaction<Unidad> specifaction) : base(unitOfWork, specifaction)
		{
			_unidades = (UnidadRepository)_repository;
			_predicate = x => (x.Ficha.Contains(_searchTerm) || x.Placa.Contains(_searchTerm) || x.Denominacion.Contains(_searchTerm)) && x.Estatus == _status;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllUnidades([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				_status = filters.Status;
				var result = await _unidades.GetAllUnidadesAsync(filters, _predicate);
				return Ok(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
