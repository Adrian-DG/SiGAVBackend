﻿namespace API.Services
{
	public static class ApplicationServices
	{
		public static IServiceCollection GetApplicationServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.GetDatabaseService(configuration, environment);
			services.GetAuthService(configuration);

			return services;
		}
	}
}
