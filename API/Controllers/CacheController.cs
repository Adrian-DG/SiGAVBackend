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
	[AllowAnonymous]
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
		public async Task<IActionResult> GetMunicipios([FromQuery] int id)
		{
			var result = await _dbContext.Municipios
						.Where(x => x.ProvinciaId == id)
						.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
						.ToListAsync();

			return Ok(result);
		}

		[HttpGet("TipoAsistencia")]
		public async Task<IActionResult> GetTipoAsistencias([FromQuery] int id)
		{
			var result = await _dbContext.TipoAsistencias
						.Where(x => (int)x.CategoriaAsistencia == id)
						.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre }).ToListAsync();
			return Ok(result);
		}

		[HttpGet("TipoUnidades")]
		public async Task<IActionResult> GetTipoUnidades()
		{
			var result = await _dbContext.TipoUnidades
						.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre })
						.ToListAsync();
			return Ok(result);
		}

		[HttpGet("VehiculoMarca")]
		public async Task<IActionResult> GetVehiculoMarca()
		{
			var result = await _dbContext.VehiculoMarcas
				.Where(x => x.Estatus)
				.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre }).ToListAsync();
			return Ok(result);
		}

		[HttpGet("VehiculoModelo")]
		public async Task<IActionResult> GetVehiculoModelo([FromQuery] int tipo, [FromQuery] int marca)
		{
			var result = await _dbContext.VehiculoModelos
						.Where(x => x.VehiculoMarcaId == marca && x.VehiculoTipoId == tipo && x.Estatus)
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

		[HttpGet("Denominaciones")]
		public async Task<IActionResult> GetDenominaciones([FromQuery] string param)
		{
			var result = await _dbContext.Denominaciones
				.Where(x => x.Nombre.Contains(param) && x.Estatus)
				.Select(x => new GenericData { Id = x.Id, Nombre = x.Nombre }).ToListAsync();

			return Ok(result);
		}
	}
}
