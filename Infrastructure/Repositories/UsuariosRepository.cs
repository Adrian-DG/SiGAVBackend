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
				EsAdministrador = model.EsAdministrador
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
							EsAdministrador = x.EsAdministrador,
							Permisos = x.Permisos.ToList(),
							Estatus = x.Estatus
						})
						.SingleAsync(x => x.Id.Equals(usuarioId));

			return result;
		}
	}
}
