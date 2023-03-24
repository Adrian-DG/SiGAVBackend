using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class TramosController : GenericController<Tramo>
	{
		private readonly TramoRepository _tramos;
		public TramosController(IUnitOfWork unitOfWork, ISpecifaction<Tramo> specifaction) : base(unitOfWork, specifaction)
		{
			_tramos = (TramoRepository)_repository;
			_predicate = x => x.Nombre.Contains(_searchTerm) && x.Estatus == _status;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllTramos([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				_status = filters.Status;
				var result = await _tramos.GetAllTramosAsync(filters, _predicate);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
