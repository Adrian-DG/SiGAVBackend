using Domain.DTO;
using Domain.ViewModels;
using Infrastructure.Context;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class UsuariosRepository : GenericRepository<Usuario>
	{
		private readonly EncryptHelper _encrypt;
		public UsuariosRepository(MainContext mainContext) : base(mainContext)
		{
			_encrypt = new EncryptHelper();	
		}

		public async Task<PagedData<UsuarioViewModel>> GetAllUsuariosAsync(PaginationFilter filters, Expression<Func<Usuario, bool>> predicate)
		{
			var results = await _repository
							.Where(predicate)
							.Skip((filters.Page - 1) * filters.Size)
							.Take(filters.Size)
							.OrderBy(x => x.FechaCreacion)
							.Select(x => new UsuarioViewModel { Id = x.Id, Cedula = x.Cedula, NombreCompleto = x.NombreCompleto(), NombreUsuario = x.Username, TipoUsuario = x.RolUsuario.ToString(), Estatus = x.Estatus  })
							.ToListAsync();

			return new PagedData<UsuarioViewModel>
			{
				Page = filters.Page,
				Size = filters.Size,
				Items = results,
				TotalCount = await GetTotalRecords(predicate)
			};
		}

		public async Task<bool> CreateUsuario(CreateUserDTO model)
		{
			if (await _repository.AnyAsync(x => x.Username == model.Username)) return false;

			_encrypt.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

			var newUsuario = new Usuario
			{
				Cedula = model.Cedula,
				Nombre = model.Nombre,
				Apellido = model.Apellido,
				FechaNacimiento = model.FechaNacimiento,
				Username = model.Username,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				EsAdministrador = model.EsAdministrador,
				RolUsuario = model.RolUsuario
			};

			await _repository.AddAsync(newUsuario);

			return	true;
		}

		public async Task<UsuarioPermisoViewModel> GetUsuarioPermisoDetalle(int usuarioId)
		{
			var result = await _repository
						.Include(x => x.Permisos)
						.Select(x => new UsuarioPermisoViewModel
						{
							Id = x.Id,
							Cedula = x.Cedula,
							NombreCompleto = x.NombreCompleto(),
							NombreUsuario = x.Username,
							TipoUsuario = x.RolUsuario.ToString(),
							Permisos = x.Permisos.Select(x => new PermisoViewModel { Nombre = x.Permiso.Nombre, Descripcion = x.Permiso.Descripcion }).ToList(),
							Estatus = x.Estatus
						})
						.SingleAsync(x => x.Id.Equals(usuarioId));

			return result;
		}

		public async Task AsignarPermiso(CreateUsuarioPermisoDTO model)
		{
			await _context.UsuarioPermisos.AddAsync(new UsuarioPermiso {  UsuarioId = model.UsuarioId, PermisoId = model.PermisoId });
		}

		public async Task UpdateUsuarioEstatus(int id)
		{
			var usuario = await _repository.FindAsync(id);
			usuario.Estatus = !usuario.Estatus;
			usuario.FechaModificacion = DateTime.Now;

			_context.Attach<Usuario>(usuario);
			_context.Entry<Usuario>(usuario).State = EntityState.Modified;
		}

		public async Task ChangePassword(int userId, string newPassword)
		{
			var user = await _repository.FindAsync(userId);
			
			if (user == null) return;

			_encrypt.CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			_context.Attach<Usuario>(user);
			_context.Entry<Usuario>(user).State = EntityState.Modified;
		}
	}
}
