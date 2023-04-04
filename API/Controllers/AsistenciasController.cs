using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class AsistenciasController : GenericController<Asistencia>
	{
		private readonly AsistenciaRepository _asistencias;
		public AsistenciasController(IUnitOfWork unitOfWork, ISpecifaction<Asistencia> specifaction) : base(unitOfWork, specifaction)
		{
			_asistencias = (AsistenciaRepository)_repository;
			_predicate = x => (x.Nombre.Contains(_searchTerm) || x.Apellido.Contains(_searchTerm) || x.Identificacion.Contains(_searchTerm)) && x.Estatus == _status;
		}

		[HttpPost("createR5")]
		public async Task<IActionResult> CreateAsistenciaR5([FromBody] CreateAsistenciaR5 model)
		{
			try
			{
				await _asistencias.CreateAsistenciaR5(model);
				return Ok(_response.GetResponse(await _uow.CommitChangesAsync()));
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpPost("create")]
		public async Task<IActionResult> CreateAsistenciaAgente([FromBody] CreateAsistenciaAgente model)
		{
			try
			{
				await _asistencias.CreateAsistenciaAgente(model);
				var response = _response.GetResponse(await _uow.CommitChangesAsync());
				return Ok(response.Status);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllAsistencias([FromQuery] PaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				_status = filters.Status;
				var result = await _asistencias.GetAllAsistencias(filters, _predicate);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPut("actualizar")]
		public async Task<IActionResult> ActualizarAsistencia([FromBody] UpdateAsistencia model)
		{
			try
			{
				await _asistencias.ActualizarAsistencia(model);
				return Ok(_response.GetResponse(await _uow.CommitChangesAsync()));
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("contador")]
		public async Task<IActionResult> GetTotalAsistenciasUnidad([FromQuery] int unidadMiembroId)
		{
			try
			{
				var result = await _asistencias.GetTotalAsistenciasUnidad(unidadMiembroId);
				return Ok(result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("all/{ficha}")]
		public async Task<IActionResult> GetAsistenciasAsignadaAUnidad([FromRoute] string ficha)
		{
			try
			{
				var result = await _asistencias.GetAsistenciasAsignadaAUnidad(ficha);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[AllowAnonymous]
		[HttpGet("metricas")]
		public async Task<IActionResult> GetMetricasAsistenciasUnidadByTramo([FromQuery] int tramoId)
		{
			try
			{
				var result = await _asistencias.GetMetricasAsistenciasUnidadByTramo(tramoId);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
