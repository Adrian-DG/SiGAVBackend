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
	public class AuthRepository : IAuthRepository
	{
		private readonly MainContext _context;
		private readonly DbSet<Usuario> _usuarios;

		private readonly EncryptHelper _encrypt;
		private readonly TokenHelper _token;
		public AuthRepository(MainContext mainContext, IConfiguration configuration)
		{
			_context = mainContext;
			_usuarios = _context.Set<Usuario>();

			_encrypt = new EncryptHelper();
			_token = new TokenHelper(configuration);
		}

		public async Task<bool> ConfirmUserExists(string username)
		{
			return await _usuarios.AnyAsync(x => x.Username == username);
		}

		public async Task<LoginResponse> LoginUser(LoginUserDTO model)
		{
			var foundUser = await _context.Usuarios
				.Include(x => x.Permisos)
				.SingleAsync(x => x.Username == model.Username);

			if (!foundUser.Estatus)
			{
				return new LoginResponse { Title = "Error", Message = "Este usuario aun no sido activado!!", Status = false };
			}

			if (!_encrypt.VerifyPasswordHash(model.Password, foundUser.PasswordHash, foundUser.PasswordSalt))
			{
				return new LoginResponse { Title = "Error", Message = "las credenciales utilizadas no son correctas!!", Status = false };
			}

			return new LoginResponse
			{
				Title = "Ok",
				Message = "El usuario fue autenticado exitosamente",
				UsuarioId = foundUser.Id,
				Usuario = foundUser.Username,
				Status = true,
				EsAdministrador = foundUser.EsAdministrador,
				RolUsuario = (int) foundUser.RolUsuario,
				Token = _token.GenerateToken(foundUser)
			};
		}

	}
}
