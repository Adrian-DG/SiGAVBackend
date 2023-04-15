using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class UnidadMiembroController : GenericController<UnidadMiembro>
	{
		private readonly UnidadMiembroRepository _unidadMiembro;
		public UnidadMiembroController(IUnitOfWork unitOfWork, ISpecifaction<UnidadMiembro> specifaction) : base(unitOfWork, specifaction)
		{
			_unidadMiembro = (UnidadMiembroRepository)_repository;
		}

		[AllowAnonymous]
		[HttpPost("create")]
		public IActionResult CreateUnidadMiembro([FromBody] CreateUnidadMiembro model)
		{
			try
			{
				var result = _unidadMiembro.CreateUnidadMiembro(model);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
