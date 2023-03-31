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
			_predicate = x => (x.Cedula.Contains(_searchTerm) || x.Nombre.Contains(_searchTerm) || x.Apellido.Contains(_searchTerm)) && x.Estatus == _status;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllMiembros([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				_status = filters.Status;
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
				await _miembros.CreateMiembro(model);
				return Ok(_response.GetResponse(await _uow.CommitChangesAsync()));
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPut("authorize")]
		public async Task<IActionResult> UpdateEstatusMiembro([FromBody] int id)
		{
			try
			{
				await _miembros.UpdateEstatusMiembro(id);
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
