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
		public UnitOfWork(MainContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public IAuthRepository AuthRepository => new AuthRepository(_context, _configuration);

		public async Task<bool> CommitChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
