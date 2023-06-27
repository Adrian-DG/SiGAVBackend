using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class MiembrosController : GenericController<Miembro>
	{
		private readonly MiembroRepository _miembros;
		public MiembrosController(IUnitOfWork unitOfWork, ISpecifaction<Miembro> specifaction) : base(unitOfWork, specifaction)
		{
			_miembros = (MiembroRepository)_repository;
			_predicate = x => (x.Cedula.Contains(_searchTerm) || x.Nombre.Contains(_searchTerm) || x.Apellido.Contains(_searchTerm)) && x.Autorizado == _status && x.Estatus;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllMiembros([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				_status = filters.Status;
				filters.Page = filters.Page > 0 ? filters.Page : 1;
				var results = await _miembros.GetAllMiembrosAsync(filters, _predicate);
				return Ok(results);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateMiembro([FromBody] CreateMiembroDTO model)
		{
			try
			{
				if (await _miembros.ConfirmEntityExists(x => x.Cedula == model.Cedula)) return Ok(new ServerResponse {  Message = "Esta cédula ya esta en uso !!", Status = false });
				await _miembros.CreateMiembro(model);
				return Ok(_response.GetResponse(await _uow.CommitChangesAsync()));
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpPost("createApp")]
		public async Task<IActionResult> CreateMiembroApp([FromBody] CreateMiembroDTO model)
		{
			try
			{
				if (await _miembros.ConfirmEntityExists(x => x.Cedula == model.Cedula)) return Ok(false);
				await _miembros.CreateMiembro(model);
				return Ok(_response.GetResponse(await _uow.CommitChangesAsync()).Status);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPut("authorize")]
		public async Task<IActionResult> UpdateEstatusMiembro([FromBody] UpdateStatusMiembroDTO model)
		{
			try
			{
				await _miembros.UpdateEstatusMiembro(model);
				return Ok(_response.GetResponse(await _uow.CommitChangesAsync()));
			}
			catch (Exception)
			{
				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("confirm")]
		public async Task<IActionResult> ConfirmMiembroExists([FromQuery] string cedula)
		{
			try
			{
				return Ok(await _miembros.ConfirmMiembroExists(cedula));
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}
