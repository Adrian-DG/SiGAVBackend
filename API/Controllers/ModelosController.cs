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
				var result = await _modeloRepository.GetAllModelos(filters, _predicate);
				return Ok(result);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
