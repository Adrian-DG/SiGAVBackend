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
			_predicate = x => (x.Ficha.Contains(_searchTerm) || x.Placa.Contains(_searchTerm) || x.Denominacion.Contains(_searchTerm)) && x.Estatus == _status;
		}

		[Authorize]
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

	}
}
