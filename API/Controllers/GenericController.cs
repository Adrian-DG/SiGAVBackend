using Application.DataAccess;
using Domain.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class GenericController<T> : ControllerBase where T : ModelMetadata
	{
		protected readonly IUnitOfWork _uow;
		protected readonly IGenericRepository<T> _repository;
		protected readonly ISpecifaction<T> _spec;

		protected Expression<Func<T, bool>> _predicate;
		protected string _searchTerm;
		protected bool _status;
		protected ServerResponse _response;
		public GenericController(IUnitOfWork unitOfWork, ISpecifaction<T> specifaction)
		{
			_uow = unitOfWork;
			_repository = (IGenericRepository<T>) _uow.Repository<T>();
			_spec = specifaction;
			_searchTerm = "";
			_response = new ServerResponse();

			_predicate = x => x.Estatus == _status;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				_status = filters.Status;
				filters.Page = filters.Page > 0 ? filters.Page : 1;
				var result = await _repository.GetAllAsync(filters, _predicate);
				return Ok(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			try
			{
				var result = await _repository.GetByIdAsync(id);

				if (result is null) return NotFound();

				return Ok(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		public async Task<IActionResult> InsertAsync([FromBody] T model)
		{
			try
			{
				await _repository.InsertAsync(model);
				return await _uow.CommitChangesAsync()
					? Ok(_response.GetResponse(true))
					: BadRequest(_response.GetResponse(false));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] T model)
		{
			try
			{
				_repository.Update(model);
				return await _uow.CommitChangesAsync()
					? Ok(_response.GetResponse(true))
					: BadRequest(_response.GetResponse(false));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			try
			{
				await _repository.Delete(id);
				return await _uow.CommitChangesAsync()
					? Ok(_response.GetResponse(true))
					: BadRequest(_response.GetResponse(false));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	}
}
