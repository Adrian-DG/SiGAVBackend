using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ModelosController : GenericController<VehiculoModelo>
	{
		private readonly VehiculoModeloRepository _modeloRepository;
		public ModelosController(IUnitOfWork unitOfWork, ISpecifaction<VehiculoModelo> specifaction) : base(unitOfWork, specifaction)
		{
			_modeloRepository = (VehiculoModeloRepository)_repository;
			_predicate = x => (x.Nombre.Contains(_searchTerm) || x.VehiculoMarca.Nombre.Contains(_searchTerm)) && x.Estatus == _status;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllModelos([FromQuery] PaginationFilter filters)
		{
			try
			{
				_status = filters.Status;
				_searchTerm = filters.SearchTerm is null ? "" : filters.SearchTerm;
				filters.Page = filters.Page > 0 ? filters.Page : 1;
				var result = await _modeloRepository.GetAllModelos(filters, _predicate);
				return Ok(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateModelo([FromBody] VehiculoModelo model)
		{
			try
			{
				if (await _repository.ConfirmEntityExists(x => x.Nombre.ToLower() == model.Nombre.ToLower())) return Ok(new ServerResponse { Message = "Este modelo ya existe!!", Status = false });
				return await InsertAsync(model);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
