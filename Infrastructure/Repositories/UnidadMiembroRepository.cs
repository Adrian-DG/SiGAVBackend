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

		public async Task<LoginUnitResponse> CreateUnidadMiembro(CreateUnidadMiembro model)
		{
			var foundUnit = await _context.Unidades.SingleAsync(x => x.Ficha == model.Ficha);

			await _context.Entry<Unidad>(foundUnit).Reference(x => x.Tramo).LoadAsync();

			var member = await _context.Miembro.SingleAsync(x => x.Cedula == model.Cedula);

			await _context.Entry<Miembro>(member).Reference(x => x.Rango).LoadAsync();

			// Create new Object

			var newAssignation = new UnidadMiembro
			{
				UnidadId = foundUnit.Id,
				MiembroId = member.Id
			};

			await _context.UnidadMiembro.AddAsync(newAssignation);

			await _context.SaveChangesAsync();

			var unidadMiembroId = await _context.UnidadMiembro
								  .Where(x => x.UnidadId.Equals(foundUnit.Id) && x.MiembroId.Equals(member.Id))
								  .OrderByDescending(x => x.FechaCreacion)
								  .FirstAsync();

			return new LoginUnitResponse
			{
				Denominacion = foundUnit.Denominacion,
				UnidadMiembroId = unidadMiembroId.Id,
				Ficha = foundUnit.Ficha,
				Placa = foundUnit.Placa,
				Tramo = foundUnit.Tramo.Nombre,
				MiembroInfo = $"Nombre: {member.NombreCompleto()}, {member.Rango.Nombre}",
				Token = _token.GenerateUnitToken(foundUnit),
				Estatus = true
			};
		}

	}
}
