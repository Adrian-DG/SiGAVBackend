using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class MarcasController : GenericController<VehiculoMarca>
	{
		public MarcasController(IUnitOfWork unitOfWork, ISpecifaction<VehiculoMarca> specifaction) : base(unitOfWork, specifaction)
		{
			_predicate = x => x.Nombre.Contains(_searchTerm) &&  x.Estatus == _status;
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateMarca([FromBody] VehiculoMarca model)
		{
			try
			{
				if (await _repository.ConfirmEntityExists(x => x.Nombre.ToLower() == model.Nombre.ToLower())) return Ok(new ServerResponse { Message = "Esta marca ya existe!!", Status = false });
				return await InsertAsync(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
