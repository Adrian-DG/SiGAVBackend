using Application.Contracts;
using Application.DataAccess;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MainContext _context;
		private readonly IConfiguration _configuration;
		private readonly Dictionary<string, object> _repositories;
		public UnitOfWork(MainContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;

			_repositories = new Dictionary<string, object>()
			{
				{ "Domain.Entities.Usuario", new UsuariosRepository(_context) },
				{ "Domain.Entities.Tramo", new TramoRepository(_context) },
				{ "Domain.Entities.Unidad", new UnidadRepository(_context) },
				{ "Domain.Entities.Miembro", new MiembroRepository(_context) },
				{ "Domain.Entities.Asistencia", new AsistenciaRepository(_context) },
				{ "Domain.Entities.UnidadMiembro", new UnidadMiembroRepository(_context, _configuration) }
			};

		}

		public IAuthRepository AuthRepository => new AuthRepository(_context, _configuration);

		public async Task<bool> CommitChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public object Repository<T>() where T : class
		{
			string assembly = typeof(T).ToString();

			if (!_repositories.ContainsKey(assembly))
			{
				_repositories.Add(assembly, new GenericRepository<T>(_context));
			}

			return _repositories[assembly];
		}
	}
}
