using Application.DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/pre-hospitalaria")]
	public class AsistenciaPreHospitalariaController : GenericController<AsistenciaPreHospitalaria>
	{
		private readonly AsistenciaPreHospitalariaRepository _asistenciasPreHospitalaria;
		public AsistenciaPreHospitalariaController(IUnitOfWork unitOfWork, ISpecifaction<AsistenciaPreHospitalaria> specifaction) : base(unitOfWork, specifaction)
		{
			_asistenciasPreHospitalaria = (AsistenciaPreHospitalariaRepository)_repository;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAsistenciaPreHospitalaria([FromQuery] AsistenciaPaginationFilter filters)
		{
			try
			{
				_searchTerm = (filters.SearchTerm is null) ? "" : filters.SearchTerm;
				filters.Page = filters.Page > 0 ? filters.Page : 1;
				filters.SearchTerm = _searchTerm;
				if (filters.EstatusAsistencia != 0) _predicate = x => (x.Nombre.Contains(_searchTerm) || x.Apellido.Contains(_searchTerm) || x.Identificacion.Contains(_searchTerm)) && (int)x.EstatusAsistencia == filters.EstatusAsistencia;
				var result = await _asistenciasPreHospitalaria.GetAsistenciaPreHospitalaria(filters, _predicate);
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[AllowAnonymous]
		[HttpPost("create-asistencia-agente")]
		public async Task<IActionResult> CreateAsistenciaPreHospitalariaAgente([FromBody] AsistenciaPreHospitalariaCreateDto asistencia)
		{
			try
			{
				await _asistenciasPreHospitalaria.CreateAsistenciaPreHospitalariaAgente(asistencia);
				var response = (await _uow.CommitChangesAsync())
					? new ServerResponse { Message = "Los cambios se guardaron correctamente !!", Status = true }
					: new ServerResponse { Message = "Error: al crear la asistencia !!", Status = false };
				return Ok(response);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}
}
