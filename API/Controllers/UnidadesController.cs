using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
			_predicate = x => (x.Ficha.Contains(_searchTerm) || x.Placa.Contains(_searchTerm) || x.Denominacion.Contains(_searchTerm));
		}

		[Authorize]
		[HttpPost("create")]
		public async Task<IActionResult> CreateUnidad([FromBody] Unidad model)
		{
			try
			{
				if (await _repository.ConfirmEntityExists(x => x.Ficha == model.Ficha)) return Ok(new ServerResponse { Message = "Esta ficha ya esta en uso !!", Status = false });
				model.EstaDisponible = false;
				model.Estatus = true;
				return await InsertAsync(model);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[Authorize]
		[HttpGet("all")]
		public async Task<IActionResult> GetAllUnidades([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				_status = filters.Status;
				filters.Page = filters.Page > 0 ? filters.Page : 1;
				var result = await _unidades.GetAllUnidadesAsync(filters, _predicate);
				return Ok(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[Authorize]
		[HttpGet("autocomplete")]
		public async Task<IActionResult> GetUnidadesAutoComplete([FromQuery] string param = "")
		{
			try
			{
				param = String.IsNullOrEmpty(param) ? "" : param;
				var result = await _unidades.GetUnidadesAutoComplete(param);
				return Ok(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("confirm")]
		public async Task<IActionResult> ConfirmUnidadExists([FromQuery] string ficha)
		{
			try
			{
				return Ok(await _unidades.ConfirmUnidadExists(ficha));
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("confirmStatus")]
		public async Task<IActionResult> ConfirmUnidadEstatus([FromQuery] string ficha)
		{
			try
			{
				var response = await _unidades.ConfirmUnidadEstatus(ficha);
				return Ok(response);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpPut("changeStatus")]
		public async Task<IActionResult> CambiarEstatusUnidad([FromBody] UpdateUnidadStatus model)
		{
			try
			{
				if (!ModelState.IsValid) return BadRequest(ModelState);
				await _unidades.CambiarEstatusUnidad(model.Ficha);
				return Ok(await _uow.CommitChangesAsync());
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		[HttpGet("filteredByTramo")]
		public async Task<IActionResult> GetUnidadesPorTramo([FromQuery] int tramoId)
		{
			try
			{
				var result = await _unidades.GetUnidadesPorTramo(tramoId);
				return new JsonResult(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}
