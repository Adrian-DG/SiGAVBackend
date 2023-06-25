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
				filters.Page = filters.Page > 0 ? filters.Page : 1;
				var result = await _tramos.GetAllTramosAsync(filters, _predicate);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet("search")]
		public async Task<IActionResult> GetListTramosByNombre()
		{
			try
			{
				var tramosFiltered = await _tramos.GetTramosByNombre();
				return new JsonResult(tramosFiltered);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("supervisar")]
		public async Task<IActionResult> GetTramosEncargadoSupervisor([FromQuery] string ficha)
		{
			try
			{
				var result = await _tramos.GetTramosEncargadoSupervisor(ficha);
				return Ok(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}
