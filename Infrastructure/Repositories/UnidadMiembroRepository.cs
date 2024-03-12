using Infrastructure.Context;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class UnidadMiembroRepository : GenericRepository<UnidadMiembro>
	{
		private readonly TokenHelper _token;
		public UnidadMiembroRepository(MainContext mainContext, IConfiguration _configuration) : base(mainContext)
		{
			_token = new TokenHelper(_configuration);
		}

		public LoginUnitResponse CreateUnidadMiembro(CreateUnidadMiembro model)
		{
			//if (_repository.Any(x => x.Unidad.Ficha == model.Ficha && x.Estatus))
			//{
			//	return new LoginUnitResponse { Estatus = false };
			//}

			var result = _context.SP_CreateUnidadMiembro_Result
						.FromSqlInterpolated($"[dbo].[CreateUnidadMiembro] {model.Cedula}, {model.Ficha}").ToList();

			var response = result[0];

			return new LoginUnitResponse
			{
				Denominacion = response.Denominacion,
				UnidadMiembroId = response.UnidadMiembroId,
				Ficha = response.Ficha,
				Placa = response.Placa,
				Tramo = response.Tramo,
				MiembroInfo = response.MiembroInfo,
				Token = _token.GenerateUnitToken(response.Ficha),
				EsEncargado = response.EsEncargado,
				Estatus = true,
				AccesoTotal = response.AccesoTotal,
				PertenceA = response.PerteneceA
			};
		}

		public async Task<bool> CloseSession(string Ficha)
		{
			var unidadMiembro = await _repository.LastAsync(x => x.Unidad.Ficha == Ficha);

			unidadMiembro.Estatus = false;
			unidadMiembro.FechaModificacion = DateTime.Now;

			_context.Attach<UnidadMiembro>(unidadMiembro);
			_context.Entry<UnidadMiembro>(unidadMiembro).State = EntityState.Detached;

			return await _context.SaveChangesAsync() > 0;
		}

	}
}
