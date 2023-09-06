using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace API.Controllers
{
	[Route("api/reportes")]
	[ApiController]
	[Authorize]
	public class GraphController : ControllerBase
	{
		private readonly IStatsRepository _statsRepository;
		private readonly Expression<Func<Asistencia, bool>> _predicate;
		private readonly ISpecifaction<Asistencia> _specifaction;
		private StatsFilterDTO _filters;
		public GraphController(IStatsRepository statsRepository, ISpecifaction<Asistencia> specifaction)
		{
			_specifaction = specifaction;
			_statsRepository = statsRepository;
			_predicate = _specifaction.GetFilterPredicate(x => (int)x.EstatusAsistencia == _filters.Estatus && x.FechaCreacion.Date >= _filters.Initial.Date && x.FechaCreacion.Date <= _filters.Final.Date);
		}

		[HttpGet("regiones")]
		public async Task<JsonResult> GetStatsRegiones([FromQuery] StatsFilterDTO filters)
		{
			try
			{
				_filters = filters;
				var result = await _statsRepository.GetAsistenciasByRegion(_predicate);
				return new JsonResult(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet("provincias")]
		public async Task<JsonResult> GetStatsProvincias([FromQuery] StatsFilterDTO filters)
		{
			try
			{
				_filters = filters;
				var result = await _statsRepository.GetAsistenciasByProvincia(_predicate);
				return new JsonResult(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet("tramos")]
		public async Task<JsonResult> GetStatsTramos([FromQuery] StatsFilterDTO filters)
		{
			try
			{
				_filters = filters;
				var result = await _statsRepository.GetAsistenciasByTramo(_predicate);
				return new JsonResult(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet("tipoVehiculos")]
		public async Task<JsonResult> GetStatsTipoVehiculo([FromQuery] StatsFilterDTO filters)
		{
			try
			{
				_filters = filters;
				var result = await _statsRepository.GetAsistenciasByTipoVehiculo(_predicate);
				return new JsonResult(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}
