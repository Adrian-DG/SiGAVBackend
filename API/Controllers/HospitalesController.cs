using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class HospitalesController : GenericController<Hospital>
	{
		public HospitalesController(IUnitOfWork unitOfWork, ISpecifaction<Hospital> specifaction) : base(unitOfWork, specifaction)
		{
		}

		[HttpGet("all")]
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
	}
}
