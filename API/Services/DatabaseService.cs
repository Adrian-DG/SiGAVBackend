using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
	public static class DatabaseService
	{
		public static IServiceCollection GetDatabaseService(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
		{
			string connectionString = environment.IsProduction()
				? configuration.GetConnectionString("ProdConnection")
				: configuration.GetConnectionString("DevConnection");

			services.AddDbContext<MainContext>(opt =>
			{
				opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("API"));
			});

			return services;
		}
	}
}
