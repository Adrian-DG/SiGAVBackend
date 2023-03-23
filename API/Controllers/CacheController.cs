using Application.DataAccess;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CacheController : ControllerBase
	{
		private readonly MainContext _dbContext;
		public CacheController(MainContext mainContext)
		{
			_dbContext = mainContext;
		}

		[HttpGet("rangos")]
		public async Task<IActionResult> GetRangos()
		{
			var result = await _dbContext.Rangos
						.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
						.ToListAsync();

			return Ok(result);
		}

		[HttpGet("regiones")]
		public async Task<IActionResult> GetRegiones()
		{
			var result = await _dbContext.RegionesAsistencia
					.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
					.ToListAsync();

			return Ok(result);
		}

		[HttpGet("provincias")]
		public async Task<IActionResult> GetProvincias()
		{
			var result = await _dbContext.Provincias
						.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
						.ToListAsync();

			return Ok(result);
		}

		[HttpGet("municipios")]
		public async Task<IActionResult> GetMunicipios([FromQuery] int Provincia)
		{
			var result = await _dbContext.Municipios
						.Where(x => x.ProvinciaId == Provincia)
						.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
						.ToListAsync();

			return Ok(result);
		}

		[HttpGet("TipoAsistencia/{categoria}")]
		public async Task<IActionResult> GetTipoAsistencias([FromRoute] int categoria)
		{
			var result = await _dbContext.TipoAsistencias
						.Where(x => (int)x.CategoriaAsistencia == categoria)
						.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre }).ToListAsync();
			return Ok(result);
		}

		[HttpGet("VehiculoMarca")]
		public async Task<IActionResult> GetVehiculoMarca()
		{
			var result = await _dbContext.VehiculoMarcas.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre }).ToListAsync();
			return Ok(result);
		}

		[HttpGet("VehiculoModelo")]
		public async Task<IActionResult> GetVehiculoModelo([FromQuery] int Marca)
		{
			var result = await _dbContext.VehiculoModelos
						.Where(x => x.VehiculoMarcaId == Marca)
						.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
						.ToListAsync();

			return Ok(result);
		}

		[HttpGet("VehiculoColores")]
		public async Task<IActionResult> GetVehiculoColores()
		{
			var result = await _dbContext.VehiculoColores.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre }).ToListAsync();
			return Ok(result);
		}

		[HttpGet("VehiculoTipo")]
		public async Task<IActionResult> GetVehiculoTipo()
		{
			var result = await _dbContext.VehiculoTipos.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre }).ToListAsync();
			return Ok(result);
		}
	}
}
