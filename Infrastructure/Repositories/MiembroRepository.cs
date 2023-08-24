using Domain.ViewModels;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class MiembroRepository : GenericRepository<Miembro>
	{
		public MiembroRepository(MainContext mainContext) : base(mainContext)
		{
		}

		public async Task<CreatedAuthorizedResponse> ConfirmMiembroExists(string cedula)
		{ 
			return new CreatedAuthorizedResponse
			{
				Created = await _repository.AnyAsync(x => x.Cedula == cedula),
				IsAuthorized = await _repository.AnyAsync(x => x.Cedula == cedula && x.Estatus)
			};
		}

		public async Task CreateMiembro(CreateMiembroDTO model)
		{
			var newMiembro = new Miembro
			{
				Cedula = model.Cedula,
				Nombre = model.Nombre,
				Apellido = model.Apellido,
				FechaNacimiento = model.FechaNacimiento,
				RangoId = model.RangoId,
				Institucion = model.Institucion,
				Autorizado = false,
				Estatus = true,
				PerteneceA = model.PerteneceA
			};

			await _repository.AddAsync(newMiembro);
		}

		public async Task<PagedData<MiembroViewModel>> GetAllMiembrosAsync(PaginationFilter filters, Expression<Func<Miembro, bool>> predicate)
		{
			var results = await _repository
							.Include(u => u.Rango)
							.Where(predicate)
							.Skip((filters.Page - 1) * filters.Size)
							.Take(filters.Size)
							.OrderBy(u => u.FechaCreacion)
							.Select(u => new MiembroViewModel
							{
								Id = u.Id,
								Cedula = u.Cedula,
								NombreCompleto = u.NombreCompleto(),
								Rango = u.Rango.Nombre,
								Institucion = u.Institucion.ToString(),
								Estatus = u.Estatus,
								Autorizado = u.Autorizado,
								FechaCreacion = u.FechaCreacion,
								UsuarioId = (int) u.UsuarioId,
								PerteneceA = u.PerteneceA.ToString()
							})
							.ToListAsync();

			return new PagedData<MiembroViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = results,
				TotalCount = await GetTotalRecords(predicate)
			};
		}

		public async Task UpdateEstatusMiembro(UpdateStatusMiembroDTO model)
		{
			var miembro = await _repository.FindAsync(model.Id);

			if (model.Type == 1)
			{
				miembro.Autorizado = !miembro.Autorizado;
			}
			else
			{
				miembro.Autorizado = false;
				miembro.Estatus = false;
			}

			_context.Attach<Miembro>(miembro);
			_context.Entry<Miembro>(miembro).State = EntityState.Modified;

		}
	}
}
