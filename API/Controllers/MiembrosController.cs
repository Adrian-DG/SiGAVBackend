using Application.DataAccess;
using Domain.Entities;
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
		public async Task<IActionResult> GetAllMiembros(PaginationFilter filters)
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

	}
}
